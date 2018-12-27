/********************************************************************************/
/* Projeto: Biblioteca ZeusMDFe                                                 */
/* Biblioteca C# para emissão de Manifesto Eletrônico Fiscal de Documentos      */
/* (https://mdfe-portal.sefaz.rs.gov.br/                                        */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/

using System;
using System.ComponentModel;
using System.Globalization;
using DFe.Classes.Entidades;
using DFe.Utils;
using MDFe.Classes.Flags;
using MDFe.Classes.Informacoes;
using MDFe.Classes.Informacoes.ConsultaNaoEncerrados;
using MDFe.Classes.Informacoes.ConsultaProtocolo;
using MDFe.Classes.Informacoes.Evento;
using MDFe.Classes.Informacoes.RetRecepcao;
using MDFe.Classes.Retorno.MDFeRecepcao;
using MDFe.Classes.Retorno.MDFeRetRecepcao;
using MDFe.Classes.Servicos.Autorizacao;
using NFe.Utils.Assinatura;
using MDFe.Utils.Configuracoes;
using MDFe.Utils.Flags;
using MDFe.Utils.Validacao;
using MDFEletronico = MDFe.Classes.Informacoes.MDFe;

namespace MDFe.Classes.Extensoes
{
    public static class ExtMDFe
    {
        public static MDFEletronico Valida(this MDFEletronico mdfe, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            if (mdfe == null) throw new ArgumentException("Erro de assinatura, MDFe esta null");

            var xmlMdfe = FuncoesXml.ClasseParaXmlString(mdfe);

            switch (config.VersaoWebService.VersaoLayout)
            {
                case VersaoServico.Versao100:
                    Validador.Valida(xmlMdfe, "MDFe_v1.00.xsd", config);
                    break;
                case VersaoServico.Versao300:
                    Validador.Valida(xmlMdfe, "MDFe_v3.00.xsd", config);
                    break;
            }

            var tipoModal = mdfe.InfMDFe.InfModal.Modal.GetType();
            var xmlModal = FuncoesXml.ClasseParaXmlString(mdfe.InfMDFe.InfModal);

            if (tipoModal == typeof(MDFeRodo))
            {
                switch (config.VersaoWebService.VersaoLayout)
                {
                    case VersaoServico.Versao100:
                        Validador.Valida(xmlModal, "MDFeModalRodoviario_v1.00.xsd", config);
                        break;
                    case VersaoServico.Versao300:
                        Validador.Valida(xmlModal, "MDFeModalRodoviario_v3.00.xsd", config);
                        break;
                }
            }

            if (tipoModal == typeof(MDFeAereo))
            {
                switch (config.VersaoWebService.VersaoLayout)
                {
                    case VersaoServico.Versao100:
                        Validador.Valida(xmlModal, "MDFeModalAereo_v1.00.xsd", config);
                        break;
                    case VersaoServico.Versao300:
                        Validador.Valida(xmlModal, "MDFeModalAereo_v3.00.xsd", config);
                        break;
                }
            }

            if (tipoModal == typeof(MDFeAquav))
            {
                switch (config.VersaoWebService.VersaoLayout)
                {
                    case VersaoServico.Versao100:
                        Validador.Valida(xmlModal, "MDFeModalAquaviario_v1.00.xsd", config);
                        break;
                    case VersaoServico.Versao300:
                        Validador.Valida(xmlModal, "MDFeModalAquaviario_v3.00.xsd", config);
                        break;
                }
            }

            if (tipoModal == typeof(MDFeFerrov))
            {
                switch (config.VersaoWebService.VersaoLayout)
                {
                    case VersaoServico.Versao100:
                        Validador.Valida(xmlModal, "MDFeModalFerroviario_v1.00.xsd", config);
                        break;
                    case VersaoServico.Versao300:
                        Validador.Valida(xmlModal, "MDFeModalFerroviario_v3.00.xsd", config);
                        break;
                }
            }

            return mdfe;
        }

