using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models.Persistance;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;

namespace WebCommercial.Models.DAO
{
    public class DetailCdeDAO : IDAO<DetailCde>
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetailCde> GetAll()
        {
            throw new NotImplementedException();
        }

        public DetailCde GetSingleById(int id)
        {
            Serreurs erreur = new Serreurs("Erreur sur lecture des clients.", "ClientsList.getClients()");
            try
            {
                DetailCde detailCde = new DetailCde();
                string sql = "SELECT * FROM detail_cde WHERE no_command = " + id.ToString();
                DataTable dataTable = DBInterface.Lecture(sql, erreur);

                detailCde.Commande = new CommandeDAO().GetSingleById(int.Parse(dataTable.Rows[0]["no_command"].ToString()));

                List<Article> articles = new List<Article>();
                List<int> qteCdees = new List<int>();
                List<bool> livree = new List<bool>();

                ArticleDAO articleDAO = new ArticleDAO();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    articles.Add(articleDAO.GetSingleById(int.Parse(dataRow["no_article"].ToString())));
                    qteCdees.Add(int.Parse(dataRow["qte_cdee"].ToString()));
                    if (dataRow["livree"].ToString() == "T")
                        livree.Add(true);
                    else
                        livree.Add(false);
                }

                detailCde.NbArticle = dataTable.Rows.Count;
                detailCde.Articles = articles;
                detailCde.QteCdees = qteCdees;
                detailCde.Livrees = livree;

                dataTable.Dispose();
                return detailCde;
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

        public void Insert(DetailCde obj)
        {
            throw new NotImplementedException();
        }

        public void Update(DetailCde obj)
        {
            throw new NotImplementedException();
        }
    }
}