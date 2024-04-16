using NovidadesNet8._02___JSON;
using NovidadesNet8._03___PrimaryConstrutor;

//DeserializaJson();
//SerializarJson();

Aluno aluno = new("paulo");
Console.WriteLine(aluno.Nome);
Console.WriteLine(aluno.Telefone);
Console.WriteLine(aluno.Idade);
Console.WriteLine(aluno.Situacao);

static void DeserializaJson()
{
    string json = "{\"NomeCompleto\": \"Paulo\", \"IdadeAnos\": 18, \"Peso\": 18}";

    /// <summary>
    /// Classe sem a annotação de UnMaped então ele ignora as propriedades do json que ele não possui
    /// </summary>
    Pessoa pessoa = UtilJson.DeserializaJson<Pessoa>(json);

    Console.WriteLine(pessoa.NomeCompleto);
    Console.WriteLine(pessoa.IdadeAnos);
    /// <summary>
    /// Classe com a annotação de UnMaped então ele informa erro se as propriedades do json não existirem na classe
    /// </summary>
    PessoaUnMaped pessoa2 = UtilJson.DeserializaJson<PessoaUnMaped>(json);

    Console.WriteLine(pessoa.NomeCompleto);
    Console.WriteLine(pessoa.IdadeAnos);
}
static void SerializarJson()
{
    /// <summary>
    /// Dependendo da Policy que eu passar ele serializa minhas propriedades de uma forma por exemplo:
    /// SnakeLower= [{"nome_completo":"Paulo Neto","idade_anos":20},{ "nome_completo":"","idade_anos":20}]
    /// </summary>
    List<Pessoa> pessoas = new()
{
    new Pessoa{NomeCompleto = "Paulo Neto", IdadeAnos = 20},
    new Pessoa{NomeCompleto = "" , IdadeAnos = 20}
};

    string result = UtilJson.SerializarJson(pessoas, UtilJson.Policy.SnakeLower);
    Console.WriteLine(result);
}