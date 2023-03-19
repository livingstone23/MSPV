namespace PVM.Services.Security.Model.Dto;

public class AuthenticationResponseDTO
{
    public bool IsAuthSuccessful { get; set; }
    public string ErrorMessage { get; set; }
    public string Token { get; set; }
    public UserDTO userDTO { get; set; }

}