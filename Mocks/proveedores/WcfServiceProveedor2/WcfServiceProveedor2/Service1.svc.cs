using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceProveedor2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<ProductoBE> GetDataUsingDataContract(string filtro)
        {
            List<ProductoBE> productos = new List<ProductoBE>();

            productos.Add(new ProductoBE()
            {
                codigo = "P001",
                linea = "Juegos PS5",
                id = 2001,
                descripcion = "FPS",
                nombre = "Call of duty Cold War",
                precioUnitario = 240000,
                unidadesDisponibles = 10
            });

            productos.Add(new ProductoBE()
            {
                codigo = "P002",
                linea = "Juegos PS5",
                id = 2002,
                descripcion = "FPS",
                nombre = "Call of duty WWII",
                precioUnitario = 140000,
                unidadesDisponibles = 1
            });

            productos.Add(new ProductoBE()
            {
                codigo = "P003",
                linea = "Juegos PS5",
                id = 2003,
                descripcion = "Survival horror",
                nombre = "Resident evil 8 the Village",
                precioUnitario = 200000,
                unidadesDisponibles = 0

            });

            productos.Add(new ProductoBE()
            {
                codigo = "P004",
                linea = "Juegos PS5",
                id = 2004,
                descripcion = "Souls",
                nombre = "Demon Souls",
                precioUnitario = 350000,
                unidadesDisponibles = 25

            });

            return productos;
        }

        public OrdenResponse PonerOrdenExterna(OrdenRequest request)
        {

            return new OrdenResponse()
            {
                numeroOrden = (new Random(DateTime.Now.Second).Next()).ToString(),
                statusOrden = "ACEPTADA"
            };

        }

    }
}
