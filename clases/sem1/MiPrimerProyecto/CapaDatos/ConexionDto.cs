﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConexionDto
    {
        public string getConexionString() {
            return ConfigurationManager.ConnectionStrings["cnxSql"].ConnectionString;
        }
    }
}
