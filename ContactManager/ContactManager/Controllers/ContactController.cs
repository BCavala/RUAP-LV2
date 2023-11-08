using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository contactRepository;
        
        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }
        [HttpGet("api/[controller]")]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
    }
}
