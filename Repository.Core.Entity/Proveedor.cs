﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entity
{
    public class Proveedor
    {
        [DisplayName("Id")]
        public int Id_Proveedor { get; set; }
        public string Descripcion { get; set; }
    }
}