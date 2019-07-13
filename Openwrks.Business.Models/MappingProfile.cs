using AutoMapper;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Models.Models.Bank;
using Openwrks.Business.Models.Models.User;

namespace Openwrks.Business.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDataModel>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name));
            CreateMap<UserCreateModel, User>();

            CreateMap<Bank, BankDataModel>();
            CreateMap<BankCreateModel, Bank>();
        }
    }
}
