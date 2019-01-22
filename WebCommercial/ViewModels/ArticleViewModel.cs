using System.Collections.Generic;
using WebCommercial.Models.Metiers;

namespace WebCommercial.Controllers
{
    public class ArticleViewModel
    {
        public int NoArticle { get; set; }
        public string LibArticle { get; set; }
        public int QteDispo { get; set; }
        public string VilleArticle { get; set; }
        public float PrixArticle { get; set; }
        public string Interrompu { get; set; }

        public ArticleViewModel(int noArticle, string libArticle, int qteDispo, string villeArticle, float prixArticle, string interrompu)
        {
            NoArticle = noArticle;
            LibArticle = libArticle;
            QteDispo = qteDispo;
            VilleArticle = villeArticle;
            PrixArticle = prixArticle;
            Interrompu = interrompu;
        }

        public ArticleViewModel(Article article):
            this(
                article.NoArtcile,
                article.LibArticle,
                article.QteDispo,
                article.VilleArt,
                article.PrixArt,
                article.Interrompu
                )
        {}

        public ArticleViewModel()
        {

        }

        
    }
}