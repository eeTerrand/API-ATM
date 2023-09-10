using System.ComponentModel.DataAnnotations;

namespace ApiATM.Models.Dtos.UserOperationDto
{
    public class WithdrawUserOperationResultDto
    {
            public string CardNumber { get; set; }
            public DateTime ExecutionDate { get; set; }
            public decimal? WithdrawalAmount { get; set; }
            public decimal? AmountOnCount { get; set; }
    }
}
