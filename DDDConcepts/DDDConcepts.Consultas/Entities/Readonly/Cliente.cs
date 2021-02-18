using DDDConcepts.SharedKernel.Entities;
using System.Collections.Generic;

namespace DDDConcepts.Consultas.Core.Entities.ReadOnly
{
    public class Cliente:EntityReadonly
    {
        public string NomeCompleto { get; set; }
        public IEnumerable<Paciente> Pacientes { get; set; }
    }
}
