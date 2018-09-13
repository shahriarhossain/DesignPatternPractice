using DesignPatternPractice.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml;

namespace DesignPatternPractice.Structural_Patterns
{
    public class AdapterPattern
    {
        public AdapterPattern()
        {
            var getList = new Humana(new HuamanaAdapter()).GetEmployeeList();
        }
    }
    public class Humana
    {
        private IHumana _humana;
        public Humana(IHumana humana)
        {
            _humana = humana;
        }
        public List<Employee> GetEmployeeList()
        {
            string empListJson = _humana.GetEmployeeList();
            return JsonConvert.DeserializeObject<Root>(empListJson).Employee;
        }
    }
    public class Root
    {
        public List<Employee> Employee { get; set; }
    }

    //Target Interface
    public interface IHumana
    {
        string GetEmployeeList();
    }
    public class HuamanaAdapter : IHumana
    {
        Desme desme;

        public HuamanaAdapter()
        {
            desme = new Desme();
        }

        public string GetEmployeeList()
        {
            var empListXML = desme.GetEmployeeList();

            //remove the first child from the XmlDocument i.e remove XML declaration
            empListXML.RemoveChild(empListXML.FirstChild);

            //avoid root element when parsing
            return JsonConvert.SerializeXmlNode(empListXML, Newtonsoft.Json.Formatting.None, true);
        }
    }


    //Third Party Provider
    public class Desme
    {
        List<Employee> employeeList;
        public Desme()
        {
            employeeList = new List<Employee>()
            {
                new Employee(){FName="Shahriar", LName="Hossain", Email="Shossain@desme.com"},
                new Employee(){FName="SK", LName="Tajbir", Email="Tajbir@desme.com"}
            };   
        }

        //Employee List in XML Format
        public XmlDocument GetEmployeeList()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(XMLGenerator.GetXMLFromObject(employeeList));
            return xml;
        }
    }
    public class Employee
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
    }
}
