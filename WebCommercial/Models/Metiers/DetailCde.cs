
using System.Collections.Generic;

namespace WebCommercial.Models.Metiers
{
    /// <summary>
    /// Class représentant les enregistrements de la table DETAIL_CDE
    /// </summary>
    public class DetailCde
    {
        //Définition des properties
        #region Properties
        public Commande Commande { get; set; }
        public int NbArticle { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<int> QteCdees { get; set; }
        public IEnumerable<bool> Livrees { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance avec tout les paramètres
        /// </summary>
        /// <param name="Commande">instance de la commande</param>
        /// <param name="nbArticle">nombre d'article en lien avec la commande</param>
        /// <param name="articles">l'article de la commande</param>
        /// <param name="qteCdees">la quantitée</param>
        /// <param name="livrees">l'état de la commande</param>
        public DetailCde(Commande commande,int nbArticle, IEnumerable<Article> articles, IEnumerable<int> qteCdees, IEnumerable<bool> livrees)
        {
            Commande = commande;
            NbArticle = nbArticle;
            Articles = articles;
            QteCdees = qteCdees;
            Livrees = livrees;
        }

        /// <summary>
        /// Initialise une nouvelle instance vide
        /// </summary>
        public DetailCde()
        { }
        #endregion


    }
}