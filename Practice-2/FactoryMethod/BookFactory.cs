namespace Practice_2_Drozdov.FactoryMethod;

public interface IBookFactory
{
    public Book CreateBook(BookType type, string name);
}

public class BookFactory : IBookFactory
{
    public Book CreateBook(BookType type, string name)
    {
        Book book = null!;
        switch (type)
        {
            case BookType.Detective:
                book = new DetectiveBook(name);
                break;
            case BookType.ScienceFiction:
                book = new ScienceFictionBook(name);
                break;
            case BookType.Novel:
                book = new NovelBook(name);
                break;
        }
        return book;
    }
}