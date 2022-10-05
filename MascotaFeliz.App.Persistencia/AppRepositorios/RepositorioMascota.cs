using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
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
        
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

//  Metodo que agrega una mascota.
        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

//  Metodo que elimina una mascota.
        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

// Metodo que retorna una lista de todas las mascotas.
        public IEnumerable<Mascota> GetAllMascotas()
        {
            return _appContext.Mascotas.Include("Dueno").Include("Veterinario").Include("Historia");
        }

//  Metodo que retorna una mascota.
        public Mascota GetMascota(int idMascota)
        {
            var mascota = _appContext.Mascotas.Where(d => d.Id == idMascota)
                                              .Include("Dueno").Include("Veterinario").Include("Historia")
                                              .FirstOrDefault();
                                              
            return mascota;
        }

// Metodo que retorna mascotas filtradas por nombre.
        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro)
        {
            var mascota = GetAllMascotas(); // Obtiene todos los saludos
            if (mascota != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascota = mascota.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascota;
        }

//  Metodo que actualiza una mascota.
        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == mascota.Id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = mascota.Nombre;
                mascotaEncontrada.Color = mascota.Color;
                mascotaEncontrada.Especie = mascota.Especie;
                mascotaEncontrada.Raza = mascota.Raza;
                mascotaEncontrada.Dueno = mascota.Dueno;
                mascotaEncontrada.Veterinario = mascota.Veterinario;
                mascotaEncontrada.Historia = mascota.Historia;
                _appContext.SaveChanges();
            }
            return mascotaEncontrada;
        }

//  Metodo que asigna un vetrinario a una mascota.
        public Veterinario AsignarVeterinario(int idVeterinario, int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
                if (veterinarioEncontrado != null)
                {
                    mascotaEncontrada.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }

//  Metodo que asigna un dueno a una mascota.
        public Dueno AsignarDueno(int idDueno, int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada != null)
            {
                var duenoEncontrado = _appContext.Duenos.FirstOrDefault(d => d.Id == idDueno);
                if (duenoEncontrado != null)
                {
                    mascotaEncontrada.Dueno = duenoEncontrado;
                    _appContext.SaveChanges();
                }
                return duenoEncontrado;
            }
            return null;
        }

//  Metodo que asigna una historia a una mascota.
        public Historia AsignarHistoria(int idHistoria, int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
            if (mascotaEncontrada != null)
            {
                var historiaEncontrada = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
                if (historiaEncontrada != null)
                {
                    mascotaEncontrada.Historia = historiaEncontrada;
                    _appContext.SaveChanges();
                }
                return historiaEncontrada;
            }
            return null;
        }

//  Metodo que retorna una mascota como lista.
        public IEnumerable<Mascota> GetHistoriaMascota(int mascotaId)
        {
            var mascotas = GetAllMascotas();
            
            if (mascotas != null)
            {
                var mascota = from m in mascotas
                              where m.Id == mascotaId
                              select m;

                return mascota;  
            }
            else
            {
                return null;
            }          
                                              
        }

//  Metodo que retorna el Id de la historia de una mascota.
        public int GetHistoriaId(int mascotaId)
        {
            var mascota = GetHistoriaMascota(mascotaId);
            int historiaId = 0;

            if (mascota != null)
            {
                foreach (var item in mascota)
                {
                    historiaId = item.Historia.Id;
                }
                return historiaId;
            }
            else
            {
                return 0;
            }
        }

    } 
}