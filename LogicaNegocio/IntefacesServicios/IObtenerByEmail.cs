﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IntefacesServicios
{
    public interface IObtenerByEmail<T>
    {
        public T Ejecutar(string email);
    }
}
