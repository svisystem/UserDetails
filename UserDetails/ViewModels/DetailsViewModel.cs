using UserDetails.Models;
using UserDetails.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserDetails.ViewModels
{
    public class DetailsViewModel
    {
        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;

                if (User != null && User.Id != null)
                {
                    Title = User.UserName + " details";
                    Exist = true;
                }
                else Title = "Add a new user";
            }
        }

        public string Title { get; set; }

        public bool Exist { get; set; }

        public string Password { get; set; }

        [DisplayName("Current password")]
        [DataType(DataType.Password)]
        [RequiredIf(nameof(Exist), true)]
        public string CurrentPassword { get; set; }

        [DisplayName("New password")]
        [DataType(DataType.Password)]
        [RequiredIf(nameof(Exist), false)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string PasswordCheck { get; set; }

        public DetailsViewModel() : this(null)
        {

        }

        public DetailsViewModel(User user)
        {
            User = user == null ? new User() : user;
        }
    }
}
