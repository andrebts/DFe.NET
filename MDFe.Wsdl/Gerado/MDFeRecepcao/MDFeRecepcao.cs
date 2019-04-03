﻿//------------------------------------------------------------------------------
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
using System.Xml.Serialization;
using MDFe.Utils.Soap;
using MDFe.Wsdl.Configuracao;
using static MDFe.Utils.Enums.Enums;

namespace MDFe.Wsdl.Gerado.MDFeRecepcao
{

    /// <summary>
    /// Classe responsável por realizar as consultas SOAP do tipo Recepção via HttpClient.
    /// Compatível com .NET Standard e .NET FRAMEWORK 4.5
    /// </summary>
    public partial class MDFeRecepcao
    {
        //Envelope SOAP para envio
        private SOAPEnvelope soapEnvelope;

        //Configurações do WSDL para estabelecimento da comunicação
        private WsdlConfiguracao configuracao;

        /// <summary>
        /// Cria o cabeçalho do envelope a ser enviado e atribui as configurações do WSDL.
        /// </summary>
        /// <param name="configuracao"></param>
        public MDFeRecepcao(WsdlConfiguracao configuracao)
        {
            if (configuracao == null)
                throw new ArgumentNullException();

            this.configuracao = configuracao;
            soapEnvelope = new SOAPEnvelope()
            {
                head = new ResponseHead<mdfeCabecMsg>()
                {
                    mdfeCabecMsg = new mdfeCabecMsg()
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
        /// Encapsula os dados da requisição no envelope por meio da serialização das partes e realiza a requisção ao Web Service.
        /// </summary>
        /// <param name="mdfeDadosMsg"></param>
        /// <returns>XmlNode</returns>
        public System.Xml.XmlNode mdfeRecepcaoLote(System.Xml.XmlNode mdfeDadosMsg)
        {
            var soapUtils = new SoapUtils();
            var xmlresult = new XmlDocument();
            var xmlEnvelop = new XmlDocument();

            soapEnvelope.body = new ResponseBody<XmlNode>()
            {
                mdfeDadosMsg = mdfeDadosMsg
            };

            xmlEnvelop = soapUtils.SerealizeDocument(soapEnvelope);
            var tes = soapUtils.SendRequest(xmlEnvelop, configuracao.CertificadoDigital, configuracao.Url,
                Tipo.MDFeConsNaoEnc);
            xmlresult.LoadXml(tes.Result);

            return ((System.Xml.XmlNode)xmlresult.GetElementsByTagName("retEnviMDFe")[0]);
        }
    }

    /// <summary>
    /// Classe base para a serealização no formato do envelope SOAP.
    /// </summary>
    [XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class SOAPEnvelope
    {
        [XmlAttribute(AttributeName = "soap12", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public string soapenva { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string xsd { get; set; }

        [XmlElement(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public ResponseHead<mdfeCabecMsg> head { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public ResponseBody<XmlNode> body { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public SOAPEnvelope()
        {
            xmlns.Add("soap12", "http://www.w3.org/2003/05/soap-envelope");
        }
    }

    /// <summary>
    /// Classe para o cabeçalho do Envelope SOAP
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseHead<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
        public T mdfeCabecMsg { get; set; }
    }

    /// <summary>
    /// Classe para o corpo do Envelope SOAP
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
        public T mdfeDadosMsg { get; set; }
    }

    /// <summary>
    /// Classe para os campos contidos no cabeçalho do Envelope SOAP
    /// </summary>
    public class mdfeCabecMsg
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