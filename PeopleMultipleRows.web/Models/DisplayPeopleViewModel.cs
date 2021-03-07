using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleMultipleRows.data;

namespace PeopleMultipleRows.web.Models
{
    public class DisplayPeopleViewModel
    {
        public List<Person> PeopleList { get; set; }
    }
}