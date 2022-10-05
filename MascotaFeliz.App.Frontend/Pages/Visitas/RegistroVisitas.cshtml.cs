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
    public class RegistroVisitasModel : PageModel
    {
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext()); 
        private static IRepositoriVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private readonly IRepositorioVisitas _repoVisita;

        [BindProperty]
        public Visita visita {get;set;}
        public Mascota mascota {get;set;}

        public IEnumerable<Veterinario> listaVeterinarios {get;set;}
        public IEnumerable<Mascota> listaMascotas {get;set;}

        public RegistroVisitasModel()
        {
            this._repoVisita = new RepositorioVisitas(new Persistencia.AppContext());
        }

        public IActionResult OnGet()
        {
            visita = new Visita();
            listaMascotas = _repoMascota.GetAllMascotas();
            listaVeterinarios = _repoVeterinario.GetAllVeterinario();
            return Page();
        }

        public IActionResult OnPost(int veterinarioId, int mascotaId)
        {
            if (ModelState.IsValid)
            {   
                int hId = _repoMascota.GetHistoriaId(mascotaId);

                visita.IdVeterinario = veterinarioId;
                visita = _repoVisita.AddVisita(visita);

                _repoHistoria.AsignarVisitas(visita.Id, hId);
                _repoVisita.UpdateVisita(visita);
                
                return RedirectToPage("/Mascotas/ListaMascotas");
            }
            else
            {
                return Page();
            }

        }
    }
}
