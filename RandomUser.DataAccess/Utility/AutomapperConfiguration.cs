using AutoMapper;
using RandomUser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.DataAccess.Utility
{
    public static class AutomapperConfiguration
    {
        public static MapperConfiguration GetConfiguration()
        {
            var config = new MapperConfiguration(cfg => 
                cfg.CreateMap<User, UserModel>()
                .ForMember(d => d.ProfilePicture, opt => opt.ConvertUsing(new FilePathConverter(), src => src.ProfilePicturePath)
            ));

            return config;
        }
    }
}
