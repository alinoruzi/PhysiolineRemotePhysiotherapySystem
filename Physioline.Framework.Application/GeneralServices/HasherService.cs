using System.Security.Cryptography;
using System.Text;

namespace Physioline.Framework.Application.GeneralServices
{
	public class HasherService
	{
		// Hashes the input string using SHA-256 and returns the hashed value as a hexadecimal string.
		public static string HashString(string input)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				// Convert the input string to bytes
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);

				// Compute the hash
				byte[] hashBytes = sha256.ComputeHash(inputBytes);

				// Convert the hash bytes to a hexadecimal string
				StringBuilder sb = new StringBuilder();
				foreach (byte b in hashBytes)
				{
					sb.Append(b.ToString("x2")); // "x2" formats each byte as a two-digit hexadecimal number
				}

				return sb.ToString();
			}
		}
	}
}
