
namespace WebCommercial.Models.Metiers
{
    /// <summary>
    /// Class représentant les enregistrements de la table COMPOSE
    /// </summary>
    public class Compose
    {
        //Définition des properties
        #region Properties
        public string NoCompose { get; set; }
        public string NoComposant { get; set; }
        public int QteComposant { get; set; }
        #endregion

        //Définition des constructeur
        #region Constructors
        /// <summary>
        /// Initialise une nouvelle instance avec tout les paramètres
        /// </summary>
        /// <param name="noCompose">le numéro du composé</param>
        /// <param name="noComposant">le numéro du composant</param>
        /// <param name="qteComposant">la quantité</param>
        public Compose(string noCompose, string noComposant, int qteComposant)
        {
            NoCompose = noCompose;
            NoComposant = noComposant;
            QteComposant = qteComposant;

        }

        /// <summary>
        /// Initialise une nouvelle instance vide
        /// </summary>
        public Compose()
        { }
        #endregion

    }
}