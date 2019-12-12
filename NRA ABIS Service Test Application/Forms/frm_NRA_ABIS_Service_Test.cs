using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NRA_ABIS_Service_Test_Application.NRA_ABIS_Service;
using System.Xml;
using System.Reflection;
//using NRA_ABIS_Service;
using System.Configuration;



//namespace ServiceTestAPP
namespace NRA_ABIS_Service_Test_Application
{
    public partial class frm_NRA_ABIS_Service_Test : Form
    {
        private NRA_ABIS_Service.NRA_ABIS_ServiceClient _client { get; set; }

        private bool _connected { get; set; } = false;

        private string caption_title { get; set; } = "Namibia ABIS Interface";



        #region --  form  --

        public frm_NRA_ABIS_Service_Test()
        {
            try
            {
                InitializeComponent();

                //load the endpoints

                load_endpoints();

                //set service down (default)

                service_down();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK);
            }
        }

        private void frm_NRA_ABIS_Service_Test_Closing(object sender, FormClosingEventArgs e)
        {
            //ensure the client is stopped

            service_down();
        }

        #endregion



        #region --  load and save endpoints  --

        /// <summary>load all the endpoint addresses in config settings into the endpoints combobox</summary>
        private void load_endpoints()
        {
            try
            {
                //clear the endpoints combobox

                cmb_endpoint_url.Items.Clear();

                //get all the saved endpoints

                List<string> endpoints = Properties.Settings.Default.endpoint_url.Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                //check if there are any saved endpoints
                
                if (endpoints != null
                    &&
                    endpoints.Count() > 0)
                {
                    //load the endpoints into the combobox

                    cmb_endpoint_url.Items.AddRange(endpoints.ToArray());

                    //get the last used endpoint

                    if (!string.IsNullOrEmpty(Properties.Settings.Default.last_endpoint))
                    {
                        cmb_endpoint_url.SelectedIndex = cmb_endpoint_url.Items.IndexOf(Properties.Settings.Default.last_endpoint);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK);
            }
        }

        /// <summary>save a newly connected endpoint to the config settings</summary>
        /// <param name="endpoint">the url endpoint address to save</param>
        private bool save_endpoints(string endpoint)
        {
            bool save_new_endpoint = true;

            try
            {
                //get all the saved endpoints

                List<string> endpoints = Properties.Settings.Default.endpoint_url.Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                //check if any endpoints exist

                if (endpoints != null
                    &&
                    endpoints.Count > 0)
                {
                    //check if the specified endpoint exists

                    save_new_endpoint = (endpoints.Where(x => x.ToString() == endpoint).Count() == 0);
                }

                //save the new endpoint

                if (save_new_endpoint)
                {
                    //add the new endpoint to the current list

                    if (endpoints == null)
                    {
                        endpoints = new List<string>();
                    }

                    endpoints.Add(endpoint);

                    //combine all the endpoints in the list

                    string new_endpoints = string.Join("||", endpoints);

                    //save the endpoints

                    Properties.Settings.Default.endpoint_url = new_endpoints;
                }

                //save the endpoint as last endpoint used

                Properties.Settings.Default.last_endpoint = endpoint;

                Properties.Settings.Default.Save();

                Properties.Settings.Default.Reload();

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK);

                return false;
            }
        }

        #endregion



        #region --  service timer  --

