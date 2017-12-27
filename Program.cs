	using System;
	using Structural;

	namespace DotNetOnLinux
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            Engine engine = new Engine();
	            Consumer consumer = new Consumer("consumer1", engine);
	            Consumer consumer2 = new Consumer("consumer2", engine);
	            engine.SwitchGear();
	            consumer.Unsubscribe();
	            engine.SwitchGear();
	            
	            Console.WriteLine("");
	            Console.WriteLine("============ Structural patterns (realize relationships between entities) ============");
	            Console.WriteLine("~~~~~~~~~~~~~ Facade (A single class that represents an entire subsystem) ~~~~~~~~~~~~~");
	            Structural.Facade facade = new Structural.Facade();
	            facade.AddMethod();
	            Console.WriteLine("~~~~~~~~~~~~~ Decorator (Attach additional responsibilities to an object dynamically) ~~~~~~~~~~~~~");
				ConcreteDecorator cd = new ConcreteDecorator();
				ConcreteComponent concreteComponent = new ConcreteComponent();
				cd.SetComponent(concreteComponent);	            
				cd.Operation();

	            Console.WriteLine("");
	            Console.WriteLine("============ Behavioural patterns (communications between entities) ============");
	            Console.WriteLine("~~~~~~~~~~~~~ Observer (one-to-many dependency between objects) ~~~~~~~~~~~~~");
	        }
	    }

	    public class Engine 
	    {
	    	private int _currentGear;
	      public Engine () 
	      {
	        _currentGear = 0;
	      }

	      public void SwitchGear(){
	      	var oldGear = _currentGear;
	      	_currentGear = _currentGear+1;
	      	Console.WriteLine("Publisher: changing gears...");
	      	Console.WriteLine("Publisher: Notifying registered subscribers...");
	      	this.OnSwitchGear(_currentGear, oldGear);
	      }

	      public event SwitchGearEvent OnSwitchGearEvent;

	      public void OnSwitchGear(int currentGear, int oldGear) 
	      {
	      	if(OnSwitchGearEvent != null)
	      	{
	      		Console.WriteLine("args in publisher {0} {1}", currentGear, oldGear);
	      		OnSwitchGearEvent(this, new SwitchedGearEventArgs(currentGear, oldGear));
	      	}
	      	
	      }

	    }

	    public class SwitchedGearEventArgs : EventArgs
	    {
	    	public int NewVal { get; set; }
	    	public int OldVal { get; set; }

	      public SwitchedGearEventArgs (int newVal, int oldVal) 
	      {
	        this.NewVal = newVal;
	        this.OldVal = oldVal;
	      }
	    }

	    public delegate void SwitchGearEvent(object sender, SwitchedGearEventArgs args);

	    public class Consumer 
	    {
	      private Engine _engine;
	      private String _name;
	      public Consumer (String name, Engine engine) 
	      {
	      	_name = name;
	        _engine = engine;
	        Console.WriteLine("{0}: Subscring to OnSwitchGearEvent...", _name);
	        _engine.OnSwitchGearEvent += new SwitchGearEvent(SwitchedGear);
	      }

	      public void SwitchedGear(object sender, SwitchedGearEventArgs args) 
	      {
	      	Console.WriteLine("{2}: args in consumer {0} {1}", args.NewVal, args.OldVal, _name);
	      }

	      public void Unsubscribe() 
	      {
	        Console.WriteLine("{0}: Unsubscring to OnSwitchGearEvent...", _name);
	      	_engine.OnSwitchGearEvent -= new SwitchGearEvent(SwitchedGear);
	      	this._engine = null;
	      }
	    }
	}
