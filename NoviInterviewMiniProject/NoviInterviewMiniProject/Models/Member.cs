using NoviInterviewMiniProject.Models.Enums;

namespace NoviInterviewMiniProject.Models
{
    public class Member
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}