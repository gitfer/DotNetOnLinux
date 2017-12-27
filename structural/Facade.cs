using System;

namespace Structural
{
    public class Facade
    {
    	SubSystem1 _subsystem1;
    	SubSystem2 _subsystem2;
    	public Facade () 
    	{
    	  _subsystem1 = new SubSystem1();
    	  _subsystem2 = new SubSystem2();
    	}

    	public void AddMethod() 
    	{
    		_subsystem1.Add();
    		_subsystem2.Add();	
    	}
    }
    public class SubSystem1 
    {
      public void Add() 
      {
      	Console.WriteLine("Add subsystem1");
      }
    }
    public class SubSystem2 
    {
    	public void Add() 
    	{
      		Console.WriteLine("Add subsystem2");
    	}
      
    }
}
