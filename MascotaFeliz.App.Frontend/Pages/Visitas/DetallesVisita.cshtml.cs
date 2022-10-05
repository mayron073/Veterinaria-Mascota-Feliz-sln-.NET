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
    public class DetallesVisitaModel : PageModel
    {
        private readonly IRepositorioVisitas _repoVisita;
        private static IRepositoriVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        
        [BindProperty]
        public Visita visita {get;set;}
        public Veterinario veterinario {get;set;}
        
        public DetallesVisitaModel()
        {
            this._repoVisita = new RepositorioVisitas(new Persistencia.AppContext());
        }
        
        public IActionResult OnGet(int visitaId)
        {
            int id = 0;
            visita = _repoVisita.GetVisita(visitaId);
            id = visita.IdVeterinario;
            veterinario = _repoVeterinario.GetVeterinario(id);
            return Page();
        }
    }
}

