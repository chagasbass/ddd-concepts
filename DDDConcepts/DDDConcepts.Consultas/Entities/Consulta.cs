using DDDConcepts.Consultas.Core.ValueObjects;
using DDDConcepts.SharedKernel.Entities;
using System;

namespace DDDConcepts.Consultas.Core.Entities
{
    public class Consulta:Entity<Guid> 
    {
        public string Titulo { get; private set; }
        public Guid ConsultaId { get; private set; }
        public int ClienteId { get; private set; }
        public int MedicoId { get; private set; }
        public int PacienteId { get; private set; }
        public int SalaConsultaId { get; private set; }
       public DataConsulta DataConsulta { get; private set; }

        #region Construtores
        public Consulta(Guid id) : base(id) { }

        private Consulta() : base(Guid.NewGuid()) { }

        public Consulta(string titulo, Guid consultaId, int clienteId,
            int medicoId, int pacienteId, int salaConsultaId,
            DateTime dataInicio, DateTime dataFim)
        {
            Titulo = titulo;
            ConsultaId = consultaId;
            ClienteId = clienteId;
            MedicoId = medicoId;
            PacienteId = pacienteId;
            SalaConsultaId = salaConsultaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        #endregion

        #region Fabricas

        /// <summary>
        /// As fabricas permitem que os objetos sejam criados sem inconssitencias
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="consultaId"></param>
        /// <param name="clienteId"></param>
        /// <param name="medicoId"></param>
        /// <param name="pacienteId"></param>
        /// <param name="salaConsultaId"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        public static Consulta CriarConsulta(string titulo, Guid consultaId, int clienteId,
            int medicoId, int pacienteId, int salaConsultaId,
            DateTime dataInicio, DateTime dataFim)
        {
            //Efetua as validações nos campos e cria um obj e retorna

            return new Consulta();
        }


        #endregion

        #region comportamentos
        /// <summary>
        /// Alterar o id do cliente e gera evento de alteração de id de cliente
        /// </summary>
        /// <param name="clienteId"></param>
        public void AlterarCliente(int clienteId) => ClienteId = clienteId;
        /// <summary>
        /// Alterar o id do medico e gera evento de alteração de id de medico
        /// </summary>
        /// <param name="medicoId"></param>  
        public void AlterarMedico(int medicoId) => MedicoId = medicoId;
        public void AlterarPaciente(int pacienteId) => PacienteId = pacienteId;
        public void AlterarSalaDeConsulta(int salaConsultaId) => SalaConsultaId = salaConsultaId;

         
        public void MarcarConsulta()
        {
            //Verifica se o compromisso encaixa na consulta
            //Grava o comprommiso
            //gera evento de marcação de consulta
        }

        #endregion
    }
}