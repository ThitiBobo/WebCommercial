using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Persistance;
using WebCommercial.Models.DAO;
using WebCommercial.Models.Exceptions;
using WebCommercial.Models.Metiers;

namespace WebCommercial.Controllers
{
    public class CommandeController : Controller
    {
        // GET: Commande
        public ActionResult Index()
        {
            IEnumerable<Commande> commandes = null;
            List<CommandeViewModel> commandeVM = new List<CommandeViewModel>();
            try
            {
                commandes = new CommandeDAO().GetAll();
                foreach (Commande cmd in commandes)
                    commandeVM.Add(new CommandeViewModel(cmd));
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des commandes : " + e.Message);
            }
            return View(commandeVM);
        }

        // GET: Commande/Details/5
        public ActionResult Details(int? id)
        {
            DetailCde commande = null;
            DetailCdeViewModel commandeVM = null;
            try
            {
                if (id == null)
                    throw new Exception();
                commande = new DetailCdeDAO().GetSingleById((int)id);
                commandeVM = new DetailCdeViewModel(commande);
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des commandes : " + e.Message);
            }
            catch(Exception e)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(commandeVM);
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            CommandeViewModel commandeVM;
            Commande commande = new Commande();
            IEnumerable<Clientel> clients = new ClientelDAO().GetAll();
            IEnumerable<Vendeur> vendeurs = new VendeurDAO().GetAll();
            commandeVM = new CommandeViewModel(commande);
            commandeVM.Clients = GetClients(clients, commande.Client);
            commandeVM.Vendeurs = GetVendeurs(vendeurs, commande.Vendeur);
            return View("~/Views/Commande/Modifier.cshtml", commandeVM);
        }

        // GET: Commande/Edit/5
        public ActionResult Modifier(int? id)
        {

            CommandeViewModel commandeVM = null;
            try
            {
                if (id == null)
                    throw new Exception();
                Commande commande = new CommandeDAO().GetSingleById((int)id);
                IEnumerable<Clientel> clients = new ClientelDAO().GetAll();
                IEnumerable<Vendeur> vendeurs = new VendeurDAO().GetAll();
                commandeVM = new CommandeViewModel(commande);
                commandeVM.Clients = GetClients(clients, commande.Client);
                commandeVM.Vendeurs = GetVendeurs(vendeurs, commande.Vendeur);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération du client : " + e.Message);
            }
            return View(commandeVM);
        }

        private IEnumerable<SelectListItem> GetClients(IEnumerable<Clientel> clients, Clientel client)
        {
            var lClients = new List<SelectListItem>();
            foreach (Clientel clientel in clients)
            {
                lClients.Add(new SelectListItem() { Text = clientel.NomCl, Value = clientel.NoClient});
            }
            if(lClients.Exists(a => a.Value == client.NoClient))
            {
                lClients.First(a => a.Value == client.NoClient).Selected = true;
            }
            
            return new SelectList(lClients, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetVendeurs(IEnumerable<Vendeur> vendeurs, Vendeur vendeur)
        {
            var lVendeurs = new List<SelectListItem>();
            foreach (Vendeur v in vendeurs)
            {
                lVendeurs.Add(new SelectListItem() { Text = v.NomVend, Value = v.NoVendeur});
            }
            if (lVendeurs.Exists(a => a.Value == vendeur.NoVendeur))
            {
                lVendeurs.First(a => a.Value == vendeur.NoVendeur).Selected = true;
            }
            
            return new SelectList(lVendeurs, "Value", "Text");
        }

    }
}
