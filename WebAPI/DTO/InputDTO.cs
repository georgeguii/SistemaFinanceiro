namespace WebAPI.DTO;

public class InputDTO
{
    public string Email { get; set; }

    public string Password { get; set; }

    public InputDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
