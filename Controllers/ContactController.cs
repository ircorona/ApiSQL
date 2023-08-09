using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiSQLPlatzi.Models;

namespace ApiSQLPlatzi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private ContactsContext contactsContext;

        public ContactController(ContactsContext context)
        {
            contactsContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> Get()
        {
            return contactsContext.Contacts.ToList(); // Corrected here
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(int id)
        {
            var selectedContact = (from c in contactsContext.Contacts // Corrected here
                                   where System.Convert.ToInt32(c.Identificador) == id
                                        select c).FirstOrDefault();

            return selectedContact;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Contacts value)
        {
            Contacts newContact = value;
            contactsContext.Contacts.Add(newContact); // Corrected here
            contactsContext.SaveChanges();
            return Ok("Tu contacto ha sido creado");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        ~ContactController()
        {
            contactsContext.Dispose();
        }
    }
}
