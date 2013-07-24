using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using StefaniniPhoneBook.Models;

namespace StefaniniPhoneBook.DAL
{
    public class PhoneBookInitializer:DropCreateDatabaseIfModelChanges<PhoneBookContext>
    {
        protected override void Seed (PhoneBookContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact { FirstName="Alan", LastName="Carlo"},
                new Contact { FirstName="James", LastName="Johnston"}
            };
            contacts.ForEach(s=>context.Contacts.Add(s));
            context.SaveChanges();

            var detailTypes = new List<DetailType>
            {
                new DetailType{DetailTypeData="E-mail"},
                new DetailType{DetailTypeData="Work Phone"},
                new DetailType{DetailTypeData="Mobile Phone"},
            };
            detailTypes.ForEach(s=>context.DetailsTypes.Add(s));
            context.SaveChanges();

            var details = new List<Detail>
            {
                new Detail{ContactID=1, DetailTypeID=2, DetailData="+40213157261"},
                new Detail{ContactID=1, DetailTypeID=1, DetailData="ac@domain.com"},
                new Detail{ContactID=2, DetailTypeID=3, DetailData="+40724545214"},
            };
            details.ForEach(s=>context.Details.Add(s));
            context.SaveChanges();
        }        
    }
}