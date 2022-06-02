using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank.Service.Profiles
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapper>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;

    }
}
