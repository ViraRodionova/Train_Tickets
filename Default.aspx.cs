using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void cbOneWay_CheckedChanged(object sender, EventArgs e)
    {
        if (cbOneWay.Checked == true) cbTwoWay.Checked = false;
    }

    protected void cbTwoWay_CheckedChanged(object sender, EventArgs e)
    {
        if (cbTwoWay.Checked == true) cbOneWay.Checked = false;
    }

    protected void btnReplaceDates_Click(object sender, ImageClickEventArgs e)
    {
        string tmp = txtDateFrom.Text;
        txtDateFrom.Text = txtDateTo.Text;
        txtDateTo.Text = tmp;
    }
}