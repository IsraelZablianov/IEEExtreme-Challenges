using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShorteningInTheRealWorld
{
    class Program
    {
        private static string baseUrl;

        static void Main(string[] args)
        {
            baseUrl = Console.ReadLine();
            var tests = int.Parse(Console.ReadLine());

            for (int i = 0; i < tests; i++)
            {
                var targetUrl = Console.ReadLine();
                List<byte> baseArr = new List<byte>(Encoding.Default.GetBytes(baseUrl));
                List<byte> targetArr = new List<byte>(Encoding.Default.GetBytes(targetUrl));
                var uInt = SingleResult(baseArr, targetArr);
                var appended = ConvertToBase64Arithmetic(uInt);
                Console.WriteLine(AppendToBaseUrl(appended));
            }
        }


        private static string AppendToBaseUrl(string appended)
        {
            return baseUrl + "/" + appended;
        }

        private static string ConvertToBase64Arithmetic(UInt64 i)
        {
            UInt64 myBase = 62;
            const string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();

            do
            {
                sb.Insert(0, alphabet[(int)(i % myBase)]);
                i = i / myBase;
            } while (i != 0);
            return sb.ToString();
        }

        private static UInt64 SingleResult(List<byte> baseUrlEncoding, List<byte> targetUrlEncoding)
        {
            List<byte> list = new List<byte>(baseUrlEncoding.Count);
            for (int i = 0; i < targetUrlEncoding.Count; i++)
            {
                var resultOfXor = baseUrlEncoding[i % baseUrlEncoding.Count] ^ targetUrlEncoding[i];
                list.Add((byte)resultOfXor);
            }
            list.Reverse();

            return BitConverter.ToUInt64(list.ToArray<byte>(), 0);
        }
    }
}
