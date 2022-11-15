using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.Dtos;
using SamuraiApp.Application.Repositories;
using SamuraiApp.Domain;
using SamuraiApp.Domain.Helpers;

namespace SamuraiApp.API.Controllers;

[Route("/api/[controller]")]
[Controller]
public class SamuraiController : ControllerBase
{
    private readonly ISamuraiRepository _samuraiRepository;
    private readonly IQuoteRepository _quoteRepository;

    public SamuraiController(ISamuraiRepository samuraiRepository, IQuoteRepository quoteRepository)
    {
        _samuraiRepository = samuraiRepository;
        _quoteRepository = quoteRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_samuraiRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateSamuraiDTO samuraiDto)
    {
        var samurai = new Samurai(samuraiDto.name);
        _samuraiRepository.Add(samurai);
        _samuraiRepository.Save();
        return Created(nameof(Get), samurai);
    }

    [HttpPost("/{samuraiId}/quotes")]
    public IActionResult ReqisterQuotes(Guid samuraiId, [FromBody] List<CreateQuoteDTO> quoteDtos)
    {
        var samurai = _samuraiRepository.Get(samuraiId);
        if (samurai == null)
        {
            return NotFound();
        }

        List<Quote> quotes = quoteDtos.Select(d => new Quote(d.name)).ToList();
        samurai.RegisterQuetesToSamurai(quotes);
        quotes.ForEach(q => _quoteRepository.Add(q));
        _quoteRepository.Save();
        return NoContent();
    }
}