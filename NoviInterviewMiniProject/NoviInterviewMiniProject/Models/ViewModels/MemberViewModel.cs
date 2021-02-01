using NoviInterviewMiniProject.Models.Enums;

namespace NoviInterviewMiniProject.Models.ViewModels
{
    public class MemberViewModel
    {
        public bool Visible { get; set; }

        public bool Active { get; set; }
        public string Name { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public MemberViewModel(Member member)
        {
            Visible = true;

            Active = member.Active;
            Name = member.Name;
            CustomerType = member.CustomerType;
            Email = member.Email;
            Phone = member.Phone;
            Mobile = member.Mobile;
        }
    }
}