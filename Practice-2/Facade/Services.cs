using Practice_2_Drozdov.FactoryMethod;
using Practice_2_Drozdov.Observer.Observable;
using Practice_2_Drozdov.Observer.Observer;

namespace Practice_2_Drozdov.Facade;

public class BookSearchSystem
{
    public bool SearchBookByTitle(string title)
    {
        Console.WriteLine($"Ищем книгу с заголовком \"{title}\"...");
        // Логика поиска книги по названию
        // Возвращаем результаты поиска
        return true;
    }
}

public class OrderSystem
{
    public Order CreateOrder(Book book, Employee employee)
    {
        Console.WriteLine($"Создан заказ книги \"{book.Title}\"");
        var order = new Order();
        order.AddObserver(employee);
        // Логика оформления заказа
        // Возвращаем информацию о заказе
        return order;
    }
}

public class PaymentSystem
{
    public bool ProcessPayment(Order order)
    {
        Console.WriteLine($"Процесс оплаты для заказа: {order}");
        // Логика обработки платежа
        return true;
    }
}

public class WarehouseSystem
{
    public void UpdateStock(Book book, int quantity)
    {
        Console.WriteLine($"Обновляем книгу \"{book.Title}\", количество стало меньше на: {quantity}");
        // Логика обновления количества книг на складе
    }
}