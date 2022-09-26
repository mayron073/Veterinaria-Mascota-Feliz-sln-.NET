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
    public class DetallesVeterinarioModel : PageModel
    {
        private readonly IRepositoriVeterinario _repoVeterinario;
        public Veterinario veterinario {get;set;}

        public DetallesVeterinarioModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int idVeterinario)
        {
            veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            if (veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else 
            {
                return Page();
            }
        }
    }
}
