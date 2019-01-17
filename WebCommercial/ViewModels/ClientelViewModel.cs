using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebCommercial.Models.Metiers;

namespace WebCommercial.ViewModels
{
    public class ClientelViewModel
    {

        public int? Id { get; set; }
        [Required(ErrorMessage = "le nom du client doit être saisie")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "le prénom du client doit être saisie")]
        public string Prenom { get; set; }
        public string Societe { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Adresse { get; set; }

        public ClientelViewModel(int? id, string nom, string prenom, string societe, string ville, string codePostal, string adresse)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Societe = societe;
            Ville = ville;
            CodePostal = codePostal;
            Adresse = adresse;
        }

        public ClientelViewModel(Clientel client): 
            this(
                int.Parse(client.NoClient),
                client.NomCl,
                client.PrenomCl,
                client.Societe,
                client.VilleCl,
                client.CodePostCl,
                client.AdresseCl
                )
        {}

        public ClientelViewModel()
        { }
    }
}