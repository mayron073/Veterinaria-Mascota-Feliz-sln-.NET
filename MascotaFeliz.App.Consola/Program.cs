using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    { 
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositoriVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        private static IRepositorioVisitas _repoVisita = new RepositorioVisitas(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");                

            //AddVeterinario();
            //ActualizarVeterinario();
            //EliminarVeterinario();
            //BuscarVeterinario();
            //ListarVeterinarios();
            
            //AddDueno();
            //BuscarDueno(3);
            //EliminarDueno(6);
            //ListarDuenos();
            //ActualizarDueno();

            //AddMascota();
            //BuscarMascota(1);
            //ListarMascotas();
            //EliminarMascota(2);
            //ActualizarMascota();
            AsignarDuenos();
            AsignarHistorias();
            AsignarVeterinarios();
            //GetDuenoId();

            //AddHistoriaO();
            //ActualizarHistoria();
            //EliminarHistoria(1);

            //AddVisita();
            //ActualizarVisita(1);
            //EliminarVisita(1);
        }

//**************************************** D U E N O S ********************************************//
        // Metodo que agrega un nuevo dueno.
        private static void AddDueno()
        {
            var dueno = new Dueno
                {
                    Nombre = "juan",
                    Apellido = "Magno",
                    Direccion = "al lado",
                    Telefono = "1001999999",
                    Correo = "emperador22@gmail.com"
                };
            _repoDueno.AddDueno(dueno);
        }

        // Metodo que muestra un dueno.
        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine("Nombre: "+ dueno.Nombre + "\nApellidos: " + dueno.Apellido + "\nDireccion: "+ dueno.Direccion + "\nTelefono: " + dueno.Telefono +"\nCorreo: "+ dueno.Correo);
        }

        // Metodo que elimina un dueno.
        private static void EliminarDueno(int idDueno)
        {
            _repoDueno.DeleteDueno(idDueno);
            Console.WriteLine("Se elimino el dueno con exito");
        }

        // Metodo que muestra todos los duenos.
        private static void ListarDuenos()
        {
            var dueno = _repoDueno.GetAllDuenos();
            foreach (Dueno d in dueno)
            {
                Console.WriteLine("Nombre: "+ d.Nombre + "\nApellidos: " + d.Apellido + "\nDireccion: "+ d.Direccion + "\nTelefono: " + d.Telefono +"\nCorreo: "+ d.Correo);
            }
        }

        // Metodo que actualiza un dueño.
        private static void ActualizarDueno()
        {
            var uDueno = new Dueno
                {
                    Nombre = "Ragnar",
                    Apellido = "Lotbrock",
                    Direccion = "Por ahí",
                    Telefono = "0000000000",
                    Correo = "viking@gmail.com"
                };
            _repoDueno.UpdateDueno(uDueno);
        }
        
//************************************ M A S C O T A S ******************************************//
        // Metodo que agrega una nueva mascota.
        private static void AddMascota()
        {
            // objeto mascota
            var mascota = new Mascota
            {
                Nombre = "Fenrir",
                Color = "Blanco",
                Especie = "Canina",
                Raza = "Husky siberiano",
            };
            _repoMascota.AddMascota(mascota);
        }
        
        // Mmetodo que muestra una masacota.
        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine("Nombre: "+ mascota.Nombre + "\nColor: " + mascota.Color + "\nRaza: "+ mascota.Raza +"\n");
        }

        // Metodo que muestra todas las mascotas.
        private static void ListarMascotas()
        {
            var mascota = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascota)
            {
                Console.WriteLine("\nNombre: "+ m.Nombre + "\nColor: " + m.Color + "\nRaza: "+ m.Raza + m.Dueno.Nombre);
            }
        }

        // Metodo que elimina una mascota.
        private static void EliminarMascota(int idMascota)
        {
            _repoMascota.DeleteMascota(idMascota);
            Console.WriteLine("Se elimino el dueno con exito");
        }      

        // Metodo que actualiza una mascota.
        private static void ActualizarMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Cronos",
                Color = "Negro",
                Especie = "Canina",
                Raza = "Doberman",
            };
            _repoMascota.UpdateMascota(mascota);
        }

        private static void AsignarVeterinarios()
        {
            var veterinario = _repoMascota.AsignarVeterinario(2, 6);
            Console.WriteLine(veterinario.Nombre+""+veterinario.Apellido);
        }

        private static void AsignarDuenos()
        {
            var dueno = _repoMascota.AsignarDueno(6, 6);
            Console.WriteLine(dueno.Nombre+""+dueno.Apellido);
        }

        private static void AsignarHistorias()
        {
            var historia = _repoMascota.AsignarHistoria(3,6);
        }
