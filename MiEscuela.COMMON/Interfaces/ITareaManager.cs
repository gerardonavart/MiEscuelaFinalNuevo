using MiEscuela.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Interfaces
{
    public interface ITareaManager : IGenericManager<Tarea>
    {
        List<Tarea> BuscarTareasDeMateria(ObjectId idMateria);

    }
}
