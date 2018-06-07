using MiEscuela.COMMON.Entidades;
using MiEscuela.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiEscuela.BIZ
{
    public class MateriaManager : IMateriaManager
    {
        IRepository<Materia> repository;

        public MateriaManager(IRepository<Materia> repo)
        {
            repository = repo;
        }

        public List<Materia> ListarElementos
        {
            get => repository.Read;
            set { }
        }

        public Materia Agregar(Materia entidad)
        {
            return repository.Create(entidad);
        }

        public List<Materia> BuscarMateriasDeUsuario(ObjectId idUsuario)
        {
            return repository.Read.Where(e => e.IdUsuario == idUsuario).ToList();
        }

        public bool Eliminar(ObjectId id)
        {
            return repository.Delete(id);
        }

        public Materia Modificar(Materia entidad)
        {
            return repository.Update(entidad);
        }

        public Materia ObtenerElementoPorId(ObjectId id)
        {
            return repository.SearchById(id);
        }
    }
}
