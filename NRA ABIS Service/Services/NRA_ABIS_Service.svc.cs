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
    public class NRA_ABIS_Service : INRA_ABIS_Service
    {

        ///// <summary>minimum byte length for fingerprint image data</summary>
        //private const int min_fingerprint_image_data_length = 100;

        ///// <summary>minimum byte length for fingerprint template data</summary>
        //private const int min_fingerprint_template_length = 100;

        ///// <summary>minimum byte length for icao portrait image data</summary>
        //private const int min_portrait_image_data_icao_length = 100;

        ///// <summary>minimum byte length for original portrait image data</summary>
        //private const int min_portrait_image_data_original_length = 100;

        ///// <summary>minimum byte length for signature image data</summary>
        //private const int min_signature_image_data_length = 100;



        /// <summary>Syncronous : Function to check if the service is running
        public bool Is_Service_Running()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }


        #region --  biometrics  --

        /// <summary>Asyncronous : Operation for identifying CPR using biometric information</summary>
        public NRA_ABIS_Envelope.Response Biometric_Identification(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Biometric_Identification;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }









                //List<Fingerprint> FingerList = new List<Fingerprint>();
                //List<Fingerprint> TempFingerList = biometricInfo.fingerprints.OfType<Fingerprint>().ToList();

                //if (TempFingerList.Count < 1)
                //{
                //    //response = new IdentificationResponse();
                //    genericResponse = new GenericResponse() { ResponseCode = 1005, ResponseMessage = "No Fingerprints Images Available", ResponseObject = response };

                //    cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "BiometricIdentification", Environment.NewLine, "No Fingerprints Images Available"));
                //    //return genericResponse;
                //}



                //foreach (Fingerprint fin in TempFingerList)
                //{
                //    if (fin != null)
                //    {
                //        if (fin.status != 0 && fin.wsqImage != null)
                //        {
                //            FingerList.Add(fin);
                //        }
                //    }
                //}



                // Determine which fingers are available and send them for matching
                //response = new IdentificationResponse()
                //{
                //    CPR_ID = long.Parse(DateTime.Now.ToString("yyMMddHHmmssfff"))
                //    ,
                //    ReferenceUniqID = Guid.NewGuid().ToString().ToUpper()
                //};
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Total of: " + FingerList.Count.ToString() + " Recieved For a Fingerprint Identification"));
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Sending Transaction with Reference ID: " + response.ReferenceUniqID + " For Fingerprint Identification"));


                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Successful Biometric identification", ResponseObject = response };

                //return genericResponse;




                //return

                return response;
            }

            catch (Exception ex)
            {
                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, ex) };
            }

            finally
            {
                //set the response date time

                response.Footer.ResponseDateTime = DateTime.Now;
            }
        }



        /// <summary>Asyncronous : </summary>
        public NRA_ABIS_Envelope.Response Biometric_Identification_Result(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Biometric_Identification_Result;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }



                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                //if (string.IsNullOrEmpty(request.Header.ReferenceUID))
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_reference_uid) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate fingerprint data

                //if (request.Detail.Fingerprint == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_object) };
                //}

                //if (request.Detail.Fingerprint.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_data) };
                //}

                //for (int i = 0; i < request.Detail.Fingerprint.Count; i++)
                //{
                //    if (request.Detail.Fingerprint[i].ImageData.Length < min_fingerprint_image_data_length)
                //    {
                //        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_image_data, i) };
                //    }
                //}

                ////validate portrait data

                //if (request.Detail.Portrait == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_object) };
                //}

                //if (request.Detail.Portrait.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_data) };
                //}

                //for (int i = 0; i < request.Detail.Portrait.Count; i++)
                //{
                //    if (request.Detail.Portrait[i].ImageDataICAO.Length < min_portrait_image_data_icao_length)
                //    {
                //        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_image_data_icao, i) };
                //    }

                //    if (request.Detail.Portrait[i].ImageDataOriginal.Length < min_portrait_image_data_original_length)
                //    {
                //        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_image_data_original, i) };
                //    }
                //}

                //validate signature data


                //validate template data

                //if (request.Detail.Fingerprint[i].Template.Length < min_fingerprint_template_length)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_template_data, i) };
                //}





                ////face identification reuslt

                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "BiometricIdentificationResult", Environment.NewLine, "Sending transaction with reference id " + identificationResultRequest.ReferenceUniqID + " for Biometric identification"));





                //populate identification response

                //response = new IdentificationResponse()
                //{
                //    CPR_ID = long.Parse(DateTime.Now.ToString("yyMMddHHmmssfff")),
                //    ReferenceUniqID = identificationResultRequest.ReferenceUniqID
                //};

                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Reference unique id not supplied", ResponseObject = response };

                //return genericResponse;
            }

            catch (Exception ex)
            {
                //response = new IdentificationResponse();
                //cslog.Handle_Exception(ex);
                //genericResponse = new GenericResponse() { ResponseCode = 1006, ResponseMessage = ex.Message.ToUpperInvariant(), ResponseObject = response };
                //return genericResponse;
            }

            return response;
        }



        /// <summary>Synchronous : </summary>
        public NRA_ABIS_Envelope.Response Biometric_Information(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Biometric_Information;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }



                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                //if (request.Header.CPRID == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_cpr_id) };
                //}





                //Prepare response structure

                //response = new BiometricInfo()
                //{
                //    fingerprints = new Fingerprint[10],
                //    portrait = new FacePortrait(),
                //    guid = Guid.NewGuid().ToString().ToUpper(),
                //    signatureImage = new byte[] { 0 }

                //};

                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "GetBiometricInformation", Environment.NewLine, "Successfully Recieved Biometric Information For Reference ID: " + response.guid));


                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Successful Recieved Biometric Information", ResponseObject = response };

                //return genericResponse;

            }
            catch (Exception ex)
            {
                //response = new BiometricInfo();
                //cslog.Handle_Exception(ex);
                //genericResponse = new GenericResponse() { ResponseCode = 1006, ResponseMessage = ex.Message.ToUpperInvariant(), ResponseObject = response };
                //return genericResponse;
            }

            return response;
        }

        #endregion



        #region --  fingerprints  --

        /// <summary>Asynchronuos : </summary>
        public NRA_ABIS_Envelope.Response Fingerprint_Identification(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Identification;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }





                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate fingerprint data

                //if (request.Detail.Fingerprint == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_object) };
                //}

                //if (request.Detail.Fingerprint.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_data) };
                //}




                //List<Fingerprint> FingerList = new List<Fingerprint>();
                //List<Fingerprint> TempFingerList = biometricInfo.fingerprints.OfType<Fingerprint>().ToList();
                //foreach (Fingerprint fin in TempFingerList)
                //{
                //    if (fin != null)
                //    {
                //        if (fin.status != 0 && fin.wsqImage != null)
                //        {
                //            FingerList.Add(fin);
                //        }
                //    }
                //}



                // Determine which fingers are available and send them for matching
                //response = new IdentificationResponse()
                //{
                //    CPR_ID = 0 /*long.Parse(DateTime.Now.ToString("yyMMddHHmmssfff"))*/
                //    ,
                //    ReferenceUniqID = Guid.NewGuid().ToString().ToUpper()
                //};
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Total of: " + FingerList.Count.ToString() + " Recieved For a Fingerprint Identification"));
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Sending Transaction with Reference ID: " + response.ReferenceUniqID + " For Fingerprint Identification"));


                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Successful fingerprint identification", ResponseObject = response };

                //return genericResponse;
            }
            catch (Exception ex)
            {
                //response = new IdentificationResponse();
                //cslog.Handle_Exception(ex);
                //genericResponse = new GenericResponse() { ResponseCode = 1006, ResponseMessage = ex.Message.ToUpperInvariant(), ResponseObject = response };
                //return genericResponse;
            }

            return response;
        }

        /// <summary>Asynchronuos</summary>
        public NRA_ABIS_Envelope.Response Fingerprint_Identification_Result(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Identification_Result;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                //if (string.IsNullOrEmpty(request.Header.ReferenceUID))
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_reference_uid) };
                //}

                





                ////response = new IdentificationResponse()
                ////{
                ////    CPR_ID = long.Parse(DateTime.Now.ToString("yyMMddHHmmssfff"))
                ////    ,
                ////    ReferenceUniqID = identificationResponse.ReferenceUniqID
                ////};


                ////cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentificationResult Operation", Environment.NewLine, "Sending Transaction with Reference ID: " + response.ReferenceUniqID + " For Fingerprint Identification"));

                //// Determine which fingers are available and send them for matching

                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Successful fingerprint identification", ResponseObject = response };

                //return genericResponse;

            }
            catch (Exception ex)
            {
                //response = new IdentificationResponse();
                //cslog.Handle_Exception(ex);
                //genericResponse = new GenericResponse() { ResponseCode = 1006, ResponseMessage = ex.Message.ToUpperInvariant(), ResponseObject = response };
                //return genericResponse;
            }

            return response;
        }

        /// <summary>Unconfirmed service call</summary>
        public NRA_ABIS_Envelope.Response Fingerprint_Insert(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Insert;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate fingerprint data

                //if (request.Detail.Fingerprint == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_object) };
                //}

                //if (request.Detail.Fingerprint.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_data) };
                //}



                //return new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Fingerprint Inserted Successful", ResponseObject = null };
            }

            catch (Exception ex)
            {
                //cslog.Handle_Exception(ex);
            }

            return response;
            
        }

        /// <summary>Synchronous : Generate template request for DCS server</summary>
        public NRA_ABIS_Envelope.Response Fingerprint_Template(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Template;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate fingerprint data

                //if (request.Detail.Fingerprint == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_object) };
                //}

                //if (request.Detail.Fingerprint.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_data) };
                //}




                //List<Fingerprint> FingerList = new List<Fingerprint>();
                //List<Fingerprint> TempFingerList = fingerprint.OfType<Fingerprint>().ToList();

                //if (TempFingerList.Count < 1)
                //{
                //    //response = new ISOFingerprintTemplates();
                //    genericResponse = new GenericResponse() { ResponseCode = 1004, ResponseMessage = "No Fingerprint Images Available", ResponseObject = response };
                //    cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "GenerateFingerprintTemplates", Environment.NewLine, "No Fingerprints Images Available"));
                //    //return genericResponse;
                //}


                //foreach (Fingerprint fin in TempFingerList)
                //{
                //    if (fin != null)
                //    {
                //        if (fin.status != 0 && fin.wsqImage != null)
                //        {
                //            FingerList.Add(fin);
                //        }
                //    }
                //}


                // Determine which fingers are available and send them for matching



                //Prepare response structure

                //response = new ISOFingerprintTemplates()
                //{
                //    ReferenceUniqID = Guid.NewGuid().ToString().ToUpper()
                //    ,
                //    fingerprintTemplates = new FingerprintTemplate[10]
                //};
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Total of: " + FingerList.Count.ToString() + " Recieved For a Template Generation"));
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Successfully Generated Templates For Reference ID: " + response.ReferenceUniqID));


                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Successful fingerprint identification", ResponseObject = response };

                //return genericResponse;

            }
            catch (Exception ex)
            {
                //response = new ISOFingerprintTemplates();
                //cslog.Handle_Exception(ex);
                //genericResponse = new GenericResponse() { ResponseCode = 1006, ResponseMessage = ex.Message.ToUpperInvariant(), ResponseObject = response };
                //return genericResponse;
            }

            return response;
        }

        /// <summary>Synchronous : Fingerprint verification service operation</summary>
        public NRA_ABIS_Envelope.Response Fingerprint_Verification(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Verification;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                //if (request.Header.CPRID == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_cpr_id) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate fingerprint data

                //if (request.Detail.Fingerprint == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_object) };
                //}

                //if (request.Detail.Fingerprint.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_fingerprint_data) };
                //}



                

                //List<Fingerprint> FingerList = new List<Fingerprint>();
                //List<Fingerprint> TempFingerList = verificationRequest.biometricInfo.fingerprints.OfType<Fingerprint>().ToList();

                //if (TempFingerList.Count < 1)
                //{
                //    //response = new VerificationResponse();
                //    //genericResponse = new GenericResponse() { ResponseCode = 1007, ResponseMessage = "No fingerprints available for Verification", ResponseObject = (VerificationResponse)response };
                //    cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Message: {2}", Environment.MachineName, Environment.NewLine, "No fingerprints available for Verification"));
                //    //return genericResponse;
                //}


                //foreach (Fingerprint fin in TempFingerList)
                //{
                //    if (fin != null)
                //    {
                //        if (fin.status != 0 && fin.wsqImage != null)
                //        {
                //            FingerList.Add(fin);
                //        }
                //    }
                //}

                //int FingerCounts = FingerList.Count;
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Message: {2}", Environment.MachineName, Environment.NewLine, FingerCounts + " detected available for verification"));

                //Call Matcher to match fingers



                //Populate VerificationResponse with match results 

                //response = new VerificationResponse()
                //{
                //    ReferenceUniqID = Guid.NewGuid().ToString().ToUpper(),
                //    result = true
                //};
                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FingerprintIdentification", Environment.NewLine, "Sending Transaction with Reference ID: " + response.ReferenceUniqID + " For Fingerprint Identification"));


                //genericResponse = new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Successful fingerprint identification", ResponseObject = (VerificationResponse)response };

                //return genericResponse;





            }
            catch (Exception ex)
            {
                //response = new VerificationResponse();
                //cslog.Handle_Exception(ex);
                //genericResponse = new GenericResponse() { ResponseCode = 1008, ResponseMessage = ex.Message.ToUpperInvariant(), ResponseObject = response };
                //return genericResponse;
            }

            return response;
        }

        #endregion



        #region --  portraits  --

        /// <summary>Asynchronuos</summary>
        public NRA_ABIS_Envelope.Response Portrait_Identification(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Portrait_Identification;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate portrait data

                //if (request.Detail.Portrait == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_object) };
                //}

                //if (request.Detail.Portrait.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_data) };
                //}



                
                
                ////portrait identification

                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FacialPortraitIdentification", Environment.NewLine, "Portrait available"));





                //populate identification response

                //response = new IdentificationResponse()
                //{
                //    CPR_ID = long.Parse(DateTime.Now.ToString("yyMMddHHmmssfff"))
                //    ,
                //    ReferenceUniqID = Guid.NewGuid().ToString().ToUpper()
                //};
            }

            catch (Exception ex)
            {
                //response = new IdentificationResponse();

                //cslog.Handle_Exception(ex);
            }

            return response;
        }



        /// <summary>Asynchronuos</summary>
        public NRA_ABIS_Envelope.Response Portrait_Identification_Result(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Portrait_Identification_Result;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                //if (string.IsNullOrEmpty(request.Header.ReferenceUID))
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_reference_uid) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate portrait data

                //if (request.Detail.Portrait == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_object) };
                //}

                //if (request.Detail.Portrait.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_data) };
                //}




                

                ////face identification reuslt

                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Source: {2}, {3}, Log Message: {4}", Environment.MachineName, Environment.NewLine, "FaceIdentificationResult", Environment.NewLine, "Sending transaction with reference id " + faceIdentificationResultRequest.ReferenceUniqID + " for face identification"));





                //populate identification response

                //response = new IdentificationResponse()
                //{
                //    CPR_ID = long.Parse(DateTime.Now.ToString("yyMMddHHmmssfff"))
                //    ,
                //    ReferenceUniqID = faceIdentificationResultRequest.ReferenceUniqID
                //};
            }

            catch (Exception ex)
            {
                //response = new IdentificationResponse();

                //cslog.Handle_Exception(ex);
            }

            return response;
        }



        /// <summary>Synchronous</summary>
        public NRA_ABIS_Envelope.Response Portrait_Verification(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Portrait_Verification;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}

                //if (request.Header.CPRID == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_cpr_id) };
                //}

                ////validate detail

                //if (request.Detail == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_detail_object) };
                //}

                ////validate portrait data

                //if (request.Detail.Portrait == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_object) };
                //}

                //if (request.Detail.Portrait.Count == 0)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_portrait_data) };
                //}




                

                

                ////call matcher to match portrait

                //cslog.WriteToTransactionLog(string.Format("Log Source Server: {0}, {1}, Log Message: {2}", Environment.MachineName, Environment.NewLine, "FacialPortraitVerification", Environment.NewLine, "Portrait available"));





                //populate verification response with match results

                //response = new VerificationResponse()
                //{
                //    ReferenceUniqID = Guid.NewGuid().ToString().ToUpper()
                //    ,
                //    result = true
                //};
            }
            catch (Exception ex)
            {
                //response = new VerificationResponse() { result = false };

                //cs/*l*/og.Handle_Exception(ex);
            }

            return response;
        }

        #endregion



        #region --  other  --

        /// <summary>Unconfirmed</summary>
        public NRA_ABIS_Envelope.Response Delete_Record(NRA_ABIS_Envelope.Request request)
        {
            DateTime request_date_time = DateTime.Now;

            NRA_ABIS_Envelope.EnvelopeType envelope_type = NRA_ABIS_Envelope.EnvelopeType.Delete_Record;

            NRA_ABIS_Envelope.Response response = null;

            try
            {
                //validate request

                response = Validate.Request(request, envelope_type, request_date_time, true, false, false, true, true, false, false);

                if (response != null)
                {
                    return response;
                }




                ////validate request

                //if (request == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_object) };
                //}

                ////validate header

                //if (request.Header == null)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_header_object) };
                //}

                //if (request.Header.RequestType == null
                //    ||
                //    request.Header.RequestType != envelope_type)
                //{
                //    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, Exception_Type.no_request_type) };
                //}




                //return new GenericResponse() { ResponseCode = 1001, ResponseMessage = "Deletion Successful", ResponseObject = null };

            }

            catch (Exception ex)
            {
                //cslog.Handle_Exception(ex);

            }

            return response;
        }

        #endregion

    }
}