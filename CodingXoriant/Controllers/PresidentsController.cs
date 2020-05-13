using System;
using AutoMapper;
using CodingXoriant.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingXoriant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidentsController: ControllerBase
    {
        IPresidentsRepository _presidentsRepository;
        IMapper _mapper;
        private readonly ILogger _logger;
        public PresidentsController(IPresidentsRepository presidentsRepository, IMapper mapper, ILogger<PresidentsController> logger)
        {
            _presidentsRepository = presidentsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult List()
        {
            _logger.LogInformation(LogEvents.ListItems, "GET Presidents Accessed");
            //IEnumerable<PresidentDTO> ienumerableDest = _mapper.Map<IEnumerable<President>, IEnumerable<PresidentDTO>>(_presidentsRepository.All);
            //return Ok(ienumerableDest);
            return Ok(_presidentsRepository.All);
        }

        // POST: api/Presidents
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<President> PostPresident(President president)
        {
            _logger.LogInformation(LogEvents.InsertItem, $"POST Presidents Called with President Name:{president.PresidentName}");
            _presidentsRepository.Insert(president);

            return CreatedAtAction(nameof(GetPresident), new { id = president.Id }, president);
        }

        // GET: api/Presidents/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<President> GetPresident(int id)
        {
            _logger.LogInformation(LogEvents.GetItem, $"GET: Presidents ID:{id}");
            var president = _presidentsRepository.Find(id);

            if (president == null)
            {
                _logger.LogDebug(LogEvents.GetItemNotFound, $"GET: Presidents not found, ID:{id}");
                return NotFound();
            }

            return Ok(president);
        }

        // DELETE: api/Presidents/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePresident(int id)
        {
            try
            {
                _logger.LogInformation(LogEvents.DeleteItem, $"DELETE: President with Id: {id} called");
                var president = _presidentsRepository.Find(id);
                if (president == null)
                {
                    _logger.LogError(LogEvents.GetItemNotFound, $"President with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _presidentsRepository.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete President action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
