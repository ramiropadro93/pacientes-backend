using MongoDB.Driver;
using Shifta.Pacientes.DataAccess.Interfaces;
using Shifta.Pacientes.Domain.Entities;

namespace Shifta.Pacientes.DataAccess.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly string connString = "mongodb+srv://ramipadro93:HXkUNnl9TN4iJKpu@cluster0.mfiwk0i.mongodb.net/";
        private readonly string databaseName = "pacientes-app";
        private readonly IMongoCollection<Paciente> _pacienteCollection;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public PacienteRepository()
        {
            var dbContext = new MongoDBContext(connString, databaseName);
            _pacienteCollection = dbContext.GetCollection<Paciente>("Paciente");
        }

        public List<Paciente> GetPacientes()
        {
            var pacientes = _pacienteCollection.Find(p => true).ToList();
            return pacientes;
        }

        public void AddOrUpdatePaciente(Paciente paciente)
        {
            _pacienteCollection.InsertOne(paciente);
        }

        public Paciente GetPaciente(string id)
        {
            return _pacienteCollection.Find(x => x.Id == id).FirstOrDefault();
        }
    }
}
