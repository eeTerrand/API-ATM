using ApiATM.Models;
using ApiATM.Models.Dtos.UserCardDto;
using ApiATM.Models.Dtos.UserOperationDto;
using AutoMapper;

namespace ApiATM.Mapper
{
    public class ATMMapper : Profile
    {
        public ATMMapper() 
        {
            CreateMap<UserCard, UserCardDto>().ReverseMap();
            CreateMap<UserCard, UpdateBlockUserCardDto>().ReverseMap();
            CreateMap<UserCard, UpdateBankBalanceUserCardDto>().ReverseMap();
            CreateMap<UserCard, CreateUserCardDto>().ReverseMap();
            CreateMap<UserCard, BalanceDataFromUserCardDto>().ReverseMap();

            CreateMap<UserOperation, UserOperationDto>().ReverseMap();
            CreateMap<UserOperation, CreateBalanceUserOperationDto>().ReverseMap();
            CreateMap<UserOperation, UpdateBankBalanceUserCardDto>().ReverseMap();

        }
    }
}
