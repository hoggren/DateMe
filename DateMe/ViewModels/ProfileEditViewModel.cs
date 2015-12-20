using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels
{
    public class ProfileEditViewModel : RegisterViewModel
    {
        public string NewPassword { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}