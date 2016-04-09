using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = nameof(Resources.Domain.ContactValueLengthError), ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = nameof(Resources.Domain.ContactValueLengthError), ErrorMessageResourceType = typeof(Resources.Domain))]
        public string ContactValue { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int ContactTypeID { get; set; }
        public ContactType ContactType { get; set; }
    }
}
