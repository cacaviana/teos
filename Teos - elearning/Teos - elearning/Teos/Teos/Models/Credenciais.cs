using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    public class Credenciais
    {
        public int Id { get; set; }
        public int ClientesID { get; set; }
        public int WebServicesApiId { get; set; }

        public Clientes Clientes { get; set; }
        public WebServicesApi WebServicesApi { get; set; }

    }
}