namespace ApiATM.Models.Dtos.UserCardDto
{
    public class CreateUserCardDto
    {
        public string Number { get; set; }
        public int Pin { get; set; }
        public bool IsLocked { get; set; }
        public decimal BankBalance { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
