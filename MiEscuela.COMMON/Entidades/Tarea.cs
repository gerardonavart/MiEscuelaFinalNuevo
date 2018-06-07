using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiEscuela.COMMON.Entidades
{
    public class Tarea : BaseDTO
    {
        //TODO Cadena de MongoDB mongodb://<dbuser>:<dbpassword>@ds261838.mlab.com:61838/dongeraescuela
        public string Titulo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Entregada { get; set; }
        public bool Prioridad { get; set; }
        public string Descripcion { get; set; }
        public decimal Calificacion { get; set; }
        public ObjectId IdTarea { get; set; }
       
        public override string ToString()
        {
            
            string entrega;
            if (Entregada == true)
            {
                entrega = "Entregada";
                
            }
            else
            {
                entrega = "No Entregada";
              
            }
            string urge;
            if (Prioridad == true)
            {
                urge = "Urgente";
            }
            else
            {
                urge = "Normal";
            }
            //return Titulo + ", Estado: " + ", Prioridad:" + urge;
            return Titulo + ", " + entrega + ", " + urge + ", " + Calificacion ;
        }
    }
}
