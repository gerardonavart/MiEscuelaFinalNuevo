using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Entidades
{
    public class Materia : BaseDTO
    {
        public string Profesor { get; set; }
        public string Horario { get; set; }
        public string Nombre { get; set; }
        public ObjectId IdUsuario { get; set; }
        public int contador { get; set; }
        public override string ToString()
        {
            return Nombre + ": " + Profesor;
        }
    }
}
