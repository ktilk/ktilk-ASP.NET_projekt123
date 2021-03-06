﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Workout
    {
        public int WorkoutID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Duration { get; set; }

        public int PlanID { get; set; }
        public virtual Plan Plan { get; set; }

        public virtual List<ExerciseInWorkout> ExercisesWorkouts { get; set; }
    }
}
