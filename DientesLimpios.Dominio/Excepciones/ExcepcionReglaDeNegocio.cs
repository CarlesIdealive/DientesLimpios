using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Excepciones;

public class ExcepcionReglaDeNegocio: Exception
{
    public ExcepcionReglaDeNegocio(string mensaje) : base(mensaje)
    {
        
    }


}
