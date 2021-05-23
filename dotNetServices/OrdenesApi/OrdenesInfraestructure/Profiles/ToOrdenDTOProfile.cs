using OrdenesCore.DTO;
using OrdenesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace OrdenesInfraestructure.Profiles
{
    public class ToOrdenDTOProfile : Profile
    {

        public ToOrdenDTOProfile()
        {
            CreateMap<Ordenes, Orden>();
            CreateMap<Ordenes, ResponseOrdenesByCliente>();
        }
    }
}
