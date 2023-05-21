using Microsoft.AspNetCore.Mvc;
using Shifta.Pacientes.Business.DTOs;
using Shifta.Pacientes.Business.Services;
using Shifta.Pacientes.DataAccess.Interfaces;
using Shifta.Pacientes.Domain.Entities;

namespace Shifta.Pacientes.Api.Controllers
{
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly IPacienteService _pacienteService;
        public PacienteController(ILogger<PacienteController> logger, IPacienteService pacienteService)
        {
            _logger = logger;
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public IEnumerable<Paciente> GetPacientes()
        {
            return _pacienteService.GetPacientes();
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public PacienteDto AddOrUpdatePaciente([FromBody]PacienteDto dto)
        {
            return _pacienteService.AddOrUpdatePaciente(dto);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public Paciente GetPacienteDetalleById(string id) 
        { 
            return _pacienteService.AbrirDetalleById(id);
        }
    }
}