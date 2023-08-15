namespace Empresa.Models;

public class Departamento
{
    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public string Sigla { get; private set; }

    public Departamento(string nome, string sigla)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Sigla = sigla;
    }
}
