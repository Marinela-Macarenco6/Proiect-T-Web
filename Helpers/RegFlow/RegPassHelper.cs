using System;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.RegFlow
{
    public class RegPassHelper
    {
        public static string HashGen(string password)
        {

            string noise =
                "aB1$eF4!7#qLxP0@Mn6^Zy*&r2T!o9#WvBgFtNcX$*KdRs" +
                "Lp6!qW9%HuJ@1oMfE3#tK!vLz@8^PbxA&Cs9MZ$YwG7qUr" +
                "Zx8&Vc3@BmK7#rWsT$1nLy8Uo!Ae&QpXv^J39ZsDtwL%Mf" +
                "Ju5*Kl1(NqRp#Yt!MZbAvC7$X&k92oLgPwTmvENf@^dHsQ" +
                "Rt0^Bn6)WpZe@fKx!rN7Q&YuLMv#As9Pto1T*H8cG$XEbq" +
                "XcF1!aZg8#WqMvNPl9^TYbK*Ur0$JsE@oLtCZpR6vBd&Xm";

            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password + noise);
            var ecodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(ecodedBytes).Replace("-", "").ToLower();
        }
    }
}

