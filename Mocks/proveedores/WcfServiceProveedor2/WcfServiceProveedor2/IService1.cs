using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceProveedor2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<ProductoBE> GetDataUsingDataContract(string filtro);

        [OperationContract]
        OrdenResponse PonerOrdenExterna(OrdenRequest request);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class OrdenRequest
    {
        [DataMember]
        public string codigoProducto { get; set; }
        [DataMember]
        public string cantidadPedida { get; set; }
        [DataMember]
        public string codigoTercero { get; set; }
    }

    [DataContract]
    public class OrdenResponse
    {
        [DataMember]
        public string numeroOrden { get; set; }
        [DataMember]
        public string statusOrden { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ProductoBE
    {

        [DataMember]
        public int id
        {
            get;
            set;
        }

        [DataMember]
        public string codigo
        {
            get;
            set;
        }

        [DataMember]
        public string nombre
        {
            get;
            set;
        }

        [DataMember]
        public string linea
        {
            get;
            set;
        }

        [DataMember]
        public string descripcion
        {
            get;
            set;
        }

        [DataMember]
        public double precioUnitario
        {
            get;
            set;
        }

        [DataMember]
        public int unidadesDisponibles
        {
            get;
            set;
        }

    }
}
