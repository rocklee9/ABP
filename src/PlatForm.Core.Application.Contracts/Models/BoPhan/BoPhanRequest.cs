using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlatForm.Core.Models.BoPhan
{
    public class BoPhanRequest
    {
        [Required(ErrorMessage = "Requied")]
        [StringLength(255)]
        [Display(Name = "BoPhanName", Prompt = "PlaceHolder")]
        public string Name { get; set; }

        [DisplayName("GhiChu")]
        [StringLength(255)]
        public string GhiChu { get; set; }
    }
}
