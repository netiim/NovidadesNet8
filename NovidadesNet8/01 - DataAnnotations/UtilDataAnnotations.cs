using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovidadesNet8;

public class UtilDataAnnotations
{
    /// <summary>
    /// Allowed = validação dos valores permitidos
    /// Denied = validação dos valores não permitidos
    /// Ambos aceitam uma mensagem de erro
    /// </summary>
    [AllowedValues("Ativo", "Inativo", "Pendente", ErrorMessage = "Status não aceito")]
    [DeniedValues("Cancelado",null, "", ErrorMessage = "Status não aceito")]
    public string Status { get; set; }
    /// <summary>
    /// Required = parametro obrigatoria a ser passado
    /// StringLength = Tamanho máximo da variável
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Nome { get; set; }
    /// <summary>
    /// Validação de base64, para arquivos importados
    /// </summary>
    [Base64String(ErrorMessage ="String base64 inválida")]
    public string Arquivo { get; set; }
    /// <summary>
    /// Range aonde as extremidades não serão aceitas
    /// </summary>
    [Range(minimum: 1, maximum: 100)]
    public int Peso { get; set; }
    /// <summary>
    /// Range aonde as extremidades serão aceitas
    /// </summary>
    [Range(minimum: 1, maximum: 100, MinimumIsExclusive = true, MaximumIsExclusive = true)]
    public int NumeroTitulos { get; set; }
    /// <summary>
    /// Range para o tipo Data só serão aceitas datas nesse intervalo
    /// </summary>
    [Range(typeof(DateTime), "01/01/2022", "31/12/2022")]
    public DateTime Idade { get; set; }
    /// <summary>
    /// Estipula o tamanho maximo da string, mas coloca qual o tamanho minimo também
    /// </summary>
    [StringLength(200, MinimumLength = 10)]
    public string Endereco { get; set; }
    /// <summary>
    /// Utiliza uma Expressão regular para validação do campo
    /// </summary>
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }

    public string Senha { get; set; }
    /// <summary>
    /// Utiliza para comparar o valor dessa popriedade com alguma outra
    /// </summary>
    [Compare("Senha")]
    public string ConfirmacaoSenha { get; set; }
    /// <summary>
    /// Utilizado para validação de e-mail
    /// </summary>
    [EmailAddress]
    public string EmailValidado { get; set; }
    /// <summary>
    /// É usado para fornecer metadados sobre o tipo de dados esperado em uma propriedade. 
    /// </summary>
    [DataType(DataType.Date)]
    public DateTime DataPedido { get; set; }
    /// <summary>
    /// É usado para fornecer metadados sobre o tipo de dados esperado em uma propriedade. 
    /// </summary>
    [DataType(DataType.Currency)]
    public decimal ValorTotal { get; set; }

}
