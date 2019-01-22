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
        [Required(ErrorMessage = "le nom de la société doit être indiqué")]
        public string Societe { get; set; }
        [Required(ErrorMessage = "la ville doit être saisie")]
        public string Ville { get; set; }
        [Required(ErrorMessage = "le code postal est obligatoire")]
        public string CodePostal { get; set; }
        [Required(ErrorMessage = "l'adresse est obligatoire")]
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