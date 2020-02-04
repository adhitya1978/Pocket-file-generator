using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace License_Tems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupControl();
        }
        
        void SetupControl()
        {
            //! fill list box from options name
            string[] optionnames = Enum.GetNames(typeof(LicenseOptionName));
            checkedListBox1.Items.AddRange(optionnames);
            Txtdeviceid.Text = "89BE8F1E-F5CD9297-CC1327A2-BD94ACFC-1AEBA451";
            DMSoft.SkinCrafter skin = new DMSoft.SkinCrafter();
            skin.SkinFile = "RedJet";
            using (System.IO.MemoryStream ms = new MemoryStream(Properties.Resources.RedJet))
            {
                skin.LoadSkinFromStream(ms);
                skin.ApplySkin();
                ms.Close();
            }

        }

        private void BtGenerate_Click(object sender, EventArgs e)
        {
            int customerid = 0;
            int.TryParse(Txtcustomerid.Text, out customerid);
            
            int systemid = 0;
            int.TryParse(TxtSysID.Text, out systemid);

            string comment = Txtcomment.Text.Length > 0 ? Txtcomment.Text : "TEMS Pocket 8.1";

            if (Txtdeviceid.Text == string.Empty) 
            {
                MessageBox.Show("empty device id not allowed");
                return;
            }

            List<LicenseOption> options = new List<LicenseOption>();
            foreach(string optionname in checkedListBox1.CheckedItems)
            {
                LicenseOption option = new LicenseOption((LicenseOptionName)Enum.Parse(typeof(LicenseOptionName), optionname, true));
                option.StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
                option.EndDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                options.Add(option);
            }

            Parameter device = new Parameter(customerid, systemid, Txtdeviceid.Text, comment);
            device.SelectOption(options);
            
            LicenseManager manager = new LicenseManager(device);
            manager.SaveLicense();
            if (manager.LoadLicenseFile() == false)
            {
                MessageBox.Show("License verify fail.");
            }
            MessageBox.Show("Generate License done.");
        }

        private void Txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            if (!(new System.Text.RegularExpressions.Regex(@"^[0-9]+$")).IsMatch(Txtcustomerid.Text))
            {
                Txtcustomerid.Clear();
                return;
            }
        }

        private void Txtdeviceid_TextChanged(object sender, EventArgs e)
        {
            if (!(new System.Text.RegularExpressions.Regex(@"[a-zA-Z0-9]{8}-[a-zA-Z0-9]{8}-[a-zA-Z0-9]{8}-[a-zA-Z0-9]{8}-[a-zA-Z0-9]{8}")).IsMatch(Txtdeviceid.Text.ToUpper()))
            {
                Txtdeviceid.BackColor = Color.Red;
            }
            else 
            {
                Txtdeviceid.BackColor = Color.Green;
            }

        }

    }
}
