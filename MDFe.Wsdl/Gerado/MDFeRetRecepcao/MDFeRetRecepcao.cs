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
using System.Xml.Serialization;
using MDFe.Utils.Soap;
using MDFe.Wsdl.Configuracao;
using static MDFe.Utils.Enums.Enums;

namespace MDFe.Wsdl.Gerado.MDFeRetRecepcao
{
    /// <summary>
    /// Classe respons�vel por realizar as consultas SOAP do tipo Retorno Recep��o via HttpClient.
    /// Compat�vel com .NET Standard e .NET FRAMEWORK 4.5
    /// </summary>
    public partial class MDFeRetRecepcao
    {
        //Envelope SOAP para envio
        private SOAPEnvelopeR soapEnvelope;

        //Configura��es do WSDL para estabelecimento da comunica��o
        private WsdlConfiguracao configuracao;

        /// <summary>
        /// Cria o cabe�alho do envelope a ser enviado e atribui as configura��es do WSDL.
        /// </summary>
        /// <param name="configuracao"></param>
        public MDFeRetRecepcao(WsdlConfiguracao configuracao)
        {
            if (configuracao == null)
                throw new ArgumentNullException();

            this.configuracao = configuracao;

            soapEnvelope = new SOAPEnvelopeR()
            {
                head = new ResponseHeadR<mdfeCabecMsgR>()
                {
                    mdfeCabecMsg = new mdfeCabecMsgR()
                    {
                        versaoDados = configuracao.Versao,
                        cUF = configuracao.CodigoIbgeEstado
                    }
                }
            };
            System.Net.ServicePointManager.SecurityProtocol =
                System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Encapsula os dados da requisi��o no envelope por meio da serializa��o das partes e realiza a requis��o ao Web Service.
        /// </summary>
        /// <param name="mdfeDadosMsg"></param>
        /// <returns>XmlNode</returns>
        public async Task<System.Xml.XmlNode> mdfeRetRecepcao(System.Xml.XmlNode mdfeDadosMsg)
        {
            var soapUtils = new SoapUtils();
            var xmlresult = new XmlDocument();
            var xmlEnvelop = new XmlDocument();

            soapEnvelope.body = new ResponseBodyR<XmlNode>()
            {
                mdfeDadosMsg = mdfeDadosMsg
            };

            xmlEnvelop = soapUtils.SerealizeDocument(soapEnvelope);
            var tes = await soapUtils.SendRequest(xmlEnvelop, configuracao.CertificadoDigital, configuracao.Url, Tipo.MDFeRetRecepcao);
            xmlresult.LoadXml(tes);

            return ((System.Xml.XmlNode)xmlresult.GetElementsByTagName("retConsReciMDFe")[0]);
        }
    }

    /// <summary>
    /// Classe base para a serealiza��o no formato do envelope SOAP.
    /// </summary>
    [XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class SOAPEnvelopeR
    {
        [XmlAttribute(AttributeName = "soap12", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public string soapenva { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string xsd { get; set; }

        [XmlElement(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public ResponseHeadR<mdfeCabecMsgR> head { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public ResponseBodyR<XmlNode> body { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public SOAPEnvelopeR()
        {
            xmlns.Add("soap12", "http://www.w3.org/2003/05/soap-envelope");
        }
    }
    /// <summary>
    /// Classe para o cabe�alho do Envelope SOAP
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseHeadR<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
        public T mdfeCabecMsg { get; set; }
    }

    /// <summary>
    /// Classe para o corpo do Envelope SOAP
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseBodyR<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
        public T mdfeDadosMsg { get; set; }
    }

    /// <summary>
    /// Classe para os campos contidos no cabe�alho do Envelope SOAP
    /// </summary>
    public class mdfeCabecMsgR
    {

        private string _cUFField;
        private string _versaoDadosField;

        public string cUF
        {
            get { return this._cUFField; }
            set { this._cUFField = value; }
        }

        public string versaoDados
        {
            get { return this._versaoDadosField; }
            set { this._versaoDadosField = value; }
        }
    }
}