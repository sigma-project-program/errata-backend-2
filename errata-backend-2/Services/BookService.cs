using ErrataManager.Models;
using ErrataManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ErrataManager.Services;

public class BookService{

    private readonly BookContext _context;
    public BookService(BookContext context){
        _context = context;
    }

    // CRUD operations

    // Get all books
    public IEnumerable<Book> GetAll(){
        return _context.Books
            .ToList();
    }

    // Get book by ID
    public Book? GetById(int id){
        var bookToReturn =  _context.Books.SingleOrDefault(p => p.Id == id);
        if(bookToReturn is null){
            throw new NullReferenceException("Book not found"); 
        }
        var errorsOfBook = from st in _context.Errors
                            where st.BookId == id
                            select st;

        bookToReturn.Errors = errorsOfBook.ToList();
        return bookToReturn;
    }

    // POST book
    public Book? Create(Book newBook){
        _context.Books.Add(newBook);
        var errors = newBook.Errors;
        if(errors is not null){
            _context.Errors.AddRange(errors);
        }
       
        _context.SaveChanges();
        return newBook;
        
    }


    // Delete a Book
    public void Deletebook(int BookId){
        var bookToDelete = _context.Books.Find(BookId);

        if(bookToDelete is null){
            throw new NullReferenceException("Book not found!");
        }

        _context.Books.Remove(bookToDelete);
        _context.SaveChanges();
    }

}