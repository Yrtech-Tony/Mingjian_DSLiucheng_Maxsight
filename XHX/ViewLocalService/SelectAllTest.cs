using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX;
using XHX.Common;

namespace XHX.ViewLocalService
{
    public partial class SelectAllTest : BaseForm
    {
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }

        XtraGridDataHandler<NameValue> xtraGridDataHandler = null;

        public SelectAllTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

            List<NameValue> nameValueList = new List<NameValue>();
            nameValueList.Add(new NameValue("sss", "sssValue"));
            nameValueList.Add(new NameValue("sss1", "sssValue1"));
            nameValueList.Add(new NameValue("sss2", "sssValue2"));

            CommonHandler.SetComboBoxEditItems(cboNameValue, nameValueList, "Name", "Value");

            xtraGridDataHandler = new XtraGridDataHandler<NameValue>(gridView1);
            CommonHandler.SetButtonImage(btnPopup, ButtonImageType.POPUP);

            gridControl1.DataSource = nameValueList;

            selection = new GridCheckMarksSelection(gridView1);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

        //show selected
        private void button1_Click(object sender, System.EventArgs e)
        {
            string s = "";
            for (int i = 0; i < selection.SelectedCount; i++)
                s += (selection.GetSelectedRow(i) as NameValue).Name + "\n";
            MessageBox.Show(s, "Selected count: " + selection.SelectedCount.ToString());
        }

        //select all
        private void button2_Click(object sender, System.EventArgs e)
        {
            selection.SelectAll();
        }

        //unselect all
        private void button3_Click(object sender, System.EventArgs e)
        {
            selection.ClearSelection();
        }

        //add row
        private void button4_Click(object sender, EventArgs e)
        {
            List<NameValue> dataSource = gridControl1.DataSource as List<NameValue>;
            NameValue nv = new NameValue("aaa", "111");

            xtraGridDataHandler.AddRow(nv);
        }

        //delete row
        private void button5_Click(object sender, EventArgs e)
        {
            xtraGridDataHandler.DelCheckedRow(gridView1.Columns.ColumnByFieldName("CheckMarkSelection"));
            selection.ClearSelection();
        }

        //save
        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("selectedValue:" + CommonHandler.GetComboBoxSelectedValue(cboNameValue));
            MessageBox.Show("DataList:" + xtraGridDataHandler.DataList.Count);

            List<NameValue> nvList = new List<NameValue>();
            foreach (NameValue nv in gridControl1.DataSource as List<NameValue>)
            {
                nv.StatusType = StatusTypes.NONE;
                nvList.Add(nv);
            }

            gridControl1.DataSource = nvList;
        }

        //show message
        private void button7_Click(object sender, EventArgs e)
        {
            if (CommonHandler.ShowMessage(MessageType.Confirm,"Save?") == DialogResult.Yes)
            {
                CommonHandler.ShowMessage(MessageType.Information, "Yes");
            }
            else
            {
                CommonHandler.ShowMessage(MessageType.Information, "No");
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string[] fileNames = null;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog.FileNames;
            }

            foreach(string fileName in fileNames)
            {
                txtPath.Text += fileName + "; ";
            }

            if (txtPath.Text.EndsWith("; "))
                txtPath.Text = txtPath.Text.Remove(txtPath.Text.LastIndexOf("; "));
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            CommonHandler.UploadImage(txtPath.Text,"20110201001","哈哈");
        }
    }

    class NameValue
    { 
        public string Name{get;set;}
        public string Value { get; set; }
        public char StatusType { get; set; }

        public NameValue() { }

        public NameValue(string name, string value) {
            Name = name;
            Value = value;
        }
    }
}
