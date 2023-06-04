using Practice_2_Drozdov.Facade;
using Practice_2_Drozdov.FactoryMethod;
using Practice_2_Drozdov.Observer.Observer;

namespace Practice_2_Drozdov;

class Program
{
    static void Main(string[] args)
    {
        IBookFactory bookFactory = new BookFactory();
        IBookFacade bookFacade = new BookFacade();
        var employee = new Employee(bookFacade);
        var detectiveBook = bookFactory.CreateBook(BookType.Detective, "Записки о Шерлоке Холмсе: Этюд в багровых тонах");
        var novelBook = bookFactory.CreateBook(BookType.Novel, "Гипотеза любви");
        
        employee.PlaceOrder(detectiveBook, employee);
        // Отрицание можно поставить/убрать
        if (!employee.SearchBookByTitle("Гипотеза любви"))
        {
            employee.PlaceOrder(novelBook, employee);
        }
    }
}