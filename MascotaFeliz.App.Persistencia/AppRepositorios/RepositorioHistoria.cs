using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
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
        
        // Constructor
        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }
        
//  Metodo que agrega una historia nueva.
        public Historia AddHistoria(Historia historia)
        {
            var historiaAgregada = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAgregada.Entity;
        }
        
// Metodo que elimina una historia.
        public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrada == null)
                return;
            _appContext.Historias.Remove(historiaEncontrada);
            _appContext.SaveChanges();
        }

//  Metodo que obtiene todas las historias y sus visitas.
        public IEnumerable<Historia> GetAllHistorias()
        {
            return _appContext.Historias.Include("Visitas");
        }

//  Metodo que obtiene una historia.
        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
        }

//  Metodo que actualiza una historia.
        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(d => d.Id == historia.Id);

            if (historiaEncontrada != null)
            {
                historiaEncontrada.FechaInicial = historia.FechaInicial;
                historiaEncontrada.Visitas = historia.Visitas;
                _appContext.SaveChanges();
            }
            return historiaEncontrada;
        }

//  Metodo que obtiene una lista de las visistas de una historia.
        IEnumerable<Visita> IRepositorioHistoria.GetVisitasHistoria(int idHistoria)
        {
            var historia = _appContext.Historias.Where(h => h.Id == idHistoria)
                                                .Include(h => h.Visitas)
                                                .FirstOrDefault();
            return historia.Visitas;
        }

// Metodo que asigna visitas a una historia.
        public IEnumerable<Visita> AsignarVisitas(int idVisita, int idHistoria)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
            
            if (historiaEncontrada != null)
            {
                var visitaEncontrada = _appContext.Visitas.FirstOrDefault(v => v.Id == idVisita);
                if (visitaEncontrada != null)
                {
                    List<Visita> visitas = new List<Visita>();
                    visitas.Add(visitaEncontrada);
                    historiaEncontrada.Visitas = visitas;
                    _appContext.SaveChanges();
                }
                return historiaEncontrada.Visitas;
            }
            return null;
        }

    }
}