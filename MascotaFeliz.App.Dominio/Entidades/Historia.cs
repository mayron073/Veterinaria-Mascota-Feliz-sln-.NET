using System;
using System.Collections.Generic;

namespace MascotaFeliz.App.Dominio
{
    public class Historia
    {
        public int Id {get;set;}
        public DateTime InitialDate {get;set;}
        public List<Visita> Visitas {get;set;}

    }
}