using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositoriVeterinario
    {
        /// <summary>
        /// Referencia al contexto
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

//  Metodo que agrega un nuevo veterinario.
        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

//  Metodo que elimina un vetrinario.
        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

//  Metodo que retorna una lista de todos los vetrinarios.
       public IEnumerable<Veterinario> GetAllVeterinario()
        {
            return _appContext.Veterinarios;
        }

//  Metodo que retorna una lista de vaterinarios filtrados por nombre.
        public IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro)
        {
            var Veterinarios = GetAllVeterinario();
            if (Veterinarios != null)  
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    Veterinarios = Veterinarios.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return Veterinarios;
        }

//  Metodo que retorna un veterinario.
        public Veterinario GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinario);
        }

//  Metodo que actualiza un veterinario.
        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombre = veterinario.Nombre;
                veterinarioEncontrado.Apellido = veterinario.Apellido;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }     
    }
}