/*
        private static void GetDuenoId()
        {
            var dueno = _repoMascota.GetDuenoId(4);
            Console.WriteLine(dueno);
        }*/

//**************************************** V E T E R I N A R I O ****************************************//
        // Metodo que agrega un nuevo veterinario.
        private static void AddVeterinario()
        {
            //objeto veterinario
            var veterinario = new Veterinario
            {
                Nombre = "Andres",
                Apellido = "Magno",
                Direccion = "alli",
                Telefono = "3333666600",
                TarjetaProfesional = "Yes"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        // Metodo que elimina un veterinario.
        private static void EliminarVeterinario(int idVeterinario)
        {
            _repoVeterinario.DeleteVeterinario(idVeterinario);
        }

        // Metodo que actualiza un veterinario.
        private static void ActualizarVeterinario()
        {
            var veterinario = new Veterinario 
            {
                Nombre = "Bjorn",
                Apellido = "Ironside",
                Direccion = "Acá vé",
                Telefono = "1007007007",
                TarjetaProfesional = "Obvio"
            };
            _repoVeterinario.UpdateVeterinario(veterinario);
        }

        // Metodo que muestra un veterinario.
        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine("Nombre: "+ veterinario.Nombre + "\nApellidos: " + veterinario.Apellido + "\nDireccion: "+ veterinario.Direccion + "\nTelefono: " + veterinario.Telefono +"\nTarjeta P: "+ veterinario.TarjetaProfesional);
        }

        // Metodo que muestra todos los veterinarios.
        private static void ListarVeterinarios()
        {
            var veterinario = _repoVeterinario.GetAllVeterinario();
            foreach (Veterinario v in veterinario)
            {
                Console.WriteLine("Nombre: "+ v.Nombre + "\nApellidos: " + v.Apellido + "\nDireccion: "+ v.Direccion + "\nTelefono: " + v.Telefono +"\nTarjeta P: "+ v.TarjetaProfesional);
            }
        }

//***************************************** H I S T O R I A S *****************************************************//
        private static void AddHistoriaO()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(2022, 10, 15)
            };
            _repoHistoria.AddHistoria(historia);
        }

        // Actualizar Historia.
        private static void ActualizarHistoria()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(2022, 5, 5)
            };
            _repoHistoria.UpdateHistoria(historia);
        }

        // Eliminar una Historia.
        private static void EliminarHistoria(int idHistoria)
        {
            _repoHistoria.DeleteHistoria(idHistoria);
        }

//******************************** V I S I T A S ************************************//
        private static void AddVisita()
        {
            var visita = new Visita
            {
                FechaDeVisita = new DateTime(2022, 10, 15),
                Temperatura = 25.0F,
                Peso = 20.0F,
                FrecuenciaRespiratoria = 10.5F,
                FrecuenciaCardiaca = 10.5F,
                EstadoMental = "Feliz",
                Recomendaciones = "Mas ejercicio"
                 //IdVeterinario = 2,
            };
            _repoVisita.AddVisita(visita);
        }

        private static void EliminarVisita(int idVisita)
        {
            _repoVisita.DeleteVisita(idVisita);
        }

        private static void ActualizarVisita(int idVisita)
        {
            var visita = new Visita
            {
                FechaDeVisita = new DateTime(2022, 10, 15),
                Temperatura = 20.0F,
                Peso = 20.75F,
                FrecuenciaRespiratoria = 10.0F,
                FrecuenciaCardiaca = 10.0F,
                EstadoMental = "Feliz",
                Recomendaciones = "Ninguna"
                //IdVeterinario = 2,
            };

            _repoVisita.UpdateVisita(visita, idVisita);
        }


    }
}
