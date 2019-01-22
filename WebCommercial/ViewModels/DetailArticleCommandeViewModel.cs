using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.ViewModels
{
    public class DetailArticleCommandeViewModel
    {

        public int NoArticle { get; set; }
        public string NomArticle { get; set; }
        public float PrixUnitaire { get; set; }
        public int QteCdee { get; set; }
        public float PrixTotalArticle { get; set; }
        public bool Livree { get; set; }

        public DetailArticleCommandeViewModel(int noArticle, string nomArticle, 
            float prixUnitaire, int qteCdee, float prixTotalArticle, bool livree)
        {
            NoArticle = noArticle;
            NomArticle = nomArticle;
            PrixUnitaire = prixUnitaire;
            QteCdee = qteCdee;
            PrixTotalArticle = prixTotalArticle;
            Livree = livree;
        }


    }
}