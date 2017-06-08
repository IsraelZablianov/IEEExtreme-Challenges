using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace XtreneInSecurity
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var logFile = File.ReadAllLines(@"C:\Users\israel\Desktop\file.txt");
        //    List<string> LogList = new List<string>(logFile);
        //    Dictionary<string, string> map = new Dictionary<string, string>(85);

        //    for (int i = 0; i < LogList.Count; i++)
        //    {
        //        map.Add(getEncodedWord(LogList[i]), LogList[i]);
        //    }
        //    using (StreamWriter file = new StreamWriter("myfile.txt"))
        //        foreach (var entry in map)
        //            file.WriteLine("map[\"{0}\"]=\"{1}\";", entry.Key, entry.Value);
        //    Console.ReadLine();
        //}

        //public static string getEncodedWord(string word)
        //{
        //    var salt = "IEEE";
        //    var paper = "Xtreme";
        //    return sha256_hash(salt + word + paper);
        //}

        //public static String sha256_hash(String value)
        //{
        //    using (SHA256 hash = SHA256Managed.Create())
        //    {
        //        Encoding enc = Encoding.UTF8;
        //        Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

        //        return Convert.ToBase64String(result);
        //    }
        //}

        static void Main(string[] args)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map["05HwH93tksb69U1ifesCQuYFP+gKPVH2L6W8JeBdXy0="] = "digital";
            map["8OtpJ+E1XHv2RDsKIEwJc9KUFwPRzaqeHJ735Er6AVE="] = "rice";
            map["8cdgZu9dBOrcTBMqElM+y9Vh5FTBRQ7n9EGa/4qVHUk="] = "snakes";
            map["8esDbw8ZVmUuUMEy2Scf5qGiZYiykevrvKpq2bVYHj4="] = "a";
            map["3hoie8omUyvM/9Qfx9dKfoptlwemYe2os8aohTGzoyw="] = "i";
            map["Rz38Ng2qI3mPkaRB6uDoCYmmfzbVTCzpt2sG1o+TZqo="] = "o";
            map["N5aunKGHeN2WETLXLzfhfCxAfkwtGU/imziiTF3t7oY="] = "e";
            map["rjwtKqkPc7cfQ+zZ+E9c+fzQYhRvhVtaKEFb+srIHcQ="] = "u";
            map["IxQxcFXR51q8h8FLblPhYfUR30lIAt6hX8TjZWVa/GE="] = "crashing";
            map["O9L1ZWYwuzgaImTjOwuogXfpC+C44zzcDhpt08LjR5c="] = "chocolate";
            map["R/ye+L9W+l6hyZ/v1POsWYboEGemIisARL8ohUvfBLI="] = "bunnies";
            map["tDdmKQpMiVDFA1YdblkHSFzL4Z9UIQ9FSouf3TybOu0="] = "password1";
            map["NmrOUzHxKSfNT8UJ1YXbRL8I+HCAb+glJ0bBXcHfagE="] = "art1";
            map["Lqxt1UjT1ecV6ucgYn+yrGSUTxPWkZgdDtbygGwC/BA="] = "world4";
            map["aJIH+q0YjYZCpierKtbue5JDtZSF8tKxVKuHYUPQ65k="] = "binary2";
            map["j2GTUqtqZpotY8wF16zkvnbdCLTnX3oOZ30SjQUnIUk="] = "formatted";
            map["ix+0IJIpLpHeSHEII+Q/IVY+FlRXn3xMA0ey6UITi34="] = "bst";
            map["socJeO02bT2w+XZUrLoopbZvQ1lRhDfE88GVrJQ8p+g="] = "square7";
            map["lUfxHX9xH2aOHheMMqQF+f5BNh97avew2uOwEN3B7HE="] = "0";
            map["h84yifAWGLj9sakEqxZ3QEjkXL42AoScP3L5Tdevm98="] = "1";
            map["r6BN0tdyAYZD0Nmc7bfV0WRcFBb1A2WIPPKHVRG59k8="] = "3";
            map["28AdfW0JHmCP4TbieGON8dafRaFpUgpzuX2bHZN6WsM="] = "4";
            map["y+zbMpySKY+WF97KkgRQ+tBpM7iTqTj9guWmGJcqfyA="] = "minimum8";
            map["zqKPAOt5ziHSeRxc0TgUZF3rJxzBHAKdJeccvt3F7Jg="] = "stand5";
            map["3uDaglIdYUn11AadEhELBjE15A0L6hAaWnZmjCGtt+M="] = "demons8";
            map["TInfNYwXvofBA+9QIe3+XEfDpO5ER+R+Jn3BOshhZWU="] = "maze3";
            map["B2E/K/DywbLEKutOKpS8HxHFrZwucwac4KjzYgsXg3g="] = "real7";
            map["FGkqFC/jLDqDZ10fql1nGw7AQNWioOrZ3ydEaJyXBwo="] = "me4t4";
            map["gE7PseB3mspPtYG3JROzT9FeqTfPFYQvBF2SJD9V19Y="] = "h0rs30";
            map["JCmqBN0MsW13tEmsQPYWg9Fj25MUrqFYvSK2arxTt0A="] = "4rt5";
            map["y1R6JQiUzUovgtdrvCkbeQAyMhFoupzhI5ZuQVPfCgw="] = "bl0ck5";
            map["81X3NN5JgTuGgqq3ErF0eL/l/wZFYkCwur6fZ06L2Us="] = "sad6";
            map["R1v9fEb9VrZuU5xiYTKTqhHF03VtXg7+KtfFHPkQuCQ="] = "cow3";
            map["tqpGCBzhR+0ONFk1sBiHPhz+kRiXmY3CGdUXqnMJwLg="] = "sh3lls4";
            map["m0IeuugWDOl9cFUFRYJhouCBT39T0dpp1xBOKPqHP94="] = "land6";
            map["KudA8vCEQdGaaCSxotpAcluXnVPS3MAZPkwI/lVupak="] = "game9";
            map["CornANxoZ5FJnlhwHmK42CDXf3h6jFr3g73YIRuoymQ="] = "c4v35";
            map["GsXTQM0w+Clb1c9B7n28mADU2quLeI1n91KTyBboeHI="] = "url5";
            map["NnSS+AuW1Z6zytSfqaiIVp4xxHHe70Av+IdhDlkoItQ="] = "g4mm42";
            map["Wau4ReopjFKk8SYYNq5lIBL+Rgg8aBR6h9UgTIv2u7I="] = "b4r4";
            map["GcJMWMDF6+f+onf6oi1FbpnN7dVrFEZnlXtHqmaygs4="] = "shortening";
            map["YollqBlewcxE/kF6PKvv0r1CLZkKx82657bB0eQbiK0="] = "dice9";
            map["VDkcRd54BhYlK5Wg2PPDa/jzGrSkMepGIv6Tw3I2ksc="] = "esport6";
            map["/PtjJboZGlsmTovvyOhBOoTVnQKUP/gJXxjLAW9Lppw="] = "bon8";
            map["eUqkcVCbgIx1bGhhmnN5MxJFJhVruINmG65TjT/EQ1k="] = "fin1te4";
            map["BwbAsOqPsxteVCpAwIjrhYogsUS1bF/bLns2QdcLYUI="] = "b34ns1";
            map["ugcIIpDID0R1uFqBAcN3PNXhwlhen77GdAccFgpbs+A="] = "roaming7";
            map["tojYiNtlWmq+7r1dSvxDk3W5at/NMAi1uxCHY61WAKk="] = "t0k3n7";
            map["LGZEfbUr/tMREpJtsao/uuewcJXApmgfHDbh1zzfdhU="] = "winn3r0";
            map["RVfhsLovxa+/6tWgeSBASIIkzXkVtDPT4yYvjboHhIk="] = "metric0";
            map["rdALvOYVhA3hnUTBlaQXigWBSgMYzGTreSKyMoAoKfw="] = "character1";
            map["9DS4orbhPFbjJcosEqQg+eg0Si5qSOnftfHiqK8sYug="] = "voyage8";
            map["LZIzmWEqXDPJsnKttFGRaG/jUhHrbTEKt1XCO6XbdME="] = "be2";
            map["rwvmTDiJxIEETbsngvpxYGwZZK+FGo7527odGuQUjtQ="] = "stand4";
            map["bi6rh2HgTbJxR2GOTNWZLlxiiWZVnObptGj0KqOCSYo="] = "c0mmun1t13s9";
            map["MHQTB1MSsvhBxMpdRUiaM9Uj1QxU7zYq3FqDlW2HT2s="] = "c0rr3ct0";
            map["IDB/pOthrWobzapJ/N8HsraNhwfbExAa2uusdiKHFFI="] = "p4ssw0rd9";
            map["gMi4hC4o7Fmv6yIrU48BVy8I1khXwkaD36G7bWiZHeo="] = "s0c14l6";
            map["DDa2TJX20pPsNftfyJ3s6LBwSMSR3EADZGDxW2wThbs="] = "p4tt3rn7";
            map["VjFTqTEY27V8lK2yCvhLhYm2Brh9bN1vWckVaevsiiY="] = "g3n3r4t33";
            map["opBtoC66YDRbLNqZAAu2FIeKfF0HMOGHCOCPYeNHdx4="] = "c4nv4s6";
            map["Y5b6UztMueFYIFMl4a61jlD/ZhFG74/rVn8XaqqU+8c="] = "pr1z3s8";
            map["BjQiH/A2FUNHlUwhBi8NWmj3HmhmAh6Ag0kRyVSaVo8="] = "gold0";
            map["usg8BTtSfewL5M3OVg91TJCTc5vONLqgUCC/Si1Grsg="] = "engineers0";
            map["hEGKCiTZSA5x560hodRoIBBTE8pv4sP1VXG4D0fXWcI="] = "optimal2";
            map["wEtqAs8JHjicWnXshAWF5Sg6NoswuG9qeJ7USw7YD7c="] = "multiple3";
            map["HWv9gx+GL/6g+0b0eOc+1Z/8BHse91/5T/DdiDwEknU="] = "xtreme4";
            map["qrkd/8imuRtiDb9N1w2hQRxJAkdx3Wqh1HVXPS7dym8="] = "m4ximum7";
            map["JOXxLH/i8i+fxDIWP2cts5Si/5En1A8M3s/vy6Aadic="] = "participants3";
            map["ot/igM+me4e3UTT731qcBkSAcToyADMCddr7i7LCWGo="] = "subterranean";
            map["kuRpkIh9kaNz6XvG8U6GO/IARH/SqhRnTiJbZHXC0yQ="] = "h34dqu4rt3rs2";
            map["mgA5kgALstQpGUBp4vZ8oiz0P4jjAGl0wjgls6kQyMA="] = "rightmost3";
            map["jtUg00EsmzzFkk8JgKg3OpkmPRpN9xbwsdNXQSPczwo="] = "entrant9";
            map["k1J9Dv3EI442CO6A2FGN1H8JgFO2kjNBvkjDR0WIvkA="] = "numbered9";
            map["YzSqlQTtq5j+Kd+hW1ISgBW0mn61vsQsxNeipq0sYCo="] = "tac04";
            map["Lq0kV5M0HDSgB4m5KZbbn6BYRNlkKfaaAr3/11ueopY="] = "4ntisoci4l9";
            map["1mT5cdKRz4BbfMdc8LAdnxfjsGO4lV0k0/V1IHtidmY="] = "conn3ct3d1";
            map["XtEWsXf16y6Bc7vQxDy7hwRdBVWo3dV9C6CDVSf4PLs="] = "gr3gor1o3";
            map["4D4NstIYSjVN826Q+SXUDDmXglJplpYWiJYf9rt7H8U="] = "in3qu4lity6";
            map["uAZthS7b4ySZtWpM9pJ7ulYnhFdpFABpR2iPRQEmff0="] = "r4nges1";
            map["CYDZabjeyTAwcEDEcvrX83514UmpjzvQUQ68DIZ/PXg="] = "synt4ctic4lly8";
            map["IXYqlHbVeONERbxFe8SaEPEEKex45EihiC/l8CR52kk="] = "v4ri4ble7";
            map["9XDFIu4RPH0EL5XR+5VYILJ3UFAyltpfjONJKp/vcLk="] = "c4bins9";
            map["HLnuqQmCYetzrau3frCDEpZ52QCIby108gugsmwAwQ0="] = "coll3ction2";
            map["cX7VyMvSYhuRvEfAUb3uNh8kmjpNFg0tatUPN562iOg="] = "commun1ty2";


            Console.WriteLine(map[Console.ReadLine()]);
        }
    }
}
