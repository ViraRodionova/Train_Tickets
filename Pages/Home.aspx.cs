using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Home : System.Web.UI.Page
{
    static int id = 200;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["getTrains"] = true;
        //ddlFrom.SelectedIndex = 3;
        //ddlTo.SelectedIndex = 4;
        txtDateOne.Text = "4/24/2016";
        btnSearch.Text = Language.GetLang().Home_SearchBtn();
    }

    private void AddPlacesInDB()
    {
        //int c_id = Convert.ToInt32(txtC_id.Text);
        //string c_type = txtC_type.Text;

        int c_id = -1;
        string c_type = null;

        switch (c_type)
        {
            case "П":
                for(int i = 1; i < 55; i++)
                {
                    id++;
                    //ConnectionClass.InsertPlaces(id, i, c_id);
                }

                break;
            case "К":
                for (int i = 1; i < 37; i++)
                {
                    id++;
                   // ConnectionClass.InsertPlaces(id, i, c_id);
                }

                break;
            case "Л":
                for (int i = 1; i < 21; i++)
                {
                    id++;
                    //ConnectionClass.InsertPlaces(id, i, c_id);
                }

                break;
            default:
                break;
        }
    }

    protected void cbOne_CheckedChanged(object sender, EventArgs e)
    {
        if (cbOne.Checked)
        {
            cbTwo.Checked = false;
            txtDateTwo.Visible = false;
        }
        else
        {
            cbTwo.Checked = true;
            txtDateTwo.Visible = true;
        }
        Page.DataBind();
    }

    protected void cbTwo_CheckedChanged(object sender, EventArgs e)
    {
        if (cbTwo.Checked)
        {
            cbOne.Checked = false;
            txtDateTwo.Visible = true;
        }
        else
        {
            cbOne.Checked = true;
            txtDateTwo.Visible = false;
        }
        Page.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchResults.aspx?stFrom=" + ddlFrom.SelectedValue
            + "&stTo=" + ddlTo.SelectedValue
            + "&date=" + txtDateOne.Text.ToString());
        
        /*string[] stations = ConnectionClass.GetStations("");
        StringBuilder sb = new StringBuilder();
        foreach(string st in stations)
        {
            sb.Append(st);
            sb.Append(", ");
        }
        lblResult.Text = sb.ToString();
        Page.DataBind();
        //InsertPlaces();*/
    }

    private void InsertPlaces()
    {
        ArrayList carriages = ConnectionClass.ListOfCarriagesID();

        foreach(Carriage c in carriages)
        {
            switch (c.type)
            {
                case 'П':
                    for (int i = 1; i < 55; i++)
                    {
                        id++;
                        ConnectionClass.InsertPlaces(i, c.Id);
                    }

                    break;
                case 'К':
                    for (int i = 1; i < 37; i++)
                    {
                        id++;
                        ConnectionClass.InsertPlaces(i, c.Id);
                    }

                    break;
                case 'Л':
                    for (int i = 1; i < 21; i++)
                    {
                        id++;
                        ConnectionClass.InsertPlaces(i, c.Id);
                    }

                    break;
                default:
                    break;
            }
        }

    }

    protected void btnReverse_Click(object sender, ImageClickEventArgs e)
    {
        string tmp = ddlFrom.SelectedValue;
        ddlFrom.SelectedValue = ddlTo.SelectedValue;
        ddlTo.SelectedValue = tmp;
    }
}