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
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        public IEnumerable<Mascota> listaMascotas {get; set;}

        public string Filtro {get;set;}
        private int flag {get;set;} 

        public ListaMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this.flag = 0;
        }

        public void OnGet()
        {
            if (flag == 0)
            {
                listaMascotas = _repoMascota.GetAllMascotas(); 
            }
            if (flag == 1)
            {
                listaMascotas = _repoMascota.GetMascotaPorFiltro(Filtro);
            }
                   
        }

        public IActionResult OnPost(string filtro)
        {
            if (filtro.Length > 0)
            {
                Filtro = filtro;
                flag = 1;
                return Page();
            }
            else
            {
                return Page();
            }
            
            
        }
    }
}
