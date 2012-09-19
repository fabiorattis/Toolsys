using System;
using System.Collections.Generic;
using RDev.ToolsSys.Business.Help;

namespace RDev.ToolsSys.Business.Entidade
{
    public class Pessoa
    {
        public string Nome
        {
            get { return Nome; }
            set { Nome = value; }
        }
        public string CPF
        {
            get { return CPF; }
            set
            {
                var numero = value;
                //Verifica se o CPF é Verdadeiro
                CPF = FuncoesGerais.ValidaCPF(numero) ? numero : string.Empty;
            }
        }
        public virtual DateTime Nascimento
        {
            get
            {
                return Nascimento;
            }
            set
            {
                if (!FuncoesGerais.ValidarData(value.ToString())) throw new RegraNegocioException("Data de Nascimento Invalida.");
                Nascimento = value;
            }
        }
        public TipoSexo sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public List<Documento>

        internal void ValidarDados(Pessoa pessoa)
        {
            var campos = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(pessoa.Nome)) campos.Add("* Nome", "");
            if (string.IsNullOrEmpty(pessoa.CPF.Replace(".", "").Replace("-", ""))) campos.Add("* Cpf", "");
            if (string.IsNullOrEmpty(pessoa.Nascimento.ToString().Replace("/", ""))) campos.Add("* Nascimento", "");

            if (campos.Count > 0) throw new CamposObrigatoriosNaoPreenchidosException("Campos Obrigatórios : ", campos);
        }
    }
}
