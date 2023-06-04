namespace Practice_2_Drozdov.FactoryMethod;

public abstract class Book
{
    public Guid ID;
    public String Title;

    public Book(string title)
    {
        ID = new Guid();
        Title = title;
    }
}