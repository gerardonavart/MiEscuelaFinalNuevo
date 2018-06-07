using MiEscuela.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Interfaces
{
    public interface IGenericManager<T> where T : BaseDTO
    {
        T Agregar(T entidad);
        T Modificar(T entidad);
        bool Eliminar(ObjectId id);
        List<T> ListarElementos { get; set; }
        T ObtenerElementoPorId(ObjectId id);
    }
}
