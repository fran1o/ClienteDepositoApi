using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public record Nombre
    {
        public string Value { get; init; }

        public Nombre(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NombreException("value");
            }
            Value = value;
        }
    }
}
