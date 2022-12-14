using AutoMapper;
using DbFirst.Data;
using ErayArıkan21898388.DataAccess.Interfaces;
using ErayArıkan21898388.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ErayArıkan21898388.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    { 
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper= mapper;
        }

       [HttpGet]
       [ProducesResponseType(200, Type = typeof(IEnumerable<Account>))]
       public IActionResult GetAccounts()
        {
            var account = _mapper.Map<List<AccountDto>>(_accountRepository.GetAccounts());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(account);
        }



        [HttpGet("{accountId}")]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int accountId)
        {
            if (!_accountRepository.AccountsExist(accountId))
                return NotFound();

            var account=_accountRepository.GetAccount(accountId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(account);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAccount(AccountDto accountCreate)
        {
            if (accountCreate == null)
                return BadRequest(ModelState);

            var account = _accountRepository.GetAccountTrimToUpper(accountCreate);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountMap = _mapper.Map<Account>(accountCreate);


            if (!_accountRepository.CreateAccount(accountMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{accountId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAccount([FromBody] AccountDto updatedAccount, int accountId)
        {
            if (updatedAccount == null)
                return BadRequest(ModelState);


            if (!_accountRepository.AccountsExist(accountId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var accountMap = _mapper.Map<Account>(updatedAccount);

            if (!_accountRepository.UpdateAccount(accountMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{accountId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAccount(int accountId)
        {
            if (!_accountRepository.AccountsExist(accountId))
            {
                return NotFound();
            }
            var accountToDelete = _accountRepository.GetAccount(accountId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_accountRepository.DeleteAccount(accountToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }



}

