using s_des.Class;

namespace s_des.Entity;

public class Keys
{
    public Keys(BitBuffer key1, BitBuffer key2)
    {
        Key1 = key1;
        Key2 = key2;
    }

    public BitBuffer Key1 { get; set; }
    public BitBuffer Key2 { get; set; }
}