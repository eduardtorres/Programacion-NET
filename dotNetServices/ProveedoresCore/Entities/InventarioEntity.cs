using ProveedoresCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProveedoresCore.Entities
{
    public class InventarioEntity
    {
        public long IdInventario { get; set; }
        public long IdProducto { get; set; }
        public long IdFabricante { get; set; }
        public long Cantidad { get; set; }        
    }
}
