using DDDConcepts.SharedKernel.ValueObjetcs;
using System;

namespace DDDConcepts.Consultas.Core.ValueObjects
{
    /// <summary>
    /// Value object para Datas
    /// </summary>
    public class DataConsulta : ValueObject<DataConsulta>
    {
        #region Propriedades

        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

        #endregion

        #region Construtores

        public DataConsulta(DateTime dataInicio, DateTime dataFim)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DataConsulta(DateTime dataInicio, TimeSpan duracao)
        {
            DataInicio = dataInicio;
            DataFim = DataInicio.Add(duracao);
        }

        #endregion

        #region Comportamentos
        public int VerificarDuracaoEmMinutos() => (DataFim - DataInicio).Minutes;
        public DataConsulta AlterarDataInicio(DateTime novaDataInicio) => new DataConsulta(novaDataInicio, DataFim);
        public DataConsulta AlterarDataFim(DateTime novaDataFim) => new DataConsulta(DataInicio, novaDataFim);
        public DataConsulta AlterarDuracao(TimeSpan duracao) => new DataConsulta(DataInicio, duracao);
        public DataConsulta AlterarDatasDeConsulta(DateTime dataInicio, DateTime dataFim) => new DataConsulta(dataInicio, dataFim);

        #endregion
    }
}
