using AutoMapper;
using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess;
using ErayArıkan21898388.DataAccess.Interfaces;
using ErayArıkan21898388.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ErayArıkan21898388.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController :Controller
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _mapper;
        public CostumerController(ICostumerRepository costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Costumer>))]
        public IActionResult GetCostumers()
        {
            var costumers = _mapper.Map<List<CostumerDto>>(_costumerRepository.GetCostumers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(costumers);
        }


        [HttpGet("{costumerId}")]
        [ProducesResponseType(200, Type = typeof(Costumer))]
        [ProducesResponseType(400)]
        public IActionResult GetCostumer(int costumerId)
        {
            if (!_costumerRepository.IsCostumerExist(costumerId))
                return NotFound();

            var costumer = _costumerRepository.GetCostumerById(costumerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(costumer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCostumer( CostumerDto costumerCreate)
        {
            if (costumerCreate == null)
                return BadRequest(ModelState);

            var costumer = _costumerRepository.GetCostumers()
                .Where(c => c.Name.Trim().ToUpper() == costumerCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var costumerMap = _mapper.Map<Costumer>(costumerCreate);

            if (!_costumerRepository.CreateCostumer(costumerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{costumerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCostumer(int costumerId, [FromBody] CostumerDto updatedCostumer)
        {
            if (updatedCostumer == null)
                return BadRequest(ModelState);

            if (costumerId != updatedCostumer.Id)
                return BadRequest(ModelState);

            if (!_costumerRepository.IsCostumerExist(costumerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var costumerMap = _mapper.Map<Costumer>(updatedCostumer);

            if (!_costumerRepository.UpdateCostumer(costumerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{costumerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCostumer(int costumerId)
        {
            if (!_costumerRepository.IsCostumerExist(costumerId))
            {
                return NotFound();
            }
            var costumerToDelete = _costumerRepository.GetCostumerById(costumerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_costumerRepository.DeleteCostumer(costumerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }

}

