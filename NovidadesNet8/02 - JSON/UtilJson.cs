using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovidadesNet8._02___JSON;

public static class UtilJson
{
    public static T DeserializaJson<T>(string corpo)
    {
        return JsonSerializer.Deserialize<T>(corpo);
    }
    public enum Policy
    {
        CamelCase,
        Pascal,
        SnakeLower,
        SnakeUpper,
        KebabLower,
        KebabUpper,
    }
    public static string SerializarJson(List<Pessoa> pessoas, Policy police = Policy.Pascal)
    {
        string resultado = string.Empty;

        switch (police)
        {
            case Policy.Pascal:
                resultado = JsonSerializer.Serialize(pessoas);
                break;
            case Policy.CamelCase:
                resultado = JsonSerializer.Serialize(pessoas,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                break;
            case Policy.SnakeLower:
                resultado = JsonSerializer.Serialize(pessoas,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });
                break;
            case Policy.SnakeUpper:
                resultado = JsonSerializer.Serialize(pessoas,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper });
                break;
            case Policy.KebabLower:
                resultado = JsonSerializer.Serialize(pessoas,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower });
                break;
            case Policy.KebabUpper:
                resultado = JsonSerializer.Serialize(pessoas,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper });
                break;
            default:
                break;
        }
        return resultado;
    }
}
/// <summary>
/// Classe criada normalmente quando tenta Deserializar para ela ignora as propriedades não existentes
/// </summary>
public class Pessoa
{
    public string NomeCompleto { get; set; }
    public int IdadeAnos { get; set; }
}
/// <summary>
/// Classe criada normalmente quando tenta Deserializar para ela lança uma exceção se tiver propriedades não existentes
/// </summary>
[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
public class PessoaUnMaped
{
    public string NomeCompleto { get; set; }
    public int IdadeAnos { get; set; }
}