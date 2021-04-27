using FabricantesCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabricantesCore.Entities
{
    public class InventarioEntity
    {
        public long IdInventario { get; set; }
        public long IdProducto { get; set; }
        public long IdFabricante { get; set; }
        public long Cantidad { get; set; }        
    }
}
