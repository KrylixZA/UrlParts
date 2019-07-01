using System.Linq;

namespace UrlParts
{
    public static class Parser
    {
        public static UrlParts Decompose(string url)
        {
            // Protocol
            var protocol = GetProtocol(ref url);

            // Sub Domain
            var subDomain = GetSubDomain(ref url);

            // Domain
            var domain = GetDomain(ref url);

            // Port
            var port = GetPort(ref url, protocol);

            //Path
            var path = GetPath(url);

            return new UrlParts
            {
                Protocol = protocol,
                SubDomain = subDomain,
                Domain = domain,
                Port = port,
                Path = path
            };
        }

        private static string GetProtocol(ref string url)
        {
            var endOfProtocolIndex = url.IndexOf(':');
            var protocol = url.Substring(0, endOfProtocolIndex);
            url = url.Replace(protocol + "://", string.Empty);

            return protocol;
        }

        private static string GetSubDomain(ref string url)
        {
            var subDomain = string.Empty;
            var numOfPeriods = url.Count(k => k == '.');
            if (numOfPeriods > 1)
            {
                var endOfSubDomainIndex = url.IndexOf('.');
                subDomain = url.Substring(0, endOfSubDomainIndex);
                url = url.Replace(subDomain + ".", string.Empty);
            }

            return subDomain;
        }

        private static string GetDomain(ref string url)
        {
            string domain;
            var beginningOfPortIndex = url.IndexOf(':');
            if (beginningOfPortIndex != -1)
            {
                domain = url.Substring(0, beginningOfPortIndex);
                url = url.Replace(domain + ":", string.Empty);
            }
            else
            {
                var beginningOfPathIndex = url.IndexOf('/');
                if (beginningOfPathIndex != -1)
                {
                    domain = url.Substring(0, beginningOfPathIndex);
                    url = url.Replace(domain + "/", string.Empty);
                }
                else
                {
                    domain = url;
                    url = url.Replace(domain, string.Empty);
                }
                
            }

            return domain;
        }

        private static string GetPort(ref string url, string protocol)
        {
            var beginningOfPathIndex = url.IndexOf('/');
            if (beginningOfPathIndex != -1)
            {
                var port = url.Substring(0, beginningOfPathIndex);
                url = url.Replace(port + "/", string.Empty);
                return port;
            }

            switch (protocol)
            {
                case "https":
                    return "443";
                case "ftp":
                    return "21";
                case "sftp":
                    return "22";
                default:
                    return "80";
            }
        }

        private static string GetPath(string url)
        {
            return url;
        }
    }
}
