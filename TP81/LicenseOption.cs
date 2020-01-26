using System;
using System.Collections.Generic;
using System.Text;


namespace License_Tems
{
  public class LicenseOption
    {
        DateTime endDate;
        LicenseOptionName OptionName;
        private DateTime startDate;

        public LicenseOption(LicenseOptionName name)
        {
          
            this.OptionName = name;
            this.startDate = ConfigItem.MIN_DATE;
           this.endDate = ConfigItem.MAX_DATE;
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        public LicenseOptionName Name
        {
            get
            {
                return this.OptionName;
            }
           
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }
    }
}
