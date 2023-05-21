using Shifta.Pacientes.Domain.Entities;

namespace Shifta.Pacientes.Business.DTOs
{
    public class PacienteDto
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Documento { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaNacimiento { get; set; }
        public byte Genero { get; set; }
        public string? FechaSalida { get; set; }
        public string GrupoSanguineo { get; set; }
        public string MotivoIngreso { get; set; }
        public string Doctor { get; set; }
        public string? Medicacion { get; set; }
        public string? Procedimientos { get; set; }
        public byte Estado { get; set; }
    }
}
