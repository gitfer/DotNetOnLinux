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
	      
	      public event EngineStartedEventHandler EngineStartedEvent;

	      public void SwitchGear() 
	      {
	      	var oldGear = _currentGear;
	      	_currentGear = _currentGear + 1;
	      	Console.WriteLine("GearSwitched in Engine {0} {1}", _currentGear, oldGear);
	      	this.OnEngineStarted(_currentGear, oldGear);
	      }

	      private void OnEngineStarted(int newGear, int oldGear) 
	      {
	      	if(EngineStartedEvent != null){
	      		var nameChangingEventHandlerArgs = new NameChangingEventHandlerArgs();
	      		nameChangingEventHandlerArgs.OldGear = oldGear;
	      		nameChangingEventHandlerArgs.NewGear = newGear;
	      		EngineStartedEvent(this, nameChangingEventHandlerArgs);
	      	}
	      }

	    }
	    public delegate void EngineStartedEventHandler(object sender, NameChangingEventHandlerArgs args);

	     public class NameChangingEventHandlerArgs : EventArgs
	    {
	    	public int OldGear { get; set; }
	    	public int NewGear { get; set; }
	    }

	    public class Consumer 
	    {
    	  private Engine _engine;

	      public Consumer (Engine engine) 
	      {
	        _engine = engine;
	        _engine.EngineStartedEvent += new EngineStartedEventHandler(GearSwitched);
	      }

	      public void GearSwitched(object sender, NameChangingEventHandlerArgs args) 
	      {
	      	Console.WriteLine("Event in consumer {0} {1}", args.NewGear, args.OldGear);
	      }
	    }
	}
