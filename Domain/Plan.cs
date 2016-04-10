using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Plan
    {
        [Key]
        [Display(ResourceType = typeof(Resources.Domain), Name = "EntityPrimaryKey")]
        public int PlanID { get; set; }

        [ForeignKey(nameof(PlanName))]
        public int PlanNameID { get; set; }
        public virtual MultiLangString PlanName { get; set; }

        public int? Rating { get; set; }

        [ForeignKey(nameof(PlanDescription))]
        public int? PlanDescriptionID { get; set; }
        public virtual MultiLangString PlanDescription { get; set; }

        [ForeignKey(nameof(PlanInstructions))]
        public int? PlanInstructionsID { get; set; }
        public virtual MultiLangString PlanInstructions { get; set; }

        public int PlanTypeID { get; set; }
        public virtual PlanType PlanType { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateClosed { get; set; }

        public string Duration { get; set; }

        public virtual List<PersonInPlan> People { get; set; }
        public virtual List<Workout> Workouts { get; set; }
    }
}
