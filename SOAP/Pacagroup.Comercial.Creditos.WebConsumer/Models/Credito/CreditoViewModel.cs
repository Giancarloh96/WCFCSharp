using System;
using System.ComponentModel.DataAnnotations;

namespace Pacagroup.Comercial.Creditos.WebConsumer.Models.Credito
{
    public class CreditoViewModel
    {

        public int idCredito { get; set; }


        public int TipoCredito { get; set; }


        public int IdCliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }


        public Decimal Monto { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DiaPago { get; set; }


        public Decimal Tasa { get; set; }


        public Decimal Comision { get; set; }
    }
}