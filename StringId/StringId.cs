using System.Data;
using System.Numerics;

[Serializable]
[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct StringId : IFormattable, IComparable, IComparable<StringId>, IEquatable<StringId>
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

    private byte _0;
    private byte _1;
    private byte _2;
    private byte _3;
    private byte _4;
    private byte _5;
    private byte _6;
    private byte _7;
    private byte _8;
    private byte _9;
    private byte _10;
    private byte _11;
    private byte _12;
    private byte _13;
    private byte _14;
    private byte _15;
    private byte _16;
    private byte _17;
    private byte _18;
    private byte _19;
    private byte _20;
    private byte _21;
    private byte _22;
    private byte _23;
    private byte _24;
    private byte _25;
    private byte _26;
    private byte _27;
    private byte _28;
    private byte _29;
    private byte _30;
    private byte _31;
    private byte _32;
    private byte _33;
    private byte _34;
    private byte _35;
    private byte _36;
    private byte _37;
    private byte _38;
    private byte _39;
    private byte _40;
    private byte _41;
    private byte _42;
    private byte _43;
    private byte _44;
    private byte _45;
    private byte _46;
    private byte _47;
    private byte length;

    private void SetByteAtIndex(byte index, byte value)
    {
        switch (index)
        {
            case 0: _0 = value; break;
            case 1: _1 = value; break;
            case 2: _2 = value; break;
            case 3: _3 = value; break;
            case 4: _4 = value; break;
            case 5: _5 = value; break;
            case 6: _6 = value; break;
            case 7: _7 = value; break;
            case 8: _8 = value; break;
            case 9: _9 = value; break;
            case 10: _10 = value; break;
            case 11: _11 = value; break;
            case 12: _12 = value; break;
            case 13: _13 = value; break;
            case 14: _14 = value; break;
            case 15: _15 = value; break;
            case 16: _16 = value; break;
            case 17: _17 = value; break;
            case 18: _18 = value; break;
            case 19: _19 = value; break;
            case 20: _20 = value; break;
            case 21: _21 = value; break;
            case 22: _22 = value; break;
            case 23: _23 = value; break;
            case 24: _24 = value; break;
            case 25: _25 = value; break;
            case 26: _26 = value; break;
            case 27: _27 = value; break;
            case 28: _28 = value; break;
            case 29: _29 = value; break;
            case 30: _30 = value; break;
            case 31: _31 = value; break;
            case 32: _32 = value; break;
            case 33: _33 = value; break;
            case 34: _34 = value; break;
            case 35: _35 = value; break;
            case 36: _36 = value; break;
            case 37: _37 = value; break;
            case 38: _38 = value; break;
            case 39: _39 = value; break;
            case 40: _40 = value; break;
            case 41: _41 = value; break;
            case 42: _42 = value; break;
            case 43: _43 = value; break;
            case 44: _44 = value; break;
            case 45: _45 = value; break;
            case 46: _46 = value; break;
            case 47: _47 = value; break;
                default: throw new ArgumentOutOfRangeException($"Expected an index between 0 and 47, found {index}");
        }
    }
    private byte GetByteAtIndex(byte index)
    {
        switch (index)
        {
            case 0: return _0;
            case 1: return _1;
            case 2: return _2;
            case 3: return _3;
            case 4: return _4;
            case 5: return _5;
            case 6: return _6;
            case 7: return _7;
            case 8: return _8;
            case 9: return _9;
            case 10: return _10;
            case 11: return _11;
            case 12: return _12;
            case 13: return _13;
            case 14: return _14;
            case 15: return _15;
            case 16: return _16;
            case 17: return _17;
            case 18: return _18;
            case 19: return _19;
            case 20: return _20;
            case 21: return _21;
            case 22: return _22;
            case 23: return _23;
            case 24: return _24;
            case 25: return _25;
            case 26: return _26;
            case 27: return _27;
            case 28: return _28;
            case 29: return _29;
            case 30: return _30;
            case 31: return _31;
            case 32: return _32;
            case 33: return _33;
            case 34: return _34;
            case 35: return _35;
            case 36: return _36;
            case 37: return _37;
            case 38: return _38;
            case 39: return _39;
            case 40: return _40;
            case 41: return _41;
            case 42: return _42;
            case 43: return _43;
            case 44: return _44;
            case 45: return _45;
            case 46: return _46;
            case 47: return _47;
            default: throw new ArgumentOutOfRangeException($"Expected an index between 0 and 47, found {index}");
        }
    }

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

    public static bool ValidForStringId(string s, bool allowUpper = true) => allowUpper ? s.All(c => VALID_CHARS_WITH_UPPER.Contains(c)) : s.All(c => VALID_CHARS.Contains(c));

    public static StringId Empty() => new StringId() { _0 = ZERO, _1 = ZERO, _2 = ZERO, _3 = ZERO, _4 = ZERO, _5 = ZERO, _6 = ZERO, _7 = ZERO, _8 = ZERO, _9 = ZERO, _10 = ZERO, _11 = ZERO, _12 = ZERO, _13 = ZERO, _14 = ZERO, _15 = ZERO, _16 = ZERO, _17 = ZERO, _18 = ZERO, _19 = ZERO, _20 = ZERO, _21 = ZERO, _22 = ZERO, _23 = ZERO, _24 = ZERO, _25 = ZERO, _26 = ZERO, _27 = ZERO, _28 = ZERO, _29 = ZERO, _30 = ZERO, _31 = ZERO, _32 = ZERO, _33 = ZERO, _34 = ZERO, _35 = ZERO, _36 = ZERO, _37 = ZERO, _38 = ZERO, _39 = ZERO, _40 = ZERO, _41 = ZERO, _42 = ZERO, _43 = ZERO, _44 = ZERO, _45 = ZERO, _46 = ZERO, _47 = ZERO, length = ZERO };

    public static StringId NewStringId(string s, bool disregardSize = true)
    {
        if (string.IsNullOrEmpty(s))
            return Empty();

        if (s.Length > STRING_SIZE && !disregardSize)
            throw new InvalidConstraintException($"Only {STRING_SIZE} characters are allowed in a StringId, provided: {s.Length}");

        StringId output = Empty();

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
                break;

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
                var v = output.GetByteAtIndex(b);
                ch <<= 2;
                v |= ch;
                output.SetByteAtIndex(b, v);
                b++;
            }
            else if (one == ONE)
            {
                // Filled: 0b0011_1111
                var v = output.GetByteAtIndex(b);
                byte v1 = ch;
                v1 &= ONE_GET_V1_ONLY;
                v1 <<= 6;
                v |= v1;
                output.SetByteAtIndex(b, v);

                b++;

                // Filled: 0b0000_0000
                byte v2 = ch;
                v2 &= ONE_GET_V2_ONLY;
                v2 >>= 2;
                output.SetByteAtIndex(b, v2);
            }
            else if (two == TWO)
            {
                // Filled: 0b0000_1111
                var v = output.GetByteAtIndex(b);
                byte v1 = ch;
                v1 &= TWO_GET_V1_ONLY;
                v1 <<= 4;
                v |= v1;
                output.SetByteAtIndex(b, v);

                b++;

                // Filled: 0b0000_0000
                byte v2 = ch;
                v2 &= TWO_GET_V2_ONLY;
                v2 >>= 4;
                output.SetByteAtIndex(b, v2);
            }
            else //zero
            {
                // Filled: 0b0000_0000
                output.SetByteAtIndex(b, ch);
            }

            i++;
        }

        output.length = i;

        return output;
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

            byte ch = GetByteAtIndex(b);

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

                byte v2 = GetByteAtIndex(b);
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

                byte v2 = GetByteAtIndex(b);
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

    public string ToString(string? format, IFormatProvider? formatProvider) => ToString(true).ToString(formatProvider);

    public BigInteger ToBigInteger() => this;

    public byte[] ToBytes() => this;

    public int CompareTo(object? obj) => ToString(true).CompareTo(obj?.ToString() ?? string.Empty);

    public int CompareTo(StringId other) => ToString(true).CompareTo(other.ToString());

    public bool Equals(StringId other)
    {
        if (length != other.length)
            return false;

        for (byte i = 0; i < VALUE_SIZE; i++)
        {
            if (GetByteAtIndex(i) != other.GetByteAtIndex(i))
                return false;
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return length == 0;

        if (obj is StringId)
            return Equals((StringId)obj);

        if (obj is BigInteger || obj is sbyte || obj is byte || obj is short || obj is ushort || obj is int || obj is uint || obj is long || obj is ulong)
            return ToBigInteger().Equals(obj);

        if (obj is byte[])
            return this == (byte[])obj;

        return false;
    }

    public override int GetHashCode() => ToString(true).GetHashCode();


    public static implicit operator StringId(string s) => NewStringId(s, true);

    public static implicit operator BigInteger(StringId id) => new BigInteger(id);

    public static implicit operator byte[](StringId id) => new byte[VALUE_SIZE] { id._0, id._1, id._2, id._3, id._4, id._5, id._6, id._7, id._8, id._9, id._10, id._11, id._12, id._13, id._14, id._15, id._16, id._17, id._18, id._19, id._20, id._21, id._22, id._23, id._24, id._25, id._26, id._27, id._28, id._29, id._30, id._31, id._32, id._33, id._34, id._35, id._36, id._37, id._38, id._39, id._40, id._41, id._42, id._43, id._44, id._45, id._46, id._47 };

    public static implicit operator StringId(byte[] b)
    {
        var output = new StringId() { _0 = b[0], _1 = b[1], _2 = b[2], _3 = b[3], _4 = b[4], _5 = b[5], _6 = b[6], _7 = b[7], _8 = b[8], _9 = b[9], _10 = b[10], _11 = b[11], _12 = b[12], _13 = b[13], _14 = b[14], _15 = b[15], _16 = b[16], _17 = b[17], _18 = b[18], _19 = b[19], _20 = b[20], _21 = b[21], _22 = b[22], _23 = b[23], _24 = b[24], _25 = b[25], _26 = b[26], _27 = b[27], _28 = b[28], _29 = b[29], _30 = b[30], _31 = b[31], _32 = b[32], _33 = b[33], _34 = b[34], _35 = b[35], _36 = b[36], _37 = b[37], _38 = b[38], _39 = b[39], _40 = b[40], _41 = b[41], _42 = b[42], _43 = b[43], _44 = b[44], _45 = b[45], _46 = b[46], _47 = b[47], length = 0 };
        output.length = (byte)output.ToString().Length;
        return output;
    }

    public static bool operator ==(string left, StringId right)
    {
        if (left.Length != right.length)
            return false;

        return left == right.ToString();
    }
    public static bool operator ==(StringId left, string right)
    {
        if (left.length != right.Length)
            return false;

        return left.ToString() == right;
    }
    public static bool operator ==(StringId left, StringId right)
    {
        if (left.length != right.length)
            return false;

        for (byte i = 0; i < VALUE_SIZE; i++)
        {
            if (left.GetByteAtIndex(i) != right.GetByteAtIndex(i))
                return false;
        }

        return true;
    }

    public static bool operator !=(string left, StringId right)
    {
        if (left.Length != right.length)
            return true;

        return left != right.ToString();
    }
    public static bool operator !=(StringId left, string right)
    {
        if (left.length != right.Length)
            return true;

        return left.ToString() != right;
    }
    public static bool operator !=(StringId left, StringId right)
    {
        if (left.length != right.length)
            return true;

        for (byte i = 0; i < VALUE_SIZE; i++)
        {
            if (left.GetByteAtIndex(i) != right.GetByteAtIndex(i))
                return true;
        }

        return false;
    }


    public static bool operator <(StringId left, StringId right) => left.CompareTo(right) < 0;

    public static bool operator <=(StringId left, StringId right) => left.CompareTo(right) <= 0;

    public static bool operator >(StringId left, StringId right) => left.CompareTo(right) > 0;

    public static bool operator >=(StringId left, StringId right) => left.CompareTo(right) >= 0;
}