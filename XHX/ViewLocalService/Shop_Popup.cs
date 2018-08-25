using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.Common;
using XHX.DTO;

namespace XHX.ViewLocalService
{
    public partial class Shop_Popup : DevExpress.XtraEditors.XtraForm
    {
        ShopDto shopdto = null;
        List<ShopDto> shopList = new List<ShopDto>();

        public List<ShopDto> ShopList
        {
            get { return shopList; }
            set { shopList = value; }
        }
        localhost.Service webService = new XHX.localhost.Service();

        public ShopDto Shopdto
        {
            get { return shopdto; }
            set { shopdto = value; }
        }
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public Shop_Popup()
        {

        }
        public Shop_Popup(string shopCode, string shopName, bool check)
        {
            InitializeComponent();
            webService.Url = "http://192.168.1.99/XHX.YiQiServer/service.asmx";
            this.LookAndFeel.SetSkinStyle(CommonHandler.Skin_Name);

            OnLoadView();
            //CommonHandler.SetComboBoxSelectedValue(cboArea, areaCode);
            Search(shopCode, shopName);
            if (check)
            {
                selection = new GridCheckMarksSelection(gridView1);
                selection.CheckMarkColumn.VisibleIndex = 0;
            }
            else
            {

            }
        }
        public void OnLoadView()
        {
            //BindComBox.BindArea(cboArea);
            // CommonHandler.BindComboBoxItems<AreaDto>(cboAreaCode, BindComBox.GetAllArea(), "AreaName", "AreaCode");
            //cboArea.Enabled = false;
        }
        private void Search(string shopCode, string shopName)
        {
            DataSet ds = webService.SearchShop(shopCode, shopName);
            List<ShopDto> shoplist = new List<ShopDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopDto shop = new ShopDto();
                    //shop.AreaCode = Convert.ToString(ds.Tables[0].Rows[i]["AreaCode"]);
                    //shop.AreaName = Convert.ToString(ds.Tables[0].Rows[i]["AreaName"]);
                    shop.SaleSmall = Convert.ToString(ds.Tables[0].Rows[i]["SellSmallAreaName"]);
                    shop.SaleBig = Convert.ToString(ds.Tables[0].Rows[i]["SellBigAreaName"]);
                    shop.AfterSmall = Convert.ToString(ds.Tables[0].Rows[i]["AfterSmallAreaName"]);
                    shop.AfterBig = Convert.ToString(ds.Tables[0].Rows[i]["AfterBigAreaName"]);
                    shop.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    shop.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    shoplist.Add(shop);
                }
            }
            grcShop.DataSource = shoplist;
        }
        public void InitializeView()
        {
            txtShop.Text = "";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtShopCode.Text, txtShop.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            shopdto = gridView1.GetRow(gridView1.FocusedRowHandle) as ShopDto;
            this.Close();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName != "CheckMarkSelection")
                e.Appearance.BackColor = Color.Gray;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "CheckMarkSelection") != null && gridView1.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    shopList.Add(gridView1.GetRow(i) as ShopDto);
                }
            }
            this.Close();
        }
    }
}
