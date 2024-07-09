using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Project.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) {
            profile.AllowNullCollections = true;
            profile.CreateMap(typeof(T), GetType());
            

        }

    }
}
