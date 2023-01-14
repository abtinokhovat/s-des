namespace s_des.Entity;
public class Transform
{
    public string IP { get; set; }
    public FK FK_1 { get; set; }
    public string SW { get; set; }
    public FK FK_2 { get; set; }
    public string Combined { get; set; }
    public string IP_1 { get; set; }
}

public class FK
{
    public string EP { get; set; }
    public string XOR_1 { get; set; }
    public string Sbox { get; set; }
    public string P4 { get; set; }
    public string XOR_2 { get; set; }
}

public class KeyGeneration
{
    public string P10 { get; set; }
    public string LS1_L { get; set; }
    public string LS1_R { get; set; }
    public string P8_1 { get; set; }
    public string LS2_L { get; set; }
    public string LS2_R { get; set; }
    public string P8_2 { get; set; }
}

public class Root
{
    public KeyGeneration KeyGeneration { get; set; }
    public Transform Encryption { get; set; }
    public Transform Decryption { get; set; }
}

