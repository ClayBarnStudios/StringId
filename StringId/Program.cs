// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Numerics;

var _a = "@planet-type/earthlike/tile_a";
var _b = "@planet-type/earthlike/tile_bb";
var _c = "@planet-type/earthlike/tile_ccc";
var _d = "@planet-type/earthlike/tile_dddd";
var _e = "@ship/fighter-252";

var _also_a = "@planet-type/earthlike/tile_a";

var a = StringId.NewStringId(_a);
var b = StringId.NewStringId(_b);
var c = StringId.NewStringId(_c);
var d = StringId.NewStringId(_d);
var e = StringId.NewStringId(_e);

var also_a = StringId.NewStringId(_also_a);

Console.WriteLine($"{a} -> {_a} with Length: {_a.Length}");
Console.WriteLine($"{b} -> {_b} with Length: {_b.Length}");
Console.WriteLine($"{c} -> {_c} with Length: {_c.Length}");
Console.WriteLine($"{d} -> {_d} with Length: {_d.Length}");
Console.WriteLine($"{e} -> {_e} with Length: {_e.Length}");

Console.WriteLine($"a == b? {a == b}");
Console.WriteLine($"a == c? {a == c}");
Console.WriteLine($"a == also_a? {a == also_a}");

BigInteger i_a = a;
BigInteger i_also_a = also_a;

Console.WriteLine($"{a} -> {i_a}");
Console.WriteLine($"{also_a} -> {i_also_a}");

Console.Write($"\n\n");

{
    int stressTest = 1_000_000;

    for (int _ = 0; _ < 10; _++)
    {
        string all_chars = "_abcdefghijklmnopqrstuvwxyz0123456789-@/\\+.&*()[]=^%$#!`~|\";:<>?";

        StringId[] stringIds = new StringId[stressTest];

        // Unoptimised Test
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < stressTest; i++)
            stringIds[i] = all_chars.Substring(0, all_chars.Length - i.ToString().Length) + i.ToString();
        sw.Stop();

        Console.WriteLine($"Created {stressTest} StringIds in ({sw.ElapsedMilliseconds}ms/{sw.ElapsedTicks}ticks)");
    }
}

{
    int stressTest = 1_000_000;

    string all_chars = "_abcdefghijklmnopqrstuvwxyz0123456789-@/\\+.&*()[]=^%$#!`~|\";:<>?";

    StringId[] stringIds = new StringId[stressTest];
    for (int i = 0; i < stressTest; i++)
        stringIds[i] = all_chars.Substring(0, all_chars.Length - i.ToString().Length) + i.ToString();

    for (int _ = 0; _ < 10; _++)
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 1; i < stressTest; i++)
        {
            if (stringIds[i] == stringIds[i - 1])
                throw new InvalidDataException($"[{i - 1}; {stringIds[i - 1]}] == [{i}; {stringIds[i]}]");
        }
        sw.Stop();

        Console.WriteLine($"Compared {stressTest} StringIds in ({sw.ElapsedMilliseconds}ms/{sw.ElapsedTicks}ticks)");
    }
}

{
    ulong stressTest = 1_000_000;

    ulong[] ids = new ulong[stressTest];
    for (ulong i = 0; i < stressTest; i++)
        ids[i] = i;

    for (int _ = 0; _ < 10; _++)
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (ulong i = 1; i < stressTest; i++)
        {
            if (ids[i] == ids[i - 1])
                throw new InvalidDataException($"[{i - 1}; {ids[i - 1]}] == [{i}; {ids[i]}]");
        }
        sw.Stop();

        Console.WriteLine($"Compared {stressTest} ulong in ({sw.ElapsedMilliseconds}ms/{sw.ElapsedTicks}ticks)");
    }
}

{
    int stressTest = 1_000_000;

    string all_chars = "_abcdefghijklmnopqrstuvwxyz0123456789-@/\\+.&*()[]=^%$#!`~|\";:<>?";

    string[] strings = new string[stressTest];
    for (int i = 0; i < stressTest; i++)
        strings[i] = all_chars.Substring(0, all_chars.Length - i.ToString().Length) + i.ToString();

    for (int _ = 0; _ < 10; _++)
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 1; i < stressTest; i++)
        {
            if (strings[i] == strings[i - 1])
                throw new InvalidDataException($"[{i - 1}; {strings[i - 1]}] == [{i}; {strings[i]}]");
        }
        sw.Stop();

        Console.WriteLine($"Compared {stressTest} Strings in ({sw.ElapsedMilliseconds}ms/{sw.ElapsedTicks}ticks)");
    }
}

Console.Read();
