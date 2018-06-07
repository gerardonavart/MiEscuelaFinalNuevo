using MiEscuela.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Interfaces
{
    public interface ICompanieroManager : IGenericManager<Companiero>
    {
        List<Companiero> CompanieroDeUsuario(ObjectId idUsuario);
    }
}
