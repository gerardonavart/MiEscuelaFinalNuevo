using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Entidades
{
    public abstract class BaseDTO
    {
        public ObjectId Id { get; set; }

        public DateTime FechaHora { get; set; }
    }
}
