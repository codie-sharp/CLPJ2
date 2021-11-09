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
            Console.WriteLine("Enter name of template to delete:");
            string template = Console.ReadLine();
            for (int i = 0; i < templateList.Count; i++)
            {
                if (templateList[i].TemplateName == template)
                {
                    templateList.RemoveAt(i);
                    ReadWrite.Write("templates", templateList);
                    Console.WriteLine($"\n{templateList[i]} deleted.");
                }
                else
                {
                    Console.WriteLine($"\n{template} not found.");
                }
            }
            MenuManager.PressAnyKey();
        }
    }
}