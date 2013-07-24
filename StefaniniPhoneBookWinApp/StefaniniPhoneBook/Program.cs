using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniPhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StefaniniPhoneBookContext())
            {
                Console.Write("Enter contact");
                var fname = Console.ReadLine();
                var lname = Console.ReadLine();

                //var contact = new Contact { FirstName = fname, LastName=lname};
                //db.Contacts.Add(contact);
                //db.SaveChanges();

                var query1 = from b in db.Contacts
                            orderby b.FirstName, b.LastName
                            select b;
                var query2 = from c in db.Contacts
                             join d in db.Details on c.ID equals d.ContactID
                             join dt in db.DetailTypes on d.DetailTypeID equals dt.ID
                             orderby c.FirstName, c.LastName
                            select
                                new {
                                        c.FirstName
                                        ,c.LastName
                                        ,dt.DetailTypeData
                                        ,d.DetailData
                                    };
                foreach (var item in query2)
                {
                    Console.WriteLine(item.FirstName+' '+item.LastName);
                        //+' '+item.DetailTypeData+' '+item.DetailData);
                }
                Console.Read();
            }
        }
    }
}
