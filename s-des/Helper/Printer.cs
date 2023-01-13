namespace s_des.Helper;

public class Printer
{
    public void DebugPrint(string text,bool debug = true)
    {
        if(!debug) return;
        Console.WriteLine($"{text}\n");
    }
}