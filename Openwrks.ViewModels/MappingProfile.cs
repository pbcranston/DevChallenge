using Openwrks.Business.Models.Interfaces;
using Openwrks.Business.Models.Models.Bank;
using Openwrks.Business.Models.Models.User;
using Openwrks.ViewModels.Interfaces;
using Openwrks.ViewModels.Models.Request.Bank;
using Openwrks.ViewModels.Models.Request.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.ViewModels.Models.Request.Users;
using Openwrks.ViewModels.Models.Response.Users;
using Openwrks.ViewModels.Models.Response.Bank;

namespace Openwrks.ViewModels
{
    public class MappingProfile : Business.Models.MappingProfile
    {
        public MappingProfile()
        {
            CreateMap<IListRequestModel, IQueryModel>()
                .ForPath(dest => dest.Paging.ItemsPerPage, opt => opt.MapFrom(src => src.ItemsPerPage))
                .ForPath(dest => dest.Paging.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
                .ForPath(dest => dest.Paging.SortBy, opt => opt.MapFrom(src => src.SortBy))
                .ForPath(dest => dest.Paging.SortDesc, opt => opt.MapFrom(src => src.SortDesc))
                .Include<UserListRequestModel, UserListQueryModel>()
                .Include<BankListRequestModel, BankListQueryModel>()
                .ReverseMap();


            CreateMap<UserDataModel, UserViewModel>();
            CreateMap<UserCreateRequestModel, UserCreateModel>();

            CreateMap<BankDataModel, BankViewModel>();
            CreateMap<BankCreateRequestModel, BankCreateModel>();
        }
    }
}
