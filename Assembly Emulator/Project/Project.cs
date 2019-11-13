using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly_Emulator.Project
{
    class Project
    {
        public List<string> FilePaths { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Directory { get; set; }

        public Project(XDocument doc)
        {
            var project = doc.Element("Project");

            Name = project.Element("Name").Value;
            Directory = project.Element("Directory").Value;

            Path = Directory + @"\" + Name + ".proj";

            FilePaths = project.Element("Files").Elements().Select(x => x.Name.LocalName).ToList();
        }
    }
}
