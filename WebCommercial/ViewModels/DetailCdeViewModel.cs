using System.Collections.Generic;
using WebCommercial.Models.Metiers;
using WebCommercial.ViewModels;

namespace WebCommercial.Controllers
{
    public class DetailCdeViewModel
    {
        
        public CommandeViewModel CommandeVM { get; set; }
        public List<DetailArticleCommandeViewModel> DetailArticle { get; set; }
        public float PrixTotal { get; set; }

        

        public DetailCdeViewModel(DetailCde detailCde)
        {
            CommandeVM = new CommandeViewModel(detailCde.Commande);
            List<Article> ListArticle = (List<Article>)detailCde.Articles;
            DetailArticle = new List<DetailArticleCommandeViewModel>();
            for (int i = 0; i < ListArticle.Count; i++)
            {
                DetailArticle.Add(
                    new DetailArticleCommandeViewModel(
                        ListArticle[i].NoArtcile,
                        ListArticle[i].LibArticle, 
                        ListArticle[i].PrixArt,
                        ((List<int>)detailCde.QteCdees)[i],
                        ((List<int>)detailCde.QteCdees)[i] * ListArticle[i].PrixArt,
                        ((List<bool>)detailCde.Livrees)[i]));
                        
            }
            foreach (DetailArticleCommandeViewModel detailArt in DetailArticle)
                PrixTotal += detailArt.PrixTotalArticle;
        }

        public DetailCdeViewModel()
        {
            CommandeVM = new CommandeViewModel();
            DetailArticle = new List<DetailArticleCommandeViewModel>();
        }
    }
}