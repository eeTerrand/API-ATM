using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiATM.Models
{
    public class UserOperation
    {
        [Key]
        public int Id { get; set; }
        public int OperationType { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal? WithdrawalAmount { get; set; }
        [ForeignKey("UserCardId")]
        public int UserCardId { get; set; }
        public UserCard UserCard { get; set; }
    }
}
