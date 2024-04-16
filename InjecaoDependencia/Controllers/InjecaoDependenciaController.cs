using InjecaoDependencia.Implementations;
using InjecaoDependencia.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace InjecaoDependencia.Controllers;

[ApiController]
[Route("[Controller]")]
public class InjecaoDependenciaController : ControllerBase
{
    /// <summary>
    /// Todas as injeções feitas no Program.cs
    /// </summary>
    private readonly ITesteInjecao _injecaoSingletonUm;
    private readonly ITesteInjecao _injecaoSingletonDois;
    private readonly ITesteInjecao _injecaoScopedUm;
    private readonly ITesteInjecao _injecaoScopedDois;
    private readonly ITesteInjecao _injecaoTransientUm;
    private readonly ITesteInjecao _injecaoTransientDois;

    public InjecaoDependenciaController([FromKeyedServices("InjecaoSingletonUm")]ITesteInjecao injecaoSingletonUm
        , [FromKeyedServices("InjecaoSingletonDois")] ITesteInjecao injecaoSingletonDois
        , [FromKeyedServices("InjecaoScopedUm")] ITesteInjecao injecaoScopedUm
        , [FromKeyedServices("InjecaoScopedDois")] ITesteInjecao injecaoScopedDois
        , [FromKeyedServices("InjecaoTransientUm")] ITesteInjecao injecaoTransientUm
        , [FromKeyedServices("InjecaoTransientDois")] ITesteInjecao injecaoTransientDois)
    {
        _injecaoSingletonUm = injecaoSingletonUm;
        _injecaoSingletonDois = injecaoSingletonDois;
        _injecaoScopedUm = injecaoScopedUm;
        _injecaoScopedDois = injecaoScopedDois;
        _injecaoTransientUm = injecaoTransientUm;
        _injecaoTransientDois = injecaoTransientDois;
    }

    /// <summary>
    /// Comparamos os valores no GUID dos dois tipos de injeção para vermos qual é o retorno, no caso do singleton vai ser o mesmo durante toda aplicação
    /// </summary>
    /// <param name="injecaoSingletonUm"></param>
    /// <param name="injecaoSingletonDois"></param>
    /// <returns></returns>

    [HttpGet("singleton")]
    public IActionResult ValoresSingleton([FromKeyedServices("InjecaoSingletonUm")] ITesteInjecao injecaoSingletonUm
        , [FromKeyedServices("InjecaoSingletonDois")] ITesteInjecao injecaoSingletonDois) 
    {
        List<ComparacaoInstancia> comparacao = new()
         {
             new ComparacaoInstancia {KeyInjecao="InjecaoSingletonUm",
             InstanciaGeradaParametro = injecaoSingletonUm.IdInstanciaValidacao.ToString(),
             InstanciaGeradaPeloConstrutor = _injecaoSingletonUm.IdInstanciaValidacao.ToString(),
             },
             new ComparacaoInstancia {KeyInjecao="InjecaoSingletonDois",
             InstanciaGeradaParametro = injecaoSingletonDois.IdInstanciaValidacao.ToString(),
             InstanciaGeradaPeloConstrutor = _injecaoSingletonDois.IdInstanciaValidacao.ToString(),
             }
         };

        string result = string.Empty;

        comparacao.ForEach(x => result += x.ToString());

        return Ok(result);
    }
    /// <summary>
    /// Comparamos os valores no GUID dos dois tipos de injeção para vermos qual é o retorno, no caso do transient vai alterar a cada instancia então o do parametro já não é igual ao do construtor
    /// </summary>
    /// <param name="injecaoTransientUm"></param>
    /// <param name="injecaoTransientDois"></param>
    /// <returns></returns>
    [HttpGet("transient")]
    public IActionResult ValoresTransient([FromKeyedServices("InjecaoTransientUm")] ITesteInjecao injecaoTransientUm
        , [FromKeyedServices("InjecaoTransientDois")] ITesteInjecao injecaoTransientDois) 
    {
        List<ComparacaoInstancia> comparacao = new()
         {
             new ComparacaoInstancia {KeyInjecao="InjecaoTransientUm",
             InstanciaGeradaParametro = injecaoTransientUm.IdInstanciaValidacao.ToString(),
             InstanciaGeradaPeloConstrutor = _injecaoTransientUm.IdInstanciaValidacao.ToString(),
             },
             new ComparacaoInstancia {KeyInjecao="InjecaoTransientDois",
             InstanciaGeradaParametro = injecaoTransientDois.IdInstanciaValidacao.ToString(),
             InstanciaGeradaPeloConstrutor = _injecaoTransientDois.IdInstanciaValidacao.ToString(),
             }
         };

        string result = string.Empty;

        comparacao.ForEach(x => result += x.ToString());

        return Ok(result);
    }
    /// <summary>
    /// Comparamos os valores no GUID dos dois tipos de injeção para vermos qual é o retorno, no caso do scoped para cada requisição ele via criar um instancia
    /// </summary>
    /// <param name="injecaoScopedUm"></param>
    /// <param name="injecaoScopedDois"></param>
    /// <returns></returns>
    [HttpGet("scoped")]
    public IActionResult ValoresScoped([FromKeyedServices("InjecaoScopedUm")] ITesteInjecao injecaoScopedUm
        , [FromKeyedServices("InjecaoScopedDois")] ITesteInjecao injecaoScopedDois)
    {
        List<ComparacaoInstancia> comparacao = new()
         {
             new ComparacaoInstancia {KeyInjecao="InjecaoScopedUm",
             InstanciaGeradaParametro = injecaoScopedUm.IdInstanciaValidacao.ToString(),
             InstanciaGeradaPeloConstrutor = _injecaoScopedUm.IdInstanciaValidacao.ToString(),
             },
             new ComparacaoInstancia {KeyInjecao="InjecaoScopedDois",
             InstanciaGeradaParametro = injecaoScopedDois.IdInstanciaValidacao.ToString(),
             InstanciaGeradaPeloConstrutor = _injecaoScopedDois.IdInstanciaValidacao.ToString(),
             }
         };

        string result = string.Empty;

        comparacao.ForEach(x => result += x.ToString());

        return Ok(result);
    }

}
