using System.Security.Cryptography;
using System.Text;

namespace WC_Simulator.Helpers.Hashing
{
    internal class SHA256Hashing : IHashing
    {
        public bool MatchHashes(byte[] hash1, byte[] hash2)
        {
            bool result = false;
            if (hash1 != null && hash2 != null)
            {
                if (hash1.Length == hash2.Length)
                {
                    result = true;
                    for (int i = 0; i < hash1.Length; i++)
                    {
                        if (hash1[i] != hash2[i])
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public byte[] GetHash(string userID, string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                return mySHA256.ComputeHash(Encoding.ASCII.GetBytes(userID + password));
            }
    }
}
