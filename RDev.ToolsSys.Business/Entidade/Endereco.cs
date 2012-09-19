using System.ComponentModel;

namespace RDev.ToolsSys.Business.Entidade
{
    public class Endereco
    {
        public string Cep { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public string Lougradouro { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
    public enum TipoEndereco
    {
        [Description("Residencial")]
        RESIDENCIAL = 1,

        [Description("Comercial")]
         Comercial = 2
    }
}

