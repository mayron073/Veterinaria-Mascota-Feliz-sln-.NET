using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        Mascota AddMascota(Mascota mascota);
        Mascota UpdateMascota(Mascota mascota);
        void DeleteMascota(int idMascota);
        Mascota GetMascota(int idMascota);
        IEnumerable<Mascota> GetMascotaPorFiltro(string filtro);
        Historia AsignarHistoria(int idHistoria, int idMascota);
        Dueno AsignarDueno(int idDueno, int idMascota);
        Veterinario AsignarVeterinario(int idVeterinario, int idMascota);
        //int GetDuenoId(int idMascota);
    }
}