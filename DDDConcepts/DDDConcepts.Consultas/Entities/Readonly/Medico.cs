using DDDConcepts.SharedKernel.Entities;

namespace DDDConcepts.Consultas.Core.Entities.ReadOnly.ReadOnly
{
    public class Medico: Entity<int>
    {
        public virtual string Nome { get; set; }

        public Medico(int id) : base(id) { }

        private Medico() { }
    }
}
