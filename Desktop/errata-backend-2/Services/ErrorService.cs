using ErrataManager.Models;
using ErrataManager.Data;

namespace ErrataManager.Services;

public class ErrorService{
    private readonly BookContext _context;

    public ErrorService(BookContext context){
        _context = context;
    }

    // CRUD operations

    // Get all errors for a particular book
    public IEnumerable<Error>? GetAllErrorsSync(int BookId){
        var bookToGet = _context.Books.Find(BookId);
        if(bookToGet is null){
            throw new NullReferenceException("Book Not Found!");
        }

        return bookToGet.Errors;
    }

    // Get an error by Id
    public Error? GetErrorById(int ErrorId){
        return _context.Errors.SingleOrDefault(p => p.Id == ErrorId);
    }

    // Add an error to a book
    public void AddError(Error newError){
        _context.Errors.Add(newError);
        _context.SaveChanges();
    }

    // Update an error
    public void UpdateError(int ErrorId, Error newError){
        var errorToUpdate = _context.Errors.Find(ErrorId);

        if(errorToUpdate is null){
            throw new NullReferenceException("Error not found");
        }

        _context.Errors.Update(newError);
        _context.SaveChanges();
    }


    // Delete an error
    public void DeleteError(int ErrorId){
        var errorToDelete = _context.Errors.Find(ErrorId);
        if(errorToDelete is null){
            throw new NullReferenceException("Error not found");
        }
        _context.Errors.Remove(errorToDelete);
        _context.SaveChanges();
    }
}