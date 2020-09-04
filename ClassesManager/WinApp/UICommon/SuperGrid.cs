using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADGV;
using System;

namespace ClassManager.WinApp.UICommon
{
    class SuperGrid : AdvancedDataGridView
    {
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
        public int _pageSize = 25;
        public BindingSource bs = new BindingSource();
        BindingList<DataTable> tables;

        public void SetPagedDataSource(DataTable dataTable, BindingNavigator bnav)
        {
            tables = new BindingList<DataTable>();
            DataTable dt = null;
            int counter = 1;
            foreach (DataRow dr in dataTable.Rows)
            {
                if (counter == 1)
                {
                    dt = dataTable.Clone();
                    tables.Add(dt);
                }
                dt.Rows.Add(dr.ItemArray);
                if (PageSize < ++counter)
                {
                    counter = 1;
                }
            }
            bnav.BindingSource = bs;
            bs.DataSource = tables;
            bs.PositionChanged += bs_PositionChanged;
            if (bs.Position != -1)
            {
                bs_PositionChanged(bs, EventArgs.Empty);
            }
            else
            {
                this.DataSource = dataTable;
            }
        }
        void bs_PositionChanged(object sender, EventArgs e)
        {
            if (tables.Count > 0)
            {
                this.DataSource = tables[bs.Position];
            }
        }
    }
}
