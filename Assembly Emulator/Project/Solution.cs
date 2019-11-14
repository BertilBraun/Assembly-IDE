using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly_Emulator.Project
{
    class Solution
    {
        public static Solution This;
        public List<Project> Projects { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Directory { get; set; }

        public Solution(string path)
        {
            This = this;
            Projects = new List<Project>();

            XDocument doc = XDocument.Load(path);
            var sol = doc.Element("Solution");

            Name = sol.Element("Name").Value;
            Directory = sol.Element("Directory").Value;

            Path = Directory + @"\" + Name + ".asln";

            foreach (XElement p in sol.Element("Projects").Elements())
                if (File.Exists(p.Element("Path").Value))
                    Projects.Add(new Project(XDocument.Load(p.Element("Path").Value)));
        }

        public void AddProject(string name)
        {
            AddProject(name, Directory + @"\" + name, Path);
        }

        public static void AddProject(string name, string Directory, string SlnPath)
        {
            var doc = XDocument.Load(SlnPath);
            var projs = doc.Element("Solution").Element("Projects");
            if (projs.Elements().Any(x => { return x.Element("Name").Value == name; }))
                DockingManagerForm.This.AddOutput("Overwriting Existing Project.");
            else
                projs.Add(
                        new XElement(Format(name) + ".proj",
                            new XElement("Path", Directory + @"\" + name + @"\" + name + ".proj"),
                            new XElement("Name", name)
                        )
                    );

            XDocument proj = new XDocument(
                new XElement("Project",
                    new XElement("Directory", Directory + @"\" + name + @"\"),
                    new XElement("Name", name),

                    new XElement("Files", "")
                )
            );

            System.IO.Directory.CreateDirectory(Directory + @"\" + name);
            File.WriteAllText(SlnPath, doc.ToString());
            File.WriteAllText(Directory + @"\" + name + @"\" + name + ".proj", proj.ToString());
            This = new Solution(SlnPath);
        }

        public static string CreateNewSolution(string name, string directory)
        {
            directory = System.IO.Path.GetFullPath(directory + @"\" + name);

            XDocument sln = new XDocument(
                new XElement("Solution",
                    new XElement("Name", name),
                    new XElement("Directory", directory),

                    new XElement("Projects", "")
                )
            );

            System.IO.Directory.CreateDirectory(directory);
            File.WriteAllText(directory + @"\" + name + ".asln", sln.ToString());

            AddProject(name, directory, directory + @"\" + name + ".asln");

            return directory + @"\" + name + ".asln";
        }

        static string Format(string sin)
        {
            return sin = sin.Replace(' ', '_');
        }
    }
}
