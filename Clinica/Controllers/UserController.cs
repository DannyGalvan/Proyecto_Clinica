using Entities.Response;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly List<string> _dataList = new() { "halo", "adios", "guatemala" };

        [HttpGet]
        public ActionResult<Response<List<string>>> Get()
        {
            
            Response<List<string>> response = new()
                                              {
                                                  Data    = _dataList,
                                                  Success   = true,
                                                  Message = "Consulta exitosa"
                                              };

            return response;
        }
    }
}
