using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class GymDbContext : DbContext, IDbContext
    {
        public GymDbContext() : base("DbConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GymDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GymDbContext, MigrationConfiguration>());
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public IDbSet<Person> Persons { get; set; }
        public IDbSet<Competition> Competitions { get; set; }
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<ContactType> ContactTypes { get; set; }
        public IDbSet<Exercise> Exercises { get; set; }
        public IDbSet<ExerciseInWorkout> ExercisesInWorkouts { get; set; }
        public IDbSet<ExerciseType> ExerciseTypes { get; set; }
        public IDbSet<Participation> Participations { get; set; }
        public IDbSet<Plan> Plans { get; set; }
        public IDbSet<PlanType> PlanTypes { get; set; }
        public IDbSet<Workout> Workouts { get; set; }
        public IDbSet<PersonInPlan> PeopleInPlans { get; set; }
        public IDbSet<PersonRoleInPlan> PersonRolesInPlans { get; set; }

        // Identity tables, PK - int
        //public IDbSet<RoleInt> RolesInt { get; set; }
        //public IDbSet<UserClaimInt> UserClaimsInt { get; set; }
        //public IDbSet<UserLoginInt> UserLoginsInt { get; set; }
        //public IDbSet<UserInt> UsersInt { get; set; }
        //public IDbSet<UserRoleInt> UserRolesInt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove all cascade deletes
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            // use Date type in ms sql, where [DataType(DataType.Date)] attribute is used
            modelBuilder.Properties<DateTime>()
        .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
        .Any(a => a.DataType == DataType.Date))
        .Configure(c => c.HasColumnType("date"));

        }
    }
}
