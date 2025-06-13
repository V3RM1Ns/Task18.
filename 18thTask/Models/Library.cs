using _18thTask.Interfaces;
using Microsoft.VisualBasic.CompilerServices;
namespace _18thTask.Models;
public class Library:Entity
{
    public byte BookLimit { get; set; }
    private List<Book> books = new List<Book>();
    
    
    public void AddBook(Book book)
    {
        Book result = books.FirstOrDefault(y=>y.Name==book.Name);
        if (result == null)
        {
            if (!(books.Count < BookLimit))
            {
                throw new CapacityLimitException("Book limit exceeded");
            }
            else
            {
                books.Add(book);
            }
        }
        else
        {
            throw new AlreadyExistsException("Book already exists");
        }
        
    }
    public Book GetBookById(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id is null");
        }
        else
        {
            List<Book> NotDeletedBooks=books.FindAll(x=>x.IsDeleted==false);
            Book result = NotDeletedBooks.FirstOrDefault(x=>x.Id==id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
    }
    public List<Book> GetAllBooks()
    {
        return new List<Book>(books.Where(x => x.IsDeleted == false|| x.IsDeleted==true));
    }
    public void DeleteBookById(int? id)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id is null");
        }
        else
        {
            List<Book> NotDeletedBooks=books.FindAll(x=>x.IsDeleted==false);
            Book result = NotDeletedBooks.FirstOrDefault(x=>x.Id==id);
            if (result == null)
            {
                throw new NotFoudException("Book not found");
            }
            else
            {
                result.IsDeleted=true;
            }
        }
    }
    public void EditBookName(int? id, string newName)
    {
        if (id == null)
        {
            throw new NullReferenceException("Id is null");
        }
        else
        {
            List<Book> NotDeletedBooks=books.FindAll(x=>x.IsDeleted==false);
            Book result = NotDeletedBooks.FirstOrDefault(x=>x.Id==id);
            if (result == null)
            {
                throw new NotFoudException("Book not found");
            }
            else
            {
                result.Name=newName;
            }
        }
    }
    public List<Book> FilterByPageCount()
    {
        List<Book> NotDeletedBooks=books.FindAll(x=>x.IsDeleted==false);
        List<Book> result = NotDeletedBooks.OrderBy(x => x.PageCount).ToList();
        return result;
    }
}
