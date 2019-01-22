using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using WebCommercial.Models.Persistance;
using WebCommercial.Models.Exceptions;

namespace WebApplication1.Models.Persistance
{
    public class DBInterface
    {
        /// <summary>
        /// Exécution de la requête demandée en paramètre, req,
        /// et retour du resultat : un DataTable
        /// Si tout se passe bien la connexion est prête à être fermée
        /// par le client qui utilisera cette connexion
        /// </summary>
        /// <param name="req">RequêteMySql à exécuter</param>
        /// <returns></returns>
        public static DataTable Lecture(String req, Serreurs er)
        {
            MySqlConnection cnx = null;
            try
            {
                cnx = Connexion.getInstance().getConnexion();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = req;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                // Construire le DataSet
                DataSet ds = new DataSet();
                da.Fill(ds, "resultat");
                cnx.Close();
                // Retourner la table
                return (ds.Tables["resultat"]);
            }
            catch (MonException me)
            {
                throw (me);
            }
            catch (Exception e)
            {
                throw new
               MonException(er.MessageUtilisateur(),
               er.MessageApplication(), e.Message);
            }
            finally
            {
                // S'il y a eu un problème, la connexion
                // peut être encore ouverte, dans ce cas
                // il faut la fermer.
                if (cnx != null)
                    cnx.Close();
            }
        }
        /// <summary>
        /// Insertion d'une requête avec OleDb
        /// </summary>
        /// <param name="requete"></param>
        public static void Insertion_Donnees(String requete)
        {
            MySqlConnection cnx = null;
            MySqlTransaction OleTrans = null;
            MySqlCommand OleCmd = null;
            try
            {
                // On ouvre une transaction
                cnx = Connexion.getInstance().getConnexion();
                OleTrans = cnx.BeginTransaction();
                OleCmd = new MySqlCommand();
                OleCmd = cnx.CreateCommand();
                OleCmd.Transaction = OleTrans;
                OleCmd.CommandText = requete;
                OleCmd.ExecuteNonQuery();
                OleTrans.Commit();
            }
            catch (MySqlException uneException)
            {
                throw new MonException(uneException.Message,"Insertion", "SQL");
            }
            finally
            {
                // on libére la ressource
                cnx.Dispose();
                OleCmd.Dispose();
                OleTrans.Dispose();
            }
        }

        public static int LastId(string table, string champId)
        {
            Serreurs erreur = new Serreurs("Erreur sur lecture de la base de données.", "DBInterface.LastId()");
            string sql = "SELECT " + champId + " FROM " 
                + table + " ORDER BY " + champId + " DESC LIMIT 1";
            try
            {
                DataTable dataTable = Lecture(sql, erreur);
                // reourne le dernier entier + 1
                int lastId = int.Parse(dataTable.Rows[0][0].ToString()) + 1;
                dataTable.Dispose();
                return lastId;
                
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
    }
}
