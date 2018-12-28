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
using System.Xml;
using DFe.Classes.Entidades;
using DFe.Utils;
using MDFe.Classes.Flags;
using MDFe.Classes.Informacoes.ConsultaNaoEncerrados;
using MDFe.Classes.Informacoes.ConsultaProtocolo;
using MDFe.Classes.Informacoes.Evento;
using MDFe.Classes.Informacoes.Evento.CorpoEvento;
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
 
        public static T Valida<T>(this T objeto, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            if (objeto == null) throw new ArgumentException("Erro de assinatura, objeto encontra-se null");

            var xmlServico = FuncoesXml.ClasseParaXmlString(objeto);

            var tipoServico = typeof(T).Name;
            var mdfeServico = (MDFeServico)Enum.Parse(typeof(MDFeServico), tipoServico);

            Validador.Valida(xmlServico, mdfeServico, config);

            switch (mdfeServico)
            {
                case MDFeServico.MDFe:
                    var mdfe = objeto as MDFEletronico;
                    var tipoModal = mdfe.InfMDFe.InfModal.Modal.GetType().Name;
                    var xmlModal = FuncoesXml.ClasseParaXmlString(mdfe.InfMDFe.InfModal);
                    mdfeServico = (MDFeServico)Enum.Parse(typeof(MDFeServico), tipoModal);
                    Validador.Valida(xmlModal, mdfeServico, config);
                    break;
                case MDFeServico.MDFeEnviMDFe:
                    var enviMdfe = objeto as MDFeEnviMDFe;
                    Valida(enviMdfe.MDFe, config);
                    break;
                case MDFeServico.MDFeEventoMDFe:
                    var evento = objeto as MDFeEventoMDFe;
                    tipoServico = evento.InfEvento.DetEvento.EventoContainer.GetType().Name;
                    var xmlTipoEvento = "";

                    if (tipoServico.Equals("MDFeEvCancMDFe"))
                        xmlTipoEvento = FuncoesXml.ClasseParaXmlString((MDFeEvCancMDFe)evento.InfEvento.DetEvento.EventoContainer);
                    if (tipoServico.Equals("MDFeEvEncMDFe"))
                        xmlTipoEvento = FuncoesXml.ClasseParaXmlString((MDFeEvEncMDFe)evento.InfEvento.DetEvento.EventoContainer);
                    if (tipoServico.Equals("MDFeEvIncCondutorMDFe"))
                        xmlTipoEvento = FuncoesXml.ClasseParaXmlString((MDFeEvIncCondutorMDFe)evento.InfEvento.DetEvento.EventoContainer);

                    mdfeServico = (MDFeServico)Enum.Parse(typeof(MDFeServico), tipoServico);
                    Validador.Valida(xmlTipoEvento, mdfeServico, config);
                    break;
            }

            return objeto;
        }

        public static string XmlString<T>(this T objeto)
        {
            return FuncoesXml.ClasseParaXmlString(objeto);
        }

        public static XmlDocument CriaRequestWs<T>(this T requisicao)
        {
            var request = new XmlDocument();
            request.LoadXml(XmlString(requisicao));
            return request;
        }

        public static void SalvarXmlEmDisco<T>(this T objeto, string identificador = null, MDFeConfiguracao cfgMdfe = null)
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
                        nome = identificador + "-sit.xml";
                    break;
                case MDFeExt.MDFeRetEventoMDFe:
                        nome = identificador + "-env.xml";
                    break;
                case MDFeExt.MDFeEventoMDFe:
                        nome = identificador + "-ped-eve.xml";
                    break;
                default:
                    nome = "arquivoXmlSalvo.xml";
                    break;
            }


            return nome;
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

        public static void Assina(this MDFeEventoMDFe evento, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;

            evento.Signature = Assinador.ObterAssinatura(evento, evento.InfEvento.Id,
                config.X509Certificate2);
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
