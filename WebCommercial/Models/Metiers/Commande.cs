using System;

namespace WebCommercial.Models.Metiers
{
    /// <summary>
    /// Class représentant les enregistrements de la table COMMANDES
    /// </summary>
    public class Commande
    {
        //Déclaration des properties
        #region Properties
        public string NoCommand { get; set; }
        public Vendeur Vendeur { get; set; }
        public Clientel Client { get; set; }
        public DateTime Date { get; set; }
        public bool Facture { get; set; }
        #endregion

        //Déclaration des constructeurs
        #region Constructors
        public Commande(string noCommand, Vendeur vendeur, Clientel client, DateTime date, bool facture)
        {
            NoCommand = noCommand;
            Vendeur = vendeur;
            Client = client;
            Date = date;
            Facture = facture;
        }

        public Commande()
        { }
        #endregion

    }
}