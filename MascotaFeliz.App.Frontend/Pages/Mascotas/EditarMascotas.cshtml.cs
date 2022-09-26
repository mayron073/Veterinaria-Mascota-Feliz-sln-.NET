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
    public class EditarMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext()); 
        private static IRepositoriVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext()); 

        [BindProperty]
        public Mascota mascota {get;set;}
        public Veterinario veterinario {get;set;}
        public Dueno dueno {get;set;}

        public IEnumerable<Dueno> listaDuenos {get;set;}
        public IEnumerable<Veterinario> listaVeterinarios {get;set;}


        public EditarMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }

        public IActionResult  OnGet(int? idMascota)
        {
            listaDuenos = _repoDueno.GetAllDuenos();
            listaVeterinarios = _repoVeterinario.GetAllVeterinario();

            if (idMascota.HasValue)
            {
                mascota = _repoMascota.GetMascota(idMascota.Value);
            }
            else
            {
                mascota = new Mascota();
            }
            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int duenoId, int veterinarioId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (mascota.Id > 0)
            {
                dueno = _repoDueno.GetDueno(duenoId);
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);

                mascota.Dueno = dueno;
                mascota.Veterinario = veterinario;

                mascota = _repoMascota.UpdateMascota(mascota);
                return RedirectToPage("./ListaMascotas");
            }
            else
            {
                _repoMascota.AddMascota(mascota);
                _repoMascota.AsignarDueno(duenoId, mascota.Id);
                _repoMascota.AsignarVeterinario(veterinarioId, mascota.Id);
                
                return RedirectToPage("./ListaMascotas");
            }
        }
    }
}
