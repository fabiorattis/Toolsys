using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RDev.ToolsSys.Business.Entidade
{
    public class Contato
    {
        public string Numero { get; set; }
        public TipoContato TipoContato { get; set; }
        public string Email { get; set; }
    }

    public enum TipoContato
    {
        [Description("Residencial")]
        RESIDENCIAL = 1,

        [Description("Comercial")]
        COMERCIAL = 2,

        [Description("Celular")]
        CELULAR = 3,

        [Description("Fax")]
        FAX = 4
    }
}
