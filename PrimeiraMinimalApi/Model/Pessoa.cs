namespace PrimeiraMinimalApi.Model;

public class Pessoa
{
    public Pessoa()
    {
        Identificador = Guid.NewGuid();
    }
    public Guid Identificador { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
