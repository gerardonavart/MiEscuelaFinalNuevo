using MiEscuela.COMMON.Entidades;
using MiEscuela.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiEscuela.BIZ
{
    public class TareaManager : ITareaManager
    {
        IRepository<Tarea> repository;
        public TareaManager(IRepository<Tarea> repo)
        {
            repository = repo;
        }

        public List<Tarea> ListarElementos
        {
            get => repository.Read;
            set { }
        }

        public Tarea Agregar(Tarea entidad)
        {
            return repository.Create(entidad);
        }

        public List<Tarea> BuscarTareasDeMateria(ObjectId idMateria)
        {
            return repository.Read.Where(e => e.IdTarea == idMateria).ToList();
        }

        public bool Eliminar(ObjectId id)
        {
            return repository.Delete(id);
        }

        public Tarea Modificar(Tarea entidad)
        {
            return repository.Update(entidad);
        }

        public Tarea ObtenerElementoPorId(ObjectId id)
        {
            return repository.SearchById(id);
        }
    }
}
