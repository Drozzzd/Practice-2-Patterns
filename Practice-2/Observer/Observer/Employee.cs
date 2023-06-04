using Practice_2_Drozdov.Facade;
using Practice_2_Drozdov.FactoryMethod;
using Practice_2_Drozdov.Observer.Observable;

namespace Practice_2_Drozdov.Observer.Observer;

public interface IObserver
{
    public void Update(object obj);
}

public class Employee : IObserver
{
    private IBookFacade Facade;

    public Employee(IBookFacade facade)
    {
        Facade = facade;
    }

    public bool SearchBookByTitle(string title)
    {
        Console.WriteLine($"Сотрудник начал поиск по названию {title}");
        return Facade.SearchBookByTitle(title);
    }

    public void PlaceOrder(Book book, Employee employee)
    {
        Facade.PlaceOrder(book, employee);
    }

    public void Update(object obj)
    {
        var order = obj as Order;
        Console.WriteLine($"У вашего заказа обновился статус! Теперь: {order.State}. Можете позвонить клиенту или что-нибудь сделать");
    }
}