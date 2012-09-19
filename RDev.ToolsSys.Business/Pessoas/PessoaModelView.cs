using System;
using System.Linq;
using RDev.ToolsSys.Business.Pessoas.Entidade;


namespace RDev.ToolsSys.Business.Pessoas
{
    public struct PessoaModelView
    {
        public PessoaModelView(Pessoa pessoa) : this()
        {
            Nome = pessoa.Nome;
            Idade = (pessoa.Nascimento.Year - DateTime.Now.Year).ToString();
            Cpf = (!pessoa.Documentos.IsNullOrEmpty()) ? pessoa.ObterDocumentoCpfCnpj().Numero : string.Empty ;
            Rg = (!pessoa.Documentos.IsNullOrEmpty()) ? pessoa.ObterDocumentoRg().Numero : string.Empty ;
            Email = (!pessoa.Contatos.IsNullOrEmpty()) ? pessoa.ObterEmail().Email : string.Empty;
        }

        public string Nome;
        public string Idade;
        public string Cpf;
        public string Rg;
        public string Email;
    }
}