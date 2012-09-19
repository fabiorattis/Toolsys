using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RDev.ToolsSys.Business.Entidade
{
    public class Documento 
    {
        public string Numero { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }

    public enum TipoDocumento
    {
        [Description ("RG")]
        RG = 1,

        [Description("CPF")]
        CPF = 2,

        [Description("IE")]
        IE = 3,

        [Description("CNPJ")]
        CNPJ = 4


    }
}  
