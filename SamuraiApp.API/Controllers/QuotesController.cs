using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Application.Repositories;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuotesController : ControllerBase
{
    private readonly IQuoteRepository _quoteRepository;
    
    public QuotesController(IQuoteRepository quoteRepository)
    {
        this._quoteRepository = quoteRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_quoteRepository.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] Quote quote)
    {
        _quoteRepository.Add(quote);
        return Ok();
    }
}