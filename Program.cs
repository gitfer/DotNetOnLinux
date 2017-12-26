	using System;

	namespace DotNetOnLinux
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            Engine engine = new Engine();
	            Consumer consumer = new Consumer(engine);
	            engine.SwitchGear();
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
	      public Consumer (Engine engine) 
	      {
	        _engine = engine;
	        _engine.OnSwitchGearEvent += new SwitchGearEvent(SwitchedGear);
	      }

	      public void SwitchedGear(object sender, SwitchedGearEventArgs args) 
	      {
	      	Console.WriteLine("args in consumer {0} {1}", args.NewVal, args.OldVal);
	      }
	    }
	}
