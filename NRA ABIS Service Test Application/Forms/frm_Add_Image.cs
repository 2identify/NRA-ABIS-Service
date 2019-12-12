using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NRA_ABIS_Service_Test_Application
{
    public partial class frm_Add_Image : Form
    {

        private eAddImage add_image { get; set; }


        public enum eAddImage
        {
            fingerprint = 0
                ,
            template = 1
                ,
            portrait = 2
                ,
            signature = 3
        }




        public frm_Add_Image(eAddImage add_image)
        {
            try
            {
                InitializeComponent();

                this.add_image = add_image;



                cmb_format.Items.AddRange(Enum.GetNames(typeof(NRA_ABIS_Envelope.TemplateFormat)));

                cmb_finger_status.Items.AddRange(Enum.GetNames(typeof(NRA_ABIS_Envelope.FingerStatus)));

                //foreach (string val in Enum.GetNames(typeof(NRA_ABIS_Envelope.TemplateFormat)))
                //{

                //}





                switch (add_image)
                {
                    case eAddImage.fingerprint:

                        this.Text += " : Fingerprint";

                        break;

                    case eAddImage.template:

                        this.Text += " : Template";
                        break;

                    case eAddImage.portrait:

                        this.Text += " : Portrait";
                        break;

                    case eAddImage.signature:

                        this.Text += " : Signature";
                        break;
                }




                //pnl_fingerprint.Visible = (add_image == eAddImage.fingerprint);
                //pnl_template.Visible = (add_image == eAddImage.template);
                //pnl_portrait.Visible= (add_image == eAddImage.portrait);

                //pnl_image_icao.Visible = (add_image == eAddImage.fingerprint);
            }

            catch (Exception ex)
            {

            }
                

            
        }

        private void frm_Add_Image_Load(object sender, EventArgs e)
        {


        }




    }
}
