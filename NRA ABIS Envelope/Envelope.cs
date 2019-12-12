using System;
using System.Collections.Generic;
using System.Runtime.Serialization;



namespace NRA_ABIS_Envelope
{
    public sealed class Assembly { }



    //cprid  = verification

    //result = guid



    public enum EnvelopeType
    {
        Biometric_Identification = 1
            ,
        Biometric_Identification_Result = 2
            ,
        Biometric_Information = 3
            ,
        Delete_Record = 4
            ,
        Exception = 5
            ,
        Fingerprint_Identification = 6
            ,
        Fingerprint_Identification_Result = 7
            ,
        Fingerprint_Insert = 8
            ,
        Fingerprint_Template = 9
            ,
        Fingerprint_Verification = 10
            ,
        Portrait_Identification = 11
            ,
        Portrait_Identification_Result = 12
            ,
        Portrait_Verification = 13
            ,
        Template_Extraction = 14
    }

    public enum FingerStatus
    {
        Captured = 1
            ,
        Amputated = 2
    }

    public enum ImageFormat
    {
        BMP = 1
            ,
        GIF = 2
            ,
        ISO_Plus_JPEG2K = 3
            ,
        ISO_Plus_PNG = 4
            ,
        ISO_Plus_Uncompressed = 5
            ,
        ISO_Plus_WSQ = 6
            ,
        JPG = 7
            ,
        JPEG2K = 8
            ,
        PNG = 9
            ,
        TIF = 10
            ,
        WSQ = 11
    }

    public enum TemplateFormat
    {
        ANSI = 1
            ,
        ANSI_Plus = 2
            ,
        ICS = 3
            ,
        ID_Kit_User = 4
            ,
        ISO = 5
            ,
        ISO_Plus = 6
            ,
        ISOCC = 7
    }



    #region --  Request  --

    [DataContract(Name = "NRA_ABIS_Envelope.Request", Namespace = "NRA_ABIS_Envelope.Request", IsReference = false)]
    public sealed class Request
    {
        public Request()
        { }

        public Request(EnvelopeType envelope_type)
        {
            Create_Request(envelope_type, false);
        }

        public Request(EnvelopeType envelope_type, bool CreateGuid)
        {
            Create_Request(envelope_type, CreateGuid);
        }

        private void Create_Request(EnvelopeType envelope_type, bool CreateGuid)
        {
            try
            {
                //create the detail objects based on the response type

                switch (envelope_type)
                {
                    case EnvelopeType.Biometric_Identification:
                    case EnvelopeType.Biometric_Identification_Result:
                    case EnvelopeType.Biometric_Information:

                        Detail.Fingerprint = new List<_Detail._Fingerprint>();
                        Detail.Portrait = new List<_Detail._Portrait>();
                        Detail.Signature = new List<_Detail._Signature>();

                        break;

                    case EnvelopeType.Fingerprint_Identification:
                    case EnvelopeType.Fingerprint_Identification_Result:
                    case EnvelopeType.Fingerprint_Insert:
                    case EnvelopeType.Fingerprint_Verification:

                        Detail.Fingerprint = new List<_Detail._Fingerprint>();

                        break;

                    case EnvelopeType.Portrait_Identification:
                    case EnvelopeType.Portrait_Identification_Result:
                    case EnvelopeType.Portrait_Verification:

                        Detail.Portrait = new List<_Detail._Portrait>();

                        break;

                    case EnvelopeType.Fingerprint_Template:
                    case EnvelopeType.Template_Extraction:

                        Detail.Template = new List<_Detail._Template>();

                        break;
                }
            }

            catch (Exception ex)
            {





            }
        }





        /// <summary>envelope header : contains id's and guids</summary>
        [DataMember(Name = "Request.Header", IsRequired = true, Order = 1)]
        public _Header Header { get; set; } = new _Header();

        /// <summary>envelope details : contains biometric detail</summary>
        [DataMember(Name = "Request.Detail", IsRequired = true, Order = 2)]
        public _Detail Detail { get; set; } = new _Detail();

        [DataContract(Name = "Request.Header")]
        public sealed class _Header
        {
            /// <summary>client identification id</summary>
            [DataMember(Name = "CPRID", IsRequired = true, Order = 3)]
            public long? CPRID { get; set; }

            /// <summary></summary>
            [DataMember(Name = "Guid", IsRequired = true, Order = 4)]
            public Guid? Guid { get; set; }

