namespace ApiATM.Models.Dtos.UserCardDto
{
    public class UpdateBlockUserCardDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsLocked { get; set; }
    }
}
