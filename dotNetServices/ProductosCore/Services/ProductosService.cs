﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductosCore.DTO;
using ProductosCore.Entities;
using ProductosCore.Interfaces;
using System.Linq;

namespace ProductosCore.Services
{
    public class ProductosService : IProductosService
    {
        private IProductosRepository _productosRepository;        

        public ProductosService(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;            
        }

        public async Task<ListarProductosResponse> ListarProductos( ListarProductosRequest request )
        {
            IReadOnlyList<Producto> lista = await _productosRepository.ListarProductos(request);

            ListarProductosResponse response = new ListarProductosResponse();

            var productos = lista.
                Select(
                x => new ProductoDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Fabricante = x.Fabricante,
                    TipoProveedor = x.TipoProveedor,
                    CodigoProveedor = x.CodigoProveedor,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Categoria = x.Categoria,
                    Precio = x.Precio,
                    Inventario = x.Inventario
                }
                );

            response.productos = productos.ToList();

            return response;
        }
    }
}
