using Empresa.Infra;
using Empresa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Controllers;

public class FuncionarioController : Controller
{
    private readonly ApplicationDbContext _contexto;

    public FuncionarioController(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> PegarTodosAsync()
    {
        return await _contexto.Funcionario.ToListAsync();
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<Funcionario>> PegarFuncionarioPeloIdAsync(int Id)
    {
        Funcionario funcionario = await _contexto.Funcionario.FindAsync(Id);

        if (funcionario == null)
            return NotFound();

        return funcionario;
    }
    [HttpPost]
    public async Task<ActionResult<Funcionario>> SalvarFuncionarioAsync(Funcionario funcionario)
    {
        await _contexto.Funcionario.AddAsync(funcionario);
        await _contexto.SaveChangesAsync();

        return Ok();
    }
    [HttpPut]
    public async Task<ActionResult> AtualizarFuncionarioAsync(Funcionario funcionario)
    {
        _contexto.Funcionario.Update(funcionario);
        await _contexto.SaveChangesAsync();

        return Ok();
    }
    [HttpDelete("{Id}")]
    public async Task<ActionResult> ExcluirFuncionarioAsync(int Id)
    {
        Funcionario funcionario = await _contexto.Funcionario.FindAsync(Id);
        if (funcionario == null)
            return NotFound();

        _contexto.Remove(funcionario);
        await _contexto.SaveChangesAsync();
        return Ok();
    }
}

