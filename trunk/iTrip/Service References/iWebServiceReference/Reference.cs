﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.1433
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace iTrip.iWebServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="iWebServiceReference.iWebServiceSoap")]
    public interface iWebServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 USER_NAME 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateUser", ReplyAction="*")]
        iTrip.iWebServiceReference.ValidateUserResponse ValidateUser(iTrip.iWebServiceReference.ValidateUserRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateUser", Namespace="http://tempuri.org/", Order=0)]
        public iTrip.iWebServiceReference.ValidateUserRequestBody Body;
        
        public ValidateUserRequest() {
        }
        
        public ValidateUserRequest(iTrip.iWebServiceReference.ValidateUserRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateUserRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string USER_NAME;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string PASSWORD;
        
        public ValidateUserRequestBody() {
        }
        
        public ValidateUserRequestBody(string USER_NAME, string PASSWORD) {
            this.USER_NAME = USER_NAME;
            this.PASSWORD = PASSWORD;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateUserResponse", Namespace="http://tempuri.org/", Order=0)]
        public iTrip.iWebServiceReference.ValidateUserResponseBody Body;
        
        public ValidateUserResponse() {
        }
        
        public ValidateUserResponse(iTrip.iWebServiceReference.ValidateUserResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateUserResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool ValidateUserResult;
        
        public ValidateUserResponseBody() {
        }
        
        public ValidateUserResponseBody(bool ValidateUserResult) {
            this.ValidateUserResult = ValidateUserResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface iWebServiceSoapChannel : iTrip.iWebServiceReference.iWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class iWebServiceSoapClient : System.ServiceModel.ClientBase<iTrip.iWebServiceReference.iWebServiceSoap>, iTrip.iWebServiceReference.iWebServiceSoap {
        
        public iWebServiceSoapClient() {
        }
        
        public iWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public iWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public iWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public iWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        iTrip.iWebServiceReference.ValidateUserResponse iTrip.iWebServiceReference.iWebServiceSoap.ValidateUser(iTrip.iWebServiceReference.ValidateUserRequest request) {
            return base.Channel.ValidateUser(request);
        }
        
        public bool ValidateUser(string USER_NAME, string PASSWORD) {
            iTrip.iWebServiceReference.ValidateUserRequest inValue = new iTrip.iWebServiceReference.ValidateUserRequest();
            inValue.Body = new iTrip.iWebServiceReference.ValidateUserRequestBody();
            inValue.Body.USER_NAME = USER_NAME;
            inValue.Body.PASSWORD = PASSWORD;
            iTrip.iWebServiceReference.ValidateUserResponse retVal = ((iTrip.iWebServiceReference.iWebServiceSoap)(this)).ValidateUser(inValue);
            return retVal.Body.ValidateUserResult;
        }
    }
}
