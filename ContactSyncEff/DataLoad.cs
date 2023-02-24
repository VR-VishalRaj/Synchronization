using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSyncEff
{
    public class DataLoad
    {
        #region Get Phone Data
        public static Dictionary<string, Contact> getPhoneDate()
        {
             Dictionary<string, Contact> phoneContacts = new Dictionary<string, Contact>
                {
                   { "John", new Contact { Name = "John", Notes = "Friend", PhoneNumbers = new List<string> { "1234567890" }, LastModified = DateTime.Now,IsDeleted = "y" }},
                   { "John Abraham", new Contact { Name = "John Abraham", Notes = "Colleague", PhoneNumbers = new List<string> { "2345678901", "3456789012" },LastModified = DateTime.Now.AddHours(-12), IsDeleted = ""  } },
                   { "Vikas", new Contact { Name = "Vikas", Notes = "Family", PhoneNumbers = new List<string> { "4567890123" },LastModified = DateTime.Now.AddSeconds(-10) ,IsDeleted = ""  } },
                   { "Yusuf Pathan", new Contact { Name = "Yusuf Pathan", Notes = "Neighbour", PhoneNumbers = new List<string> { "4567890123" },LastModified = DateTime.Now ,IsDeleted = ""  } }

                };
            return phoneContacts;
        }

        #endregion

        #region Get Cloud Data
        public static Dictionary<string, Contact> getCloudData()
        {
            Dictionary<string, Contact> cloudContacts = new Dictionary<string, Contact>
             {
                { "John", new Contact { Name = "John", Notes = "Father", PhoneNumbers = new List<string> { "1234567890" },LastModified = DateTime.Now.AddDays(-1), IsDeleted = "" } },
                { "John Abraham", new Contact { Name = "John Abraham", Notes = "Colleague", PhoneNumbers = new List<string> { "2345678901" ,"2222222222","55555555555"},LastModified = DateTime.Now,IsDeleted = "" } },
                { "Dhoni", new Contact { Name = "Dhoni", Notes = "Friend", PhoneNumbers = new List<string> { "5678901234" },LastModified = DateTime.Now , IsDeleted = "" } },
                { "Vikas ", new Contact { Name = "Vikas", Notes = "uncle", PhoneNumbers = new List<string> { "1111110123" },LastModified = DateTime.Now.AddSeconds(-10), IsDeleted = ""  } }

             };
            return cloudContacts;
        }

        #endregion

    }
}