        /// <summary>timer that polls if service is up</summary>
        private void timer_service_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timer_service.Interval == 100)
                {
                    timer_service.Interval = 10000;
                }

                switch (_client.Is_Service_Running())
                {
                    case true:

                        service_up();

                        break;

                    case false:

                        service_down();

                        break;
                }
            }

            catch (Exception ex)
            {
                service_down();

                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        private void service_up()
        {
            cmb_endpoint_url.Enabled = false;

            btn_connect.Enabled = true;
            btn_connect.Text = "Disconnect";

            lbl_server_status.Text = "Server Status : Online";
            lbl_server_status.BackColor = Color.LimeGreen;
            lbl_server_status.ForeColor = Color.Black;

            grp_request_parameters.Enabled = true;

            grp_biometrics.Enabled = true;
            grp_fingerprints.Enabled = true;
            grp_portraits.Enabled = true;
            grp_other.Enabled = true;

            grp_response_results.Enabled = true;

            Cursor = Cursors.Default;
        }

        private void service_down()
        {
            //stop the timer

            timer_service.Stop();

            //set client

            if (_client != null)
            {
                if (_client.State == System.ServiceModel.CommunicationState.Opened)
                {
                    _client.Close();
                }

                _client = null;
            }

            //set connected

            _connected = false;

            //set controls

            cmb_endpoint_url.Enabled = true;

            btn_connect.Enabled = true;
            btn_connect.Text = "Connect";

            lbl_server_status.Text = "Server Status : Offline";
            lbl_server_status.BackColor = Color.Red;
            lbl_server_status.ForeColor = Color.White;

            grp_request_parameters.Enabled = false;

            grp_biometrics.Enabled = false;
            grp_fingerprints.Enabled = false;
            grp_portraits.Enabled = false;
            grp_other.Enabled = false;

            grp_response_results.Enabled = false;

            Cursor = Cursors.Default;
        }

        #endregion



        #region --  buttons click  --

        /// <summary>connect or disconnect from service</summary>
        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                //set wait cursor

                Cursor = Cursors.WaitCursor;

                //disable connection controls

                cmb_endpoint_url.Enabled = false;

                btn_connect.Enabled = false;

                //check the status of the service

                switch (_connected)
                {
                    case true:      //disconnect from service

                        service_down();

                        break;

                    case false:     //connect to service

                        _client = new NRA_ABIS_Service.NRA_ABIS_ServiceClient();

                        _client.Endpoint.Address = new System.ServiceModel.EndpointAddress(cmb_endpoint_url.Text);

                        _client.Open();

                        //set connected

                        _connected = true;

                        //start the timer to poll the service to ensure it is connect

                        timer_service.Interval = 100;
                        timer_service.Start();

                        //save the currently used endpoint

                        save_endpoints(cmb_endpoint_url.Text);

                        break;
                }
            }

            catch (Exception ex)
            {
                //disconnect

                if (_client != null)
                {
                    if (_client.State == System.ServiceModel.CommunicationState.Opened)
                    {
                        _client.Close();
                    }

                    _client = null;
                }

                service_down();

                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }


        private void btn_fingerprints_add_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Add_Image add_image = new frm_Add_Image(frm_Add_Image.eAddImage.fingerprint);

                add_image.ShowDialog(this);










            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_fingerprints_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_fingerprints.Items.Count > 0
                    &&
                    lst_fingerprints.SelectedIndex > -1)
                {
                    lst_fingerprints.Items.RemoveAt(lst_fingerprints.SelectedIndex);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_templates_add_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Add_Image add_image = new frm_Add_Image(frm_Add_Image.eAddImage.template);

                add_image.ShowDialog(this);










            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_templates_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_templates.Items.Count > 0
                    &&
                    lst_templates.SelectedIndex > -1)
                {
                    lst_templates.Items.RemoveAt(lst_templates.SelectedIndex);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_portraits_add_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Add_Image add_image = new frm_Add_Image(frm_Add_Image.eAddImage.portrait);

                add_image.ShowDialog(this);










            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_portraits_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_portraits.Items.Count > 0
                    &&
                    lst_portraits.SelectedIndex > -1)
                {
                    lst_portraits.Items.RemoveAt(lst_portraits.SelectedIndex);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        private void btn_signatures_add_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Add_Image add_image = new frm_Add_Image(frm_Add_Image.eAddImage.signature);

                add_image.ShowDialog(this);










            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_signatures_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_signatures.Items.Count > 0
                    &&
                    lst_signatures.SelectedIndex > -1)
                {
                    lst_signatures.Items.RemoveAt(lst_signatures.SelectedIndex);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        #endregion



        #region --  service buttons : biometrics  --

        /// <summary></summary>
        private void btn_biometric_identification_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Biometric_Identification);

                NRA_ABIS_Envelope.Response response = _client.Biometric_Identification(request);

                Response_To_Text(response);

                web_browser.Url = new System.Uri(@"C:\Temp\DHA Test\10 Only\020506162777400420302_00001.xml");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_biometric_identification_result_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Biometric_Identification_Result);

                NRA_ABIS_Envelope.Response response = _client.Biometric_Identification_Result(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_biometric_information_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Biometric_Information);

                NRA_ABIS_Envelope.Response response = _client.Biometric_Information(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        #endregion



        #region --  service buttons : fingerprints  --

        /// <summary></summary>
        private void btn_fingerprint_identification_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Identification);

                NRA_ABIS_Envelope.Response response = _client.Fingerprint_Identification(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_fingerprint_identification_result_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Identification_Result);

                NRA_ABIS_Envelope.Response response = _client.Fingerprint_Identification_Result(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_fingerprint_insert_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Insert);

                NRA_ABIS_Envelope.Response response = _client.Fingerprint_Insert(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_fingerprint_template_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Template);

                NRA_ABIS_Envelope.Response response = _client.Fingerprint_Template(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_fingerprint_verification_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Fingerprint_Verification);

                NRA_ABIS_Envelope.Response response = _client.Fingerprint_Verification(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        #endregion



        #region --  service buttons : portraits  --

        /// <summary></summary>
        private void btn_portrait_identification_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Portrait_Identification);

                NRA_ABIS_Envelope.Response response = _client.Portrait_Identification(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_portrait_identification_result_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Portrait_Identification_Result);

                NRA_ABIS_Envelope.Response response = _client.Portrait_Identification_Result(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        /// <summary></summary>
        private void btn_portrait_verification_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Portrait_Verification);

                NRA_ABIS_Envelope.Response response = _client.Portrait_Verification(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        #endregion



        #region --  service buttons : other  --

        /// <summary></summary>
        private void btn_delete_record_Click(object sender, EventArgs e)
        {
            try
            {
                txt_response.Clear();

                NRA_ABIS_Envelope.Request request = new NRA_ABIS_Envelope.Request(NRA_ABIS_Envelope.EnvelopeType.Delete_Record);

                NRA_ABIS_Envelope.Response response = _client.Delete_Record(request);

                Response_To_Text(response);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpper(), caption_title);
            }
        }

        #endregion



        #region --  response result processing  --

        /// <summary></summary>
        /// <param name="response"></param>
        private void Response_To_Text(NRA_ABIS_Envelope.Response response)
        {
            string text = string.Empty;

            string newline_1 = Environment.NewLine + Environment.NewLine;

            string newline_2 = Environment.NewLine + Environment.NewLine + "\t";

            string newline_3 = Environment.NewLine + "\t";

            string newline_4 = Environment.NewLine + "\t\t";

            string newline_5 = Environment.NewLine + "\t\t\t";

            try
            {
                if (response == null)
                {
                    text += "Response is null";
                }

                if (response != null)
                {
                    //-----------------------------------------------------------------------------

                    //header

                    if (response.Header == null)
                    {
                        text += "HEADER is null";
                    }

                    if (response.Header != null)
                    {
                        text += "HEADER";

                        text += newline_3 + "CPRID : " + (response.Header.CPRID == null ? "null" : response.Header.CPRID.ToString());

                        text += newline_3 + "Guid : " + (response.Header.Guid == null ? "null" : response.Header.Guid.ToString());

                        text += newline_3 + "ReferenceUID : " + (response.Header.ReferenceUID == null ? "null" : response.Header.ReferenceUID);
                    }

                    //-----------------------------------------------------------------------------

                    //detail

                    if (response.Detail == null)
                    {
                        text += newline_1 + "DETAIL is null";
                    }

                    if (response.Detail != null)
                    {
                        text += newline_1 + "DETAIL";

                        //-------------------------------------------------------------------------

                        //fingerprint

                        if (response.Detail.Fingerprint == null)
                        {
                            text += newline_2 + "FINGERPRINT is null";
                        }

                        if (response.Detail.Fingerprint != null)
                        {
                            if (response.Detail.Fingerprint.Count == 0)
                            {
                                text += newline_2 + "FINGERPRINT has zero data";
                            }

                            if (response.Detail.Fingerprint.Count > 0)
                            {
                                for (int i = 0; i < response.Detail.Fingerprint.Count; i++)
                                {
                                    text += newline_4 + "FINGERPRINT " + (i + 1).ToString("00");

                                    text += newline_5 + "Status : " + (response.Detail.Fingerprint[i].Status == null ? "null" : response.Detail.Fingerprint[i].Status.ToString());

                                    text += newline_5 + "ImageData : " + (response.Detail.Fingerprint[i].ImageData == null ? "null" : response.Detail.Fingerprint[i].ImageData.Length.ToString() + " bytes");

                                    text += newline_5 + "Postion : " + (response.Detail.Fingerprint[i].Postion == null ? "null" : response.Detail.Fingerprint[i].Postion.ToString());

                                    //text += newline_5 + "Template : " + (response.Detail.Fingerprint[i].Template == null ? "null" : response.Detail.Fingerprint[i].Template.Length.ToString() + " bytes");

                                    //text += newline_5 + "TemplateFormat : " + (response.Detail.Fingerprint[i].TemplateFormat == null ? "null" : response.Detail.Fingerprint[i].TemplateFormat.ToString());

                                    text += newline_5 + "Quality : " + (response.Detail.Fingerprint[i].Quality == null ? "null" : response.Detail.Fingerprint[i].Quality.ToString());
                                }
                            }
                        }

                        //-------------------------------------------------------------------------

                        //portrait

                        if (response.Detail.Portrait == null)
                        {
                            text += newline_2 + "PORTRAIT is null";
                        }

                        if (response.Detail.Portrait != null)
                        {
                            if (response.Detail.Portrait.Count == 0)
                            {
                                text += newline_2 + "PORTRAIT has zero data";
                            }

                            if (response.Detail.Portrait.Count > 0)
                            {
                                for (int i = 0; i < response.Detail.Portrait.Count; i++)
                                {
                                    text += newline_4 + "PORTRAIT " + (i + 1).ToString("00");

                                    text += newline_5 + "CropLeft : " + (response.Detail.Portrait[i].CropLeft == null ? "null" : response.Detail.Portrait[i].CropLeft.ToString());

                                    text += newline_5 + "CropTop : " + (response.Detail.Portrait[i].CropTop == null ? "null" : response.Detail.Portrait[i].CropTop.ToString());

                                    text += newline_5 + "CropWidth : " + (response.Detail.Portrait[i].CropWidth == null ? "null" : response.Detail.Portrait[i].CropWidth.ToString());

                                    text += newline_5 + "CropHeight : " + (response.Detail.Portrait[i].CropHeight == null ? "null" : response.Detail.Portrait[i].CropHeight.ToString());

                                    text += newline_5 + "ImageDataICAO : " + (response.Detail.Portrait[i].ImageDataICAO == null ? "null" : response.Detail.Portrait[i].ImageDataICAO.Length.ToString() + " bytes");

                                    text += newline_5 + "ImageDataOriginal : " + (response.Detail.Portrait[i].ImageDataOriginal == null ? "null" : response.Detail.Portrait[i].ImageDataOriginal.Length.ToString() + " bytes");
                                }
                            }
                        }

                        //-------------------------------------------------------------------------

                        //signature

                        if (response.Detail.Signature == null)
                        {
                            text += newline_2 + "SIGNATURE is null";
                        }

                        if (response.Detail.Signature == null)
                        {
                            if (response.Detail.Signature != null)
                            {
                                if (response.Detail.Signature.Count == 0)
                                {
                                    text += newline_2 + "SIGNATURE has zero data";
                                }

                                if (response.Detail.Signature.Count > 0)
                                {
                                    for (int i = 0; i < response.Detail.Signature.Count; i++)
                                    {
                                        text += newline_4 + "SIGNATURE " + (i + 1).ToString("00");

                                        text += newline_5 + "ImageData : " + (response.Detail.Signature[i].ImageData == null ? "null" : response.Detail.Signature[i].ImageData.Length.ToString() + " bytes");
                                    }
                                }
                            }
                        }

                        //-------------------------------------------------------------------------

                        //template

                        if (response.Detail.Template == null)
                        {
                            text += newline_2 + "TEMPLATE is null";
                        }

                        if (response.Detail.Template == null)
                        {
                            if (response.Detail.Template != null)
                            {
                                if (response.Detail.Template.Count == 0)
                                {
                                    text += newline_2 + "TEMPLATE has zero data";
                                }

                                if (response.Detail.Template.Count > 0)
                                {
                                    for (int i = 0; i < response.Detail.Template.Count; i++)
                                    {
                                        text += newline_4 + "TEMPLATE " + (i + 1).ToString("00");

                                        text += newline_5 + "TemplateFormat : " + (response.Detail.Template[i].TemplateFormat == null ? "null" : response.Detail.Template[i].TemplateFormat.ToString());

                                        text += newline_5 + "Template : " + (response.Detail.Template[i].Template == null ? "null" : response.Detail.Template[i].Template.Length.ToString() + " bytes");
                                    }
                                }
                            }
                        }

                        //-------------------------------------------------------------------------
                    }

                    //-----------------------------------------------------------------------------

                    //footer

                    if (response.Footer == null)
                    {
                        text += newline_4 + "Footer is null";
                    }

                    if (response.Footer != null)
                    {
                        text += newline_1 + "FOOTER";

                        text += newline_3 + "ResponseCode : " + (response.Footer.ResponseCode == null ? "null" : response.Footer.ResponseCode.ToString());

                        text += newline_3 + "ResponseMessage : " + (response.Footer.ResponseMessage == null ? "null" : response.Footer.ResponseMessage);

                        text += newline_3 + "ResponseStatus : " + (response.Footer.ResponseStatus == null ? "null" : response.Footer.ResponseStatus.ToString());

                        text += newline_3 + "ResponseType : " + (response.Footer.ResponseType == null ? "null" : response.Footer.ResponseType.ToString());
                    }

                    //-----------------------------------------------------------------------------
                }
            }

            catch (Exception ex)
            {
                text = "Exception" + Environment.NewLine + ex.Message;
            }

            txt_response.Text = text;
        }

        #endregion

        
    }
}