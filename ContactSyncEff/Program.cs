using ContactSyncEff;
using System;
using System.Collections.Generic;

#region Information
/*
1. This Utility provides synchronization between cloud and phone contact list.

2. I have used four .cs class
    a) program.cs --> has main method
    b) Contacts.cs --> has Contact model class
    c) DataLoad.cs  --> loads hardcoded contact list for both cloud and phone
    d) PerformSynchronization.cs  --> has main logic 'dosync' method

3. Model class (Contact.cs) has below fields -
    a)  string Name 
    b)  string Notes 
    c)  List<string> PhoneNumbers 
    d)  DateTime LastModified       --> use to track the lastest contact
    e)  string IsDeleted            --> to track if contact is deleted or not (considered deleted if it is set to "y" otherwise keep it empty)

*/
#endregion

class Program
{
    #region Main
    public static void Main(string[] args)
    {
       
        Dictionary<string, Contact> phoneContacts = DataLoad.getPhoneDate();
        Dictionary<string, Contact> cloudContacts = DataLoad.getCloudData();

        Console.WriteLine("Contacts present on devices initially:");
        Display(phoneContacts, cloudContacts);

        PerformSynchronization sync = new PerformSynchronization();
        sync.doSync(phoneContacts, cloudContacts);

        Console.WriteLine("\n---------------------------------------------"+"\nContacts present on devices after Sync:");
        Display(phoneContacts, cloudContacts);
    }

    #endregion

    #region private
    private static void Display(Dictionary<string, Contact> phoneContacts, Dictionary<string, Contact> cloudContacts)
    {
        Console.WriteLine("\nPhone contacts:");
        foreach (Contact contact in phoneContacts.Values)
        {
            Console.WriteLine($"{contact.Name} ({contact.Notes}) | Contact Number: {string.Join(", ", contact.PhoneNumbers)} | Last updated on: {contact.LastModified}");
        }

        Console.WriteLine("\nCloud contacts:");
        foreach (Contact contact in cloudContacts.Values)
        {
            Console.WriteLine($"{contact.Name} ({contact.Notes}) | Contact Number: {string.Join(", ", contact.PhoneNumbers)} | Last updated on: {contact.LastModified}");
        }
    }

    #endregion

}