using ExemploWebApiPoo.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ExemploWebApiPoo.Controllers
{
    public class PessoaController : ControllerBase
    {
        [HttpPost("InserirPessoa")]
        public string InserirPessoa(string cpfPessoa, string nomePessoa,
                                    DateTime dataNascimento, string telefone,
                                    string nomeMaePessoa, string emailPessoa) 
        {
            return "Registro inserido com sucesso";
        }
        
        [HttpPut("AlterarPessoa")]
        public string AlterarPessoa(string cpfPessoa, string nomePessoa,
                                    DateTime dataNascimento, string telefone,
                                    string nomeMaePessoa, string emailPessoa) 
        {
            return "Registro alterado com sucesso";
        }
        
        [HttpDelete("ExcluirPessoa")]
        public string ExcluirPessoa(string cpfPessoa, string nomePessoa,
                                    DateTime dataNascimento, string telefone,
                                    string nomeMaePessoa, string emailPessoa) 
        {
            return "Registro Excluido com sucesso";
        }
        
        [HttpGet("PesquisarTodos")]
        public string PesquisarTodos(string cpfPessoa, string nomePessoa,
                                    DateTime dataNascimento, string telefone,
                                    string nomeMaePessoa, string emailPessoa) 
        {
            Pessoa pessoa = new Pessoa();

            pessoa.cpf = cpfPessoa;
            pessoa.nome = nomePessoa;
            pessoa.dataNascimento = dataNascimento;
            pessoa.telefone = telefone;
            pessoa.nomeMae = nomeMaePessoa;
            pessoa.email = emailPessoa;

            return pessoa.PesquisarTodos();
        }
    }
}
