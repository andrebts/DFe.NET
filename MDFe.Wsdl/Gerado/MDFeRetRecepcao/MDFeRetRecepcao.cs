//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
/********************************************************************************/
/* Projeto: Biblioteca ZeusMDFe                                                 */
/* Biblioteca C# para emiss�o de Manifesto Eletr�nico Fiscal de Documentos      */
/* (https://mdfe-portal.sefaz.rs.gov.br/                                        */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Voc� pode obter a �ltima vers�o desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca � software livre; voc� pode redistribu�-la e/ou modific�-la */
/* sob os termos da Licen�a P�blica Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a vers�o 2.1 da Licen�a, ou (a seu crit�rio) */
/* qualquer vers�o posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca � distribu�da na expectativa de que seja �til, por�m, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia impl�cita de COMERCIABILIDADE OU      */
/* ADEQUA��O A UMA FINALIDADE ESPEC�FICA. Consulte a Licen�a P�blica Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICEN�A.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Voc� deve ter recebido uma c�pia da Licen�a P�blica Geral Menor do GNU junto*/
/* com esta biblioteca; se n�o, escreva para a Free Software Foundation, Inc.,  */
/* no endere�o 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Voc� tamb�m pode obter uma copia da licen�a em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco jos� da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/

using System;
using System.Threading.Tasks;
using System.Xml;
using DFe.Classes.Entidades;
using MDFe.Wsdl.Configuracao;
using SOAP.Handler.Body;
using SOAP.Handler.Configuracao;
using SOAP.Handler.Head;
using SOAP.Handler.Requisicao;
using static SOAP.Handler.Enums.Enums;

namespace MDFe.Wsdl.Gerado.MDFeRetRecepcao
{
    /// <summary>
    /// Classe respons�vel por realizar as consultas SOAP do tipo Retorno Recep��o via HttpClient.
    /// Compat�vel com .NET Standard e .NET FRAMEWORK 4.5
    /// </summary>
    public partial class MDFeRetRecepcao
    {
        //Envelope SOAP para envio
        private SoapConfig soapConfig;

        //Configura��es do WSDL para estabelecimento da comunica��o
        private WsdlConfiguracao configuracao;

        /// <summary>
        /// Atribui as configura��es do WSDL.
        /// </summary>
        /// <param name="configuracao"></param>
        public MDFeRetRecepcao(WsdlConfiguracao configuracao)
        {
            if (configuracao == null)
                throw new ArgumentNullException();

            this.configuracao = configuracao;

            System.Net.ServicePointManager.SecurityProtocol =
                System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Encapsula os dados da requisi��o no envelope e realiza a requis��o ao Web Service.
        /// </summary>
        /// <param name="mdfeDadosMsg"></param>
        /// <returns>XmlNode</returns>
        public async Task<System.Xml.XmlNode> mdfeRetRecepcao(System.Xml.XmlNode mdfeDadosMsg)
        {
            var resposta = string.Empty;
            var xmlResult = new XmlDocument();

            var retorno = new SoapHttpClient();

            var estado = (Estado)Enum.Parse(typeof(Estado), configuracao.CodigoIbgeEstado);
            var versaoServico = (VersaoServico)Enum.Parse(typeof(VersaoServico), configuracao.Versao);

            var tagcorpo = new TagCorpo(estado.GetParametroDeEntradaWsdl(false, TipoRequisicao.MDFe));

            soapConfig = new SoapConfig
            {
                Cabecalho = new Cabecalho(estado, versaoServico,
                    new TagCabecalho(), "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao",
                    TipoRequisicao.MDFe),
                Corpo = new Corpo("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao", tagcorpo),
                Certificado = configuracao.CertificadoDigital,
                TimeOut = configuracao.TimeOut,
                Url = configuracao.Url
            };

            soapConfig.Corpo.Xml = mdfeDadosMsg;

            resposta = await retorno.Invoke(soapConfig);

            xmlResult.LoadXml(resposta);

            return ((System.Xml.XmlNode)xmlResult.GetElementsByTagName("retConsReciMDFe")[0]);
        }
    }
}