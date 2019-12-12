using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;



namespace NRA_ABIS_Service
{
    /// <summary>
    /// Namibia ABIS Backend Interface Service
    /// </summary>
    [ServiceContract]
    public interface INRA_ABIS_Service
    {

        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Is_Service_Running_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Is_Service_Running_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Is_Service_Running", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        bool Is_Service_Running();

        



        /// <summary>Asyncronous</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Biometric_Identification_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Biometric_Identification_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Biometric_Identification", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Biometric_Identification(NRA_ABIS_Envelope.Request Request);

        /// <summary>Asyncronous</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Biometric_Identification_Result_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Biometric_Identification_Result_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Biometric_Identification_Result", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Biometric_Identification_Result(NRA_ABIS_Envelope.Request Request);

        /// <summary>Synchronous</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Biometric_Information_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Biometric_Information_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Biometric_Information", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Biometric_Information(NRA_ABIS_Envelope.Request Request);





        /// <summary>Asynchronuos : </summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Identification_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Identification_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Fingerprint_Identification", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Fingerprint_Identification(NRA_ABIS_Envelope.Request Request);

        /// <summary>Asynchronuos</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Identification_Result_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Identification_Result_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Fingerprint_Identification_Result", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Fingerprint_Identification_Result(NRA_ABIS_Envelope.Request Request);

        /// <summary>Unconfirmed service call</summary>
        /// <returns></returns>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Insert_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Insert_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Fingerprint_Insert", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Fingerprint_Insert(NRA_ABIS_Envelope.Request request);

        /// <summary>Synchronous</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Template_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Template_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Fingerprint_Template", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Fingerprint_Template(NRA_ABIS_Envelope.Request Request);

        /// <summary>Synchronous : Fingerprint verification service operation</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Verification_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Fingerprint_Verification_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Fingerprint_Verification", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Fingerprint_Verification(NRA_ABIS_Envelope.Request Request);





        /// <summary>Asynchronuos</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Portrait_Identification_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Portrait_Identification_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Portrait_Identification", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Portrait_Identification(NRA_ABIS_Envelope.Request Request);

        /// <summary>Asynchronuos</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Portrait_Identification_Result_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Portrait_Identification_Result_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Portrait_Identification_Result", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Portrait_Identification_Result(NRA_ABIS_Envelope.Request Request);

        /// <summary>Synchronous</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Portrait_Verification_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Portrait_Verification_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Portrait_Verification", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Portrait_Verification(NRA_ABIS_Envelope.Request Request);





        /// <summary>Unconfirmed</summary>
        [OperationContract(Action = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Delete_Record_Request", ReplyAction = "http://localhost:49950/Services/NRA_ABIS_Service.svc/Delete_Record_Response")]
        [WebInvoke(Method = "POST", UriTemplate = "/Delete_Record", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        NRA_ABIS_Envelope.Response Delete_Record(NRA_ABIS_Envelope.Request request);

    }
}