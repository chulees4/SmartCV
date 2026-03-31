using System.ComponentModel.DataAnnotations;

namespace SmartCV.ViewModels.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    public bool RememberMe { get; set; }
}

public class LectureLoginViewModel
{
    [Required(ErrorMessage = "Mã giảng viên là bắt buộc")]
    public string LectureCode { get; set; } = "";

    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}
