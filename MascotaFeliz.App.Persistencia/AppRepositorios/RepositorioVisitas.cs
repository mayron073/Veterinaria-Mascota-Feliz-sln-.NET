using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitas : IRepositorioVisitas
    {
        /// <summary>
        /// Referencia al contexto de Visita
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        // Constructor
        public RepositorioVisitas(AppContext appContext)
        {
            _appContext = appContext;
        }

//  Agregar una nueva visita.
        public Visita AddVisita(Visita visita)
        {
            var visitaEncontrada = _appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaEncontrada.Entity;
        }

//  Eliminar una visita.
        public void DeleteVisita(int idVisita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
            if (visitaEncontrada == null)
            {
                return;
            }
            _appContext.Visitas.Remove(visitaEncontrada);
            _appContext.SaveChanges();
        }

//  Actualizar una visita.
        public Visita UpdateVisita(Visita visita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(d => d.Id == visita.Id);
            if (visitaEncontrada != null)
            {
                visitaEncontrada.FechaDeVisita = visita.FechaDeVisita;
                visitaEncontrada.Temperatura = visita.Temperatura;
                visitaEncontrada.Peso = visita.Peso;
                visitaEncontrada.FrecuenciaRespiratoria = visita.FrecuenciaRespiratoria;
                visitaEncontrada.FrecuenciaCardiaca = visita.FrecuenciaCardiaca;
                visitaEncontrada.EstadoMental = visita.EstadoMental;
                visitaEncontrada.Recomendaciones = visita.Recomendaciones;
                visitaEncontrada.IdVeterinario = visita.IdVeterinario;

                _appContext.SaveChanges();
            }
            return visitaEncontrada;
        }

//  Retornar una visita.
        public Visita GetVisita(int idVisita)
        {
            return _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
        }

        public IEnumerable<Visita> GetAllVisitas()
        {
            return _appContext.Visitas;
        }

    }

}