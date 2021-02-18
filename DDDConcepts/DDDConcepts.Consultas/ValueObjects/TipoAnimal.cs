using DDDConcepts.SharedKernel.ValueObjetcs;

namespace DDDConcepts.Consultas.Core.ValueObjects
{
    public class TipoAnimal:ValueObject<TipoAnimal>
    {
        public string Especie { get; private set; }
        public string Raca { get; private set; }

        public TipoAnimal(string especie, string raca)
        {
            Especie = especie;
            Raca = raca;
        }

        public TipoAnimal AlterarEspecie(string especie) => new TipoAnimal(especie, Raca);
        public TipoAnimal AlterarRaca(string raca) => new TipoAnimal(Especie, raca);

    }
}
