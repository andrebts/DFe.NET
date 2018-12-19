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
using System.IO;
using System.Net;
#if NETSTANDARD
#endif
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SMDFe.Wsdl.Configuracao;
using System.Xml;
using System.Xml.Serialization;
using SMDFe.Wsdl.Cabe�alho;


namespace SMDFe.Wsdl.Gerado.MDFeStatusServico
{ // 
  // This source code was auto-generated by wsdl, Version=4.6.1055.0.
  // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
#if NET45
    [System.Web.Services.WebServiceBindingAttribute(Name="MDFeStatusServicoSoap12", Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico")]
    public partial class MDFeStatusServico : System.Web.Services.Protocols.SoapHttpClientProtocol {
#endif
#if NETSTANDARD2_0
    public partial class MDFeStatusServico
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
        private System.Threading.SendOrPostCallback mdfeStatusServicoMDFOperationCompleted;
    
        /// <remarks/>
        public MDFeStatusServico(WsdlConfiguracao configuracao) {
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
                request.Headers.Add(HttpHeader.ACTION, "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico/mdfeStatusServicoMDF");
                request.KeepAlive = true;
                request.ContentType = HttpHeader.CONTETTYPE;
                request.Accept = HttpHeader.ACCEPT;
                request.Method = HttpHeader.METHOD;
                request.UserAgent = HttpHeader.AGENT;
                request.ProtocolVersion = HttpVersion.Version11;


                request.ClientCertificates.Add(configuracao.CertificadoDigital);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO na cria��o da Requisi��o -> " + e);
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
                Console.WriteLine("ERRO na inser��o do envelope -> " + e);
                throw;
            }

        }
#endif

        /// <remarks/>
        public event mdfeStatusServicoMDFCompletedEventHandler mdfeStatusServicoMDFCompleted;
#if NET45
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("mdfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico/mdfeStatusServicoMDF", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico")]
        public System.Xml.XmlNode mdfeStatusServicoMDF([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico")] System.Xml.XmlNode mdfeDadosMsg) {

            object[] results = this.Invoke("mdfeStatusServicoMDF", new object[] {
                mdfeDadosMsg});
#endif

#if NETSTANDARD2_0
        public System.Xml.XmlNode mdfeStatusServicoMDF(System.Xml.XmlNode mdfeDadosMsg)
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

                var ms = new MemoryStream();
                soapserializer.Serialize(ms, soapEnvelope);
                ms.Position = 0;

                var reader = new StreamReader(ms).ReadToEnd();

                xmlEnvelop.PreserveWhitespace = false;
                xmlEnvelop.LoadXml(reader);

            }
            catch (XmlException e)
            {
                Console.WriteLine("ERRO no xml do envelope -> " + e.Message);

            }

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

            var xmlNode = xmlresult.GetElementsByTagName("retConsStatServMDFe")[0];

#endif
#if NET45
            return ((System.Xml.XmlNode)(results[0]));
#endif
#if NETSTANDARD2_0
            return xmlNode;
#endif
        }
#if NET45
        /// <remarks/>
        public System.IAsyncResult BeginmdfeStatusServicoMDF(System.Xml.XmlNode mdfeDadosMsg, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("mdfeStatusServicoMDF", new object[] {
                mdfeDadosMsg}, callback, asyncState);
        }
#endif

#if NET45
        /// <remarks/>
        public System.Xml.XmlNode EndmdfeStatusServicoMDF(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
#endif

#if NET45
        /// <remarks/>
        public void mdfeStatusServicoMDFAsync(System.Xml.XmlNode mdfeDadosMsg) {
            this.mdfeStatusServicoMDFAsync(mdfeDadosMsg, null);
        }
#endif

#if NET45
        /// <remarks/>
        public void mdfeStatusServicoMDFAsync(System.Xml.XmlNode mdfeDadosMsg, object userState) {
            if ((this.mdfeStatusServicoMDFOperationCompleted == null)) {
                this.mdfeStatusServicoMDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeStatusServicoMDFOperationCompleted);
            }
            this.InvokeAsync("mdfeStatusServicoMDF", new object[] {
                mdfeDadosMsg}, this.mdfeStatusServicoMDFOperationCompleted, userState);
        }

#endif

#if NET45
        private void OnmdfeStatusServicoMDFOperationCompleted(object arg) {
            if ((this.mdfeStatusServicoMDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.mdfeStatusServicoMDFCompleted(this, new mdfeStatusServicoMDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico", IsNullable=false)]
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
    * Classes para a serializa��o e cria��o do envelope no formato SOAP 1.2
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
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico")]
        public T mdfeCabecMsg { get; set; }
    }

    //Classe Body SOAP 1.2
    [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeStatusServico")]
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
    public delegate void mdfeStatusServicoMDFCompletedEventHandler(object sender, mdfeStatusServicoMDFCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class mdfeStatusServicoMDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
        private object[] results;
    
        internal mdfeStatusServicoMDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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