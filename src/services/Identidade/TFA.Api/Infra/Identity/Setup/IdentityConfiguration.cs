﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TFA.Api.Infra.Identity.Context;

namespace TFA.Api.Infra.Identity.Setup
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<SecurityDbContext>(options =>
            {
                options.UseSqlServer(@"server=(localdb)\mssqllocaldb",
                    p => p.EnableRetryOnFailure(
                            maxRetryCount: 2,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null).MigrationsHistoryTable("Security_Migrations", null));
            });

            services.AddDefaultIdentity<UserRegister>((op) =>
            {
                op.SignIn.RequireConfirmedAccount = true;
                op.SignIn.RequireConfirmedEmail = true;
            }).AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddErrorDescriber<MessagesPortuguese>()
                .AddDefaultTokenProviders();

            //jwt

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidIn,
                    ValidIssuer = appSettings.Issuer
                };
            });

        }
    }
}
