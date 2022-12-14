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
    public class WithdrawalController:Controller
    {
        private readonly IWithdrawalRepository _withdrawalRepository;
        private readonly IMapper _mapper;
        public WithdrawalController(IWithdrawalRepository withdrawalRepository, IMapper mapper)
        {
            _withdrawalRepository = withdrawalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Withdrawal>))]
        public IActionResult GetWithdrawals()
        {
            var withdrawals = _mapper.Map<List<WithdrawalDto>>(_withdrawalRepository.GetWithdrawals());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(withdrawals);
        }

        [HttpGet("{withdrawalId}")]
        [ProducesResponseType(200, Type = typeof(Withdrawal))]
        [ProducesResponseType(400)]
        public IActionResult GetWithdrawal(int withdrawalId)
        {
            if (!_withdrawalRepository.IsWithdrawalExist(withdrawalId))
                return NotFound();

            var costumer = _withdrawalRepository.GetWithdrawal(withdrawalId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(costumer);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateWithdrawal(WithdrawalDto witdrawalCreate)
        {
            if (witdrawalCreate == null)
                return BadRequest(ModelState);

            var withdrawal = _withdrawalRepository.GetWithdrawals()
                .Where(c => c.Amount == witdrawalCreate.Amount)
                .FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loanMap = _mapper.Map<Loan>(witdrawalCreate);

            if (!_withdrawalRepository.CreateWithdrawal(loanMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{withdrawalId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWithdrawal(int withdrawalId)
        {
            if (!_withdrawalRepository.IsWithdrawalExist(withdrawalId))
            {
                return NotFound();
            }
            var withdrawalToDelete = _withdrawalRepository.GetWithdrawal(withdrawalId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_withdrawalRepository.DeleteWithdrawal(withdrawalToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }


    }
}
