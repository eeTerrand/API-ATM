using ApiATM.Data;
using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;
using ApiATM.Models.Dtos.UserOperationDto;
using ApiATM.Repository.IRepository;

namespace ApiATM.Repository
{
    public class UserOperationRepository : IUserOperationRepository
    {
        private readonly ApplicationDbContext _bd;
        public UserOperationRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public bool RegisterBankBalance(UserOperation addRegister)
        {
            addRegister.ExecutionDate = DateTime.Now;
            addRegister.OperationType = 0;
            _bd.UserOperation.Add(addRegister);
            return Save();            
        }

        public WithdrawUserOperationResultDto RegisterWithdrawFunds(UserOperation addRegister,UserCard cardData)
        {
            addRegister.ExecutionDate = DateTime.Now;
            addRegister.OperationType = 1;
            _bd.UserOperation.Add(addRegister);
            Save();

            return new WithdrawUserOperationResultDto
            {
                AmountOnCount = cardData.BankBalance,
                WithdrawalAmount = addRegister.WithdrawalAmount,
                CardNumber = cardData.Number,
                ExecutionDate = addRegister.ExecutionDate
            };
        }

        public bool Save()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
