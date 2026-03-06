using LiveTesting.Domain.Books;

namespace LiveTesting.Persistence;

public sealed class BookData
{
    private readonly List<Book> _books = new();
    
    public IReadOnlyList<Book> Books => _books;

    public void Add(Book book)
    {
        int lastId = _books.Count == 0 
            ? 0 
            : _books.Max(b => b.Id);
        
        book.Id = lastId + 1;
        
        _books.Add(book);
    }
    
    public void Remove(int id)
    {
        _books.RemoveAll(b => b.Id == id);
    }
}