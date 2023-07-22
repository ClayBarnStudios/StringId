// See https://aka.ms/new-console-template for more information

using System.Numerics;

var _a = "@planet-type/earthlike/tile_a";
var _b = "@planet-type/earthlike/tile_bb";
var _c = "@planet-type/earthlike/tile_ccc";
var _d = "@planet-type/earthlike/tile_dddd";
var _e = "@ship/fighter-252";

var a = StringId.NewStringId(_a);
var b = StringId.NewStringId(_b);
var c = StringId.NewStringId(_c);
var d = StringId.NewStringId(_d);
var e = StringId.NewStringId(_e);

Console.WriteLine($"{a} -> {_a} with Length: {_a.Length}");
Console.WriteLine($"{b} -> {_b} with Length: {_b.Length}"); 
Console.WriteLine($"{c} -> {_c} with Length: {_c.Length}");
Console.WriteLine($"{d} -> {_d} with Length: {_d.Length}");
Console.WriteLine($"{e} -> {_e} with Length: {_e.Length}");
Console.Read();
