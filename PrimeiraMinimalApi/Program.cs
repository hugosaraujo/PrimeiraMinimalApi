using PrimeiraMinimalApi.Model;

var builder = WebApplication.CreateBuilder(args);

//Habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Instanciando o repositório em memória 
var repositorio = new RepositorioDePessoa(true);

app.UseSwagger(); //Ativação do swagger

app.MapGet("/", () => "Hello World!");

//Listar todas as pessoas
app.MapGet("/ListaPessoas", () =>
{
    return repositorio.SelecionarPessoas();
});

//Buscar pelo CPF 
app.MapGet("/ListaPessoas/{cpf}", (string cpf) =>
{
    return repositorio.SelecionarPessoa(cpf);
});

//Adicionar pessoa.
app.MapPost("/ListaPessoas/adicionar", (Pessoa pessoa) => {
    return repositorio.AdicionarPessoas(pessoa);
});

//Atualizar pessoa.
app.MapPut("/ListaPessoas/atualizar", (Pessoa pessoa) => {
    return repositorio.AtualizarPessoas(pessoa);
});

//Remover pessoa.
app.MapDelete("/ListaPessoas/remover", (string cpf) => {
    return repositorio.RemoverPessoas(cpf);
});

app.UseSwaggerUI();// Ativando a interface Swagger

app.Run();
