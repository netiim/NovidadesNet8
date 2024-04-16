using InjecaoDependencia.Interface;

namespace InjecaoDependencia.Implementations
{
    public class TesteInjecao : ITesteInjecao
    {
        /// <summary>
        /// Definindo um Guid para validar o comportamento
        /// </summary>
        public Guid IdInstanciaValidacao { get;} = Guid.NewGuid();
    }
}
