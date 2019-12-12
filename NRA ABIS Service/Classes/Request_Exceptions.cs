using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using NRA_ABIS_Service.utils;



namespace NRA_ABIS_Service
{


    internal enum Exception_Type
    {
        success = 0
            ,
        no_request_object = 1
            ,
        no_header_object = 2
            ,
        no_cpr_id = 3
            ,
        no_guid = 4
            ,
        no_reference_uid = 5
            ,
        no_request_type = 6
            ,
        invalid_request_type = 7
            ,
        no_detail_object = 8
            ,
        no_fingerprint_object = 9
            ,
        no_fingerprint_data = 10
            ,
        no_fingerprint_status = 11
            ,
        no_fingerprint_image_data = 12
            ,
        invalid_fingerprint_image_data_length = 13
            ,
        no_fingerprint_image_format = 14
            ,
        no_fingerprint_position = 15
            ,
        no_fingerprint_quality = 16
            ,
        no_portrait_object = 17
            ,
        no_portrait_data = 18
            ,
        no_portrait_image_data = 19
            ,
        double_portrait_image_data = 20
            ,
        no_portrait_crop_height = 21
            ,
        no_portrait_crop_left = 22
            ,
        no_portrait_crop_top = 23
            ,
        no_portrait_crop_width = 24
            ,
        no_portrait_image_data_original = 25
            ,
        invalid_portrait_image_data_original_length = 26
            ,
        no_portrait_image_format = 27
            ,
        no_portrait_image_data_icao = 28
            ,
        invalid_portrait_image_data_icao_length = 29
            ,
        no_signature_object = 30
            ,
        no_signature_data = 31
            ,
        no_signature_image_data = 32
            ,
        invalid_signature_image_data_length = 33
            ,
        no_signature_image_format = 34
            ,
        no_template_object = 35
            ,
        no_template_data = 36
            ,
        no_template_image_data = 37
            ,
        invalid_template_data_length = 38
            ,
        no_template_format = 39
    }



    internal static class Request_Exceptions
    {
        /// <summary></summary>
        internal static NRA_ABIS_Envelope.Response._Footer Set_Exception(NRA_ABIS_Envelope.EnvelopeType envelope_type, DateTime request_date_time, Exception_Type exception_type, int data_index = 0)
        {
            int? log_code = 0000;

            string log_source = envelope_type.ToString();

            string log_message = string.Empty;

            bool log_status = false;

            NRA_ABIS_Envelope.Response._Footer footer = null;

            try
            {
                switch (exception_type)
                {
                    case Exception_Type.success:

                        log_code = 1001;

                        log_message = "success";

                        log_status = true;

                        break;

                    case Exception_Type.no_request_object:

                        log_code = 1002;

                        log_message = "no request object";

                        break;

                    case Exception_Type.no_header_object:

                        log_code = 1003;

                        log_message = "no header object in request";

                        break;

                    case Exception_Type.no_cpr_id:

                        log_code = 1004;

                        log_message = "no cprid in request header";

                        break;

                    case Exception_Type.no_guid:

                        log_code = 1005;

                        log_message = "no guid in request header";

                        break;

                    case Exception_Type.no_reference_uid:

                        log_code = 1006;

                        log_message = "no reference uid in request header";

                        break;

                    case Exception_Type.no_request_type:

                        log_code = 1007;

                        log_message = "no request type in request header";

                        break;

                    case Exception_Type.invalid_request_type:

                        log_code = 1008;

                        log_message = "invalid request type in request header";

                        break;

                    case Exception_Type.no_detail_object:

                        log_code = 1009;

                        log_message = "no detail object in request";

                        break;

                    case Exception_Type.no_fingerprint_object:

                        log_code = 1010;

                        log_message = "no fingerprint object in request";

                        break;

                    case Exception_Type.no_fingerprint_data:

                        log_code = 1011;

                        log_message = "no fingerprint data in request";

                        break;

                    case Exception_Type.no_fingerprint_status:

                        log_code = 1012;

                        log_message = "no fingerprint status on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_fingerprint_image_data:

                        log_code = 1013;

                        log_message = "no fingerprint image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.invalid_fingerprint_image_data_length:

                        log_code = 1014;

                        log_message = "invalid fingerprint image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_fingerprint_image_format:

                        log_code = 1015;

                        log_message = "no fingerprint image format on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_fingerprint_position:

                        log_code = 1016;

                        log_message = "no fingerprint position on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_fingerprint_quality:

                        log_code = 1017;

                        log_message = "no fingerprint quality on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_object:

                        log_code = 1018;

                        log_message = "no portrait object in request";

                        break;

                    case Exception_Type.no_portrait_data:

                        log_code = 1019;

                        log_message = "no portrait data in request";

                        break;

                    case Exception_Type.no_portrait_image_data:

                        log_code = 1020;

                        log_message = "no portrait image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.double_portrait_image_data:

                        log_code = 1021;

                        log_message = "double portrait image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_crop_height:

                        log_code = 1022;

                        log_message = "no portrait crop height on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_crop_left:

                        log_code = 1023;

                        log_message = "no portrait crop left on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_crop_top:

                        log_code = 1024;

                        log_message = "no portrait crop top on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_crop_width:

                        log_code = 1025;

                        log_message = "no portrait crop width on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_image_data_original:

                        log_code = 1026;

                        log_message = "no original portrait image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.invalid_portrait_image_data_original_length:

                        log_code = 1027;

                        log_message = "invalid original portrait image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_image_format:

                        log_code = 1028;

                        log_message = "no portrait image format on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_portrait_image_data_icao:

                        log_code = 1029;

                        log_message = "no portrait image icao data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.invalid_portrait_image_data_icao_length:

                        log_code = 1030;

                        log_message = "invalid icao portrait image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_signature_object:

                        log_code = 1031;

                        log_message = "no signature object in request";

                        break;

                    case Exception_Type.no_signature_data:

                        log_code = 1032;

                        log_message = "no signature data in request";

                        break;

                    case Exception_Type.no_signature_image_data:

                        log_code = 1033;

                        log_message = "no signature image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.invalid_signature_image_data_length:

                        log_code = 1034;

                        log_message = "invalid signature image data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_signature_image_format:

                        log_code = 1035;

                        log_message = "no signature image format on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_template_object:

                        log_code = 1036;

                        log_message = "no template object in request";

                        break;

                    case Exception_Type.no_template_data:

                        log_code = 1037;

                        log_message = "no template data in request";

                        break;

                    case Exception_Type.no_template_image_data:

                        log_code = 1038;

                        log_message = "no template data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.invalid_template_data_length:

                        log_code = 1039;

                        log_message = "invalid template data on index " + data_index.ToString() + " in request";

                        break;

                    case Exception_Type.no_template_format:

                        log_code = 1040;

                        log_message = "no template format on index " + data_index.ToString() + " in request";

                        break;
                }

                //create the response footer

                footer = new NRA_ABIS_Envelope.Response._Footer()
                {
                    ResponseCode = log_code
                    ,
                    ResponseMessage = log_message
                    ,
                    ResponseType = envelope_type
                    ,
                    ResponseStatus = log_status
                };

                //write to log

                Write_To_Log(log_code, log_source, log_message, log_status);
            }

            catch (Exception ex)
            {
                footer = Set_Exception(envelope_type, ex);
            }

            //return

            return footer;
        }

