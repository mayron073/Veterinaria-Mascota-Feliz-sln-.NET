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
        /// Referencia al contexto de Dueno
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

        public Historia AddHistoria(Historia historia)
        {
            var historiaAgregada = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAgregada.Entity;
        }

        public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrada == null)
                return;
            _appContext.Historias.Remove(historiaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<Historia> GetAllHistorias()
        {
            return _appContext.Historias;
        }

        public IEnumerable<Historia> GetHistoriasPorFiltro(string filtro)
        {
            return _appContext.Historias;
        }

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
        }

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

        IEnumerable<Visita> IRepositorioHistoria.GetVisitasHistoria(int idHistoria)
        {
            var historia = _appContext.Historias.Where(h => h.Id == idHistoria)
                                                .Include(h => h.Visitas)
                                                .FirstOrDefault();
            return historia.Visitas;
        }

    }
}