using System;
using System.Collections.Generic;

namespace Behavioral
{
    abstract class Subject 
    {
    	private List<Observer> _observers = new List<Observer>();
    	
    	public void Attach(Observer observer) 
    	{
    		_observers.Add(observer);
    	}

      public void Notify() 
      {
      	foreach (Observer observer in _observers) 
      	{
      		observer.Update();
      	}
      }
    }

    abstract class Observer 
    {
      public abstract void Update();
    }

    // ---------------------------------------------

    class ConcreteSubject : Subject
    {
      public String State { get; set; }
    }

    class ConcreteObserver : Observer 
    {
    	   private string _name;
    private string _observerState;
    private ConcreteSubject _subject;
 
    // Constructor
    public ConcreteObserver(
      ConcreteSubject subject, string name)
    {
      this._subject = subject;
      this._name = name;
    }
 
    public override void Update()
    {
      _observerState = _subject.State;
      Console.WriteLine("Observer {0}'s new state is {1}",
        _name, _observerState);
    }
 
    // Gets or sets subject
    public ConcreteSubject Subject
    {
      get { return _subject; }
      set { _subject = value; }
    }
      
    }
}
