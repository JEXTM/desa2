using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRCDO.Models;

namespace SRCDO.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        SRCOEntities3 usuario = new SRCOEntities3();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var innerJoin = from u in usuario.user
                            join c in usuario.client on u.iduser equals c.idUser 
                            where u.iduser == id && c.idUser == id
                            select new ElClient
                            {
                                iduser = u.iduser,
                                nickname = u.nickname,
                                password = u.pass,
                                role = u.idRole,
                                name = c.name,
                                lastname = c.lastname,
                                address = c.address,
                                email = c.email
                            };
            SRCDO.Models.user user = usuario.user.Single(emp => emp.iduser == id);
            return View(innerJoin.ToList());
        }
        public ActionResult Register(ElClient client)
        {
            user user = new user();
            //select right('00000'+convert(varchar(5), MAX(iduser)+1), 5) from [user]
           // var max = from p in usuario.user select usuario.user.Max(x => x.iduser+1);
            user.iduser = client.iduser;
            user.nickname = client.nickname;
            user.pass = client.password;
            user.idRole = "C";
            usuario.user.Add(user);
            SRCDO.Models.client ncli = new SRCDO.Models.client();
            ncli.idUser = client.iduser;
            ncli.name = client.name;
            ncli.lastname = client.lastname;
            ncli.address = client.address;
            ncli.email = client.email;
            usuario.client.Add(ncli);
            ViewData["msg"] = "Se registro Correctamente Correctamente";
            usuario.SaveChanges();
            return View();
        }


        public ActionResult Edit(int id)
        {
            var innerJoin = from u in usuario.user
                            join c in usuario.client on u.iduser equals c.idUser
                            where u.iduser == id && c.idUser == id
                            select new ElClient
                            {
                                iduser = u.iduser,
                                nickname = u.nickname,
                                password = u.pass,
                                role = u.idRole,
                                name = c.name,
                                lastname = c.lastname,
                                address = c.address,
                                email = c.email
                            };
            return View(innerJoin.First());
        }

        public ActionResult List()
        {
            var innerJoin = from c in usuario.client
                            join u in usuario.user on c.idUser equals u.iduser
                            join r in usuario.role on u.idRole equals r.idRole
                            select new ElClient
                            {
                                iduser = u.iduser,
                                nickname = u.nickname,
                                password = u.pass,
                                role = r.role1,
                                name = c.name,
                                lastname = c.lastname,
                                address = c.address,
                                email = c.email
                            };
            return View(innerJoin.ToList());
        
        }
        public ActionResult Delete(int id)
        {
            var innerJoin = from u in usuario.user
                            join c in usuario.client on u.iduser equals c.idUser
                            where u.iduser == id && c.idUser == id
                            select new ElClient
                            {
                                iduser = u.iduser,
                                nickname = u.nickname,
                                password = u.pass,
                                role = u.idRole,
                                name = c.name,
                                lastname = c.lastname,
                                address = c.address,
                                email = c.email
                            };
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            Session.Remove("usuario");
            return RedirectToAction("Index","Home");
        }

    }
}
