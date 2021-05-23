using OrdenesCore.DTO;
using OrdenesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace OrdenesInfraestructure.Profiles
{
    public class ToDetallenOrdenDTOProfile : Profile
    {
        public ToDetallenOrdenDTOProfile()
        {
            CreateMap<DetalleOrdenes, DetalleOrden>();
        }
    }
}