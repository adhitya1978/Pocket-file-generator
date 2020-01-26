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
        /***
        private void button1_Click(object sender, EventArgs e)
        {
            opFD.Filter = "License File (*.lic)|*.LIC";
            opFD.Title = "Selece License File";
            if (opFD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = opFD.FileName;                
                
                 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            FileStream fs = new FileStream(textBox1.Text, FileMode.OpenOrCreate,FileAccess.ReadWrite, FileShare.ReadWrite);
           
            loadlicense.Load(fs);
            TxtLog.Items.Clear();
            TxtLog.Items.Add("Comment      :" + loadlicense.Comment);
            TxtLog.Items.Add("Device ID    :" + loadlicense.DeviceId);
            TxtLog.Items.Add("CustomerID   :" + Convert.ToString(loadlicense.CustomerId));
            TxtLog.Items.Add("System ID    :" + Convert.ToString(loadlicense.SystemId));
            TxtLog.Items.Add("TimeStamp   :" + loadlicense.TimeStamp);
            TxtLog.Items.Add("ContentID   :" + loadlicense.ContentId);
            TxtLog.Items.Add("ContentVersion   :" + loadlicense.ContentVersion);
            TxtID.Text = loadlicense.DeviceId;
            fs.Flush();
            fs.Close();
            
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string ID = licensemanage.CreateDeviceId(TxtImei.Text);
            TxtID.Text = ID.ToString();
        }

        private void BtValid_Click(object sender, EventArgs e)
        {
            licensemanage.SetDeviceID(TxtID);
            licensemanage.setPath(textBox1);
            LicenseOptionName LicenseOptionName = new LicenseOptionName();
            LicenseOption licenseoption = new LicenseOption(LicenseOptionName);
            licensemanage.LoadLicense();
            if (licensemanage.CheckLicense())
            {
                TxtLog.Items.Clear();
                 if (licensemanage.IsOptionValid(LicenseOptionName.Pocket))
                  { 
                          licensemanage.CheckOption(LicenseOptionName.Pocket);
                          TxtLog.Items.Add("Option Name :" + LicenseOptionName.Pocket  );                         
                      
                  }
                 if (licensemanage.IsOptionValid(LicenseOptionName.IndoorMaps))
                 {
                     licensemanage.CheckOption(LicenseOptionName.IndoorMaps);
                     TxtLog.Items.Add("Option Name :" + LicenseOptionName.IndoorMaps);
                 
 
                 }
                 if (licensemanage.IsOptionValid(LicenseOptionName.TechCDMA) )
                 {
                     licensemanage.CheckOption(LicenseOptionName.TechCDMA);
                     TxtLog.Items.Add("Option Name :" + LicenseOptionName.TechCDMA);
                     
 
                 }
                 if (licensemanage.IsOptionValid(LicenseOptionName.TechGSM))
                 {
                     licensemanage.CheckOption(LicenseOptionName.TechGSM);
                     TxtLog.Items.Add("Option Name :" + LicenseOptionName.TechGSM);
                    

                 }

                 if (licensemanage.IsOptionValid(LicenseOptionName.TechWCDMA) )
                 {

                     licensemanage.CheckOption(LicenseOptionName.TechWCDMA);
                     TxtLog.Items.Add("Option Name :" + LicenseOptionName.TechWCDMA);
                 
                 }

                 if (licensemanage.IsOptionValid(LicenseOptionName.TraceRouter) )
                 {
                     licensemanage.CheckOption(LicenseOptionName.TraceRouter);
                     TxtLog.Items.Add("Option Name :" + LicenseOptionName.TraceRouter);
                     
                 }
                 
                 TxtLog.Items.Add("Starting Time :" + licenseoption.StartDate);
                 TxtLog.Items.Add("End Time :" + licenseoption.EndDate);


                 if (licenseoption.EndDate != ConfigItem.MAX_DATE)
                 {
                     TxtLog.Items.Add(string.Format("Valid until {0:d}", licenseoption.EndDate));

                 }
                 else
                 {
                     TxtLog.Items.Add("Unlimited License");
                 }


                 }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(@"D:\", "logging.ini");
            loadlicense.WriteLicense();

            loadlicense.Save(path);
        }

        private void BtSaveLi_Click(object sender, EventArgs e)
        {

        }
        **/
        

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
