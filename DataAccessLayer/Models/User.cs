using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

       // [Required(ErrorMessage = "Choose from TENANT or PROPERTYMANAGER")]
        [RegularExpression("^(TENANT|PROPERTYMANAGER)$", ErrorMessage = "Invalid Userrole")]
        public string Userrole { get; set; }
    }
}
