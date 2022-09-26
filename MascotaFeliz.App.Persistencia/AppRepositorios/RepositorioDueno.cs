using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioDueno : IRepositorioDueno
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        // Constructor
        public RepositorioDueno(AppContext appContext)
        {
            _appContext = appContext;
        }

        // Metodo para agregar nuevo dueno.
        public Dueno AddDueno(Dueno dueno)
        {
            var duenoAdicionado = _appContext.Duenos.Add(dueno);
            _appContext.SaveChanges();
            return duenoAdicionado.Entity;
        }

        // Metodo para eliminar un dueno.
        public void DeleteDueno(int idDueno)
        {
            var duenoEncontrado = _appContext.Duenos.FirstOrDefault(d => d.Id == idDueno);
            if (duenoEncontrado == null)
                return;
            _appContext.Duenos.Remove(duenoEncontrado);
            _appContext.SaveChanges();
        }

       // Metodo para mostrar todos los duenos.
       public IEnumerable<Dueno> GetAllDuenos()
        {
            return GetAllDuenos_();
        }

        // Metodo que muestra duenos por nombre.
        public IEnumerable<Dueno> GetDuenosPorFiltro(string filtro)
        {
            var duenos = GetAllDuenos(); // Obtiene todos los saludos
            if (duenos != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    duenos = duenos.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return duenos;
        }

        // Metodo para retornar todos los duenos.
        public IEnumerable<Dueno> GetAllDuenos_()
        {
            return _appContext.Duenos;
        }

        // Metodo que obtiene un dueno.
        public Dueno GetDueno(int idDueno)
        {
            return _appContext.Duenos.FirstOrDefault(d => d.Id == idDueno);
        }

        // Metodo que actualiza un dueno.
        public Dueno UpdateDueno(Dueno dueno)
        {
            var duenoEncontrado = _appContext.Duenos.FirstOrDefault(d => d.Id == dueno.Id);
            if (duenoEncontrado != null)
            {
                duenoEncontrado.Nombre = dueno.Nombre;
                duenoEncontrado.Apellido = dueno.Apellido;
                duenoEncontrado.Direccion = dueno.Direccion;
                duenoEncontrado.Telefono = dueno.Telefono;
                duenoEncontrado.Correo = dueno.Correo;
                _appContext.SaveChanges();
            }
            return duenoEncontrado;
        }       
    }
}