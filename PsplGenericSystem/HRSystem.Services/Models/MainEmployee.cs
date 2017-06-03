using System.Collections.Generic;

namespace HRSystem.Services.Models
{
    public partial class MainEmployee
    {
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public int RecentHire { get; set; }
        public int Termination { get; set; }
        public int OpenEnrollments { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public IEnumerable<DOB> DOB_List { get; set; }
        public IEnumerable<RecentActivity> RecentActivity_List { get; set; }
        public IEnumerable<Employee> Employee_List { get; set; }
        public IEnumerable<Plan> Plan_List { get; set; }
        public IEnumerable<EnrollmentType> Enrollment_List { get; set; }
        public int OECount { get; set; }
        public int NHCount { get; set; }
        public int LECount { get; set; }
        public WidgetLayerView widgetList { get; set; }
    }

    public class DOB
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
    }

    public class RecentActivity
    {
        public string FLName { get; set; }
        public string DisplayName { get; set; }
        public byte[] Photo { get; set; }
        public string TimeinAgo { get; set; }
    }

    public class Employee
    {
        public string UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Plan
    {
        public string PlanType { get; set; }
    }

    public class EnrollmentType
    {
        public string Type { get; set; }
    }
    public class WidgetLayerView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Zone { get; set; }
        public bool RenderTitle { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public int? LayerId { get; set; }
        public string CssClasses { get; set; }
    }
}
