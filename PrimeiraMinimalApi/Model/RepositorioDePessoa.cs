namespace PrimeiraMinimalApi.Model;

public class RepositorioDePessoa
{
    public RepositorioDePessoa(bool dados)
    {
        if (dados)
        {
            CriarDadosEmMemoria();
        }
        else
        {
            ListaPessoas = new List<Pessoa>();
        }
    }

    private void CriarDadosEmMemoria()
    {

        this.ListaPessoas = new List<Pessoa>()
            {
                new Pessoa()
                {
                    Nome = "André Silva",
                    Cpf = "123456789-12",
                    Email ="andresilva@email.com"
                },
                new Pessoa()
                {
                    Nome = "Pedro Malazartes",
                    Cpf = "182993692-12",
                    Email ="pedromala@email.com"
                },
                new Pessoa()
                {
                    Nome = "Maria Joaquina",
                    Cpf = "987351984-12",
                    Email ="mariajoaquina@email.com"
                }
            };
    }

    public List<Pessoa> ListaPessoas { get; set; }

    public Pessoa AdicionarPessoas(Pessoa p)
    {
        ListaPessoas.Add(p);
        return p;
    }

    public bool RemoverPessoas(string cpf)
    {
        var pessoaTemp = (from pessoa in this.ListaPessoas
                          where pessoa.Cpf == cpf
                          select pessoa).SingleOrDefault();
        if (pessoaTemp == null)
        {
            return false;
        }
        var removido = ListaPessoas.Remove(pessoaTemp);
        return removido;
    }

    public List<Pessoa> SelecionarPessoas()
    {
        return this.ListaPessoas;
    }

    public Pessoa SelecionarPessoa(string cpf)
    {
        var pessoaTemp = (from pessoa in ListaPessoas
                          where pessoa.Cpf == cpf
                          select pessoa).SingleOrDefault();
        if (pessoaTemp == null)
        {
            return new Pessoa();
        }
        return pessoaTemp;
    }

    public bool AtualizarPessoas(Pessoa p)
    {
        var pessoaTemp = (from pessoa in this.ListaPessoas
                          where pessoa.Cpf == p.Cpf
                          select pessoa).SingleOrDefault();
        if (pessoaTemp == null)
        {
            return false;
        }

        pessoaTemp.Identificador = p.Identificador;
        pessoaTemp.Nome = p.Nome;

        return true;
    }

}