        public static MDFEletronico Assina(this MDFEletronico mdfe, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            if (mdfe == null) throw new ArgumentException("Erro de assinatura, MDFe esta null");

            var modeloDocumentoFiscal = mdfe.InfMDFe.Ide.Mod;
            var tipoEmissao = (int)mdfe.InfMDFe.Ide.TpEmis;
            var codigoNumerico = mdfe.InfMDFe.Ide.CMDF;
            var estado = mdfe.InfMDFe.Ide.CUF;
            var dataEHoraEmissao = mdfe.InfMDFe.Ide.DhEmi;
            var cnpj = mdfe.InfMDFe.Emit.CNPJ;
            var numeroDocumento = mdfe.InfMDFe.Ide.NMDF;
            int serie = mdfe.InfMDFe.Ide.Serie;

            var dadosChave = ChaveFiscal.ObterChave(estado, dataEHoraEmissao, cnpj, modeloDocumentoFiscal, serie, numeroDocumento, tipoEmissao, codigoNumerico);

            mdfe.InfMDFe.Id = "MDFe" + dadosChave.Chave;
            mdfe.InfMDFe.Versao = config.VersaoWebService.VersaoLayout;
            mdfe.InfMDFe.Ide.CDV = dadosChave.DigitoVerificador;

            var assinatura = Assinador.ObterAssinatura(mdfe, mdfe.InfMDFe.Id, config.X509Certificate2);

            mdfe.Signature = assinatura;

            return mdfe;
        }

        public static string XmlString(this MDFEletronico mdfe)
        {
            return FuncoesXml.ClasseParaXmlString(mdfe);
        }

        public static T Valida<T>(T objeto, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            if (objeto == null) throw new ArgumentException("Erro de assinatura, objeto encontra-se null");

            var xmlServico = FuncoesXml.ClasseParaXmlString(objeto);

            var tipoServico = typeof(T).Name;
            var mdfeServico = (MDFeServico) Enum.Parse(typeof(MDFeServico), tipoServico);

            Validador.Valida(xmlServico, mdfeServico, cfgMdfe);

            switch (mdfeServico)
            {
                case MDFeServico.MDFEletronico:
                    var mdfe = objeto as MDFEletronico;
                    var tipoModal = mdfe.InfMDFe.InfModal.Modal.GetType().Name;
                    var xmlModal = FuncoesXml.ClasseParaXmlString(mdfe.InfMDFe.InfModal);
                    mdfeServico = (MDFeServico)Enum.Parse(typeof(MDFeServico), tipoModal);
                    Validador.Valida(xmlModal, mdfeServico, cfgMdfe);
                    break;
                case MDFeServico.MDFeEnviMDFe:
                    var enviMdfe = objeto as MDFeEnviMDFe;
                    xmlServico = FuncoesXml.ClasseParaXmlString(enviMdfe.MDFe);
                    tipoServico = enviMdfe.MDFe.GetType().Name;
                    mdfeServico = (MDFeServico)Enum.Parse(typeof(MDFeServico), tipoServico);
                    Validador.Valida(xmlServico, mdfeServico, cfgMdfe);
                    break;
                case MDFeServico.MDFeEventoMDFe:
                    var evento = objeto as MDFeEventoMDFe;
                    tipoServico = evento.InfEvento.DetEvento.EventoContainer.GetType().Name;
                    var xmlTipoEvento = FuncoesXml.ClasseParaXmlString(evento.InfEvento.DetEvento.EventoContainer);
                    mdfeServico = (MDFeServico)Enum.Parse(typeof(MDFeServico), tipoServico);
                    Validador.Valida(xmlTipoEvento, mdfeServico, cfgMdfe);
                    break;
            }

            return objeto;
        }
        //remover depois e deixar apenas o outro abaixo
        public static void SalvarXmlEmDisco(this MDFEletronico mdfe, string nomeArquivo = null, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            if (config.NaoSalvarXml()) return;

            if (string.IsNullOrEmpty(nomeArquivo))
                nomeArquivo = config.CaminhoSalvarXml + @"\" + mdfe.Chave() + "-mdfe.xml";

            FuncoesXml.ClasseParaArquivoXml(mdfe, nomeArquivo);
        }

