using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Social_app.Models;
using SocialApp.Core.Models;

namespace Social_app
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserResponse>();

                cfg.CreateMap<UserResponse, User>()
                    .ForMember(b => b.Id, o => o.Ignore())
                    .ForMember(c => c.Surname, o => o.Ignore())
                    .ForMember(g => g.BirthDate, o => o.Ignore())
                    .ForMember(c => c.Email, o => o.Ignore())
                    .ForMember(c => c.Password, o => o.Ignore())
                    .ForMember(c => c.Interests, o => o.Ignore())
                    .ForMember(c => c.Post, o => o.Ignore());



            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}