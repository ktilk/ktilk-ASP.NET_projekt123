using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeID { get; set; }

        [ForeignKey(nameof(ContactTypeName))]
        public int ContactTypeNameID { get; set; }
        public virtual MultiLangString ContactTypeName { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
