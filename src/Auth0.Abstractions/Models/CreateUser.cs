using Newtonsoft.Json;

namespace LaDanse.External.Auth0.Abstractions.Models
{
    public class CreateUser
    {
        public class Request
        {
            [JsonProperty("email")] public string Email { get; set; }

            [JsonProperty("blocked")] public bool Blocked { get; set; }

            [JsonProperty("email_verified")] public bool EmailVerified { get; set; }

            [JsonProperty("nickname")] public string Nickname { get; set; }

            [JsonProperty("connection")] public string Connection { get; set; }

            [JsonProperty("password")] public string Password { get; set; }

            [JsonProperty("verify_email")] public bool VerifyEmail { get; set; }

            [JsonProperty("app_metadata")] public AppMetaData AppMetaData { get; set; }
        }

        public class Response
        {
            [JsonProperty("blocked")] public bool Blocked { get; set; }

            [JsonProperty("created_at")] public string CreatedAt { get; set; }

            [JsonProperty("email")] public string Email { get; set; }

            [JsonProperty("email_verified")] public bool EmailVerified { get; set; }

            [JsonProperty("nickname")] public string Nickname { get; set; }

            [JsonProperty("picture")] public string Picture { get; set; }

            [JsonProperty("updated_at")] public string UpdatedAt { get; set; }

            [JsonProperty("user_id")] public string UserId { get; set; }

            [JsonProperty("identities")] public Identity[] Identities { get; set; }
        }

        public class AppMetaData
        {
            [JsonProperty("ladanse_legacy_id")] public string LaDanseLegacyId { get; set; }
        }

        public class Identity
        {
            [JsonProperty("connection")] public string Connectoion { get; set; }

            [JsonProperty("provider")] public string Provider { get; set; }

            [JsonProperty("user_id")] public string UserId { get; set; }

            [JsonProperty("isSocial")] public bool IsSocial { get; set; }
        }
    }
}