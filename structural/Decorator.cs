using System;

namespace Structural
{
    abstract class Component {
        public abstract void Operation();
    }

    abstract class Decorator : Component {
    
        protected Component component;

        public void SetComponent(Component component) 
        {
          this.component = component;
        }

        public override void Operation() {
            if(component != null){
                component.Operation();
            }
        }
    }
    //  -------------------------------------

    class ConcreteComponent : Component {
        public override void Operation() {
            Console.WriteLine("ConcreteComponent Operation");
        }
    }

    class ConcreteDecorator : Decorator {
        public override void Operation(){
            base.Operation();
            AddedOperation();
        }
        public void AddedOperation() 
        {
            Console.WriteLine("Added Operation");
        }
    }

}
