using System.Data;
using System.Numerics;

[Serializable]
[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct StringId // : IFormattable, IComparable, IComparable<StringId>, IEquatable<StringId>
{
    /// <summary>
    /// 6 bits per character
    /// 64 max character length
    /// 8 bits per byte
    /// </summary>
    private const byte VALUE_SIZE = 48;

    private const byte STRING_SIZE = 64;

    private const byte ZERO = 0b0000_0000;
    private const byte ONE = 0b0000_0001;
    private const byte TWO = 0b0000_0010;
    private const byte THREE = 0b0000_0011;

    private const byte ZERO_BIT_MASK = 0b0011_1111;
    private const byte ONE_V1_BIT_MASK = 0b1100_0000;
    private const byte ONE_V2_BIT_MASK = 0b0000_1111;
    private const byte TWO_V1_BIT_MASK = 0b1111_0000;
    private const byte TWO_V2_BIT_MASK = 0b0000_0011;
    private const byte THREE_BIT_MASK = 0b1111_1100;

    private const byte ONE_GET_V1_ONLY = 0b0000_0011;
    private const byte ONE_GET_V2_ONLY = 0b0011_1100;
    private const byte TWO_GET_V1_ONLY = 0b0000_1111;
    private const byte TWO_GET_V2_ONLY = 0b0011_0000;

    public const string VALID_CHARS_WITH_UPPER = "_abcdefghijklmnopqrstuvwxyz0123456789-@/\\+.&*()[]=^%$#!`~|\";:<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string VALID_CHARS = "_abcdefghijklmnopqrstuvwxyz0123456789-@/\\+.&*()[]=^%$#!`~|\";:<>?";

    private byte[] value;
    private byte length;

    /// <param name="b">*6-bit only* filled byte</param>
    /// <returns>Mapped `char` value</returns>
    private static char ByteToChar(byte b)
    {
        switch (b)
        {
            case 0: return '_';
            case 1: return 'a';
            case 2: return 'b';
            case 3: return 'c';
            case 4: return 'd';
            case 5: return 'e';
            case 6: return 'f';
            case 7: return 'g';
            case 8: return 'h';
            case 9: return 'i';
            case 10: return 'j';
            case 11: return 'k';
            case 12: return 'l';
            case 13: return 'm';
            case 14: return 'n';
            case 15: return 'o';
            case 16: return 'p';
            case 17: return 'q';
            case 18: return 'r';
            case 19: return 's';
            case 20: return 't';
            case 21: return 'u';
            case 22: return 'v';
            case 23: return 'w';
            case 24: return 'x';
            case 25: return 'y';
            case 26: return 'z';
            case 27: return '0';
            case 28: return '1';
            case 29: return '2';
            case 30: return '3';
            case 31: return '4';
            case 32: return '5';
            case 33: return '6';
            case 34: return '7';
            case 35: return '8';
            case 36: return '9';
            case 37: return '-';
            case 38: return '@';
            case 39: return '/';
            case 40: return '\\';
            case 41: return '+';
            case 42: return '.';
            case 43: return '&';
            case 44: return '*';
            case 45: return '(';
            case 46: return ')';
            case 47: return '[';
            case 48: return ']';
            case 49: return '=';
            case 50: return '^';
            case 51: return '%';
            case 52: return '$';
            case 53: return '#';
            case 54: return '!';
            case 55: return '`';
            case 56: return '~';
            case 57: return '|';
            case 58: return '"';
            case 59: return ';';
            case 60: return ':';
            case 61: return '<';
            case 62: return '>';
            case 63: return '?';
            default: return '_';
        }
    }

    /// <param name="c">Mapped char value</param>
    /// <returns>*6-bit only* filled byte</returns>
    private static byte CharToByte(char c)
    {
        switch (c)
        {
            case '_': return 0;
            case 'a': return 1;
            case 'b': return 2;
            case 'c': return 3;
            case 'd': return 4;
            case 'e': return 5;
            case 'f': return 6;
            case 'g': return 7;
            case 'h': return 8;
            case 'i': return 9;
            case 'j': return 10;
            case 'k': return 11;
            case 'l': return 12;
            case 'm': return 13;
            case 'n': return 14;
            case 'o': return 15;
            case 'p': return 16;
            case 'q': return 17;
            case 'r': return 18;
            case 's': return 19;
            case 't': return 20;
            case 'u': return 21;
            case 'v': return 22;
            case 'w': return 23;
            case 'x': return 24;
            case 'y': return 25;
            case 'z': return 26;
            case '0': return 27;
            case '1': return 28;
            case '2': return 29;
            case '3': return 30;
            case '4': return 31;
            case '5': return 32;
            case '6': return 33;
            case '7': return 34;
            case '8': return 35;
            case '9': return 36;
            case '-': return 37;
            case '@': return 38;
            case '/': return 39;
            case '\\': return 40;
            case '+': return 41;
            case '.': return 42;
            case '&': return 43;
            case '*': return 44;
            case '(': return 45;
            case ')': return 46;
            case '[': return 47;
            case ']': return 48;
            case '=': return 49;
            case '^': return 50;
            case '%': return 51;
            case '$': return 52;
            case '#': return 53;
            case '!': return 54;
            case '`': return 55;
            case '~': return 56;
            case '|': return 57;
            case '"': return 58;
            case ';': return 59;
            case ':': return 60;
            case '<': return 61;
            case '>': return 62;
            case '?': return 63;

            // Only lower allowed -> convert all upper to lower value
            case 'A': return 1;
            case 'B': return 2;
            case 'C': return 3;
            case 'D': return 4;
            case 'E': return 5;
            case 'F': return 6;
            case 'G': return 7;
            case 'H': return 8;
            case 'I': return 9;
            case 'J': return 10;
            case 'K': return 11;
            case 'L': return 12;
            case 'M': return 13;
            case 'N': return 14;
            case 'O': return 15;
            case 'P': return 16;
            case 'Q': return 17;
            case 'R': return 18;
            case 'S': return 19;
            case 'T': return 20;
            case 'U': return 21;
            case 'V': return 22;
            case 'W': return 23;
            case 'X': return 24;
            case 'Y': return 25;
            case 'Z': return 26;

            default: return 0;
        }
    }

    public static bool ValidForStringId(string s, bool allowUpper = true)
    {
        if (allowUpper)
            return s.All(c => VALID_CHARS_WITH_UPPER.Contains(c));
        else
            return s.All(c => VALID_CHARS.Contains(c));
    }

    public override string ToString() => ToString(true);

    public string ToString(bool trim_trailing_zeros = true)
    {
        var output = "";

        byte i = 0;
        byte b = 0;
        while (i < STRING_SIZE)
        {
            /*

            6/8 | byte - 0 only | b = 0
            12/8 -> 4/8 | byte - 0 & 1  | b = 1
            18/8 -> 2/8 | byte - 1 & 2 | b = 2
            24/8 -> 8/8 | byte - 2 only  | b = 3

            6/8 | byte - 3 only | b = 4
            12/8 -> 4/8 | byte - 3 & 4  | b = 5
            18/8 -> 2/8 | byte - 4 & 5 | b = 6
            24/8 -> 8/8 | byte - 5 only  | b = 7

            */

            byte ch = value[b];

            // byte zero = 0;
            byte one = ONE;
            byte two = TWO;
            byte three = THREE;

            one &= i;
            two &= i;
            three &= i;

            if (three == THREE)
            {
                ch &= THREE_BIT_MASK;
                ch >>= 2;
                output += ByteToChar(ch);
                b++;
            }
            else if (one == ONE)
            {
                ch &= ONE_V1_BIT_MASK;
                ch >>= 6;
                // Used: 0b1100_0000

                b++;

                byte v2 = value[b];
                v2 &= ONE_V2_BIT_MASK;
                v2 <<= 2;
                // Used: 0b0000_1111

                ch |= v2;
                output += ByteToChar(ch);
            }
            else if (two == TWO)
            {
                ch &= TWO_V1_BIT_MASK;
                ch >>= 4;
                // Used: 0b1111_0000

                b++;

                byte v2 = value[b];
                v2 &= TWO_V2_BIT_MASK;
                v2 <<= 4;
                // Used: 0b0000_0011

                ch |= v2;
                output += ByteToChar(ch);
            }
            else //zero
            {
                ch &= ZERO_BIT_MASK;
                output += ByteToChar(ch);
                // Used: 0b0011_1111
            }
            i++;
        }

        return trim_trailing_zeros ? output.TrimEnd('_') : output;
    }

    public static StringId Empty()
    {
        return new StringId()
        {
            value = new[] {
                ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO,
                ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO,
                ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO,
                ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO, ZERO
            }
        };
    }

    public static implicit operator StringId(string s) => NewStringId(s, true);

    public static implicit operator StringId(BigInteger i) => new StringId() { value = i.ToByteArray() };

    //public static implicit operator BigInteger(StringId s) => s.ToBigInt();
    //public BigInteger ToBigInt() => new BigInteger(_value);

    public static StringId NewStringId(string s, bool disregardSize = true)
    {
        if (string.IsNullOrEmpty(s))
            return Empty();

        if (s.Length > STRING_SIZE && !disregardSize)
            throw new InvalidConstraintException($"Only {STRING_SIZE} characters are allowed in a StringId, provided: {s.Length}");

        byte[] _value = new byte[VALUE_SIZE];

        byte i = 0;
        byte b = 0;
        while (b < VALUE_SIZE)
        {
            /*

            6/8 | byte - 0 only | b = 0
            12/8 -> 4/8 | byte - 0 & 1  | b = 1
            18/8 -> 2/8 | byte - 1 & 2 | b = 2
            24/8 -> 8/8 | byte - 2 only  | b = 3

            6/8 | byte - 3 only | b = 4
            12/8 -> 4/8 | byte - 3 & 4  | b = 5
            18/8 -> 2/8 | byte - 4 & 5 | b = 6
            24/8 -> 8/8 | byte - 5 only  | b = 7

            */

            if (s.Length <= i)
            {
                // Zero fill remainer
                byte _one = i;
                _one &= i;
                if (_one != ONE)
                    b++; // Don't ZERO out in-progress byte

                for (byte z = b; z < VALUE_SIZE; z++)
                    _value[z] = ZERO;

                break;
            }

            byte ch = CharToByte(s[i]);

            // byte zero = 0;
            byte one = ONE;
            byte two = TWO;
            byte three = THREE;

            one &= i;
            two &= i;
            three &= i;

            if (three == THREE)
            {
                // Filled: 0b0000_0011
                ch <<= 2;
                _value[b] |= ch;
                b++;
            }
            else if (one == ONE)
            {
                // Filled: 0b0011_1111
                byte v1 = ch;
                v1 &= ONE_GET_V1_ONLY;
                v1 <<= 6;
                _value[b] |= v1;

                b++;

                // Filled: 0b0000_0000
                byte v2 = ch;
                v2 &= ONE_GET_V2_ONLY;
                v2 >>= 2;
                _value[b] = v2;
            }
            else if (two == TWO)
            {
                // Filled: 0b0000_1111
                byte v1 = ch;
                v1 &= TWO_GET_V1_ONLY;
                v1 <<= 4;
                _value[b] |= v1;

                b++;

                // Filled: 0b0000_0000
                byte v2 = ch;
                v2 &= TWO_GET_V2_ONLY;
                v2 >>= 4;
                _value[b] = v2;
            }
            else //zero
            {
                // Filled: 0b0000_0000
                _value[b] = ch;
            }

            i++;
        }

        return new StringId()
        {
            value = _value,
            length = i,
        };
    }
}