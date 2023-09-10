namespace ApiATM.Models.Dtos.UserCardDto
{
    public class LoginAttemptsUserCardDto
    {
        public int? Id { get; set; }
        public bool CouldLogin { get; set; }
        public int LoginAttempts { get; set; }
    }
}
