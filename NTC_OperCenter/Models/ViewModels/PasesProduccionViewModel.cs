using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTC_OperCenter.Models.ViewModels
{
    public class PasesProduccionViewModel
    {
            public string ServidorDevDescripcion { get; set; }
            public string TipoObjetoDescripcion { get; set; }
            public string ProyectoDescripcion { get; set; }
            public string RutaPasesDescripcion { get; set; }
            public List<PasesProduccionDetalleViewModel> detalles { get; set; }
    }



    public class PasesProduccionDetalleViewModel
    {
       public string Servidor_Dest { get; set; }

    }




}