using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models.Persistance;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;
using WebCommercial.Models.Erreurs;

namespace WebCommercial.Models.DAO
{
    public class ArticleDAO : IDAO<Article>
    {
        public void Delete(int Id)
        {
            throw new ProhibitedFunctionException();
        }

        public IEnumerable<Article> GetAll()
        {
            IEnumerable<Article> articles = new List<Article>();
            Serreurs erreur = new Serreurs("Erreur sur lecture des articles.", "ArticleList.getClients()");
            try
            {
                string sql = "SELECT * FROM article ORDER BY no_article";
                DataTable dataTable = DBInterface.Lecture(sql, erreur);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ((List<Article>)articles).Add(new Article(
                        int.Parse(dataRow["no_article"].ToString()),
                        dataRow["lib_article"].ToString(),
                        int.Parse(dataRow["qte_dispo"].ToString()),
                        dataRow["ville_art"].ToString(),
                        float.Parse(dataRow["prix_art"].ToString()),
                        dataRow["interrompu"].ToString()
                        ));
                }
                dataTable.Dispose();
                return articles;

            }
            catch (MonException e)
            {
                throw new MonException(erreur.MessageUtilisateur(), erreur.MessageApplication(), e.Message);
            }
            catch (MySqlException e)
            {
                throw new MonException(erreur.MessageUtilisateur(), erreur.MessageApplication(), e.Message);
            }
        }

        public Article GetSingleById(int id)
        {
            Article article;
            Serreurs erreur = new Serreurs("Erreur sur lecture des articles.", "ArticleList.getClients()");
            try
            {
                string sql = "SELECT * FROM articles WHERE no_article = " + id;
                DataTable dataTable = DBInterface.Lecture(sql, erreur);
                DataRow dataRow = dataTable.Rows[0];
                article = new Article(
                        int.Parse(dataRow["no_article"].ToString()),
                        dataRow["lib_article"].ToString(),
                        int.Parse(dataRow["qte_dispo"].ToString()),
                        dataRow["ville_art"].ToString(),
                        float.Parse(dataRow["prix_art"].ToString()),
                        dataRow["interrompu"].ToString()
                        );
                dataTable.Dispose();
                return article;

            }
            catch (MonException e)
            {
                throw new MonException(erreur.MessageUtilisateur(), erreur.MessageApplication(), e.Message);
            }
            catch (MySqlException e)
            {
                throw new MonException(erreur.MessageUtilisateur(), erreur.MessageApplication(), e.Message);
            }
        }

        public void Insert(Article obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Article obj)
        {
            
        }
    }
}