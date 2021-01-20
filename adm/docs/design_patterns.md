# The five most important design patterns
---

On this document, we will discuss the five most important design patterns that are implemented on a daily basis in software engineering. The principles will be listed bellow and they are the basis of how to write good code.

## The Singleton principle
Almost every application implements these singletons in one or more areas of their inner functions. 
It states: Classes that are singletons just are "constructed" one time, That is, a object is created from the class in run time and all other calls refers to this same instance. So it is a limitation to just one construction per runtime for the class.

```csharp
public class SingletonDemo {
   private static SingletonDemo instance = null;
   
   private SingletonDemo() {
   }
   
   public static SingletonDemo getInstance() {
      if(instance == null) {
         instance = new SingletonDemo();
      }
      return instance;
   }
}
```

The method `getInstance()` makes sure that only one instance of the object is created. The construct is private and can only be assessed throw the function. There are lots scenarios where we only want one instance of a class opened.
The problem with this design pattern is that the function `getInstance()` is not thread-safe. So it's possible to exist more than one instance simultaneously.

## The Factory Pattern principle
This Design pattern is important as it enhance polymorphism in our code. With this method it's possible to not determine a type on the code in an concrete manner. As an alternative we can call a constructor that knows what to use. By doing that one can avoid creating cross dependency between a parent and a child class.
For example:

```csharp
void GameObject boneco = new GameObject;
```

This is bad as 


```csharp
using System;

namespace code.DesignPatterns.FactoryMethod.Conceptual
{
    // The Creator class declares the factory method that is supposed to return
    // an object of a Product class. The Creator's subclasses usually provide
    // the implementation of this method.
    abstract class Creator
    {
        // Note that the Creator may also provide some default implementation of
        // the factory method.
        public abstract IProduct FactoryMethod();

        // Also note that, despite its name, the Creator's primary
        // responsibility is not creating products. Usually, it contains some
        // core business logic that relies on Product objects, returned by the
        // factory method. Subclasses can indirectly change that business logic
        // by overriding the factory method and returning a different type of
        // product from it.
        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    // Concrete Creators override the factory method in order to change the
    // resulting product's type.
    class ConcreteCreator1 : Creator
    {
        // Note that the signature of the method still uses the abstract product
        // type, even though the concrete product is actually returned from the
        // method. This way the Creator can stay independent of concrete product
        // classes.
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    // The Product interface declares the operations that all concrete products
    // must implement.
    public interface IProduct
    {
        string Operation();
    }

    // Concrete Products provide various implementations of the Product
    // interface.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());
            
            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }

        // The client code works with an instance of a concrete creator, albeit
        // through its base interface. As long as the client keeps working with
        // the creator via the base interface, you can pass it any creator's
        // subclass.
        public void ClientCode(Creator creator)
        {
            // ...
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
```
