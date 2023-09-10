using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;
using ApiATM.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiATM.Controllers
{
    [ApiController]
    [Route("api/usercards")]
    public class UserCardsController : ControllerBase
    {
        private readonly IUserCardRepository _userCardRepository;
        private readonly IMapper _mapper;

        public UserCardsController(IUserCardRepository userCardRepository, IMapper mapper)
        {
            _userCardRepository = userCardRepository;
            _mapper = mapper;
        }

        [HttpPost("UnlockUser/{cardNumber}")]
        public IActionResult UnlockUserCard(string cardNumber)
        {
            return Ok(_userCardRepository.UnlockUser(cardNumber));
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUserCard([FromBody] CreateUserCardDto cardUser)
        {
            var couldCreate = _userCardRepository.CreateUserCard(cardUser);
            if(couldCreate == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }            
        }

        [HttpPost("login/{cardNumber}", Name = "LoginWithCardNumber")]
        public IActionResult GetUserCardByNumber(string cardNumber)
        {
            var cardData = _userCardRepository.LoginWithCardNumber(cardNumber);

            if (cardData != null) 
            {
                return Ok(cardData);
            }
            else 
            {
                return RedirectToAction();
            }           
        }

        [HttpPost("login-pin/{pinNumber}/{cardId}", Name = "LoginWithPin")]
        public IActionResult LoginWithPin(int pinNumber, int cardId)
        {
            var couldLogin = _userCardRepository.LoginWithPinNumber(pinNumber, cardId);
            if (couldLogin.CouldLogin)
            {
                return Ok(couldLogin);
            }
            else if (couldLogin.CouldLogin is false && couldLogin.LoginAttempts == 4 ) 
            {
                return BadRequest(couldLogin);
            }
            else 
            { 
                return BadRequest(couldLogin); 
            }            
        }
    }
}
