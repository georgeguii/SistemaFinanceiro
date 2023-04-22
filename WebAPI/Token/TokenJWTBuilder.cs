using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Token;

public class TokenJWTBuilder
{
    private SecurityKey _securityKey = null;
    private string _subject = string.Empty;
    private string _issuer = string.Empty;
    private string _audience = string.Empty;
    private Dictionary<string, string> _claims = new Dictionary<string, string>();
    private int _expiryInMinutes = 5;

    public TokenJWTBuilder AddSecurityKey(SecurityKey securityKey)
    {
        _securityKey = securityKey;
        return this;
    }

    public TokenJWTBuilder AddSubject(string subject)
    {
        _subject = subject;
        return this;
    }

    public TokenJWTBuilder AddIssuer(string issuer)
    {
        _issuer = issuer;
        return this;
    }

    public TokenJWTBuilder AddAudience(string audience)
    {
        _audience = audience;

        return this;
    }

    public TokenJWTBuilder AddClaim(string type, string value)
    {
        _claims.Add(type, value);
        return this;
    }

    public TokenJWTBuilder AddClaims(Dictionary<string, string> claims)
    {
        _claims.Union(claims);
        return this;
    }

    public TokenJWTBuilder AddExpiry(int expiryInMinutes)
    {
        _expiryInMinutes = expiryInMinutes;
        return this;
    }

    private void EnsureArguments()
    {
        if (_securityKey is null)
            throw new ArgumentException("Security Key");

        if (string.IsNullOrEmpty(_subject))
            throw new ArgumentException("Subject");

        if (string.IsNullOrEmpty(_issuer))
            throw new ArgumentException("Issuer");

        if (string.IsNullOrEmpty(_audience))
            throw new ArgumentException("Audience");
    }

    public TokenJWT Builder()
    {
        EnsureArguments();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(_claims.Select(item => new Claim(item.Key, item.Value)));

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
            signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
            );


        return new TokenJWT(token);
    }
}
