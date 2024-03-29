﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Contracts.Interfaces;
using Openwrks.Business.Services;
using BankProviders.Bizfi;

namespace Openwrks.Business
{
    public static class BusinessHelper
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBankService, BankService>();

        }
    }
}
