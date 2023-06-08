using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CreateCityRequestDto
    {
        //[Required(ErrorMessage = "Name is mandatory field")]
        //[StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Id is mandatory field")]
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
