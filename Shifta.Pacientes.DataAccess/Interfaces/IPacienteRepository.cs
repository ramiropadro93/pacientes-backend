using Shifta.Pacientes.Domain.Entities;

namespace Shifta.Pacientes.DataAccess.Interfaces
{
    public interface IPacienteRepository
    {
        List<Paciente> GetPacientes();
        void AddOrUpdatePaciente(Paciente paciente);
        Paciente GetPaciente(string id);
    }
}
