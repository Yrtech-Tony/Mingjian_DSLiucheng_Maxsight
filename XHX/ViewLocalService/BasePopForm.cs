using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XHX.ViewLocalService
{
    public partial class BasePopForm : Form
    {
        public BasePopForm()
        {
            InitializeComponent();
            SpecialCaseSearch s = new SpecialCaseSearch();
            ((System.ComponentModel.ISupportInitialize)(s)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(s)).EndInit();
        }
    }
}
