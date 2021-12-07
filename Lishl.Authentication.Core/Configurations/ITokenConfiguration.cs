namespace Lishl.Authentication.Core.Configurations
{
    public interface ITokenConfiguration
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenExpires { get; set; }
    }
}