using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace HromadaWEB.Web
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private string? _jwtToken;
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!string.IsNullOrEmpty(_jwtToken))
            {
                var identity = new ClaimsIdentity(ParseClaimsFromJwt(_jwtToken), "jwt");
                var user = new ClaimsPrincipal(identity);
                return Task.FromResult(new AuthenticationState(user));
            }

            return Task.FromResult(new AuthenticationState(_anonymous));
        }

        public Task MarkUserAsAuthenticated(string token)
        {
            _jwtToken = token;
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            return Task.CompletedTask;
        }

        public void MarkUserAsLoggedOut()
        {
            _jwtToken = null;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            try
            {
                // JWT має формат header.payload.signature, тому беремо payload
                var payload = jwt.Split('.')[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
                if (keyValuePairs != null)
                {
                    claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));
                }
            }
            catch
            {
                // Якщо виникає помилка при парсингу, повертаємо пустий список claims
            }
            return claims;
        }


        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }

}