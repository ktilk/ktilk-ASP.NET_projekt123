using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExerciseType
    {
        [Key]
        [Display(ResourceType = typeof(Resources.Domain), Name = "EntityPrimaryKey")]
        public int ExerciseTypeID { get; set; }

        [ForeignKey(nameof(ExerciseTypeName))]
        public int? ExerciseTypeNameID { get; set; }
        public virtual MultiLangString ExerciseTypeName { get; set; }

        [ForeignKey(nameof(ExerciseTypeDescription))]
        public int? ExerciseTypeDescriptionID { get; set; }
        public virtual MultiLangString ExerciseTypeDescription { get; set; }

        public virtual List<Exercise> Exercises { get; set; }
    }
}
