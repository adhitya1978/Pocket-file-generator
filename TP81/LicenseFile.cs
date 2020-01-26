using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace License_Tems
{

    public class LicenseFile : StructuredConfigFile
    {

        private string comment;
        private const int CurrentVersion = 0;
        private int customerId = 1;
        private string deviceId;
        private SortedList<LicenseOptionName, LicenseOption> options = new SortedList<LicenseOptionName, LicenseOption>();
        private static readonly byte[] PublicKeyBlob = new byte[] { 
            6, 2, 0, 0, 0, 0xa4, 0, 0, 0x52, 0x53, 0x41, 0x31, 0, 4, 0, 0, 
            1, 0, 1, 0, 0xe9, 0x87, 0x21, 0x51, 140, 0x34, 0xf9, 0xc6, 0xf9, 0x1d, 50, 0xfe, 
            160, 0xbb, 0xf5, 100, 0xe5, 0x81, 20, 0xb5, 0x4b, 0xdb, 0x18, 0x21, 0xda, 2, 0xb3, 200, 
            0x5f, 13, 0xbf, 0x2c, 0xa3, 0x24, 0xe3, 0xb9, 0x39, 0x84, 250, 0x6d, 0x66, 0x68, 0xa5, 20, 
            3, 0x2a, 0x75, 0x13, 0x76, 0x7b, 0xfe, 210, 0xc7, 0x43, 0x61, 0xf7, 0x45, 0x21, 0xed, 0x8d, 
            50, 0x58, 0xce, 0x77, 20, 0x7c, 0x48, 80, 0x8b, 50, 0x5d, 110, 0x67, 0xee, 0x85, 0xf1, 
            0x71, 0x3e, 0xd5, 0x33, 0xbb, 0x85, 0x15, 15, 0x26, 0x57, 0x4e, 0xc2, 0x26, 0x8e, 210, 0x4f, 
            0xf9, 230, 140, 0xb5, 0xf1, 0xfb, 0xf5, 0xec, 0x9e, 0xe9, 0xef, 0xf8, 6, 0xef, 0x91, 0x33, 
            0xba, 0x49, 0x4c, 0xed, 0x48, 12, 0x41, 0x31, 0x95, 0x25, 40, 0x76, 0x15, 0x73, 0x76, 0x1b, 
            0x53, 130, 13, 0xce
         };

        private int systemId;
        private DateTime timeStamp;

        public LicenseFile()
        {
            timeStamp = DateTime.Now;
        }
        public void addOption(LicenseOption option)
        {
            if (options.Count != 0)
            {
                options.Add(option.Name, option);
            }


        }

        public override void LoadFromList(IEnumerable<ConfigSection> sections, int version)
        {
            MemoryStream stream = new MemoryStream();

            byte[] signature = null;
            foreach (ConfigSection section in sections)
            {
                if (section.Id == 0)
                {
                    foreach (ConfigItem item in section)
                    {
                        switch (item.Tag)
                        {
                            case 0:
                                {
                                    signature = item.RawValue;
                                    //writer.BaseStream.Write(signature,0,signature.Length);
                                    continue;
                                }
                            case 1:
                                {
                                    this.timeStamp = item.DateTimeValue;
                                    //writer.Write(timeStamp.ToString());
                                    continue;
                                }
                            case 2:
                                {
                                    this.CustomerId = item.IntegerValue;
                                    //writer.Write(customerId);
                                    continue;
                                }
                            case 3:
                                {
                                    this.SystemId = item.IntegerValue;
                                    //writer.Write(systemId);
                                    continue;
                                }
                            case 4:
                                {
                                    this.DeviceId = item.StringValue;
                                    //writer.Write(deviceId);
                                    continue;
                                }
                            case 5:
                                {
                                    this.Comment = item.StringValue;
                                    //writer.Write(comment);
                                    continue;
                                }
                        }
                    }

                }
                else
                {

                    LicenseOption option = new LicenseOption((LicenseOptionName)section.Id);
                    foreach (ConfigItem item2 in section)
                    {
                        switch (item2.Tag)
                        {
                            case 0:
                                {
                                    option.StartDate = item2.DateTimeValue;
                                    //writer.Write(option.Name.ToString()+"-"+item2.DateTimeValue.ToString());
                                    continue;
                                }
                            case 1:
                                {
                                    option.EndDate = item2.DateTimeValue;
                                    //writer.Write(option.Name.ToString() + "-" + item2.DateTimeValue.ToString());
                                    continue;
                                }

                        }
                    }
                    addOption(option);
                }
                stream.WriteByte((byte)section.Id);
                foreach (ConfigItem item3 in section)
                {
                    if ((section.Id != 0) || (item3.Tag != 0))
                    {
                        stream.WriteByte((byte)item3.Tag);
                        stream.Write(item3.RawValue, 0, item3.RawValue.Length);
                    }
                }
            }
            if (signature == null)
            {
                throw new IOException("License hash not found.");
            }
            byte[] buffer = stream.ToArray();
            BinaryWriter bufferbinary = new BinaryWriter(new FileStream(@"buffer.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite));
            bufferbinary.Write(buffer);
            bufferbinary.Flush();
            bufferbinary.Close();

            BinaryWriter fsign = new BinaryWriter(new FileStream(@"signature.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite));
            fsign.Write(signature);
            fsign.Close();

            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.ImportCspBlob(PublicKeyBlob);

            if (!provider.VerifyData(buffer, "SHA1", signature))
            {
                throw new IOException("License signature invalid.");
            }



        }


        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }


        public void WriteLicense()
        {
            BinaryReader reader = new BinaryReader(new FileStream(@"D:\binary1.bin", FileMode.Open, FileAccess.Read));
            byte[] signature = null;
            ConfigSection cs = new ConfigSection();
            ConfigItem _item = new ConfigItem(reader, -1);
            cs.Add(_item);
            cs.Id = 0;
            if (cs.Id == 0)
            {
                foreach (ConfigItem item in cs)
                {
                    switch (item.Tag)
                    {
                        case 0:
                            {
                                signature = item.RawValue;
                                break;
                            }
                        case 1:
                            {
                                this.timeStamp = DateTime.Now;
                                continue;
                            }
                        case 2:
                            {
                                this.CustomerId = 1;
                                continue;
                            }
                        case 3:
                            {
                                this.SystemId = 2797;
                                continue;
                            }
                        case 4:
                            {
                                this.DeviceId = "A7E8C86F-51A957BD-CD123C19-CA3E15D3-B97035C7";
                                continue;
                            }
                        case 5:
                            {
                                this.Comment = "Pocket";
                                continue;
                            }

                    }

                }
            }
            else if (cs.Id == 1)
            {


            }

        }

        protected override IEnumerable<ConfigSection> SaveToList()
        {
            List<ConfigSection> section = new List<ConfigSection>();
            ConfigSection SectionAdd = new ConfigSection(0);
            ConfigItem ItemInsert = new ConfigItem(0, true);
            section.Add(SectionAdd);
            SectionAdd.Add(ItemInsert);

            foreach (ConfigSection sec in section)
            {
                if (sec.Id == 0)
                {
                    foreach (ConfigItem itemsave in sec)
                    {
                        switch (itemsave.Tag)
                        {
                            case 0:
                                {
                                    timeStamp = DateTime.Now;
                                    continue;
                                }
                            case 1:
                                {
                                    this.comment = "IMEI";
                                    continue;
                                }
                            case 2:
                                {
                                    this.customerId = 1;
                                    continue;
                                }
                            case 3:
                                {
                                    //-----------Set unique id ----------- //
                                    this.deviceId = "";
                                    continue;
                                }
                            case 4:
                                {
                                    this.systemId = 2797;
                                    continue;
                                }
                            case 5:
                                {
                                    //---------- RSA need to sign data --------//

                                    continue;
                                }

                        }

                    }
                }
                else
                {
                    LicenseOption option = new LicenseOption((LicenseOptionName)sec.Id);

                    foreach (ConfigItem ItemName in sec)
                    {

                        switch (ItemName.Tag)
                        {
                            case 0:
                                {
                                    option.StartDate = DateTime.Now;
                                    continue;
                                }
                            case 1:
                                {
                                    option.EndDate = DateTime.MaxValue;
                                    continue;
                                }
                        }
                    }
                    addOption(option);
                    section.Add(sec);
                }


            }
            return SaveToList();
            // throw new Exception("generate license not support");

        }

        /*Test Code generate*/
        public override void create(IEnumerable<ConfigSection> Section)
        {

            foreach (ConfigSection section in SaveToList())
            {

                if (section.Id == 0)
                {
                    foreach (ConfigItem item in section)
                    {
                        switch (item.Tag)
                        {
                            case 0:
                                this.customerId = this.CustomerId;
                                continue;
                            case 1:
                                this.deviceId = this.DeviceId;
                                continue;
                            case 2:
                                this.comment = this.Comment;
                                continue;
                            case 3:
                                this.TimeStamp = timeStamp;
                                continue;
                            case 4:

                                break;



                        }
                    }
                }
            }
            throw new NotImplementedException();
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public override int ContentId
        {

            get
            {
                return ContentIds.License;
            }


        }

        public override int ContentVersion
        {
            get
            {
                return 0;
            }
        }

        public int CustomerId
        {
            get
            {
                return this.customerId;
            }
            set
            {
                this.customerId = value;
            }
        }

        public string DeviceId
        {
            get
            {
                return this.deviceId;
            }
            set
            {
                this.deviceId = value;
            }
        }

        public SortedList<LicenseOptionName, LicenseOption> Options
        {
            get
            {
                return this.options;
            }
        }

        public int SystemId
        {
            get
            {
                return this.systemId;
            }
            set
            {
                this.systemId = value;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
            set
            {
                this.timeStamp = value;
            }
        }

        protected enum GlobalSettings
        {
            Signature,
            TimeStamp,
            CustomerId,
            SystemId,
            DeviceId,
            Comment
        }

        protected enum OptionSettings
        {
            StartDate,
            EndDate
        }


    }
}
