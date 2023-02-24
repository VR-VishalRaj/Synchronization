using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSyncEff
{
    public class PerformSynchronization
    {
        #region DoSync Method
        private object lockObj = new object();
        public  void doSync(Dictionary<string, Contact> phoneContacts, Dictionary<string, Contact> cloudContacts)
        {
            lock (lockObj)                           // we can apply lock to make it thread safe, so that at a time only one can access this code
            {
                Dictionary<string, Contact> mergedContacts = new Dictionary<string, Contact>(phoneContacts);

                foreach (Contact cloudContact in cloudContacts.Values)
                {
                    if (!mergedContacts.ContainsKey(cloudContact.Name))
                    {
                        mergedContacts.Add(cloudContact.Name, cloudContact);     // Adding new contact to merge list
                    }
                    else
                    {
                        // Update existing contact with cloud data
                        Contact phoneContact = mergedContacts[cloudContact.Name];

                        if (phoneContact.LastModified < cloudContact.LastModified)
                        {
                            phoneContact.Notes = cloudContact.Notes;
                            phoneContact.PhoneNumbers = cloudContact.PhoneNumbers;
                            phoneContact.LastModified = cloudContact.LastModified;
                            phoneContact.IsDeleted = cloudContact.IsDeleted;
                        }
                    }
                }

                phoneContacts.Clear();
                cloudContacts.Clear();

                foreach (Contact contact in mergedContacts.Values)
                {
                    if (contact.IsDeleted != "y")                  // checking if contact is deleted or not
                    {
                        phoneContacts.Add(contact.Name, contact);
                        cloudContacts.Add(contact.Name, contact);
                    }
                }
            }
        }

        #endregion
    }
}
