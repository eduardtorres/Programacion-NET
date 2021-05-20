using AutoMapper;
using OrdenesCore.DTO;
using OrdenesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesInfraestructure.Profiles
{
    public class OrdenesProfile : Profile
    {
        public OrdenesProfile()
        {
            CreateMap<Orden, Ordenes>();
        }
    }
}
