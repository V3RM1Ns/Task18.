using _18thTask.Interfaces;
namespace _18thTask.Models;
public class Book:Entity
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
    public bool IsDeleted { get; set; }
    private static int _id = 0;
    public int Id { get;}
    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name} Author: {AuthorName} PageCount: {PageCount} IsDeleted: {IsDeleted}, Id:{Id}");
    }
    public Book(string name,string author,int pageCount)
    {
        Name=name;
        AuthorName=author;
        PageCount=pageCount;
        IsDeleted=false;
        Id = ++_id;
    }
}