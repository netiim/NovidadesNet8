using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovidadesNet8._03___PrimaryConstrutor
{
    /// <summary>
    /// Criando a classe já com o construtor e dentro dela podemos criar outros construtores que chamem esse
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="idade"></param>
    /// <param name="telefone"></param>
    /// <param name="situacao"></param>
    public class Aluno(string nome, string idade, string telefone, string situacao = "Em adequação")
    {
        /// <summary>
        /// Construtor que recebe apenas nome, chama o construtor padrão da classe e preenche as outras informações com vazio
        /// </summary>
        /// <param name="nome"></param>
        public Aluno(string nome):
            this(nome, string.Empty, string.Empty) { }

        public string Nome => nome;
        public string Idade => idade;
        public string Telefone => telefone;
        public string Situacao => situacao;
    }
}
