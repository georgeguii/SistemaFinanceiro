using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Token;

public class JwtSecurityKey
{
    public static SymmetricSecurityKey Create(string secret)
        => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

}
