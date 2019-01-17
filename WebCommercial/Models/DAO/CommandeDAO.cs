

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models.Persistance;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;

namespace WebCommercial.Models.DAO
{
    public class CommandeDAO : IDAO<Commande>
    {
        public void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Commande> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Commande GetSingleById(int id)
        {
            Serreurs erreur = new Serreurs("Erreur sur lecture de la commande.", "CommandeDAO.GetSingleById(id)");
            try
            {
                Commande commande = new Commande();
                string sql = "SELECT * FROM commandes WHERE no_command = " + id.ToString();
                DataTable dataTable = DBInterface.Lecture(sql, erreur);

                commande.NoCommand = dataTable.Rows[0]["no_command"].ToString();
                commande.Vendeur = new VendeurDAO().GetSingleById(int.Parse(dataTable.Rows[0]["no_vendeur"].ToString()));
                commande.Client = new ClientelDAO().GetSingleById(int.Parse(dataTable.Rows[0]["no_client"].ToString()));
                commande.Date = DateTime.ParseExact(dataTable.Rows[0]["date_cde"].ToString(),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                if (dataTable.Rows[0]["facture"].ToString() == "T")
                    commande.Facture = true;
                else
                    commande.Facture = false;

                dataTable.Dispose();
                return commande;
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

        public void Insert(Commande obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Commande obj)
        {
            throw new System.NotImplementedException();
        }
    }
}