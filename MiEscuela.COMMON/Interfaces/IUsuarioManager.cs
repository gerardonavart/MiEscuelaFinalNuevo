using MiEscuela.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Interfaces
{
    public interface IUsuarioManager : IGenericManager<Usuario>
    {
        Usuario Login(string usuario, string pass);
        Usuario CrearCuenta(string usuario, string pass);

    }
}
