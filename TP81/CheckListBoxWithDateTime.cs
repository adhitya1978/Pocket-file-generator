using System;
using System.Collections.Generic;
using System.Text;

namespace License_Tems
{
    class CheckListBoxWithDateTime : System.Windows.Forms.CheckedListBox
    {
        protected override void OnItemCheck(System.Windows.Forms.ItemCheckEventArgs ice)
        {
            
            base.OnItemCheck(ice);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
    }
}
