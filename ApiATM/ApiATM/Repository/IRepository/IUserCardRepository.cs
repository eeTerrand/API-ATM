using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;

namespace ApiATM.Repository.IRepository
{
    public interface IUserCardRepository
    {        
        UserCard GetById(int id);
        UserCard GetByCardNumber(string cardNumber);
        LoginAttemptsUserCardDto LoginWithPinNumber (int pinNumber, int cardId);
        int? LoginWithCardNumber (string cardNumber);
        UserCard UpdateBankBalanceDataCard(UpdateBankBalanceUserCardDto userCard);
        bool CreateUserCard(CreateUserCardDto userCard);
        bool UnlockUser(string cardNumber);
        bool Save();   

    }
}
