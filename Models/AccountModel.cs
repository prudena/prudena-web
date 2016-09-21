using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }
        
        public string Message { get; set; }
        public bool ShowMessage { get; set; }

        public bool ShowResponse { get; set; }
    }

    public class ForgotUsernameModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        [Display(Name = "Email")]
        public string Email { get; set; }

      
        public string Message { get; set; }
        public bool ShowMessage { get; set; }

        public bool ShowResponse { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Code { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [Required]
        public string NewPassword { get; set; }


        public string Message { get; set; }
        public bool ShowMessage { get; set; }

        public bool ShowResponse { get; set; }
    }


    public class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class RegisterModel
    {
        public bool ShowTermsError { get; set; }
        
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public int DefaultDashboardID { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Terms and Conditions")]
        public bool TermsAndConditions { get; set; }

        [Display(Name = "How Did You Hear About Us?")]
        public string HowDidYouHearAboutUs { get; set; }

        [Display(Name = "Promo Code")]
        public string CouponCode { get; set; }

        [Display(Name = "Check here to receive product update and promotional emails from Prudena.")]
        public bool ProductUpdatesAndPromotions { get; set; }

        [Display(Name = "Check here to receive email alerts when a new Morning Monte is published.")]
        public bool ReceiveMorningMonte { get; set; }

        [Display(Name = "How much is")]
        public string Captcha { get; set; }

        public string ReturnUrl { get; set; }
    }
}
