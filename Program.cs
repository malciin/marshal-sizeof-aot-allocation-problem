using System.Runtime.InteropServices;

bool memIncreased = false;

for (var i = 0; i < 100000; i++)
{
    var preMem = GC.GetTotalMemory(false);
    var size = Marshal.SizeOf<TestStruct>();
    var postMem = GC.GetTotalMemory(false);

    if (i < 1000) continue;     // warmup

    if (postMem > preMem)
    {
        Console.WriteLine($"Detected increase {preMem / 1024.0:0.0}KB -> {postMem / 1024.0:0.0}KB");
        memIncreased = true;
    }
}

if (!memIncreased) Console.WriteLine("Memory never increased! :)");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

public struct TestStruct
{
    long x;
    long y;
    long z;
}
