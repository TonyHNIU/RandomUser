using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.DataAccess.Utility
{
    public abstract class AutoMapperBase
    {
        protected readonly IMapper Mapper;

        protected AutoMapperBase()
        {
            var config = AutomapperConfiguration.GetConfiguration();

            Mapper = config.CreateMapper();
        }
    }
}
