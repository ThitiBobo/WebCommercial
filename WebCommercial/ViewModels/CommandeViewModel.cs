using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebCommercial.Models.Metiers;
using WebCommercial.ViewModels;

namespace WebCommercial.Controllers
{
    public class CommandeViewModel
    {
        
        public int NoCommande{ get; set; }
        public Vendeur Vendeur{ get; set; }
        public ClientelViewModel Clientel { get; set; }
        public string Date { get; set; }
        public bool Facture { get; set; }

        public IEnumerable<SelectListItem> Vendeurs { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }

        public CommandeViewModel(int noCommande, Vendeur vendeur, Clientel clientel, string date, bool facture)
        {
            NoCommande = noCommande;
            Vendeur = vendeur;
            Clientel = new ClientelViewModel(clientel);
            Date = date;
            Facture = facture;

            Vendeurs = new List<SelectListItem>();
            Clients = new List<SelectListItem>();
        }

        public CommandeViewModel(Commande commande):
            this(
                int.Parse(commande.NoCommand),
                commande.Vendeur,
                commande.Client,
                commande.Date,
                commande.Facture)
        {}

        public CommandeViewModel()
        {
            Vendeur = new Vendeur();
            Clientel = new ClientelViewModel();
            Vendeurs = new List<SelectListItem>();
            Clients = new List<SelectListItem>();
        }

    }
}