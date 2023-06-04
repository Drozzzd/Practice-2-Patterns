namespace Practice_2_Drozdov.FactoryMethod;

public enum BookType
{
    Detective,
    ScienceFiction,
    Novel
}

public class DetectiveBook : Book
{
    public DetectiveBook(string title) : base(title)
    {
    }
}

public class ScienceFictionBook : Book
{
    public ScienceFictionBook(string title) : base(title)
    {
    }
}

public class NovelBook : Book
{
    public NovelBook(string title) : base(title)
    {
    }
}