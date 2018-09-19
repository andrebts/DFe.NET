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
using System.Security.Cryptography.X509Certificates;
using SMDFe.Wsdl.Configuracao;

namespace SMDFe.Wsdl.Gerado.MDFeRetRecepcao
{ // 
  // This source code was auto-generated by wsdl, Version=4.6.1055.0.
  // 

#if NET45
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MDFeRetRecepcaoSoap12", Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
    public partial class MDFeRetRecepcao : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
        private mdfeCabecMsg mdfeCabecMsgValueField;
    
        private System.Threading.SendOrPostCallback mdfeRetRecepcaoOperationCompleted;
    
        /// <remarks/>
        public MDFeRetRecepcao(WsdlConfiguracao configuracao) {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = configuracao.Url;
            mdfeCabecMsgValue = new mdfeCabecMsg
            {
                versaoDados = configuracao.Versao,
                cUF = configuracao.CodigoIbgeEstado
            };
            this.ClientCertificates.Add(configuracao.CertificadoDigital);
            this.Timeout = configuracao.TimeOut;
        }
    
        public mdfeCabecMsg mdfeCabecMsgValue {
            get {
                return this.mdfeCabecMsgValueField;
            }
            set {
                this.mdfeCabecMsgValueField = value;
            }
        }
    
        /// <remarks/>
        public event mdfeRetRecepcaoCompletedEventHandler mdfeRetRecepcaoCompleted;
    
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("mdfeCabecMsgValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao/mdfeRetRecepcao", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
        public System.Xml.XmlNode mdfeRetRecepcao([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")] System.Xml.XmlNode mdfeDadosMsg) {
            object[] results = this.Invoke("mdfeRetRecepcao", new object[] {
                mdfeDadosMsg});
            return ((System.Xml.XmlNode)(results[0]));
        }
    
        /// <remarks/>
        public System.IAsyncResult BeginmdfeRetRecepcao(System.Xml.XmlNode mdfeDadosMsg, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("mdfeRetRecepcao", new object[] {
                mdfeDadosMsg}, callback, asyncState);
        }
    
        /// <remarks/>
        public System.Xml.XmlNode EndmdfeRetRecepcao(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
    
        /// <remarks/>
        public void mdfeRetRecepcaoAsync(System.Xml.XmlNode mdfeDadosMsg) {
            this.mdfeRetRecepcaoAsync(mdfeDadosMsg, null);
        }
    
        /// <remarks/>
        public void mdfeRetRecepcaoAsync(System.Xml.XmlNode mdfeDadosMsg, object userState) {
            if ((this.mdfeRetRecepcaoOperationCompleted == null)) {
                this.mdfeRetRecepcaoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeRetRecepcaoOperationCompleted);
            }
            this.InvokeAsync("mdfeRetRecepcao", new object[] {
                mdfeDadosMsg}, this.mdfeRetRecepcaoOperationCompleted, userState);
        }
    
        private void OnmdfeRetRecepcaoOperationCompleted(object arg) {
            if ((this.mdfeRetRecepcaoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.mdfeRetRecepcaoCompleted(this, new mdfeRetRecepcaoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
    
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao", IsNullable=false)]
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
#else
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MDFeRetRecepcao 
    {

        private mdfeCabecMsg mdfeCabecMsgValueField;

        private System.Threading.SendOrPostCallback mdfeRetRecepcaoOperationCompleted;

        /// <remarks/>
        public MDFeRetRecepcao(WsdlConfiguracao configuracao)
        {
            
        }

        public mdfeCabecMsg mdfeCabecMsgValue
        {
            get
            {
                return this.mdfeCabecMsgValueField;
            }
            set
            {
                this.mdfeCabecMsgValueField = value;
            }
        }

        /// <remarks/>
        public event mdfeRetRecepcaoCompletedEventHandler mdfeRetRecepcaoCompleted;

        /// <remarks/>
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
        public System.Xml.XmlNode mdfeRetRecepcao([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")] System.Xml.XmlNode mdfeDadosMsg)
        {
            return null;
        }

        /// <remarks/>
        public System.IAsyncResult BeginmdfeRetRecepcao(System.Xml.XmlNode mdfeDadosMsg, System.AsyncCallback callback, object asyncState)
        {
            return null;
        }

        /// <remarks/>
        public System.Xml.XmlNode EndmdfeRetRecepcao(System.IAsyncResult asyncResult)
        {
            return null;
        }

        /// <remarks/>
        public void mdfeRetRecepcaoAsync(System.Xml.XmlNode mdfeDadosMsg)
        {
            this.mdfeRetRecepcaoAsync(mdfeDadosMsg, null);
        }

        /// <remarks/>
        public void mdfeRetRecepcaoAsync(System.Xml.XmlNode mdfeDadosMsg, object userState)
        {
            if ((this.mdfeRetRecepcaoOperationCompleted == null))
            {
                this.mdfeRetRecepcaoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmdfeRetRecepcaoOperationCompleted);
            }
           
        }

        private void OnmdfeRetRecepcaoOperationCompleted(object arg)
        {
           
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
           
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRetRecepcao", IsNullable = false)]
    public partial class mdfeCabecMsg 
    {

        private string cUFField;

        private string versaoDadosField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string cUF
        {
            get
            {
                return this.cUFField;
            }
            set
            {
                this.cUFField = value;
            }
        }

        /// <remarks/>
        public string versaoDados
        {
            get
            {
                return this.versaoDadosField;
            }
            set
            {
                this.versaoDadosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
#endif
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void mdfeRetRecepcaoCompletedEventHandler(object sender, mdfeRetRecepcaoCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class mdfeRetRecepcaoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
        private object[] results;
    
        internal mdfeRetRecepcaoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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