using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BW_W3_D5_ProgettoEcommerce
{
    public partial class Dettaglio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // se la pagina viene renderizzata per la prima volta
            if (!IsPostBack)
            {
                // controlliamo che il valore della stringa dell'id della query string che stiamo prendendo dall'URL non sia vuoto o null 
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // Otteniamo l'ID dalla query string e lo convertiamo in int 
                    int itemId = Convert.ToInt32(Request.QueryString["id"]);

                    // Richiamiamo la lista dei prodotti dalla sessione
                    List<_Default.Item> itemsList = (List<_Default.Item>)Session["ItemsList"];

                    // Questo metodo serve a trovare il prodotto con l'ID corrispondente a quello ottenuto dall'URL
                    _Default.Item item = itemsList.FirstOrDefault(i => i.Id == itemId);

                    // se il prodotto esiste e non è null
                    if (item != null)
                    {
                        // verrà impostato come InnerText del titolo H2 con id itemTitle il nome del prodotto
                        itemTitle.InnerText = item.Nome;
                        
                        // e verrà creato un template literal che verrà appeso al div con id detailsBox
                        string newDetail = 
                            $@"
                               <img src='{item.ImmagineUrl}' class='mt-3' height=300/>
                               <p class='mt-4 fs-2'>{item.Descrizione}</p>
                               <p class='mt-4 fs-3'>Prezzo: {item.Prezzo.ToString("C")}</p>
                               <button class='btn btn-primary mt-2' OnClick='addToCart'>Aggiungi al Carrello</button>
                              ";
                        detailsBox.InnerHtml = newDetail;
                    }
                    else
                    {
                        // Altrimenti, se l'elemento non viene trovato, il titolo della pagina diventa un messaggio di errore
                        itemTitle.InnerText = "Elemento non trovato.";
                    }
                }
                else
                {
                    // Oppure se l'ID nella query string non viene specificato, altro messaggio d'errore
                    itemTitle.InnerText = "ID non specificato.";
                }
            }
        }

        // dichiarazione del metodo che all'OnClick aggiunge i prodotti al carrello
        protected void addToCart(object sender, EventArgs e)
        {
            // Stesso procedimento per ottenere l'id dalla query string
            int itemId = Convert.ToInt32(Request.QueryString["id"]);

            // Creiamo una nuova sessione e una nuova lista
            List<_Default.Item> cart = (List<_Default.Item>)Session["Cart"];
            if (cart == null)
            {
                cart = new List<_Default.Item>();
            }

            // Stesso metodo per trovare il prodotto nella lista con ID corrispondente
            _Default.Item prodotto = _Default.itemsList.FirstOrDefault(item => item.Id == itemId);

            // se il prodotto esiste e non è null
            if (prodotto != null)
            {
                // aggiungiamo il prodotto alla lista, e quindi alla sessione
                cart.Add(prodotto);
                Session["Cart"] = cart;
            }

            // Messaggio di conferma che riempie il paragrafo con id message
            message.InnerText = "Prodotto aggiunto al carrello!";
        }
    }
}