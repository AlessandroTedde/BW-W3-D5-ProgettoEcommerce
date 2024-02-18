using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BW_W3_D5_ProgettoEcommerce
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            
            // se la sessione esiste già...
            if (Session["Cart"] != null)
            {
                // richiamo la lista dei prodotti nel carrello
                List<_Default.Item> cart = (List<_Default.Item>)Session["Cart"];

                // ...e la connetto al datasource
                CartGrid.DataSource = cart;
                CartGrid.DataBind();
                // connetto i DataField ai campi della lista cart
                CartGrid.DataKeyNames = new string[] { "Id" };
                CartGrid.DataBind();



                // calcolo il totale
                double total = 0;
                foreach (_Default.Item item in cart)
                {
                    total += item.Prezzo * item.Quantita;
                }
                // e lo mostro
                TotalLabel.Text = $"Totale: {total.ToString("C")}";
            }
            else
            {
                EmptyCartButton.Visible = false;
                EmptyCartLabel.Visible = true;
            }
          }
        }
        protected void EmptyCartButton_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                // svuoto il carrello
                Session["Cart"] = null;
                // e ricarico la pagina
                Response.Redirect("Carrello.aspx");
            }
            else
            {
                EmptyCartLabel.Visible = true;
                EmptyCartLabel.Text = "Il carrello è già vuoto.";
            }
        }

        protected void ContinueShoppingButton_Click(object sender, EventArgs e)
        {
            // torno alla pagina principale
            Response.Redirect("Default.aspx");
        }
    }
}