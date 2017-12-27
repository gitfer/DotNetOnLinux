using System;

namespace Creational
{

    public interface IComponent 
    {
        
    }

    public class Creator 
    {
      public static IComponent Create(string key){
        if(key == "first")
        {
            Console.WriteLine("Building a Component1...");
            return new Component1();
        }

        Console.WriteLine("Building a Component2...");
        return new Component2();
      }
    }

    public class Component1 : IComponent 
    {
          
    }
    public class Component2: IComponent 
    {
      
    }
}
