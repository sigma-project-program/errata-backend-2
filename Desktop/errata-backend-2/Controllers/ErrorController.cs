using ErrataManager.Models;
using ErrataManager.Data;
using ErrataManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ErrataManager.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
    ErrorService _service;

    public ErrorController(ErrorService service){
        _service = service;
    }

    // Get all errors
    // [HttpGet]
    // [Route("api/service/error/{id:int}")]
    // public async Task<IEnumerable<Error>?> GetAllErrorsAsync(int id){
    //     return await Task.FromResult(_service.GetAllErrorsSync(id));
    // }

    // Get Error by Id
    [HttpGet]
    [Route("api/service/error/get/{errorId:int}")]
    [EnableCors("corsapp")]
    public async Task<Error?> GetErrorById(int errorId){
        return await Task.FromResult(_service.GetErrorById(errorId));
    }

    // CreateError(errorToAdd) Handles the POST request to add the error to the database.
    [HttpPost]
    [EnableCors("corsapp")]
    public Error? CreateError(Error errorToAdd){
        _service.AddError(errorToAdd);
        return errorToAdd;
    }

    [HttpPut]
    [Route("api/service/error/update/{errorId:int}")]
    [EnableCors("corsapp")]
    // UpdateError(id, errorToUpdate) Handles the PUT request to update the error in the database.
    public Error? UpdateErrorDatabase(int id, Error errorToUpdate){
        _service.UpdateError(id, errorToUpdate);
        return errorToUpdate;
    }

    [HttpDelete]
    [Route("api/service/error/delete/{id:int}")]
    [EnableCors("corsapp")]
    // DeleteError(id) Handles the DELETE request to delete the error from the database.
    public void DeleteErrorDatabse(int id){
        _service.DeleteError(id);
    }

}