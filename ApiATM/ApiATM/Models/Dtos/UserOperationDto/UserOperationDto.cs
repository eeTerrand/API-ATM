using System.ComponentModel.DataAnnotations;

namespace ApiATM.Models.Dtos.UserOperationDto
{
    public class UserOperationDto
    {
            public int Id { get; set; }
            public int CardNumber { get; set; }
            public int OperationType { get; set; }
            public decimal? RetiredAmount { get; set; }
            public int CardId { get; set; }
    }
}
