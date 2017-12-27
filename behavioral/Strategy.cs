using System;
using System.Collections.Generic;

namespace Behavioral
{
  abstract class Strategy 
  {
    public abstract void Sort();
  }

  class SortStrategy1 : Strategy 
  {
    public override void Sort() 
    {
      Console.WriteLine("Sort Strategy1");
    }
  }

  class SortStrategy2 : Strategy 
  {
    public override void Sort() 
    {
      Console.WriteLine("Sort Strategy2");
    }
  }

   class Context
  {
    private Strategy _strategy;
 
    // Constructor
    public Context(Strategy strategy)
    {
      this._strategy = strategy;
    }
 
    public void ContextSortInterface()
    {
      _strategy.Sort();
    }
  }
}
