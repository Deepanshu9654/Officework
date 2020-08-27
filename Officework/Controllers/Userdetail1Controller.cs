using Officework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace Officework.Controllers
{
    public class Userdetail1Controller : ApiController
    {
        [AuthenticationFilter]
        public IEnumerable<Userdetail1> Get()
        {
            FormData1Entities form = new FormData1Entities();
            return form.Userdetail1;
        }
        [AuthenticationFilter]
        public Userdetail1 Get(int id)
        { 
            FormData1Entities form = new FormData1Entities();
            Userdetail1 user = form.Userdetail1.Find(id);
            return user;
        }
        [AuthenticationFilter]
        public IHttpActionResult Post(Userdetail1 user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                FormData1Entities form = new FormData1Entities();
                form.Userdetail1.Add(user);
                form.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);


        }

        public Userdetail1 Delete(int id)
        {
            FormData1Entities form = new FormData1Entities();
            Userdetail1 user= form.Userdetail1.Find(id);
            form.Userdetail1.Remove(user);
            form.SaveChanges();
            return user;

        }
    }
}
