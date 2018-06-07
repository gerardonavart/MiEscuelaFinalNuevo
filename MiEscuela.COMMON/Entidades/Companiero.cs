using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Entidades
{
    public class Companiero : BaseDTO
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        //public string FechaNac { get; set; }
        public ObjectId IdUsuario { get; set; }

        public override string ToString()
        {
            return Apellidos + " " + Nombre;
        }
    }
}