        public static void SalvarXmlEmDisco<T>(T objeto, string identificador = null, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            if (config.NaoSalvarXml()) return;

            identificador = config.CaminhoSalvarXml + @"\" + ObterNomeclaturaDoArquivo(objeto, identificador);

            FuncoesXml.ClasseParaArquivoXml(objeto, identificador);
        }

        private static string ObterNomeclaturaDoArquivo<T>(T objeto, string identificador = null)
        {
            var nome = "xmlsalvo.xml";
            var classe = typeof(T).Name;
            var tipo = (MDFeExt)Enum.Parse(typeof(MDFeExt), classe);
            switch (tipo)
            {
                case MDFeExt.MDFEletronico:
                    var mdfe = objeto as MDFEletronico;
                    nome = mdfe.Chave() + "-mdfe.xml";
                    break;
                case MDFeExt.MDFeConsReciMDFe:
                    var consReci = objeto as MDFeConsReciMDFe;
                    nome = consReci.NRec + "-ped-rec.xml";
                    break;
                case MDFeExt.MDFeConsSitMDFe:
                    var consSit = objeto as MDFeConsSitMDFe;
                    nome = consSit.ChMDFe + "-ped-sit.xml";
                    break;
                case MDFeExt.MDFeConsStatServMDFe:
                    nome = "-pedido-status-servico.xml";
                    break;
                case MDFeExt.MDFeCosMDFeNaoEnc:
                    var consNaoEnc = objeto as MDFeCosMDFeNaoEnc;
                    nome = consNaoEnc.CNPJ + "-ped-sit.xml";
                    break;
                case MDFeExt.MDFeEnviMDFe:
                    var enviMDFe = objeto as MDFeEnviMDFe;
                    nome = enviMDFe.MDFe.Chave() + "-completo-mdfe.xml";
                    break;
                case MDFeExt.MDFeRetConsReciMDFe:
                    var consReciMdFe = objeto as MDFeRetConsReciMDFe;
                    nome = consReciMdFe.NRec + "-pro-rec.xml";
                    break;
                case MDFeExt.MDFeRetConsStatServ:
                    nome = "-retorno-status-servico.xml";
                    break;
                case MDFeExt.MDFeRetEnviMDFe:
                    var retEnviMDFe = objeto as MDFeRetEnviMDFe;
                    nome = retEnviMDFe.InfRec.NRec + "-rec.xml";
                    break;
                case MDFeExt.MDFeRetConsMDFeNao:
                    if (string.IsNullOrEmpty(identificador))
                        nome = identificador + "-sit.xml";
                    break;
                case MDFeExt.MDFeRetConsSitMDFe:
                    if (string.IsNullOrEmpty(identificador))
                        nome = identificador + "-sit.xml";
                    break;
                case MDFeExt.MDFeRetEventoMDFe:
                    if (string.IsNullOrEmpty(identificador))
                        nome = identificador + "-env.xml";
                    break;
                default:
                    nome = "arquivoXmlSalvo.xml";
                    break;
            }


            return nome;
        }

        public static string Chave(this MDFEletronico mdfe)
        {
            var chave = mdfe.InfMDFe.Id.Substring(4, 44);
            return chave;
        }

        public static string CNPJEmitente(this MDFEletronico mdfe)
        {
            var cnpj = mdfe.InfMDFe.Emit.CNPJ;

            return cnpj;
        }

        public static Estado UFEmitente(this MDFEletronico mdfe)
        {
            var estadoUf = mdfe.InfMDFe.Emit.EnderEmit.UF;

            return estadoUf;
        }

        public static long CodigoIbgeMunicipioEmitente(this MDFEletronico mdfe)
        {
            var codigo = mdfe.InfMDFe.Emit.EnderEmit.CMun;

            return codigo;
        }
    }
}
