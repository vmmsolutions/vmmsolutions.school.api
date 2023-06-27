﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vmmsolutions.School.Application.Dto.ApplicationSettings;

namespace Vmmsolutions.School.Api.Provider
{
    /// <summary>
    /// JwtAuthProvider
    /// </summary>
    public static class AuthProvider
    {
        /// <summary>
        /// ConfigureJwtServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureJwtServices(this IServiceCollection services)
        {
            services.AddAuthentication(opt => { opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(opt => { opt.TokenValidationParameters = GetJwtParameters(services); });
        }
        /// <summary>
        /// Jwt parameters
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static TokenValidationParameters GetJwtParameters(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            var jwtAppSettingOptions = configuration.GetSection("AzureAd").Get<JwtIssuerOptions>();

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions.SecretKey));

            var options = new JwtIssuerOptions();

            options.Issuer = jwtAppSettingOptions.Instance;
            options.Audience = jwtAppSettingOptions.Instance;
            options.SecretKey = jwtAppSettingOptions.SecretKey;
            options.SymmetricSecurityKey = signingKey;
            options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(opt => opt = options);

            var tokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = options.Issuer,
                    ValidateAudience = true,
                    ValidAudience = options.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = options.SymmetricSecurityKey,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

            return tokenValidationParameters;
        }
    }

    /// <summary>
    /// JwtIssuerOptions
    /// </summary>
    public class JwtIssuerOptions
    {
        /// <summary>
        ///     "aud" (Audience) Claim
        /// </summary>
        /// <remarks>
        ///     The "aud" (audience) claim identifies the recipients that the JWT is
        ///     intended for.  Each principal intended to process the JWT MUST
        ///     identify itself with a value in the audience claim.  If the principal
        ///     processing the claim does not identify itself with a value in the
        ///     "aud" claim when this claim is present, then the JWT MUST be
        ///     rejected.  In the general case, the "aud" value is an array of case-
        ///     sensitive strings, each containing a StringOrURI value.  In the
        ///     special case when the JWT has one audience, the "aud" value MAY be a
        ///     single case-sensitive string containing a StringOrURI value.  The
        ///     interpretation of audience values is generally application specific.
        ///     Use of this claim is OPTIONAL.
        /// </remarks>
        public string Audience { get; set; }

        /// <summary>
        ///     "exp" (Expiration Time) Claim (returns IssuedAt + ValidFor)
        /// </summary>
        /// <remarks>
        ///     The "exp" (expiration time) claim identifies the expiration time on
        ///     or after which the JWT MUST NOT be accepted for processing.  The
        ///     processing of the "exp" claim requires that the current date/time
        ///     MUST be before the expiration date/time listed in the "exp" claim.
        ///     Implementers MAY provide for some small leeway, usually no more than
        ///     a few minutes, to account for clock skew.  Its value MUST be a number
        ///     containing a NumericDate value.  Use of this claim is OPTIONAL.
        /// </remarks>
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        /// <summary>
        ///     "iat" (Issued At) Claim (default is UTC NOW)
        /// </summary>
        /// <remarks>
        ///     The "iat" (issued at) claim identifies the time at which the JWT was
        ///     issued.  This claim can be used to determine the age of the JWT.  Its
        ///     value MUST be a number containing a NumericDate value.  Use of this
        ///     claim is OPTIONAL.
        /// </remarks>
        public DateTime IssuedAt => DateTime.UtcNow;

        /// <summary>
        ///     Gets or sets "iss" (Issuer) Claim
        /// </summary>
        /// <remarks>
        ///     The "iss" (issuer) claim identifies the principal that issued the
        ///     JWT.  The processing of this claim is generally application specific.
        ///     The "iss" value is a case-sensitive string containing a StringOrURI
        ///     value.  Use of this claim is OPTIONAL.
        /// </remarks>
        public string Issuer { get; set; }

        /// <summary>
        ///     "jti" (JWT ID) Claim (default ID is a GUID)
        /// </summary>
        /// <remarks>
        ///     The "jti" (JWT ID) claim provides a unique identifier for the JWT.
        ///     The identifier value MUST be assigned in a manner that ensures that
        ///     there is a negligible probability that the same value will be
        ///     accidentally assigned to a different data object; if the application
        ///     uses multiple issuers, collisions MUST be prLoged among values
        ///     produced by different issuers as well.  The "jti" claim can be used
        ///     to prLog the JWT from being replayed.  The "jti" value is a case-
        ///     sensitive string. Use of this claim is OPTIONAL.
        /// </remarks>
        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());

        /// <summary>
        ///     "nbf" (Not Before) Claim (default is UTC NOW)
        /// </summary>
        /// <remarks>
        ///     The "nbf" (not before) claim identifies the time before which the JWT
        ///     MUST NOT be accepted for processing.  The processing of the "nbf"
        ///     claim requires that the current date/time MUST be after or equal to
        ///     the not-before date/time listed in the "nbf" claim.  Implementers MAY
        ///     provide for some small leeway, usually no more than a few minutes, to
        ///     account for clock skew.  Its value MUST be a number containing a
        ///     NumericDate value.  Use of this claim is OPTIONAL.
        /// </remarks>
        public DateTime NotBefore => DateTime.UtcNow;

        /// <summary>
        /// 
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        ///     The signing key to use when generating tokens.
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }

        /// <summary>
        ///     Gets or sets "sub" (Subject) Claim
        /// </summary>
        /// <remarks>
        ///     The "sub" (subject) claim identifies the principal that is the
        ///     subject of the JWT.  The claims in a JWT are normally statements
        ///     about the subject.  The subject value MUST either be scoped to be
        ///     locally unique in the context of the issuer or be globally unique.
        ///     The processing of this claim is generally application specific.  The
        ///     "sub" value is a case-sensitive string containing a StringOrURI
        ///     value.  Use of this claim is OPTIONAL.
        /// </remarks>
        public string Subject { get; set; }

        /// <summary>
        /// SymmetricSecurityKey
        /// </summary>
        public SymmetricSecurityKey SymmetricSecurityKey { get; set; }

        /// <summary>
        ///     Set the timespan the token will be valid for (default is 5 min/300 seconds)
        /// </summary>
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(5);

        public string ClientId { get; set; }

        public string Tenant { get; set; }

        public string Instance { get; set; }


    }
}