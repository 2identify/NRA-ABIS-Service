using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace NRA_ABIS_Service
{
    internal static class Validate
    {
        /// <summary>minimum byte length for fingerprint image data</summary>
        private const int min_fingerprint_image_data_length = 100;

        /// <summary>minimum byte length for original portrait image data</summary>
        private const int min_portrait_image_data_original_length = 100;

        /// <summary>minimum byte length for icao portrait image data</summary>
        private const int min_portrait_image_data_icao_length = 100;

        /// <summary>minimum byte length for signature image data</summary>
        private const int min_signature_image_data_length = 100;

        /// <summary>minimum byte length for fingerprint template data</summary>
        private const int min_template_data_length = 100;



        /// <summary>Validate a requets envelope</summary>
        internal static NRA_ABIS_Envelope.Response Request(NRA_ABIS_Envelope.Request request, NRA_ABIS_Envelope.EnvelopeType envelope_type, DateTime request_date_time
            , bool header_cprid, bool header_guid, bool header_reference_uid
            , bool detail_fingerprint, bool detail_portrait, bool detail_signature, bool detail_template)
        {
            try
            {
                //---------------------------------------------------------------------------------

                //validate the request object

                if (request == null)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_request_object) };
                }

                //---------------------------------------------------------------------------------

                //validate the request header

                if (request.Header == null)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_header_object) };
                }

                if (header_cprid
                    &&
                    request.Header.CPRID == null)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_cpr_id) };
                }

                if (header_guid
                    &&
                    request.Header.Guid == null)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_guid) };
                }

                if (header_reference_uid
                    &&
                    string.IsNullOrEmpty(request.Header.ReferenceUID))
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_reference_uid) };
                }

                if(request.Header.RequestType == null)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_request_type) };
                }

                if (request.Header.RequestType != envelope_type)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.invalid_request_type) };
                }

                //---------------------------------------------------------------------------------

                //validate request detail

                if (request.Detail == null)
                {
                    return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_detail_object) };
                }

                //---------------------------------------------------------------------------------

                //validate request detail fingerprint

                if (detail_fingerprint)
                {
                    if (request.Detail.Fingerprint == null)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_object) };
                    }

                    if (request.Detail.Fingerprint.Count < 1)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_data) };
                    }

                    for (int i = 0; i < request.Detail.Fingerprint.Count; i++)
                    {
                        if (request.Detail.Fingerprint[i].Status == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_status, i) };
                        }

                        if (request.Detail.Fingerprint[i].ImageData == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_image_data, i) };
                        }

                        if (request.Detail.Fingerprint[i].ImageData.Length < min_fingerprint_image_data_length)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.invalid_fingerprint_image_data_length, i) };
                        }

                        if (request.Detail.Fingerprint[i].ImageFormat == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_image_format, i) };
                        }

                        if (request.Detail.Fingerprint[i].Postion == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_position, i) };
                        }

                        if (request.Detail.Fingerprint[i].Quality == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_fingerprint_quality, i) };
                        }
                    }
                }

                //---------------------------------------------------------------------------------

                //validate request detail portrait

                if (detail_portrait)
                {
                    if (request.Detail.Portrait == null)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_object) };
                    }

                    if (request.Detail.Portrait.Count < 1)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_data) };
                    }

                    for (int i = 0; i < request.Detail.Portrait.Count; i++)
                    {
                        if (request.Detail.Portrait[i].ImageDataICAO == null
                            &&
                            request.Detail.Portrait[i].ImageDataOriginal == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_image_data, i) };
                        }

                        if (request.Detail.Portrait[i].ImageDataICAO != null
                            &&
                            request.Detail.Portrait[i].ImageDataOriginal != null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.double_portrait_image_data, i) };
                        }

                        if (request.Detail.Portrait[i].ImageDataICAO == null)
                        {
                            if (request.Detail.Portrait[i].CropHeight == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_crop_height, i) };
                            }

                            if (request.Detail.Portrait[i].CropLeft == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_crop_left, i) };
                            }

                            if (request.Detail.Portrait[i].CropTop == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_crop_top, i) };
                            }

                            if (request.Detail.Portrait[i].CropWidth == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_crop_width, i) };
                            }

                            if (request.Detail.Portrait[i].ImageDataOriginal == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_image_data_original, i) };
                            }

                            if (request.Detail.Portrait[i].ImageDataOriginal.Length < min_portrait_image_data_original_length)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.invalid_portrait_image_data_original_length, i) };
                            }

                            if (request.Detail.Portrait[i].ImageFormat == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_image_format, i) };
                            }
                        }

                        if (request.Detail.Portrait[i].ImageDataOriginal == null)
                        {
                            if (request.Detail.Portrait[i].ImageDataICAO == null)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_portrait_image_data_icao, i) };
                            }

                            if (request.Detail.Portrait[i].ImageDataICAO.Length < min_portrait_image_data_icao_length)
                            {
                                return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.invalid_portrait_image_data_icao_length, i) };
                            }
                        }
                    }
                }

                //---------------------------------------------------------------------------------

                //validate request detail signature

                if (detail_signature)
                {
                    if (request.Detail.Signature == null)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_signature_object) };
                    }

                    if (request.Detail.Signature.Count < 1)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_signature_data) };
                    }

                    for (int i = 0; i < request.Detail.Signature.Count; i++)
                    {
                        if (request.Detail.Signature[i].ImageData == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_signature_image_data, i) };
                        }

                        if (request.Detail.Signature[i].ImageData.Length < min_signature_image_data_length)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.invalid_signature_image_data_length, i) };
                        }

                        if (request.Detail.Signature[i].ImageFormat == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_signature_image_format, i) };
                        }
                    }
                }

                //---------------------------------------------------------------------------------

                //validate request detail template

                if (detail_template)
                {
                    if (request.Detail.Template == null)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_template_object) };
                    }

                    if (request.Detail.Template.Count < 1)
                    {
                        return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_template_data) };
                    }

                    for (int i = 0; i < request.Detail.Template.Count; i++)
                    {
                        if (request.Detail.Template[i].Template == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_template_image_data, i) };
                        }

                        if (request.Detail.Template[i].Template.Length < min_template_data_length)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.invalid_template_data_length, i) };
                        }

                        if (request.Detail.Template[i].TemplateFormat == null)
                        {
                            return new NRA_ABIS_Envelope.Response() { Footer = Request_Exceptions.Set_Exception(envelope_type, request_date_time, Exception_Type.no_template_format, i) };
                        }
                    }
                }

                //---------------------------------------------------------------------------------
            }

            catch (Exception ex)
            {




            }

            return null;
        }



    }
}