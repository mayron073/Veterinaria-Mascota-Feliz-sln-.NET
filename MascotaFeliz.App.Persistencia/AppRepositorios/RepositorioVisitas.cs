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

        public Visita AddVisita(Visita visita)
        {
            var visitaEncontrada = _appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaEncontrada.Entity;
        }

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

        public Visita UpdateVisita(Visita visita, int idVisita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
            if (visitaEncontrada != null)
            {
                visitaEncontrada.FechaDeVisita = visita.FechaDeVisita;
                visitaEncontrada.Temperatura = visita.Temperatura;
                visitaEncontrada.Peso = visita.Peso;
                visitaEncontrada.FrecuenciaRespiratoria = visita.FrecuenciaRespiratoria;
                visitaEncontrada.FrecuenciaCardiaca = visita.FrecuenciaCardiaca;
                visitaEncontrada.EstadoMental = visita.EstadoMental;
                visitaEncontrada.Recomendaciones = visita.Recomendaciones;
                //visitaEncontrada.IdVeterinario = visita.IdVeterinario;

                _appContext.SaveChanges();
            }
            return visitaEncontrada;
        }

        public Visita GetVisita(int idVisita)
        {
            return _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
        }

        public IEnumerable<Visita> GetAllVisitas()
        {
            return _appContext.Visitas;
        }

        public IEnumerable<Visita> GetVisitasPorFiltro(string filtro)
        {
            var visita = GetAllVisitas(); // Obtiene todos los saludos
           /* if (visita != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    visita = visita.Where(s => s.Nombre.Contains(filtro));
                }
            }*/
            return visita;
        }

    }

}