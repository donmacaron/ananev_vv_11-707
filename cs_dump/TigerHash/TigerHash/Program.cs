using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace TigerHash
{
    public class Hash
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var text = "sUGHilduhbnlzdvougjoutjgoijv;idfjkp;odrkf[ordfkl'[d[frf" +
                "dkgkdbvdnvdkvnkjdxfvnkdfvlkdjvourseniuvsnjdkfveoavnjsloajkmlioscdk" +
                "jkdjfksnskvisevnisnvse;nseo;veoervnijrnknvesnjksernjajljdjnsd;jrnjjrerbnvjnjn";
            Console.WriteLine(GetHashSha256($"{text}")+
                "\n"+
                $"{text}");
        }

        public static string GetHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
