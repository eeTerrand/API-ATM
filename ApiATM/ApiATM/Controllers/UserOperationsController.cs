using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;
using ApiATM.Models.Dtos.UserOperationDto;
using ApiATM.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiATM.Controllers
{
    [ApiController]
    [Route("api/useroperations")]
    public class UserOperationsController : ControllerBase
    {
        private readonly IUserCardRepository _userCardRepository;
        private readonly IUserOperationRepository _userOperationRepository;
        private readonly IMapper _mapper;
        public UserOperationsController(IMapper mapper, IUserOperationRepository userOperationRepository, IUserCardRepository userCardRepository) 
        {
            _mapper = mapper;
            _userOperationRepository = userOperationRepository;
            _userCardRepository = userCardRepository;
        }
        [HttpPost("AddBalance")]
        public IActionResult CreateBalanceRegister([FromBody] CreateBalanceUserOperationDto balanceOperation)
        {
            var userOperation = _mapper.Map<UserOperation>(balanceOperation);
            _userOperationRepository.RegisterBankBalance(userOperation);
            var cardData = _userCardRepository.GetById(balanceOperation.UserCardId);
            var balanceData = _mapper.Map<BalanceDataFromUserCardDto>(cardData);
            return Ok(balanceData);
        }

        [HttpPost("WithdrawFunds")]
        public IActionResult WithdrawFunds([FromBody] UpdateBankBalanceUserCardDto updateBankBalance)
        {
            var shouldRegisterUpdatedData = _userCardRepository.UpdateBankBalanceDataCard(updateBankBalance);

            if (shouldRegisterUpdatedData != null)
            {
                var userOperation = _mapper.Map<UserOperation>(updateBankBalance);
                var operationResult = _userOperationRepository.RegisterWithdrawFunds(userOperation, shouldRegisterUpdatedData);
                
                return Ok(operationResult);
            }
            else 
            { 
                return BadRequest(); 
            }
        }
    }
}
