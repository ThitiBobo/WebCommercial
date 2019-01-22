using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommercial.Models;
using WebCommercial.Models.DAO;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;
using WebCommercial.ViewModels;

namespace WebCommercial.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            IEnumerable<Clientel> clients = null;
            List<ClientelViewModel> clientsVM = new List<ClientelViewModel>();
            try
            {
                clients = new ClientelDAO().GetAll();
                foreach (Clientel clientel in clients)
                    clientsVM.Add(new ClientelViewModel(clientel));
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des clients : " + e.Message);
            }
            return View(clientsVM);

        }

        public ActionResult Modifier(int? id)
        {
            ClientelViewModel clientVM = null;
            try
            {
                if (id == null)
                    throw new Exception();
                Clientel client = new ClientelDAO().GetSingleById((int)id);
                clientVM = new ClientelViewModel(client);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération du client : " + e.Message);
            }
            return View(clientVM);
        }

        [HttpPost]
        public ActionResult Save(ClientelViewModel clientVM)
        {
            try
            {
                new ClientelDAO().Update(new Clientel(
                clientVM.Id.ToString(),
                clientVM.Societe,
                clientVM.Nom,
                clientVM.Prenom,
                clientVM.Adresse,
                clientVM.Ville,
                clientVM.CodePostal
                ));
                //return View("~/Views/Client/Index.cshtml");
                return RedirectToAction("Index");
            }
            catch (MonException exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            


        }

        
    }
}