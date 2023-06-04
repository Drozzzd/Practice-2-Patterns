using Practice_2_Drozdov.FactoryMethod;
using Practice_2_Drozdov.Observer.Observable;
using Practice_2_Drozdov.Observer.Observer;

namespace Practice_2_Drozdov.Facade;

public interface IBookFacade
{
    public bool SearchBookByTitle(string title);
    public void PlaceOrder(Book book, Employee employee);
}

/// <summary>
/// Класс BookFacade инкапсулирует сложность взаимодействия с подсистемами и предоставляет методы,
/// такие как SearchBookByTitle() для поиска книги по названию и PlaceOrder() для оформления заказа.
/// </summary>
public class BookFacade : IBookFacade
{
    private BookSearchSystem searchSystem;
    private OrderSystem orderSystem;
    private PaymentSystem paymentSystem;
    private WarehouseSystem warehouseSystem;

    public BookFacade()
    {
        searchSystem = new BookSearchSystem();
        orderSystem = new OrderSystem();
        paymentSystem = new PaymentSystem();
        warehouseSystem = new WarehouseSystem();
    }
    
    public bool SearchBookByTitle(string title)
    {
        Console.WriteLine($"В фасаде мы ищем книгу по заголовку {title}");
        return searchSystem.SearchBookByTitle(title);
    }

    public void PlaceOrder(Book book, Employee employee)
    {
        Order order = orderSystem.CreateOrder(book, employee);
        var paymentResult = paymentSystem.ProcessPayment(order);
        if (paymentResult)
        {
            order.State = OrderState.Paid;
            order.NotifyObservers();
            warehouseSystem.UpdateStock(book, 1);
            order.State = OrderState.Packaging;
            order.NotifyObservers();
            Console.WriteLine("Заказ успешно размещен.");
        }
        else
        {
            order.State = OrderState.Cancelled;
            order.NotifyObservers();
            Console.WriteLine("Не удалось оплатить заказ.");
        }
    }
}