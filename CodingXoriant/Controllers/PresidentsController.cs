using CodingXoriant.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodingXoriant.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class PresidentsController: ControllerBase
    {
        IPresidentsRepository _presidentsRepository;
        public PresidentsController(IPresidentsRepository presidentsRepository)
        {
            _presidentsRepository = presidentsRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_presidentsRepository.All);
        }
    }
}
