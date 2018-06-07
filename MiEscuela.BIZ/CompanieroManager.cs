using MiEscuela.COMMON.Entidades;
using MiEscuela.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiEscuela.BIZ
{
    public class CompanieroManager : ICompanieroManager
    {
        IRepository<Companiero> repository;
        public CompanieroManager(IRepository<Companiero> repo)
        {
            repository = repo;
        }

        public List<Companiero> ListarElementos
        {
            get => repository.Read;
            set { }
        }

        public Companiero Agregar(Companiero entidad)
        {
            return repository.Create(entidad);
        }

        public List<Companiero> CompanieroDeUsuario(ObjectId idUsuario)
        {
            //repository.Read.Sort(e=> e.FechaNac == )
            return repository.Read.Where(e => e.IdUsuario == idUsuario).ToList();
            //return repository.Read.Sort(e => e.FechaNac == id)
        }
        
        public bool Eliminar(ObjectId id)
        {
            return repository.Delete(id);
        }

        public Companiero Modificar(Companiero entidad)
        {
            return repository.Update(entidad);
        }

        public Companiero ObtenerElementoPorId(ObjectId id)
        {
            return repository.SearchById(id);
        }
    }
}
