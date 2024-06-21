﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.RestFull
{
    public interface IRestFull
    {
        String Request(string token, string resource);
        string Post(string token, string resource, string json);
        void Delete(string token, string resource);
        string Put(string token, string endPoint, string jsonEntity);
    }
}
