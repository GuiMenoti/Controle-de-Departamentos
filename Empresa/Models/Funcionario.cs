namespace Empresa.Models;

public class Funcionario
{
    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public string Rg { get; private set; }

    public string Foto { get; private set; }

    public string Departamento { get; private set; }

    public Funcionario(string nome, string rg, string foto, string departamento)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Rg = rg;
        Foto = foto;
        Departamento = departamento;
    }


}
