using System;
using System.Collections.Generic;

namespace CLPJ2
{
    public class Emailer
    {
        //Need to pull templates and contacts and add to list for email
        TemplateList templateList = new TemplateList();
        ContactList contactList = new ContactList();

        public Emailer()
        {

        }
        public void EmailTemplate(TemplateList templateList)
        {
            templateList.ViewTemplates();
        }
        public void EmailContact(ContactList contactList)
        {
            contactList.ViewContacts();
        }
        public void SendEmail()
        {
            MenuManager.PressAnyKey();
        }
    }
}
