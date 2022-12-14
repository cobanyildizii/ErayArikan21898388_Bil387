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
    public class LoanController : Controller
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        public LoanController(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Loan>))]
        public IActionResult GetLoans()
        {
            var loan = _mapper.Map<List<LoanDto>>(_loanRepository.GetLoans());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(loan);
        }

        [HttpGet("{loanId}")]
        [ProducesResponseType(200, Type = typeof(Loan))]
        [ProducesResponseType(400)]
        public IActionResult GetLoan(int loanId)
        {
            if (!_loanRepository.IsLoanExist(loanId))
                return NotFound();

            var loan = _loanRepository.GetLoanById(loanId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(loan);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLoan(LoanDto loanCreate)
        {
            if (loanCreate == null)
                return BadRequest(ModelState);

            var loan = _loanRepository.GetLoans()
                .Where(c => c.PaybackAmount == loanCreate.PaybackAmount)
                .FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loanMap = _mapper.Map<Loan>(loanCreate);

            if (!_loanRepository.CreateLoan(loanMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{loanId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLoan(int loanId)
        {
            if (!_loanRepository.IsLoanExist(loanId))
            {
                return NotFound();
            }
            var loanToDelete = _loanRepository.GetLoanById(loanId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_loanRepository.DeleteLoan(loanToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
