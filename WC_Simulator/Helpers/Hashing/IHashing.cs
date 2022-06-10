using System.Security;

namespace WC_Simulator.Helpers.Hashing
{
    internal interface IHashing
    {
        bool MatchHashes(byte[] hash1, byte[] hash2);

        byte[] GetHash(string username, string password);
    }
}
