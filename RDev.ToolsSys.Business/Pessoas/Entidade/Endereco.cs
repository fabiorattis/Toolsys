using RDev.ToolsSys.Business.Pessoas.Entidade.Enuns;

namespace RDev.ToolsSys.Business.Pessoas.Entidade
{
    public class Endereco
    {
        #region Atributos Privados

        private virtual string _cep;
        private virtual TipoEndereco _tipoEndereco;
        private virtual string _logradouro;
        private virtual string _bairro;
        private virtual string _numero;
        private virtual string _estado;
        private virtual string _cidade;

        #endregion

        #region Propriedades

        public virtual string Cep { get { return _cep; } set { Cep = _cep; } }
        public virtual TipoEndereco TipoEndereco { get { return _tipoEndereco; } set { TipoEndereco = _tipoEndereco; } }
        public virtual string Logradouro { get { return _logradouro; } set { Logradouro = _logradouro; } }
        public virtual string Bairro { get { return _bairro; } set { Bairro = _bairro; } }
        public virtual string Numero { get { return _numero; } set { Numero = _numero; } }
        public virtual string Estado { get { return _estado; } set { Estado = _estado; } }
        public virtual string Cidade { get { return _cidade; } set { Cidade = _cidade; } }

        #endregion

        #region Helpers

        internal virtual Endereco PesquisarEnderecoPorCep(string pCep)
        {
            return PesquisarEnderecoPorCep(pCep);
        }

        #endregion
    }
}