            /// <summary>internal unique id in guid format : only valid for verification calls</summary>
            [DataMember(Name = "ReferenceUID", IsRequired = true, Order = 5)]
            public string ReferenceUID { get; set; }

            /// <summary>the web service request type</summary>
            [DataMember(Name = "RequestType", IsRequired = true, Order = 6)]
            public EnvelopeType? RequestType { get; set; }
        }

        [DataContract(Name = "Request.Detail")]
        public sealed class _Detail
        {
            /// <summary>list of fingerprint information</summary>
            [DataMember(Name = "Request.Detail.Fingerprint", IsRequired = true, Order = 7)]
            public List<_Fingerprint> Fingerprint { get; set; }

            /// <summary>list of portrait information</summary>
            [DataMember(Name = "Request.Detail.Portrait", IsRequired = true, Order = 8)]
            public List<_Portrait> Portrait { get; set; }

            /// <summary>list of signature information</summary>
            [DataMember(Name = "Request.Detail.Signature", IsRequired = true, Order = 9)]
            public List<_Signature> Signature { get; set; }

            /// <summary>list of signature information</summary>
            [DataMember(Name = "Request.Detail.Template", IsRequired = true, Order = 10)]
            public List<_Template> Template { get; set; }

            [DataContract(Name = "Request.Detail.Fingerprint")]
            public sealed class _Fingerprint
            {
                /// <summary>amputation status of the current finger</summary>
                [DataMember(Name = "Status", IsRequired = true, Order = 11)]
                public FingerStatus? Status { get; set; }

                /// <summary></summary>
                [DataMember(Name = "ImageData", IsRequired = true, Order = 12)]
                public byte[] ImageData { get; set; }

                /// <summary></summary>
                [DataMember(Name = "ImageFormat", IsRequired = true, Order = 13)]
                public ImageFormat? ImageFormat { get; set; }

                /// <summary>the position of the current finger</summary>
                [DataMember(Name = "Postion", IsRequired = true, Order = 14)]
                public int? Postion { get; set; }

                /// <summary>quality score of the current finger</summary>
                [DataMember(Name = "Quality", IsRequired = true, Order = 15)]
                public int? Quality { get; set; }
            }

            [DataContract(Name = "Request.Detail.Portrait")]
            public sealed class _Portrait
            {
                /// <summary>portrait final height : only for original image</summary>
                [DataMember(Name = "CropHeight", IsRequired = true, Order = 16)]
                public int? CropHeight { get; set; }

                /// <summary>portrait left crop length : only for original image</summary>
                [DataMember(Name = "CropLeft", IsRequired = true, Order = 17)]
                public int? CropLeft { get; set; }

                /// <summary>portrait top crop length : only for original image</summary>
                [DataMember(Name = "CropTop", IsRequired = true, Order = 18)]
                public int? CropTop { get; set; }

                /// <summary>portrait final width : only for original image</summary>
                [DataMember(Name = "CropWidth", IsRequired = true, Order = 19)]
                public int? CropWidth { get; set; }

                /// <summary>ICAO compliant portrait image data</summary>
                [DataMember(Name = "ImageDataICAO", IsRequired = true, Order = 20)]
                public byte[] ImageDataICAO { get; set; }

                /// <summary>portrait image data</summary>
                [DataMember(Name = "ImageDataOriginal", IsRequired = true, Order = 21)]
                public byte[] ImageDataOriginal { get; set; }

                /// <summary> : only for original image</summary>
                [DataMember(Name = "ImageFormat", IsRequired = true, Order = 22)]
                public ImageFormat? ImageFormat { get; set; }
            }

            [DataContract(Name = "Request.Detail.Signature")]
            public sealed class _Signature
            {
                /// <summary>signature image data</summary>
                [DataMember(Name = "ImageData", IsRequired = true, Order = 23)]
                public byte[] ImageData { get; set; }

                /// <summary></summary>
                [DataMember(Name = "ImageFormat", IsRequired = true, Order = 24)]
                public ImageFormat? ImageFormat { get; set; }
            }

            [DataContract(Name = "Request.Detail.Template")]
            public sealed class _Template
            {
                /// <summary></summary>
                [DataMember(Name = "Template", IsRequired = true, Order = 25)]
                public byte[] Template { get; set; }

                /// <summary></summary>
                [DataMember(Name = "TemplateFormat", IsRequired = true, Order = 26)]
                public TemplateFormat? TemplateFormat { get; set; }
            }
        }
    }

