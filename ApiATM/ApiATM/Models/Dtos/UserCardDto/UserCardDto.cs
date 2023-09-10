namespace ApiATM.Models.Dtos.UserCardDto
{
    public class UserCardDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Pin { get; set; }
        public bool IsLocked { get; set; }
        public float BankBalance { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