        /// <summary></summary>
        /// <param name="envelope_type"></param>
        /// <param name="exception"></param>
        internal static NRA_ABIS_Envelope.Response._Footer Set_Exception(NRA_ABIS_Envelope.EnvelopeType envelope_type, Exception exception)
        {
            int? log_code;

            string log_source = envelope_type.ToString();

            string log_message = string.Empty;

            NRA_ABIS_Envelope.Response._Footer footer = null;

            try
            {
                //set the parameters

                log_code = 1098;

                log_message = exception.Message.ToLower();

                //create the response footer

                footer = new NRA_ABIS_Envelope.Response._Footer()
                {
                    ResponseCode = log_code
                    ,
                    ResponseMessage = log_message
                    ,
                    ResponseType = envelope_type
                    ,
                    ResponseStatus = false
                };
            }

            catch (Exception ex)
            {
                //set the parameters

                log_code = 1099;

                log_message = ex.Message.ToLower();

                //create the response footer

                footer = new NRA_ABIS_Envelope.Response._Footer()
                {
                    ResponseCode = log_code
                    ,
                    ResponseMessage = log_message
                    ,
                    ResponseType = envelope_type
                    ,
                    ResponseStatus = false
                };

            }

            //write to log

            Write_To_Log(log_code, log_source, log_message, false);

            //return

            return footer;
        }


        /// <summary></summary>
        private static void Write_To_Log(int? log_code, string log_source, string log_message, bool log_status)
        {
            Logging logging = new Logging();

            try
            {
                logging.WriteToTransactionLog
                    (
                          "Log Server : " + Environment.MachineName
                        + Environment.NewLine
                        + "Log Source : " + log_source
                        + Environment.NewLine
                        + "Log Status : " + log_status
                        + Environment.NewLine
                        + "Log Code : " + log_code.ToString()
                        + Environment.NewLine
                        + "Log Message : " + log_message
                    );
            }

            catch (Exception ex)
            {
                logging.Handle_Exception(ex);
            }
        }
    }
}