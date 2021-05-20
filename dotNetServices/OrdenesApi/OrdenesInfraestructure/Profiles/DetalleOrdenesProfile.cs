using AutoMapper;
using OrdenesCore.DTO;
using OrdenesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenesInfraestructure.Profiles
{
    public class DetalleOrdenesProfile : Profile
    {
        public DetalleOrdenesProfile()
        {
            CreateMap<DetalleOrden, DetalleOrdenes>();
        }
    }
}
