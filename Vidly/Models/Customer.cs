using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Customer's Name.")]  //  /Which Cause Can't Be Nullable
        [StringLength(250)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Typee")]
        public byte MembershipTypeId { get; set; } // Define As Foriegn Key

        [Display(Name="Date Of Birth")]
        [Min18YearsIfMember]         // If User Select MemberShipType The Birthdate Must Be Mentioned and If It wasn't Pay As You go the Customer Must be at least on 18 
        public DateTime? Birthday { get; set; }


        




    }
}