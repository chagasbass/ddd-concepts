using DDDConcepts.Consultas.Core.ValueObjects;
using DDDConcepts.SharedKernel.Entities;

namespace DDDConcepts.Consultas.Core.Entities.ReadOnly
{
    public class Paciente: EntityReadonly
    {
        public TipoAnimal TipoAnimal { get; set; }
        public int ClienteId { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; }
        public string PreferenciaDeMedico { get; set; }
    }
}
