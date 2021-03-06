﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.17929
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.17929。
// 
#pragma warning disable 1591

namespace TechDays2013.wcfconvert {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IConvert", Namespace="http://tempuri.org/")]
    public partial class WCFTempService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CelsiusToFahrenheitOperationCompleted;
        
        private System.Threading.SendOrPostCallback FahrenheitToCelsiusOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WCFTempService() {
            this.Url = "http://wcfconvert.azurewebsites.net/WCFTempService.svc";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CelsiusToFahrenheitCompletedEventHandler CelsiusToFahrenheitCompleted;
        
        /// <remarks/>
        public event FahrenheitToCelsiusCompletedEventHandler FahrenheitToCelsiusCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IConvert/CelsiusToFahrenheit", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CelsiusToFahrenheit([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Celsius) {
            object[] results = this.Invoke("CelsiusToFahrenheit", new object[] {
                        Celsius});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CelsiusToFahrenheitAsync(string Celsius) {
            this.CelsiusToFahrenheitAsync(Celsius, null);
        }
        
        /// <remarks/>
        public void CelsiusToFahrenheitAsync(string Celsius, object userState) {
            if ((this.CelsiusToFahrenheitOperationCompleted == null)) {
                this.CelsiusToFahrenheitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCelsiusToFahrenheitOperationCompleted);
            }
            this.InvokeAsync("CelsiusToFahrenheit", new object[] {
                        Celsius}, this.CelsiusToFahrenheitOperationCompleted, userState);
        }
        
        private void OnCelsiusToFahrenheitOperationCompleted(object arg) {
            if ((this.CelsiusToFahrenheitCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CelsiusToFahrenheitCompleted(this, new CelsiusToFahrenheitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IConvert/FahrenheitToCelsius", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string FahrenheitToCelsius([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string Fahrenheit) {
            object[] results = this.Invoke("FahrenheitToCelsius", new object[] {
                        Fahrenheit});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void FahrenheitToCelsiusAsync(string Fahrenheit) {
            this.FahrenheitToCelsiusAsync(Fahrenheit, null);
        }
        
        /// <remarks/>
        public void FahrenheitToCelsiusAsync(string Fahrenheit, object userState) {
            if ((this.FahrenheitToCelsiusOperationCompleted == null)) {
                this.FahrenheitToCelsiusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFahrenheitToCelsiusOperationCompleted);
            }
            this.InvokeAsync("FahrenheitToCelsius", new object[] {
                        Fahrenheit}, this.FahrenheitToCelsiusOperationCompleted, userState);
        }
        
        private void OnFahrenheitToCelsiusOperationCompleted(object arg) {
            if ((this.FahrenheitToCelsiusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FahrenheitToCelsiusCompleted(this, new FahrenheitToCelsiusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CelsiusToFahrenheitCompletedEventHandler(object sender, CelsiusToFahrenheitCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CelsiusToFahrenheitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CelsiusToFahrenheitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void FahrenheitToCelsiusCompletedEventHandler(object sender, FahrenheitToCelsiusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FahrenheitToCelsiusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FahrenheitToCelsiusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591