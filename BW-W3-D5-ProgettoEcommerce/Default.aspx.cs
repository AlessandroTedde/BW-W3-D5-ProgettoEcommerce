using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BW_W3_D5_ProgettoEcommerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // se la sessione non esiste già...
                if (Session["ItemsList"] == null)
                {
                    // ...inizializzo la sessione ItemsList che mi servirà per immagazzinare i prodotti dentro la lista per poi riutilizzarli in altre pagine
                    Session["ItemsList"] = itemsList;
                }
                // per ogni oggetto nella lista oggetti 
                foreach(Item item in itemsList)
                {
                    // Creo questa stringa in template literal che sfrutta i dati dei prodotti nella lista per popolare vari attributi/InnerText
                    string newCard = $@"
                        <div class='col'>
                                 <div class='card'>
                                     <img src='{item.ImmagineUrl}' class='card-img-top' height=194 width=194>
                                     <div class='card-body'>
                                       <h5 class='card-title'>{item.Nome}</h5>
                                         <a href='Dettaglio.aspx?id={item.Id}' class='btn btn-primary mt-3'>Vai ai Dettagli</a>
                                     </div>
                                </div>
                            </div>";
                    // appendo il template literal appena creato all'elemento nella pagina aspx con id itemsBox, che chiaramente si ripeterà per ogni prodotto presente nella lista
                    itemsBox.InnerHtml += newCard;

                }
            }
        }
        // istanzio la classe Item
            public class Item
            {
                public int Id { get; set; }
                public string Nome { get; set; }
                public string Descrizione { get; set; }
                public double Prezzo { get; set; }
                public string ImmagineUrl { get; set; }
                public int Quantita { get; set; } 

            // la inizializzo
            public Item(int id, string nome, string descrizione, double prezzo, string immagine, int quantita)
            {
                Id = id;
                Nome = nome;
                Descrizione = descrizione;
                Prezzo = prezzo;
                ImmagineUrl = immagine;
                Quantita = quantita;
            }
         }

         
            // creo la lista statica itemsList richiamando la classe Item
            public static List<Item> itemsList = new List<Item>()
            {
               
                
                    new Item
                    (
                        0,
                        "Smartwatch Fitness Tracker",
                        "Monitora la tua attività fisica, il sonno e le notifiche del telefono con questo smartwatch elegante e funzionale. Dotato di GPS integrato e resistente all'acqua, è l'accessorio perfetto per chi vuole mantenere uno stile di vita attivo.",
                        129.70,
                        "https://www.ilgrandebazar.it/cdn/shop/products/61t1cks8mBL_507af09a-9105-4835-be69-fd2a0e14793e_1500x.jpg?v=1583402723",
                        0
                    ),
                    new Item
                    (
                        1,
                        "Set Pennelli Professionali",
                        "Realizza look impeccabili con questo set di pennelli da trucco di alta qualità. Con diverse forme e dimensioni per applicare fondotinta, ombretto, eyeliner e altro ancora, questo set è indispensabile per gli amanti del trucco.",
                        25.60,
                        "https://vip-makeup.it/wp-content/uploads/2021/02/pennelli-sito.jpg",
                        0
                    ),
                    new Item
                    (
                        2,
                        "Fotocamera Mirrorless",
                        "Cattura momenti indimenticabili con questa fotocamera mirrorless compatta e potente. Dotata di un sensore di immagine avanzato e la capacità di cambiare obiettivi, questa fotocamera offre prestazioni da professionista in un corpo leggero e portatile.",
                        3599.99,
                        "https://www.resetdigitale.it/119043-large_default/fotocamera-mirrorless-fujifilm-x-s10-18-55mm.jpg",
                        0
                    ),
                    new Item
                    (
                        3,
                        "Tappetino da Yoga Antiscivolo",
                        "Pratica yoga con comfort e sicurezza su questo tappetino antiscivolo di alta qualità. Realizzato in materiale ecologico e disponibile in vari colori vivaci, questo tappetino ti aiuta a mantenere la concentrazione durante ogni posizione.",
                        12.00,
                        "https://staticfanpage.akamaized.net/wp-content/uploads/sites/11/2019/06/Tappetino-da-yoga-Toplus.jpg",
                        0
                    ),
                    new Item
                    (
                        4,
                        "Auricolari Bluetooth",
                        "Goditi la libertà di ascoltare musica ovunque tu vada con questi auricolari Bluetooth wireless. Con un design leggero e un audio nitido, questi auricolari offrono un'esperienza di ascolto senza interruzioni per ore.",
                        57.50,
                        "https://photo.yeppon.it/jbl-wave-200tws-cuffie/95-95670640_1192680305.jpg",
                        0
                    ),
                    new Item
                    (
                        5,
                        "Borsa da Viaggio con Ruote",
                        "Viaggia con stile e praticità con questa borsa da viaggio resistente con ruote. Dotata di scomparti spaziosi e tasche organizer, questa borsa ti permette di trasportare comodamente tutti i tuoi effetti personali durante i tuoi viaggi.",
                        125.70,
                        "https://www.shopsmart.it/642-thickbox_default/borsone-viaggio-con-ruote-uomo-donna-trolley-pelle-morbido-borsa-viaggio-nero.jpg",
                        0
                    )
                };

    }
        
    }
