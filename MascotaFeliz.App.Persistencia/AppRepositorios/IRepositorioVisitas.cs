using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisitas
    {
        IEnumerable<Visita> GetAllVisitas();
        Visita AddVisita(Visita visita);
        Visita UpdateVisita(Visita visita, int idVisita);
        void DeleteVisita(int idVisita);
        Visita GetVisita(int idVisita);
        IEnumerable<Visita> GetVisitasPorFiltro(string filtro);
    }
}