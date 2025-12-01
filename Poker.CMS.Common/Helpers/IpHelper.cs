using System.Net;

namespace Poker.CMS.Common.Helpers
{
    public static class IpHelper
    {
        public static bool IsIpAllowed(string ip, string ipMask)
        {
            var allowedIp = IPAddress.Parse(ipMask.Split('/')[0]);
            var allowedPrefixLength = int.Parse(ipMask.Split('/')[1]);

            var ipBytes = IPAddress.Parse(ip).GetAddressBytes();
            var allowedIpBytes = allowedIp.GetAddressBytes();

            // Convert prefix length to bytes and mask
            var mask = IPAddress.HostToNetworkOrder(
                BitConverter.ToInt32(BitConverter.GetBytes(uint.MaxValue), 0) << (32 - allowedPrefixLength)
            );

            var ipMasked = BitConverter.ToInt32(ipBytes, 0) & mask;
            var allowedIpMasked = BitConverter.ToInt32(allowedIpBytes, 0) & mask;

            return ipMasked == allowedIpMasked;
        }
    }
}
