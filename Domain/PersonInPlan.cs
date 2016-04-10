using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PersonInPlan
    {
        [Key]
        [Display(ResourceType = typeof(Resources.Domain), Name = "EntityPrimaryKey")]
        public int PersonInPlanID { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int PlanID { get; set; }
        public Plan Plan { get; set; }

        public int PersonRoleInPlanID { get; set; }
        public PersonRoleInPlan PersonRoleInPlan { get; set; }
    }
}
