using System;
namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Color {get;set;}
        public string Breed {get;set;}
        public string Raze {get;set;}
        public Dueno Dueno {get;set;}
        public Veterinario Veterinario {get;set;}
        public Historia Historia {get;set;}
        
    }
}