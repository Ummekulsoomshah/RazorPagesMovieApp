using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovieApp.models
{
    public class customer
    {

        public int Id { get; set; }
        public string Name { get; set; }


        [Display(Name = "Membership Type")]
        public string Membershiptype { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
    }
}
