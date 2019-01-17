using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models.Persistance;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;

namespace WebCommercial.Models.DAO
{
    public class ClientelDAO : IDAO<Clientel>
    {
        public IEnumerable<Clientel> GetAll()
        {
            IEnumerable<Clientel> clients = new List<Clientel>();
            Serreurs erreur = new Serreurs("Erreur sur lecture des clients.","ClientsList.getClients()");
            try
            {
                string sql = "SELECT * FROM clientel ORDER BY no_client";
                DataTable dataTable = DBInterface.Lecture(sql, erreur);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ((List<Clientel>)clients).Add(new Clientel(
                        dataRow["no_client"].ToString(),
                        dataRow["societe"].ToString(),
                        dataRow["nom_cl"].ToString(),
                        dataRow["prenom_cl"].ToString(),
                        dataRow["adresse_cl"].ToString(),
                        dataRow["ville_cl"].ToString(),
                        dataRow["code_post_cl"].ToString()
                        ));
                }
                dataTable.Dispose();
                return clients;

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

        public void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Clientel GetSingleById(int id)
        {
            Clientel client;
            Serreurs erreur = new Serreurs("Erreur sur lecture des clients.", "ClientsList.getClients()");
            try
            {
                string sql = "SELECT * FROM clientel WHERE no_client = " + id;
                DataTable dataTable = DBInterface.Lecture(sql, erreur);
                DataRow dataRow = dataTable.Rows[0];
                client = new Clientel(
                        dataRow["no_client"].ToString(),
                        dataRow["societe"].ToString(),
                        dataRow["nom_cl"].ToString(),
                        dataRow["prenom_cl"].ToString(),
                        dataRow["adresse_cl"].ToString(),
                        dataRow["ville_cl"].ToString(),
                        dataRow["code_post_cl"].ToString()
                        );
                return client;
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

        public void Insert(Clientel obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Clientel obj)
        {
            throw new System.NotImplementedException();
        }
    }
}