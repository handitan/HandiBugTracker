using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HandiBugTrackerWebClient.Models
{
    public class AccountViewModel
    {
        [Required]
        [DisplayName("Username")]
        public string LoginName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}