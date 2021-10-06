using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class Organization : Record
    {
        public Organization()
        {
            ChildOrganizations = new List<Organization>();
            Сonsumers = new List<Сonsumer>();
        }
        public string Name { get; set; }

        public string Address { get; set; }

        public List<Organization> ChildOrganizations { get; set; }
        public List<Сonsumer> Сonsumers { get; set; }
    }
}
