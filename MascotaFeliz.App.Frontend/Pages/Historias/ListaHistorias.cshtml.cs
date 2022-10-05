using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListaHistoriasModel : PageModel
    {
        private static IRepositorioHistoria _repoHistoria =  new RepositorioHistoria(new Persistencia.AppContext()); 
        private readonly IRepositorioMascota _repoMascota;

        [BindProperty]
        public Mascota mascota {get;set;}

        public IEnumerable<Visita> listaVisitas {get;set;}

        public ListaHistoriasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            
        }

        public void OnGet(int idMascota)
        {
            mascota = _repoMascota.GetMascota(idMascota);
            listaVisitas = _repoHistoria.GetVisitasHistoria(mascota.Historia.Id);
        }
    }
}
