using System.Runtime.Serialization;

namespace Pacagroup.Comercial.Creditos.Dominio
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string CodigoError { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}
