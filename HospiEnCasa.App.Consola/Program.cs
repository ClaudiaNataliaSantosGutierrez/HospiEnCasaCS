using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework!");
            //AddPaciente();
            //BuscarPaciente(3);
            MostrarPacientes();
        }

        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Raquel",
                Apellidos = "Santos",
                NumeroTelefono = "7845203",
                Genero = Genero.Femenino,
                Direccion = "cra 25",
                Longitud = 5.07062F,
                Latitud = -75.52298F,
                Ciudad = "Bogota",
                FechaNacimiento = new DateTime(1999, 07, 07)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        //private static void BuscarPaciente(int idPaciente)
        private static void MostrarPacientes()
        {
            //var paciente = _repoPaciente.GetPaciente(idPaciente);
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre+" "+paciente.Apellidos);
        }
    }
}
