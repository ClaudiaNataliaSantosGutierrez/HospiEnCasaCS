using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Frontend.Pages.Pacientes
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public IEnumerable<Paciente> Pacientes {get; set;}
        public IndexModel(IRepositorioPaciente repoPaciente)
        {
            _repoPaciente = repoPaciente;
        }
        public void OnGet()
        {
            Pacientes = _repoPaciente.GetAllPacientes();
        }
    }
}
