using ApiATM.Data;
using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;
using ApiATM.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ApiATM.Repository
{
    public class UserCardRepository : IUserCardRepository
    {
        private readonly ApplicationDbContext _bd;
        public UserCardRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool UnlockUser(string cardNumber)
        {
            var dataUser = GetByCardNumber(cardNumber);

            dataUser.IsLocked = false;
            dataUser.LoginAttempts = 0;

            return Save();        
        }
        public bool CreateUserCard(CreateUserCardDto createUserCardDto)
        {            
            if(createUserCardDto.Number.Length > 16 || createUserCardDto.Number.Length < 16)
            {
                return false;
            }

            if(createUserCardDto.BankBalance < 0) 
            { 
                return false; 
            }
            if (createUserCardDto.Pin.ToString().Length > 4)
            {
                return false;
            }
            var cardToAdd = new UserCard
            {
                Number = createUserCardDto.Number,
                LoginAttempts = 0,
                BankBalance = createUserCardDto.BankBalance,
                ExpirationDate = createUserCardDto.ExpirationDate,
                IsLocked = createUserCardDto.IsLocked,
                Pin = createUserCardDto.Pin
            };
            _bd.UserCards.Add(cardToAdd);
            return Save();
        }

        public UserCard GetByCardNumber(string cardNumber)
        {
            return _bd.UserCards.FirstOrDefault(f => f.Number.Equals(cardNumber));

        }

        public int? LoginWithCardNumber(string cardNumber)
        {
            var cardData = GetByCardNumber(cardNumber);
            if (cardData != null && cardData.IsLocked is false) 
            {
                return cardData.Id;
            }
            else
            {
                return null;
            }
        }

        public UserCard GetById(int id)
        {
            
            return _bd.UserCards.FirstOrDefault(f => f.Id == id);
        }

        public LoginAttemptsUserCardDto LoginWithPinNumber(int pinNumber, int cardId)
        {
            var cardData = GetById(cardId);

            if(cardData.LoginAttempts == 4)
            {
                cardData.IsLocked = true;
                Save();
                return new LoginAttemptsUserCardDto
                {
                    CouldLogin = false,
                    LoginAttempts = cardData.LoginAttempts
                };
            }

            if (cardData.Pin != pinNumber)
            {
                cardData.LoginAttempts = cardData.LoginAttempts + 1;
                Save();
                return new LoginAttemptsUserCardDto
                {                    
                    CouldLogin = false,
                    LoginAttempts = cardData.LoginAttempts
                };
            }
            else
            {
                cardData.LoginAttempts = 0;
                Save();
                return new LoginAttemptsUserCardDto
                {
                    Id = cardData.Id,
                    CouldLogin = true,
                };
            }
        }

        public UserCard UpdateBankBalanceDataCard(UpdateBankBalanceUserCardDto userCard)
        {
            var accountUserCardData = GetById(userCard.UserCardId);
            if (accountUserCardData.BankBalance - userCard.WithdrawalAmount >= 0)
            {
                accountUserCardData.BankBalance -= userCard.WithdrawalAmount;
                Save();
                return accountUserCardData;
            }
            else
            {
                return null;
            }
            
        }

        public bool Save()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
