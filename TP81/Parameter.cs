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
