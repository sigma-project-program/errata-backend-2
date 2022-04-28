using ErrataManager.Models;
using ErrataManager.Services;
using ErrataManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ErrataManager.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{  
    BookService _service;

    public BookController(BookService service){
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetAllBooks(){
        return await Task.FromResult(_service.GetAll());
    }

    [HttpGet]
    [Route("api/service/{id:int}")]
    [EnableCors("corsapp")]
    public async Task<ActionResult<Book>> GetBookById(int id){
        var bookToReturn =  await Task.FromResult(_service.GetById(id));        
        if(bookToReturn is null){
            return NotFound();
        }
        return bookToReturn;
    }

    [HttpPost]
    [EnableCors("corsapp")]
    public async Task<IActionResult> AddBook(Book book){
        var bookToReturn = await Task.FromResult(_service.Create(book));
        return await Task.FromResult(CreatedAtAction(nameof(GetBookById), new {id = bookToReturn!.Id}, bookToReturn));
    }

    [HttpDelete]
    [Route("{id}")]
    [EnableCors("corsapp")]
    public async Task<IActionResult> DeleteBook(int id){
        var bookToDelete = await Task.FromResult(_service.GetById(id));
        if(bookToDelete is null){
            return NotFound();
        }
        else{
            _service.Deletebook(id);
            return NoContent();
        }
    }
    
}