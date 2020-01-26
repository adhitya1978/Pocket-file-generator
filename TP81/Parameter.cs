using System;
using System.Collections.Generic;
using System.Text;

namespace License_Tems
{
    public class Parameter
    {
        //! customer id
        int customerId;
        //! system id
        int systemid;
        //! device id
        string deviceid;
        //! comment
        string comment;

        List<LicenseOption> options;

        public Parameter(int CustomerId, int SystemId, string DeviceId, string Comment)
        {
            customerId = CustomerId;
            systemid = SystemId;
            deviceid = DeviceId;
            comment = Comment;
        }

        public void SelectOption(List<LicenseOption> Options)
        {
            options = Options;
        }

        public int CustomerId
        {
            get{ return customerId; }
        }
        public int SystemId
        {
            get { return systemid; } 
        }
        public string DeviceId
        {
            get 
            {
                /**
                byte[] deviceUniqueID = System.Text.ASCIIEncoding.ASCII.GetBytes(deviceid);
                StringBuilder builder = new StringBuilder(deviceUniqueID.Length * 3);
                for (int i = 0; i < deviceUniqueID.Length; i++)
                {
                    if ((i > 0) && ((i % 4) == 0))
                    {
                        builder.Append('-');
                    }
                    builder.AppendFormat(null, "{0:X2}", new object[] { deviceUniqueID[i] });
                }
                return builder.ToString();
                **/
                return deviceid;
            }
        }

        public string Comment
        {
            get { return comment; }
        }

        public List<LicenseOption> Options
        {
            get { return options; }
        }

    }
}
