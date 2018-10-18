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
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SMDFe.Wsdl.Configuracao;

namespace SMDFe.Wsdl.Gerado.MDFeRecepcao
{ // 
  // This source code was auto-generated by wsdl, Version=4.6.1055.0.
  // 

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
#if NET45
    [System.Web.Services.WebServiceBindingAttribute(Name="MDFeRecepcaoSoap12", Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
    public partial class MDFeRecepcao : System.Web.Services.Protocols.SoapHttpClientProtocol {
#endif
#if NETSTANDARD2_0
    public partial class MDFeRecepcao
    {
#endif
#if NET45
        private mdfeCabecMsg mdfeCabecMsgValueField;
#endif

#if NETSTANDARD2_0
        private SOAPEnvelope soapEnvelope;
        private XmlDocument xmlEnvelop;
        private WsdlConfiguracao configuracao;
        private HttpWebRequest request;
#endif

        private System.Threading.SendOrPostCallback mdfeRecepcaoLoteOperationCompleted;
    
        /// <remarks/>
        public MDFeRecepcao(WsdlConfiguracao configuracao) {
#if NETSTANDARD2_0
            try
            {
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
                request.Headers.Add("SOAPAction", "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao/mdfeRecepcaoLote");
                request.KeepAlive = true;
                request.ContentType = "application/soap+xml; charset=\"UTF-8\"";
                request.Accept = "*/*";
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                request.ProtocolVersion = HttpVersion.Version11;


                request.ClientCertificates.Add(configuracao.CertificadoDigital);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO na criação da Requisição -> " + e);
            }


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
#endif

#if NETSTANDARD2_0
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            try
            {
                using (Stream stream = webRequest.GetRequestStream())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(soapEnvelopeXml.OuterXml);
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO na inserção do envelope -> " + e);
                throw;
            }

        }
#endif

        /// <remarks/>
        public event mdfeRecepcaoLoteCompletedEventHandler mdfeRecepcaoLoteCompleted;
#if NET45
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("mdfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao/mdfeRecepcaoLote", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
        public System.Xml.XmlNode mdfeRecepcaoLote([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")] System.Xml.XmlNode mdfeDadosMsg) {
            object[] results = this.Invoke("mdfeRecepcaoLote", new object[] {
                mdfeDadosMsg});
#endif
#if NETSTANDARD2_0
        public System.Xml.XmlNode mdfeRecepcaoLote(System.Xml.XmlNode mdfeDadosMsg)
        {
            string result = "";
            var xmlresult = new XmlDocument();
            try
            {


                soapEnvelope.body = new ResponseBody<XmlNode>()
                {
                    mdfeDadosMsg = mdfeDadosMsg
                };

                var soapserializer = new XmlSerializer(typeof(SOAPEnvelope));
                xmlEnvelop = new XmlDocument();

                using (var sww = new StreamWriter("soap.xml"))
                {
                    using (XmlWriter writer = XmlWriter.Create(sww,
                        new XmlWriterSettings() { Indent = false }))
                    {
                        soapserializer.Serialize(writer, soapEnvelope);
                        writer.Close();

                    }
                }
                xmlEnvelop.PreserveWhitespace = false;
                xmlEnvelop.Load("soap.xml");

            }
            catch (XmlException e)
            {
                Console.WriteLine("ERRO no xml do envelope -> " + e.Message);

            }
            /*
            InsertSoapEnvelopeIntoWebRequest(xmlEnvelop, request);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        result = rd.ReadToEnd();
                        xmlresult.LoadXml(result);

                    }
                }

            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    string message = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(message);
                }

            }

            var xmlNode = xmlresult.GetElementsByTagName("retEnviMDFe")[0];
            */
#endif
#if NET45
            return ((System.Xml.XmlNode)(results[0]));
#endif
#if NETSTANDARD2_0
            return null; //xmlNode;
#endif

        }
#if NET45
        /// <remarks/>
        public System.IAsyncResult BeginmdfeRecepcaoLote(System.Xml.XmlNode mdfeDadosMsg, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("mdfeRecepcaoLote", new object[] {
                mdfeDadosMsg}, callback, asyncState);
        }
#endif

#if NET45
        /// <remarks/>
        public System.Xml.XmlNode EndmdfeRecepcaoLote(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
#endif

#if NET45
        /// <remarks/>
        public void mdfeRecepcaoLoteAsync(System.Xml.XmlNode mdfeDadosMsg) {
            this.mdfeRecepcaoLoteAsync(mdfeDadosMsg, null);
        }
#endif

#if NET45
        /// <remarks/>
        public void mdfeRecepcaoLoteAsync(System.Xml.XmlNode mdfeDadosMsg, object userState) {
            if ((this.mdfeRecepcaoLoteOperationCompleted == null)) {
                this.mdfeRecepcaoLoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeRecepcaoLoteOperationCompleted);
            }
            this.InvokeAsync("mdfeRecepcaoLote", new object[] {
                mdfeDadosMsg}, this.mdfeRecepcaoLoteOperationCompleted, userState);
        }
#endif

#if NET45
        private void OnmdfeRecepcaoLoteOperationCompleted(object arg) {
            if ((this.mdfeRecepcaoLoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.mdfeRecepcaoLoteCompleted(this, new mdfeRecepcaoLoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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

#if NET45
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao", IsNullable=false)]
    public partial class mdfeCabecMsg : System.Web.Services.Protocols.SoapHeader {
    
        private string cUFField;
    
        private string versaoDadosField;
    
        private System.Xml.XmlAttribute[] anyAttrField;
    
        /// <remarks/>
        public string cUF {
            get {
                return this.cUFField;
            }
            set {
                this.cUFField = value;
            }
        }
    
        /// <remarks/>
        public string versaoDados {
            get {
                return this.versaoDadosField;
            }
            set {
                this.versaoDadosField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
#endif

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
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
        public T mdfeCabecMsg { get; set; }
    }

    //Classe Body SOAP 1.2
    [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcao")]
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void mdfeRecepcaoLoteCompletedEventHandler(object sender, mdfeRecepcaoLoteCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class mdfeRecepcaoLoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
        private object[] results;
    
        internal mdfeRecepcaoLoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}