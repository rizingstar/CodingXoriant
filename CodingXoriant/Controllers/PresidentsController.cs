using CodingXoriant.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodingXoriant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // POST: api/Presidents
        [HttpPost]
        public ActionResult<President> PostPresident(President president)
        {
            _presidentsRepository.Insert(president);

            return CreatedAtAction(nameof(GetPresident), new { id = president.Id }, president);
        }

        // GET: api/Presidents/5
        [HttpGet("{id}")]
        public ActionResult<President> GetPresident(int id)
        {
            var president = _presidentsRepository.Find(id);

            if (president == null)
            {
                return NotFound();
            }

            return president;
        }
    }
}
