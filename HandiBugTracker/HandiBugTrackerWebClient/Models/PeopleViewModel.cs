using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandiBugTrackerWebClient.Models
{
    public class PeopleViewModel
    {
        public string LoggedInEmailAddress { get; set; }
        public string LoggedInUserId { get; set; }
        public string LoggedInFirstName { get; set; }
        public string LoggedInLastName { get; set; }
        public string LoggedInFullName
        {
            get
            {
                return (LoggedInFirstName + ' ' + LoggedInLastName);
            }
        }
    }
}