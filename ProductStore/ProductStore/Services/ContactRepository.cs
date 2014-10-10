using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProductStore.Models;

namespace ProductStore.Services
{
    public class ContactRepository
    {
        public Contact[] GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Contact[])ctx.Cache[CacheKey];
            }

            return new Contact[]
            {
                //new Contact
                //{
                //    Id = 1,
                //    Nama = "Dona Alianda"
                //},

                //new Contact
                //{
                //    Id = 2,
                //    Nama = "Alianda Dona"
                //}
                new Contact
                {
                    Id = 0,
                    Nama = "Placeholder"
                }
            };
        }

        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Contact[]
            {
                new Contact
                {
                    Id = 1, Nama = "Dona Alianda"
                },
                new Contact
                {
                    Id = 2, Nama = "Alianda Dona"
                }
            };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }


    }
}