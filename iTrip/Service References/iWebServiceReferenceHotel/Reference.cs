﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.3082
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace iTrip.iWebServiceReferenceHotel {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="iWebServiceReferenceHotel.iWebServiceHotelSoap")]
    public interface iWebServiceHotelSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetHotelList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        System.Data.DataSet GetHotelList(string userName, string whereStr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetHotelOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        iTrip.iWebServiceReferenceHotel.HOTEL_ORDER GetHotelOrder(int HOTEL_ORDER_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddHotelOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        void AddHotelOrder(iTrip.iWebServiceReferenceHotel.HOTEL_ORDER Entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateHotelOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        void UpdateHotelOrder(iTrip.iWebServiceReferenceHotel.HOTEL_ORDER Entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteHotelOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        void DeleteHotelOrder(int HOTEL_ORDER_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOrderHotelList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        System.Data.DataSet GetOrderHotelList(string userName);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HOTEL_ORDER : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int hOTEL_ORDER_IDField;
        
        private int rOOM_IDField;
        
        private string uSER_NAMEField;
        
        private System.Nullable<System.DateTime> cHECK_INField;
        
        private System.Nullable<System.DateTime> cHECK_OUTField;
        
        private System.Nullable<decimal> fAREField;
        
        private System.Nullable<int> cONFIRM_FLAGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int HOTEL_ORDER_ID {
            get {
                return this.hOTEL_ORDER_IDField;
            }
            set {
                this.hOTEL_ORDER_IDField = value;
                this.RaisePropertyChanged("HOTEL_ORDER_ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int ROOM_ID {
            get {
                return this.rOOM_IDField;
            }
            set {
                this.rOOM_IDField = value;
                this.RaisePropertyChanged("ROOM_ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string USER_NAME {
            get {
                return this.uSER_NAMEField;
            }
            set {
                this.uSER_NAMEField = value;
                this.RaisePropertyChanged("USER_NAME");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public System.Nullable<System.DateTime> CHECK_IN {
            get {
                return this.cHECK_INField;
            }
            set {
                this.cHECK_INField = value;
                this.RaisePropertyChanged("CHECK_IN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public System.Nullable<System.DateTime> CHECK_OUT {
            get {
                return this.cHECK_OUTField;
            }
            set {
                this.cHECK_OUTField = value;
                this.RaisePropertyChanged("CHECK_OUT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=5)]
        public System.Nullable<decimal> FARE {
            get {
                return this.fAREField;
            }
            set {
                this.fAREField = value;
                this.RaisePropertyChanged("FARE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        public System.Nullable<int> CONFIRM_FLAG {
            get {
                return this.cONFIRM_FLAGField;
            }
            set {
                this.cONFIRM_FLAGField = value;
                this.RaisePropertyChanged("CONFIRM_FLAG");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface iWebServiceHotelSoapChannel : iTrip.iWebServiceReferenceHotel.iWebServiceHotelSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class iWebServiceHotelSoapClient : System.ServiceModel.ClientBase<iTrip.iWebServiceReferenceHotel.iWebServiceHotelSoap>, iTrip.iWebServiceReferenceHotel.iWebServiceHotelSoap {
        
        public iWebServiceHotelSoapClient() {
        }
        
        public iWebServiceHotelSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public iWebServiceHotelSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public iWebServiceHotelSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public iWebServiceHotelSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetHotelList(string userName, string whereStr) {
            return base.Channel.GetHotelList(userName, whereStr);
        }
        
        public iTrip.iWebServiceReferenceHotel.HOTEL_ORDER GetHotelOrder(int HOTEL_ORDER_ID) {
            return base.Channel.GetHotelOrder(HOTEL_ORDER_ID);
        }
        
        public void AddHotelOrder(iTrip.iWebServiceReferenceHotel.HOTEL_ORDER Entity) {
            base.Channel.AddHotelOrder(Entity);
        }
        
        public void UpdateHotelOrder(iTrip.iWebServiceReferenceHotel.HOTEL_ORDER Entity) {
            base.Channel.UpdateHotelOrder(Entity);
        }
        
        public void DeleteHotelOrder(int HOTEL_ORDER_ID) {
            base.Channel.DeleteHotelOrder(HOTEL_ORDER_ID);
        }
        
        public System.Data.DataSet GetOrderHotelList(string userName) {
            return base.Channel.GetOrderHotelList(userName);
        }
    }
}
