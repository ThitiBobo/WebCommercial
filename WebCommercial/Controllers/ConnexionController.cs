using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommercial.Models.Metiers;
using WebCommercial.Models.Utilitaires;

namespace WebCommercial.Controllers
{
    public class ConnexionController : Controller
    {
        // GET: Connexion
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Controle()
        {
            try
            {
                // on récupère les données du formulaire
                String login= Request["login"];
                String mdp = Request["pwd"];              
                try
                {
                    Service unService = new Service();
                    Utilisateur unUtilisateur = unService.getUtilistateur(login);
                    if (unUtilisateur != null)
                    {
                        try
                        {
                            String pwdmd5 = FonctionsUtiles.md5(mdp);
                            if (unUtilisateur.MotPasse.CompareTo(pwdmd5)==0)
                                Session["id"] = unUtilisateur.NumUtil;
                            else
                            {
                                ModelState.AddModelError("Erreur", "Erreur lors du contrôle  du mot de passe pour : " + login);
                                return View("Error");
                            }
                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError("Erreur", "Erreur lors du contrôle : " + e.Message);
                            return View("Error");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Erreur", "Erreur  login erroné : " + login);
                        return View("Error");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Erreur", "Erreur lors de l'authentification : " + e.Message);
                    return View("Error");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de l'authentification : " + e.Message);
                return View("Error");
            }
        }
        */

      













    }
}