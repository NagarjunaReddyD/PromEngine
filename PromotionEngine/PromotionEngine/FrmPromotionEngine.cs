using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace PromotionEngine
{
    public partial class FrmPromotionEngine : Form
    {
        public int APrice = 0;
        public int BPrice = 0;
        public int CPrice = 0;
        public int DPrice = 0;
        public int AProm = 0;
        public int BProm = 0;
        public int CDProm = 0;
        public int ATotal = 0;
        public int BTotal = 0;
        public int CTotal = 0;
        public int DTotal = 0;
        public int CDTotal = 0;
        public FrmPromotionEngine()
        {
            InitializeComponent();
        }
        private void Calculate()
        {
            if (chkA.Checked)
            {
                int m = int.Parse(cmbA.SelectedItem.ToString());
                lblPromoA.Visible = true;
                lblPromoAValue.Visible = true;


                for (int i = 0; i <= m; i++)
                {
                    if (m >= 3)
                    {

                        m = m - 3;
                        ATotal = ATotal + AProm;
                        lblPromoAValue.Text = ATotal.ToString();
                    }

                }

                for (int i = 0; i <= m; i++)
                {
                    if (m < 3 && m > 0)
                    {

                        ATotal = ATotal + APrice;
                        lblPromoAValue.Text = ATotal.ToString();
                        m = m - 1;


                    }
                }

            }
            if (chkB.Checked)
            {
                int m = int.Parse(cmbB.SelectedItem.ToString());
                lblPromoB.Visible = true;
                lblPromoBValue.Visible = true;


                for (int i = 0; i <= m; i++)
                {
                    if (m >= 2)
                    {

                        m = m - 2;
                        BTotal = BTotal + BProm;
                        lblPromoBValue.Text = BTotal.ToString();
                    }

                }

                for (int i = 0; i <= m; i++)
                {
                    if (m < 2 && m > 0)
                    {

                        BTotal = BTotal + BPrice;
                        lblPromoBValue.Text = BTotal.ToString();
                        m = m - 1;


                    }
                }

            }
            if (chkC.Checked && chkD.Checked)
            {
                if (int.Parse(cmbC.SelectedItem.ToString()) == int.Parse(cmbD.SelectedItem.ToString()))
                {
                    CDTotal = CDProm * int.Parse(cmbD.SelectedItem.ToString());
                }

                else if (int.Parse(cmbC.SelectedItem.ToString()) > int.Parse(cmbD.SelectedItem.ToString()))
                {
                    CDTotal = CDProm * int.Parse(cmbD.SelectedItem.ToString());
                    CDTotal = CDTotal + (CPrice * (int.Parse(cmbC.SelectedItem.ToString()) - int.Parse(cmbD.SelectedItem.ToString())));
                }
                else
                {
                    CDTotal = CDProm * int.Parse(cmbC.SelectedItem.ToString());
                    CDTotal = CDTotal + (DPrice * (int.Parse(cmbD.SelectedItem.ToString()) - int.Parse(cmbC.SelectedItem.ToString())));
                }

                lblPromoCDValue.Text = CDTotal.ToString();
                lblPromoCD.Visible = true;
                lblPromoCDValue.Visible = true;
            }
            if (chkC.Checked && !chkD.Checked)
            {

                lblPromoC.Visible = true;
                lblPromoCValue.Visible = true;
                CTotal = CPrice * int.Parse(cmbC.SelectedItem.ToString());
                lblPromoCValue.Text = CTotal.ToString();
            }
            if (chkD.Checked && !chkC.Checked)
            {

                lblPromoD.Visible = true;
                lblPromoDValue.Visible = true;
                DTotal = DPrice * int.Parse(cmbD.SelectedItem.ToString());
                lblPromoDValue.Text = DTotal.ToString();
            }

            lblSummaryValue.Text = Convert.ToString(ATotal + BTotal + CTotal + DTotal + CDTotal);
            lblSummary.Visible = true;
            lblSummaryValue.Visible = true;

        }
        private bool Validate()
        {
            if (chkA.Checked == false && chkB.Checked == false && chkC.Checked == false && chkD.Checked == false)
            {
                lblValidate.Text = "Please Select any one of the product";
                return false;
            }
            if (chkA.Checked == true && cmbA.Text == "Select Qty")
            {
                lblValidate.Text = "Please select Qty for Product A";
                return false;
            }
            if (chkB.Checked == true && cmbB.Text == "Select Qty")
            {
                lblValidate.Text = "Please select Qty for Product B";
                return false;
            }
            if (chkC.Checked == true && cmbC.Text == "Select Qty")
            {
                lblValidate.Text = "Please select Qty for Product C";
                return false;
            }
            if (chkD.Checked == true && cmbD.Text == "Select Qty")
            {
                lblValidate.Text = "Please select Qty for Product D";
                return false;
            }
            lblValidate.Text = "";
            lblPromoAValue.Text = "";
            lblPromoBValue.Text = "";
            lblPromoCValue.Text = "";
            lblPromoDValue.Text = "";
            lblPromoCDValue.Text = "";

            lblSummaryValue.Text = "";
            lblPromoA.Visible = false;
            lblPromoB.Visible = false;
            lblPromoC.Visible = false;
            lblPromoD.Visible = false;
            lblPromoCD.Visible = false;
            lblSummary.Visible = false;
            ATotal = 0;
            BTotal = 0;
            CTotal = 0;
            DTotal = 0;
            CDTotal = 0;
            return true;
        }
        private void Clear()
        {
            //Reset all fields;
            lblValidate.Text = "";
            APrice = int.Parse(ConfigurationSettings.AppSettings["APrice"].ToString());
            BPrice = int.Parse(ConfigurationSettings.AppSettings["BPrice"].ToString());
            CPrice = int.Parse(ConfigurationSettings.AppSettings["CPrice"].ToString());
            DPrice = int.Parse(ConfigurationSettings.AppSettings["DPrice"].ToString());
            AProm = int.Parse(ConfigurationSettings.AppSettings["3A"].ToString());
            BProm = int.Parse(ConfigurationSettings.AppSettings["2B"].ToString());
            CDProm = int.Parse(ConfigurationSettings.AppSettings["CD"].ToString());

            lblPriceA.Text = "Price: " + ConfigurationSettings.AppSettings["APrice"].ToString();
            lblPriceB.Text = "Price: " + ConfigurationSettings.AppSettings["BPrice"].ToString();
            lblPriceC.Text = "Price: " + ConfigurationSettings.AppSettings["CPrice"].ToString();
            lblPriceD.Text = "Price: " + ConfigurationSettings.AppSettings["DPrice"].ToString();
            chkA.Checked = false;
            chkB.Checked = false;
            chkC.Checked = false;
            chkD.Checked = false;
            cmbA.Text = "Select Qty";
            cmbB.Text = "Select Qty";
            cmbC.Text = "Select Qty";
            cmbD.Text = "Select Qty";
            lblPromoA.Visible = false;
            lblPromoAValue.Visible = false;
            lblPromoB.Visible = false;
            lblPromoBValue.Visible = false;
            lblPromoC.Visible = false;
            lblPromoCValue.Visible = false;
            lblPromoD.Visible = false;
            lblPromoDValue.Visible = false;
            lblPromoCD.Visible = false;
            lblPromoCDValue.Visible = false;
            lblSummary.Visible = false;
            lblSummaryValue.Visible = false;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (Validate() == true)
            {
                Calculate();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FrmPromotionEngine_Load(object sender, EventArgs e)
        {
            // Reset all fields;
            Clear();
        }
    }
}
