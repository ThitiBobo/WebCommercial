using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models.Persistance;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;

namespace WebCommercial.Models.DAO
{
    public class VendeurDAO : IDAO<Vendeur>
    {
        public void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vendeur> GetAll()
        {
            IEnumerable<Vendeur> vendeurs = new List<Vendeur>();
            Serreurs erreur = new Serreurs("Erreur sur lecture des vendeur.", "ClientsList.getClients()");
            try
            {
                string sql = "SELECT * FROM vendeur ORDER BY no_vendeur";
                DataTable dataTable = DBInterface.Lecture(sql, erreur);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ((List<Vendeur>)vendeurs).Add(new Vendeur(
                        dataRow["no_vendeur"].ToString(),
                        null,
                        dataRow["nom_vend"].ToString(),
                        dataRow["prenom_vend"].ToString(),
                        dataRow["date_embau"].ToString(),
                        dataRow["ville_vend"].ToString(),
                        float.Parse(dataRow["salaire_vend"].ToString()),
                        float.Parse(dataRow["commission"].ToString())
                        ));
                }
                dataTable.Dispose();
                return vendeurs;

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

        public Vendeur GetSingleById(int id)
        {
            Vendeur vendeur;
            Serreurs erreur = new Serreurs("Erreur sur lecture des clients.", "ClientsList.getClients()");
            try
            {
                string sql = "SELECT * FROM vendeur WHERE no_vendeur = " + id;
                DataTable dataTable = DBInterface.Lecture(sql, erreur);
                DataRow dataRow = dataTable.Rows[0];
                vendeur = new Vendeur(
                        dataRow["no_vendeur"].ToString(),
                        null,
                        dataRow["nom_vend"].ToString(),
                        dataRow["prenom_vend"].ToString(),
                        dataRow["date_embau"].ToString(),
                        dataRow["ville_vend"].ToString(),
                        float.Parse(dataRow["salaire_vend"].ToString()),
                        float.Parse(dataRow["commission"].ToString())
                        );
                return vendeur;
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

        public void Insert(Vendeur obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Vendeur obj)
        {
            throw new System.NotImplementedException();
        }
    }
}