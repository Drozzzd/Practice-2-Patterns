using Practice_2_Drozdov.FactoryMethod;
using Practice_2_Drozdov.Observer.Observer;

namespace Practice_2_Drozdov.Observer.Observable;

public interface IObservable
{
    List<IObserver> Observers { get; set; }
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class Order : IObservable
{
    public OrderState State { get; set; }
    public List<IObserver> Observers { get; set; }

    public Order()
    {
        State = OrderState.Stock;
        Observers = new List<IObserver>();
    }

    public void AddObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in Observers)
        {
            observer.Update(this);
        }
    }
}