    #endregion



    #region --  Response  --

    [DataContract(Name = "NRA_ABIS_Envelope.Response", Namespace = "NRA_ABIS_Envelope.Response", IsReference = false)]
    public sealed class Response
    {
        public Response()
        { }

        public Response(EnvelopeType envelope_type, bool is_excpetion = false)
        {
            Create_Response(envelope_type, false, is_excpetion);
        }

        public Response(EnvelopeType envelope_type, bool create_guid, bool is_excpetion = false)
        {
            Create_Response(envelope_type, create_guid, is_excpetion);
        }

        private void Create_Response(EnvelopeType envelope_type, bool create_guid, bool is_excpetion)
        {
            try
            {
                //when it is not an exception object, create the detail objects based on the envelope type

                if (!is_excpetion)
                {
                    switch (envelope_type)
                    {
                        case EnvelopeType.Biometric_Identification:
                        case EnvelopeType.Biometric_Identification_Result:
                        case EnvelopeType.Biometric_Information:

                            Detail.Fingerprint = new List<_Detail._Fingerprint>();
                            Detail.Portrait = new List<_Detail._Portrait>();
                            Detail.Signature = new List<_Detail._Signature>();

                            break;

                        case EnvelopeType.Fingerprint_Identification:
                        case EnvelopeType.Fingerprint_Identification_Result:
                        case EnvelopeType.Fingerprint_Insert:
                        case EnvelopeType.Fingerprint_Verification:

                            Detail.Fingerprint = new List<_Detail._Fingerprint>();

                            break;

                        case EnvelopeType.Portrait_Identification:
                        case EnvelopeType.Portrait_Identification_Result:
                        case EnvelopeType.Portrait_Verification:

                            Detail.Portrait = new List<_Detail._Portrait>();

                            break;

                        case EnvelopeType.Fingerprint_Template:
                        case EnvelopeType.Template_Extraction:

                            Detail.Template = new List<_Detail._Template>();

                            break;
                    }

                    //create a guid

                    if (create_guid)
                    {
                        this.Header.Guid = Guid.NewGuid();
                    }
                }

                //set the reponse type

                this.Footer.ResponseType = envelope_type;
            }

            catch (Exception ex)
            {





            }
        }

        /// <summary>envelope header : contains id's and guids</summary>
        [DataMember(Name = "Response.Header", IsRequired = true, Order = 1)]
        public _Header Header { get; set; } = new _Header();

        /// <summary>envelope details : contains biometric detail</summary>
        [DataMember(Name = "Response.Detail", IsRequired = true, Order = 2)]
        public _Detail Detail { get; set; } = new _Detail();

        /// <summary>envelope footer : contains response type, code and message</summary>
        [DataMember(Name = "Response.Footer", IsRequired = true, Order = 3)]
        public _Footer Footer { get; set; } = new _Footer();

        [DataContract(Name = "Response.Header")]
        public sealed class _Header
        {
            /// <summary>client identification id</summary>
            [DataMember(Name = "CPRID", IsRequired = true, Order = 4)]
            public long? CPRID { get; set; }

            /// <summary></summary>
            [DataMember(Name = "Guid", IsRequired = true, Order = 5)]
            public Guid? Guid { get; set; }

            /// <summary>internal unique id in guid format : only valid for verification calls</summary>
            [DataMember(Name = "ReferenceUID", IsRequired = true, Order = 6)]
            public string ReferenceUID { get; set; }
        }

        [DataContract(Name = "Response.Detail")]
        public sealed class _Detail
        {
            /// <summary>list of fingerprint information</summary>
            [DataMember(Name = "Response.Detail.Fingerprint", IsRequired = true, Order = 7)]
            public List<_Fingerprint> Fingerprint { get; set; }

            /// <summary>list of portrait information</summary>
            [DataMember(Name = "Response.Detail.Portrait", IsRequired = true, Order = 8)]
            public List<_Portrait> Portrait { get; set; }

            /// <summary>list of signature information</summary>
            [DataMember(Name = "Response.Detail.Signature", IsRequired = true, Order = 9)]
            public List<_Signature> Signature { get; set; }

            /// <summary>list of signature information</summary>
            [DataMember(Name = "Response.Detail.Template", IsRequired = true, Order = 10)]
            public List<_Template> Template { get; set; }

