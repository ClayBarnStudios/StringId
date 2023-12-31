# StringId
A 64 char string to deterministic ID `struct`.

```csharp
var _a = "@my-type-name/subpath/unique";
var _c = "@my-type-name/subpath/very_unique";
var a = StringId.NewStringId(_a)
var b = StringId.NewStringId(_a)
var c = StringId.NewStringId(_c)

Console.WriteLine($"{a} -> {_a} with Length: {_a.Length}");
// Output: @my-type-name/subpath/unique -> @my-type-name/subpath/unique with Length: 28

Console.WriteLine($"a == b? {a == b}");
// Output: a == b? True

Console.WriteLine($"a == c? {a == c}");
// Output: a == c? False

BigInteger i_a = a;

Console.WriteLine($"{a} -> {i_a}");
/* Output: @my-type-name/subpath/unique -> 31172722559049346692838570210739845563305134756710

    **a.k.a.**

    31 172 722 559 049 346 692 838 570 210 739 845 563 305 134 756 710

    OR

    thirty-one quindecillion, 
    one hundred seventy-two quattuordecillion, 
    seven hundred twenty-two tredecillion, 
    five hundred fifty-nine duodecillion, 
    forty-nine undecillion, 
    three hundred forty-six decillion, 
    six hundred ninety-two nonillion, 
    eight hundred thirty-eight octillion, 
    five hundred seventy septillion, 
    two hundred ten sextillion, 
    seven hundred thirty-nine quintillion, 
    eight hundred forty-five quadrillion, 
    five hundred sixty-three trillion, 
    three hundred five billion, 
    one hundred thirty-four million, 
    seven hundred fifty-six thousand, 
    seven hundred ten 
*/
```



#### Current Benchmarks:

##### Creation Benchmark

***Includes:***
- Call to `NewStringId()`
- Substring Operation: `all_chars.Substring(0, all_chars.Length - i.ToString().Length) + i.ToString()` where `i` is the current index


| Call Count | Result (Average of 10 attempts) |
|------------|---------------------------------|
| 10k        | 16.2ms                          |
| 100k       | 163.4ms                         |
| 1m         | 1513.9ms                        |



##### Equality Benchmark

***Includes:***
- Only `if (stringIds[i] == stringIds[i - 1])`

| Call Count + 1 | Result (Average of 10 attempts) |
|----------------|---------------------------------|
| 10k            | <1ms                            |
| 100k           | 3ms                             |
| 1m             | 30.3ms                          |

***For reference, it takes 2ms avg to compare 1 million `ulong` on my machine***
***For reference, it takes 21ms avg to compare 1 million `string` on my machine***
