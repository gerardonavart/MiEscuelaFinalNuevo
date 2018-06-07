using MiEscuela.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Interfaces
{
    public interface IRepository<T> where T : BaseDTO
    {
        //Una interfaz define que se va a hacer
        T Create(T entidad);
        List<T> Read { get; }
        T Update(T entidad);
        bool Delete(ObjectId id);
        T SearchById(ObjectId id);
    }
}
