using Shifta.Pacientes.Business.DTOs;
using Shifta.Pacientes.DataAccess.Interfaces;
using Shifta.Pacientes.Domain.Entities;
using System.Globalization;

namespace Shifta.Pacientes.Business.Services
{
    public interface IPacienteService
    {
        public List<Paciente> GetPacientes();
        public PacienteDto AddOrUpdatePaciente(PacienteDto dto);
        public Paciente AbrirDetalleById(string id);
    }

    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Paciente AbrirDetalleById(string id)
        {
            return _pacienteRepository.GetPaciente(id);
        }

        public PacienteDto AddOrUpdatePaciente(PacienteDto dto)
        {
            if (dto.FechaSalida == null) { 
                var paciente = new Paciente
                {
                    Nombre = dto.Nombre,
                    Edad = dto.Edad,
                    Documento = dto.Documento,
                    Estado = dto.Estado,
                    FechaNacimiento = dto.FechaNacimiento,
                    FechaIngreso = DateTime.Now.ToString("HH:mm dd/MM/yyyy"),
                    GrupoSanguineo = dto.GrupoSanguineo,
                    MotivoIngreso = dto.MotivoIngreso,
                    Procedimientos = dto.Procedimientos,
                    Doctor = dto.Doctor,
                    Genero = dto.Genero,
                    Medicacion = dto.Medicacion
                };
                _pacienteRepository.AddOrUpdatePaciente(paciente);
            } else
            {
                //TODO: Update paciente
            }

            return dto;
        }

        public List<Paciente> GetPacientes()
        {
            return _pacienteRepository.GetPacientes();
        }
    }
}
