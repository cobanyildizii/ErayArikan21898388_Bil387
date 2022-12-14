using AutoMapper;
using DbFirst.Data;
using ErayArıkan21898388.Data;
using ErayArıkan21898388.DataAccess;
using ErayArıkan21898388.DataAccess.Interfaces;
using ErayArıkan21898388.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ErayArıkan21898388.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController:Controller
    {
        private readonly IDepositRepository _depositRepository;
        private readonly IMapper _mapper;
        public DepositController(IDepositRepository depositRepository, IMapper mapper)
        {
            _depositRepository = depositRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Deposit>))]
        public IActionResult GetDeposits()
        {
            var deposit = _mapper.Map<List<DepositDto>>(_depositRepository.GetDeposits());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(deposit);
        }

        [HttpGet("{depositId}")]
        [ProducesResponseType(200, Type = typeof(Deposit))]
        [ProducesResponseType(400)]
        public IActionResult GetDeposit(int depositId)
        {
            if (!_depositRepository.IsDepositExist(depositId))
                return NotFound();

            var deposit = _depositRepository.GetDeposit(depositId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(deposit);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDeposit(DepositDto depositCreate)
        {
            if (depositCreate == null)
                return BadRequest(ModelState);

            var deposit = _depositRepository.GetDeposits()
                .Where(c => c.Amount == depositCreate.Amount)
                .FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var depositMap = _mapper.Map<Deposit>(depositCreate);

            if (!_depositRepository.CreateDeposit(depositMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{depositId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCostumer(int depositId)
        {
            if (!_depositRepository.IsDepositExist(depositId))
            {
                return NotFound();
            }
            var depositToDelete = _depositRepository.GetDeposit(depositId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_depositRepository.DeleteDeposit(depositToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}
