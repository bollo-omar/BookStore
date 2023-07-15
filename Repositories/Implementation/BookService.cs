using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation;

public class BookService : IBookService
{
    private readonly DatabaseContext _context;

    public BookService(DatabaseContext context)
    {
        this._context = context;
    }

    public bool Add(Book model)
    {
        try
        {
            _context.Book.Add(model);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var data = this.FindById(id);

            if (data == null)
                return false;
            _context.Book.Remove(data);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public Book FindById(int id)
    {
        return _context.Book.Find(id);
    }

    public IEnumerable<Book> GetAll()
    {
        var data = (from book in _context.Book
            join author in _context.Author on book.AuthorId equals author.Id
            join publisher in _context.Publisher on book.PublisherId equals publisher.Id
            join genre in _context.Genre on book.GenreId equals genre.Id
            select new Book
            {
                Id = book.Id,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Isbn = book.Isbn,
                PublisherId = book.PublisherId,
                Title = book.Title,
                TotalPages = book.TotalPages,
                GenreName = book.GenreName,
                AuthorName = book.AuthorName,
                PublisherName = book.PublisherName
            }).ToList();
        return data;
    }

    public bool Update(Book model)
    {
        try
        {
            _context.Book.Update(model);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}