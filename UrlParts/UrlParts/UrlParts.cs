
namespace UrlParts
{
    public class UrlParts
    {
        public string Protocol { get; set; }
        public string SubDomain { get; set; }
        public string Domain { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }

        public UrlParts() { }

        public UrlParts(string protocol, string subDomain, string domain, string port, string path)
        {
            this.Protocol = protocol;
            this.SubDomain = subDomain;
            this.Domain = domain;
            this.Port = port;
            this.Path = path;
        }
    }
}
