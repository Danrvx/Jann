using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscarDatos.Models
{
    public class ClientesBuscar
    {
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
    }

    public class ListaClientesF 
    {
        public string Nombre { get; set; }

        public string Apellidop { get; set; }

        public string Apellidom { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Asesor { get; set; }

        public string Fraccionamiento { get; set; }

        public string Financiamiento { get; set; }

        public string Estatus { get; set; }

        public string Ultimo_seguimiento { get; set; }

        public string Ver_expediente { get; set; }


    }
    
}