            [DataContract(Name = "Response.Detail.Fingerprint")]
            public sealed class _Fingerprint
            {
                /// <summary>amputation status of the current finger</summary>
                [DataMember(Name = "Status", IsRequired = true, Order = 11)]
                public FingerStatus? Status { get; set; }

                /// <summary></summary>
                [DataMember(Name = "ImageData", IsRequired = true, Order = 12)]
                public byte[] ImageData { get; set; }

                /// <summary>the position of the current finger</summary>
                [DataMember(Name = "Postion", IsRequired = true, Order = 13)]
                public int? Postion { get; set; }

                /// <summary>quality score of the current finger</summary>
                [DataMember(Name = "Quality", IsRequired = true, Order = 14)]
                public int? Quality { get; set; }

                /// <summary></summary>
                [DataMember(Name = "ImageFormat", IsRequired = true, Order = 15)]
                public ImageFormat? ImageFormat { get; set; }
            }

            [DataContract(Name = "Response.Detail.Portrait")]
            public sealed class _Portrait
            {
                /// <summary>portrait left crop length : to be confirmed</summary>
                [DataMember(Name = "CropLeft", IsRequired = true, Order = 16)]
                public int? CropLeft { get; set; }

                /// <summary>portrait top crop length : to be confirmed</summary>
                [DataMember(Name = "CropTop", IsRequired = true, Order = 17)]
                public int? CropTop { get; set; }

                /// <summary>portrait final width : to be confirmed</summary>
                [DataMember(Name = "CropWidth", IsRequired = true, Order = 18)]
                public int? CropWidth { get; set; }

                /// <summary>portrait final height : to be confirmed</summary>
                [DataMember(Name = "CropHeight", IsRequired = true, Order = 19)]
                public int? CropHeight { get; set; }

                /// <summary>ICAO compliant portrait image data</summary>
                [DataMember(Name = "ImageDataICAO", IsRequired = true, Order = 20)]
                public byte[] ImageDataICAO { get; set; }

                /// <summary>portrait image data</summary>
                [DataMember(Name = "ImageDataOriginal", IsRequired = true, Order = 21)]
                public byte[] ImageDataOriginal { get; set; }

                /// <summary>original image data format</summary>
                [DataMember(Name = "ImageFormat", IsRequired = true, Order = 22)]
                public ImageFormat? ImageFormat { get; set; }
            }

            [DataContract(Name = "Response.Detail.Signature")]
            public sealed class _Signature
            {
                /// <summary>signature image data</summary>
                [DataMember(Name = "ImageData", IsRequired = true, Order = 23)]
                public byte[] ImageData { get; set; }

                /// <summary></summary>
                [DataMember(Name = "ImageFormat", IsRequired = true, Order = 24)]
                public ImageFormat? ImageFormat { get; set; }
            }

            [DataContract(Name = "Response.Detail.Template")]
            public sealed class _Template
            {
                /// <summary></summary>
                [DataMember(Name = "Template", IsRequired = true, Order = 25)]
                public byte[] Template { get; set; }

                /// <summary></summary>
                [DataMember(Name = "TemplateFormat", IsRequired = true, Order = 26)]
                public TemplateFormat? TemplateFormat { get; set; }
            }
        }

        [DataContract(Name = "Response.Footer")]
        public sealed class _Footer
        {
            /// <summary>the date and time when the request was received</summary>
            [DataMember(Name = "RequestDateTime", IsRequired = true, Order = 27)]
            public DateTime? RequestDateTime { get; set; }

            /// <summary>the web service call response code</summary>
            [DataMember(Name = "ResponseCode", IsRequired = true, Order = 28)]
            public int? ResponseCode { get; set; }

            /// <summary>the web service call response message</summary>
            [DataMember(Name = "ResponseMessage", IsRequired = true, Order = 29)]
            public string ResponseMessage { get; set; }

            /// <summary>the web service call reponse status</summary>
            [DataMember(Name = "ResponseStatus", IsRequired = true, Order = 30)]
            public bool? ResponseStatus { get; set; }

            /// <summary>the web service reponse type based on the web service call that was made</summary>
            [DataMember(Name = "ResponseType", IsRequired = true, Order = 31)]
            public EnvelopeType? ResponseType { get; set; }

            /// <summary>the date and time when the response was sent</summary>
            [DataMember(Name = "ResponseDateTime", IsRequired = true, Order = 32)]
            public DateTime? ResponseDateTime { get; set; }
        }
    }

    #endregion

}