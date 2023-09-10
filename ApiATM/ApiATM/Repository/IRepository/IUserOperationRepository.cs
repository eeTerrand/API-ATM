using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;
using ApiATM.Models.Dtos.UserOperationDto;

namespace ApiATM.Repository.IRepository
{
    public interface IUserOperationRepository
    {
        bool RegisterBankBalance(UserOperation addRegister);
        WithdrawUserOperationResultDto RegisterWithdrawFunds(UserOperation addRegister, UserCard cardData);
        bool Save();

    }
}
