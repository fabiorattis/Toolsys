﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RDev.ToolsSys.Business.Help;
using RDev.ToolsSys.Business.Pessoas.Entidade.Enuns;

namespace RDev.ToolsSys.Business.Pessoas.Entidade
{
    [Serializable]
    public class Pessoa
    {
        public Pessoa()
        {
            Documentos = new List<Documento>();
            Enderecos = new List<Endereco>();
            Contatos = new List<Contato>();
        }

        #region Atributos Privados
        private int id;
        private string nome;
        private DateTime nascimento;
        private DateTime cadastrado;
        private List<Documento> documentos;
        private List<Endereco> enderecos;
        private List<Contato> contatos;
        private TipoSexo tipoSexo;
        private TipoEstadoCivil tipoEstadoCivil;
        private TipoPessoa tipoPessoa;
        #endregion

        #region Propriedades
        public int Id { get; private set; }
        public string Nome { get { return nome; } set { nome = value; } }

        public DateTime Nascimento
        {
            get { return nascimento; }
            set
            {
                if (!FuncoesGerais.ValidarData(value.ToString()))
                    throw new RegraNegocioException("Data de Nascimento Invalida.");
                nascimento = value;
            }
        }
        public DateTime Cadastrado { get { return cadastrado; } set { cadastrado = value; } }

        public TipoSexo TipoSexo { get { return tipoSexo; } set { tipoSexo = value; } }
        public TipoPessoa TipoPessoa { get { return tipoPessoa; } set { tipoPessoa = value; } }
        public TipoEstadoCivil TipoEstadoCivil { get { return tipoEstadoCivil; } set { tipoEstadoCivil = value; } }

        public List<Documento> Documentos { get { return documentos; } set { documentos = value; } }
        public List<Endereco> Enderecos { get { return enderecos; } set { enderecos = value; } }
        public List<Contato> Contatos { get { return contatos; } set { contatos = value; } }
        #endregion

        #region Helpers

        public Documento ObterDocumentoCpfCnpj()
        {
            if (Documentos != null || Documentos.Count > 0)
            {
                var objdoc = Documentos.Select(x => x.TipoDocumento == TipoDocumento.CNPJ || x.TipoDocumento == TipoDocumento.CPF);

                //Documento objdoc2 = new Documento();
                //foreach (var doc in Documentos)
                //{
                //    if (doc.TipoDocumento == TipoDocumento.CPF || doc.TipoDocumento == TipoDocumento.CNPJ)
                //    {
                //        objdoc2 = doc;
                //    }

                //}

                //Documento objdoc3 = new Documento();
                //for (int i = 0; i < Documentos.Count; i++)
                //{
                //    var doc = Documentos[i];
                //    if (doc.TipoDocumento == TipoDocumento.CPF || doc.TipoDocumento == TipoDocumento.CNPJ)
                //    {
                //        objdoc3 = doc;
                //    }

                //}
            }

            return null;
        }
        public Documento ObterDocumentoRg()
        {
            if (Documentos != null || Documentos.Count > 0)
            {
                return
                    Documentos.FirstOrDefault(
                        x => x.TipoDocumento == TipoDocumento.RG || x.TipoDocumento == TipoDocumento.IE);
            }
            return null;
        }
        public Endereco ObterEndereco()
        {
            if (this.Enderecos == null || this.Enderecos.Count <= 0)
                return null;

            var endereco = this.Enderecos.
                FirstOrDefault(x => x.TipoEndereco == TipoEndereco.RESIDENCIAL || x.TipoEndereco == TipoEndereco.COMERCIAL);

            return endereco;
        }
        public void ValidarEmail()
        {
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            var contato = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.EMAIL);
            if (contato != null)
            {
                if (!regex.IsMatch(contato.Email))
                {
                    throw new RegraNegocioException("Informe um E-mail Válido");
                }
            }
        }
        public Contato ObterEmail()
        {
            if (this.Contatos == null || this.Contatos.Count <= 0)
                return null;

            var email = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.EMAIL);


            return email;
        }
        public Contato ObterTelefone()
        {
            if (this.Contatos == null || this.Contatos.Count <= 0)
                return null;

            var telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.RESIDENCIAL);
            if (telefone.IsNull()) telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.COMERCIAL);
            if (telefone.IsNull()) telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.CELULAR);
            if (telefone.IsNull()) telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.FAX);

            return telefone;
        }

        #endregion
    }
}
