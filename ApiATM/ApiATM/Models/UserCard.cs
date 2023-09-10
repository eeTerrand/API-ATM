using System.ComponentModel.DataAnnotations;

namespace ApiATM.Models
{
    public class UserCard
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public int Pin { get; set; }
        public bool IsLocked { get; set; }
        public decimal BankBalance { get; set; }
        public int LoginAttempts { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
