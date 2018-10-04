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
using SMDFe.Wsdl.Configuracao;
using System.Xml;

namespace SMDFe.Wsdl.Gerado.MDFeConsultaProtoloco
{ // 
  // This source code was auto-generated by wsdl, Version=4.6.1055.0.
  // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
#if NET45
    [System.Web.Services.WebServiceBindingAttribute(Name="MDFeConsultaSoap12", Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta")]
    public partial class MDFeConsulta : System.Web.Services.Protocols.SoapHttpClientProtocol {
#endif
#if NETSTANDARD2_0
        public partial class MDFeConsulta
    {
#endif

#if NET45
        private mdfeCabecMsg mdfeCabecMsgValueField;
#endif

#if NETSTANDARD2_0
        private string soapEnvelop;
        private XmlDocument xmlEnvelop;
        private WsdlConfiguracao configuracao;
#endif

        private System.Threading.SendOrPostCallback mdfeConsultaMDFOperationCompleted;
    
        /// <remarks/>
        public MDFeConsulta(WsdlConfiguracao configuracao) {
#if NETSTANDARD2_0
            this.configuracao = configuracao;
            soapHead(configuracao);
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
        private void soapHead(WsdlConfiguracao confi)
        {
            soapEnvelop = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                          "<soap12:Envelope xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd= \"http://www.w3.org/2001/XMLSchema\">"
                                + "<soap12:Header>"
                                    + $"<mdfeCabecMsg xmlns = \"{confi.Url}\">"
                                        + $"<cUF>{confi.CodigoIbgeEstado}</cUF>"
                                        + $"<versaoDados>{confi.Versao}</versaoDados>"
                                    + "</mdfeCabecMsg>"
                                + "</soap12:Header>"
                                + "<soap12:Body>"
                                     + "#"
                                + "</soap12:Body>"
                          + "</soap12:Envelope>";
        }
#endif

        /// <remarks/>
        public event mdfeConsultaMDFCompletedEventHandler mdfeConsultaMDFCompleted;

#if NET45
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("mdfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta/mdfeConsultaMDF", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta")]
        public System.Xml.XmlNode mdfeConsultaMDF([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta")] System.Xml.XmlNode mdfeDadosMsg) {
            object[] results = this.Invoke("mdfeConsultaMDF", new object[] {
                mdfeDadosMsg});
#endif
#if NETSTANDARD2_0
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta")]
        public System.Xml.XmlNode mdfeConsultaMDF([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta")] System.Xml.XmlNode mdfeDadosMsg) {
            soapEnvelop = soapEnvelop.Replace("#", mdfeDadosMsg.OuterXml);

            xmlEnvelop = new XmlDocument();
            xmlEnvelop.LoadXml(soapEnvelop);

            object[] results = null; // Chamada da requisi��o
#endif
            return ((System.Xml.XmlNode)(results[0]));
        }
#if NET45
        /// <remarks/>
        public System.IAsyncResult BeginmdfeConsultaMDF(System.Xml.XmlNode mdfeDadosMsg, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("mdfeConsultaMDF", new object[] {
                mdfeDadosMsg}, callback, asyncState);
        }
#endif

#if NET45
        /// <remarks/>
        public System.Xml.XmlNode EndmdfeConsultaMDF(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
#endif
#if NET45
        /// <remarks/>
        public void mdfeConsultaMDFAsync(System.Xml.XmlNode mdfeDadosMsg) {
            this.mdfeConsultaMDFAsync(mdfeDadosMsg, null);
        }
#endif
#if NET45
        /// <remarks/>
        public void mdfeConsultaMDFAsync(System.Xml.XmlNode mdfeDadosMsg, object userState) {
            if ((this.mdfeConsultaMDFOperationCompleted == null)) {
                this.mdfeConsultaMDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeConsultaMDFOperationCompleted);
            }

            this.InvokeAsync("mdfeConsultaMDF", new object[] {
                mdfeDadosMsg}, this.mdfeConsultaMDFOperationCompleted, userState);


        }
#endif
#if NET45
        private void OnmdfeConsultaMDFOperationCompleted(object arg) {
            if ((this.mdfeConsultaMDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.mdfeConsultaMDFCompleted(this, new mdfeConsultaMDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta", IsNullable=false)]
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
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void mdfeConsultaMDFCompletedEventHandler(object sender, mdfeConsultaMDFCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class mdfeConsultaMDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
        private object[] results;
    
        internal mdfeConsultaMDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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