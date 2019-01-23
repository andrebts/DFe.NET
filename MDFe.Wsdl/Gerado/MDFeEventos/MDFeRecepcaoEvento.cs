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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using MDFe.Utils.Soap;
using MDFe.Wsdl.Cabeçalho;
using MDFe.Wsdl.Configuracao;
using MDFe.Wsdl.Gerado.MDFeConsultaNaoEncerrados;

namespace MDFe.Wsdl.Gerado.MDFeEventos
{
    // 
    // This source code was auto-generated by wsdl, Version=4.6.1055.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
#if NET45
[System.Web.Services.WebServiceBindingAttribute(Name = "MDFeRecepcaoEventoSoap12",
    Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento")]
public partial class MDFeRecepcaoEvento : System.Web.Services.Protocols.SoapHttpClientProtocol
{

#endif
#if NETSTANDARD2_0
    public partial class MDFeRecepcaoEvento
    {
#endif
#if NET45
    private mdfeCabecMsg mdfeCabecMsgValueField;
#endif

#if NETSTANDARD2_0
        private SOAPEnvelope soapEnvelope;
        private WsdlConfiguracao configuracao;
        private HttpWebRequest request;
#endif
#if NET45
        private System.Threading.SendOrPostCallback mdfeRecepcaoEventoOperationCompleted;
#endif   
        /// <remarks/>
        public MDFeRecepcaoEvento(WsdlConfiguracao configuracao)
        {
#if NETSTANDARD2_0
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
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

            request = (HttpWebRequest)WebRequest.Create(configuracao.Url);
            request.Headers.Add(HttpHeader.ACTION, "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento/mdfeRecepcaoEvento");
            request.KeepAlive = true;
            request.ContentType = HttpHeader.CONTETTYPE;
            request.Accept = HttpHeader.ACCEPT;
            request.Method = HttpHeader.METHOD;
            request.UserAgent = HttpHeader.AGENT;
            request.ProtocolVersion = HttpVersion.Version11;

            request.ClientCertificates.Add(configuracao.CertificadoDigital);
#endif

#if NET45
        this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
        this.Url = configuracao.Url;
        this.mdfeCabecMsgValue = new mdfeCabecMsg
        {
            cUF = configuracao.CodigoIbgeEstado,
            versaoDados = configuracao.Versao
        };
        this.ClientCertificates.Add(configuracao.CertificadoDigital);
        this.Timeout = configuracao.TimeOut;
#endif
        }

#if NET45
    public mdfeCabecMsg mdfeCabecMsgValue {
        get {
            return this.mdfeCabecMsgValueField;
        }
        set {
            this.mdfeCabecMsgValueField = value;
        }
    }
    /// <remarks/>
    public event mdfeRecepcaoEventoCompletedEventHandler mdfeRecepcaoEventoCompleted;

    /// <remarks/>
    [System.Web.Services.Protocols.SoapHeaderAttribute("mdfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento/mdfeRecepcaoEvento", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
    [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento")]
    public System.Xml.XmlNode mdfeRecepcaoEvento([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento")] System.Xml.XmlNode mdfeDadosMsg) {

        object[] results = this.Invoke("mdfeRecepcaoEvento", new object[] {
                    mdfeDadosMsg});  
        return ((System.Xml.XmlNode)(results[0]));
     }
#endif
#if NETSTANDARD2_0
        public System.Xml.XmlNode mdfeRecepcaoEvento(System.Xml.XmlNode mdfeDadosMsg)
        {
            var result = "";
            var soapUtils = new SoapUtils();
            var xmlresult = new XmlDocument();
            var xmlEnvelop = new XmlDocument();

            soapEnvelope.body = new ResponseBody<XmlNode>()
            {
                mdfeDadosMsg = mdfeDadosMsg
            };

            xmlEnvelop = soapUtils.SerealizeDocument(soapEnvelope);
            request = soapUtils.InsertSoapEnvelopeIntoWebRequest(xmlEnvelop, request);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    result = rd.ReadToEnd();
                    xmlresult.LoadXml(result);
                }
            }

            return ((System.Xml.XmlNode) xmlresult.GetElementsByTagName("retEventoMDFe")[0]);
        }

#endif

#if NET45
/// <remarks/>
    public System.IAsyncResult BeginmdfeRecepcaoEvento(System.Xml.XmlNode mdfeDadosMsg, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("mdfeRecepcaoEvento", new object[] {
                    mdfeDadosMsg}, callback, asyncState);
    }
#endif

#if NET45
/// <remarks/>
    public System.Xml.XmlNode EndmdfeRecepcaoEvento(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((System.Xml.XmlNode)(results[0]));
    }
#endif

#if NET45
/// <remarks/>
    public void mdfeRecepcaoEventoAsync(System.Xml.XmlNode mdfeDadosMsg) {
        this.mdfeRecepcaoEventoAsync(mdfeDadosMsg, null);
    }
#endif

#if NET45
/// <remarks/>
    public void mdfeRecepcaoEventoAsync(System.Xml.XmlNode mdfeDadosMsg, object userState) {
        if ((this.mdfeRecepcaoEventoOperationCompleted == null)) {
            this.mdfeRecepcaoEventoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeRecepcaoEventoOperationCompleted);
        }
        this.InvokeAsync("mdfeRecepcaoEvento", new object[] {
                    mdfeDadosMsg}, this.mdfeRecepcaoEventoOperationCompleted, userState);
    }
#endif
#if NET45
    private void OnmdfeRecepcaoEventoOperationCompleted(object arg) {
        if ((this.mdfeRecepcaoEventoCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.mdfeRecepcaoEventoCompleted(this, new mdfeRecepcaoEventoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
#endif

#if NET45
/// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
#endif
    }

#if NETSTANDARD2_0
    /*
    * Classes para a serialização e criação do envelope no formato SOAP 1.2
    */

    //Classe Envelope SOAP 1.2
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

    //Classe Header SOAP 1.2
    [XmlRoot(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseHead<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento")]
        public T mdfeCabecMsg { get; set; }
    }

    //Classe Body SOAP 1.2
    [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento")]
        public T mdfeDadosMsg { get; set; }
    }

    //Classe mdfeCabecMsg SOAP 1.2
    public class mdfeCabecMsg
    {

        private string _cUFField;
        private string _versaoDadosField;

        /// <remarks/>
        public string cUF
        {
            get { return this._cUFField; }
            set { this._cUFField = value; }
        }

        /// <remarks/>
        public string versaoDados
        {
            get { return this._versaoDadosField; }
            set { this._versaoDadosField = value; }
        }
    }

#endif
#if NET45
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void mdfeRecepcaoEventoCompletedEventHandler(object sender, mdfeRecepcaoEventoCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class mdfeRecepcaoEventoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
        private object[] results;
    
        internal mdfeRecepcaoEventoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
            this.results = results;
        }
    
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
#endif
}