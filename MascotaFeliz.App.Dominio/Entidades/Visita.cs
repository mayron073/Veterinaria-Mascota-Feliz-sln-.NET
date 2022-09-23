using System;
namespace MascotaFeliz.App.Dominio
{
    public class Visita
    {
        public int Id {get;set;}
        public DateTime VisitDate {get;set;}
        public float Temperature {get;set;}
        public float Weight {get;set;}
        public float BreathingFrequency {get;set;}
        public float HeartRate {get;set;}
        public string MindState {get;set;}
        public int IdVeterinario {get;set;}
        public string Recommendations {get;set;}
    }
}