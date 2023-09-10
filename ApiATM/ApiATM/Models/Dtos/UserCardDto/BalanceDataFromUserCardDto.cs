namespace ApiATM.Models.Dtos.UserCardDto
{
    public class BalanceDataFromUserCardDto
    {
        public string Number { get; set; }
        public float BankBalance { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
