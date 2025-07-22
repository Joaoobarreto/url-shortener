using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace url_shortener.Domain.Utils;
public static class Base62Converter
{
    private const string Base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        byte[] bytes = Encoding.UTF8.GetBytes(input);

        BigInteger value = new BigInteger(bytes.Concat(new byte[] { 0 }).ToArray());

        var result = new StringBuilder();

        while (value > 0)
        {
            value = BigInteger.DivRem(value, Base62Chars.Length, out BigInteger remainder);
            result.Insert(0, Base62Chars[(int)remainder]);
        }

        return result.ToString();
    }

    public static string Decode(string base62)
    {
        if (string.IsNullOrEmpty(base62))
            return string.Empty;

        BigInteger value = BigInteger.Zero;
        foreach (char c in base62)
        {
            value *= 62;
            int index = Base62Chars.IndexOf(c);
            if (index == -1)
                throw new ArgumentException($"Invalid Base62 character: {c}");
            value += index;
        }

        byte[] bytes = value.ToByteArray();

        if (bytes[^1] == 0)
            Array.Resize(ref bytes, bytes.Length - 1);

        return Encoding.UTF8.GetString(bytes);
    }
}
