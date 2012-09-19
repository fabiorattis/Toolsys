using RDev.ToolsSys.Business.Pessoas.Entidade;
using RDev.ToolsSys.Business.Pessoas.Repositorio;

namespace RDev.ToolsSys.Business.Pessoas.Servico
{
    public interface IpessoaServico
    {
        Pessoa Pesquisar(int idPessoa);
        Pessoa PesquisarDocumento(Documento documento);
        Pessoa PesquisarPessoaPorNome(string Nome);
    }

    class PessoaServico : IpessoaServico
    {
        private readonly IPessoaRepositorio _pessoaRepositorioSQL;

        public PessoaServico(IPessoaRepositorio pessoaRepositorioSql)
        {
            _pessoaRepositorioSQL = pessoaRepositorioSql;
        }

        public Pessoa Pesquisar(int idPessoa)
        {
           return _pessoaRepositorioSQL.Pesquisar(idPessoa);
        }

        public Pessoa PesquisarDocumento(Documento documento)
        {
            return _pessoaRepositorioSQL.PesquisarPessoaPor(documento);
        }

        public Pessoa PesquisarPessoaPorNome(string Nome)
        {
            return _pessoaRepositorioSQL.PesquisarPessoa(Nome);
        }
    }
}
