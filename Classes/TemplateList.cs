using System;
using System.Collections.Generic;
using System.Linq;

namespace CLPJ2
{
    public class Template //Template object class ***TEMPLATE LIST OBJECT FURTHER DOWN IN FILE***
    {
        public string TemplateName {get; set;}
        public string TemplateContent {get; set;}
        public override string ToString()
        {
            return TemplateName +"\n" +TemplateContent +"\n";
        }
            
            public Template (string templateName, string templateContent)
            {
                TemplateName = templateName;
                TemplateContent = templateContent;
            }
    }

    public class TemplateList //Template list object class
    {
        List<Template> templateList;
        public TemplateList()
        {
            templateList = ReadWrite.Read<List<Template>>("templates");
            if (templateList == null)
            {
                templateList = new List<Template>();
            }
        }

        public void ViewTemplates()
        {
             if (!templateList.Any())
            {
                Console.WriteLine("There are no templates to display.");
            }
            else
            {
                foreach (var template in templateList)
                {
                    Console.WriteLine(template);
                }
            }
            MenuManager.PressAnyKey();
        }

        public void CreateTemplates()
        {
            string newTemplateName;
            string newTemplateContent;
            Console.WriteLine("Enter template name:");
            newTemplateName = Console.ReadLine();
            Console.WriteLine($"Enter content for {newTemplateName}:");
            newTemplateContent = Console.ReadLine();
            var newTemplate = new Template(newTemplateName, newTemplateContent);
            templateList.Add(newTemplate);
            ReadWrite.Write("templates", templateList);
            Console.WriteLine("\nTemplate saved.");
            MenuManager.PressAnyKey();
        }

        public void DeleteTemplates()
        {
            Console.WriteLine("Enter name or content of template to delete:");
            string search = Console.ReadLine();
            List<Template> deleteThese = new List<Template>();
            for (int i = 0; i < templateList.Count; i++)
            {
                if (templateList[i].TemplateName == search || templateList[i].TemplateContent == search)
                {
                    deleteThese.Add(templateList[i]);
                }
            }
            if (!deleteThese.Any())
            {
                Console.WriteLine($"\nTemplate {search} not found.");
            }
            else 
            {
                foreach (var template in deleteThese)
                {
                    Console.WriteLine($"{template} deleted.");
                    templateList.Remove(template);
                }
                ReadWrite.Write("templates", templateList);
            }
            MenuManager.PressAnyKey();
        }
        public void SearchTemplates()
        {
            Console.WriteLine("Enter name or content of template:");
            string search = Console.ReadLine();
            var query = from Template in templateList where search == Template.TemplateName || search == Template.TemplateContent select Template;
            foreach (var Template in query)
            {
                Console.WriteLine(Template);
            }
            MenuManager.PressAnyKey();
        }
    }
}