using Empresa.Infra;
using Empresa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Controllers;

public class DepartamentoController : Controller
{
    private readonly ApplicationDbContext _contexto;

    public DepartamentoController(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Departamento>>> PegarTodosAsync()
    {
        return await _contexto.Departamento.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Departamento>> PegarDepartamentoPeloIdAsync(int departamentoId)
    {
        Departamento departamento = await _contexto.Departamento.FindAsync(departamentoId);
        if (departamento == null)
            return NotFound();

        return departamento;

    }


    [HttpPost]
    public async Task<ActionResult<Departamento>> SalvarDepartamentoAsync(Departamento departamento)
    {
        await _contexto.Departamento.AddAsync(departamento);
        await _contexto.SaveChangesAsync();
        return Ok();


    }

    [HttpPut]
    public async Task<ActionResult> AtualizarDepartamentoAsync(Departamento departamento)
    {
        _contexto.Departamento.Update(departamento);
        await _contexto.SaveChangesAsync();
        return Ok();


    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> ExcluirDeparatamentoAsync(int departamentoId)
    {
        Departamento departamento = await _contexto.Departamento.FindAsync(departamentoId);
        if (departamento == null)
            return NotFound();


        _contexto.Remove(departamento);
        await _contexto.SaveChangesAsync();
        return Ok();

    }
}

