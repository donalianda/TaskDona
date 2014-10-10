using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ProductStore.Models;
using ProductStore.Services;


namespace ProductStore.Controllers
{
    public class ContactController : ApiController
    {
        //public string[] Get()
        //{
        //    return new string[]
        //    {
        //         "Hello",
        //         "World"
        //    };
        //}
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        public Contact[] Get()
        {
            //return new Contact[]
            //{
            //    new Contact
            //    {
            //        Id = 1,
            //        Nama = "Dona Alianda"
            //    },
            //    new Contact
            //    {
            //        Id = 2,
            //        Nama = "Alianda Dona"
            //    }
            //};

            return contactRepository.GetAllContacts();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }

        
    }
}
