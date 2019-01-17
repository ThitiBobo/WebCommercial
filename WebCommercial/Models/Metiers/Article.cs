
namespace WebCommercial.Models.Metiers
{
    /// <summary>
    /// Class représentant les enregistrements de la table Article
    /// </summary>
    public class Article
    {
        //Définition des properties
        #region Properties
        public int NoArtcile { get; set; }
        public string LibArticle { get; set; }
        public int QteDispo { get; set; }
        public string VilleArt { get; set; }
        public float PrixArt { get; set; }
        public string Interrompu { get; set; }
        #endregion

        //Définition des constructeurs
        #region Constructeurs
        public Article(int noArtcile, string libArticle, int qteDispo, string villeArt, float prixArt, string interrompu)
        {
            NoArtcile = noArtcile;
            LibArticle = libArticle;
            QteDispo = qteDispo;
            VilleArt = villeArt;
            PrixArt = prixArt;
            Interrompu = interrompu;
        }

        public Article()
        { }
        #endregion



    }
}