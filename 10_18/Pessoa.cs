using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace ExemploWebApiPoo.Dominio
{
    public class Pessoa
    {
        public string cpf;
        public string nome;
        public DateTime dataNascimento;
        public string nomeMae;
        public string telefone;
        public string email;
        //Métodos CRUD
        public void Inserir()
        { 
            //Incluir Pessoa;
        }public void Alterar(Int32 id)
        {
            //Alterar Pessoa;
        }public void Excluir(Int32 id)
        {
            //Excluir Pessoa;
        }
        public string PesquisarTodos() 
        {
            string retorno = $"CPF: {cpf}\r\n " +
                $"Nome: {nome}" +
                $"Nome da Mãe: {nomeMae}" +
                $"Telefone: {telefone}";
            return retorno;
        }
        public string PesquisarPorCpf(String cpf)
        {
            string retorno = $"CPF: {cpf}\r\n " +
                $"Nome: {nome}" +
                $"Nome da Mãe: {nomeMae}" +
                $"Telefone: {telefone}";
            return retorno;

        }
    }
}
