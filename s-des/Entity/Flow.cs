using Newtonsoft.Json;

namespace s_des.Entity;
public class Transform
{
    [JsonProperty("IP")]
    public string IP { get; set; }
    [JsonProperty("FK_1")]
    public FK FK_1 { get; set; }
    [JsonProperty("SW")] 
    public string SW { get; set; }
    [JsonProperty("FK_2")]
    public FK FK_2 { get; set; }
    [JsonProperty("Combined")]
    public string Combined { get; set; }
    [JsonProperty("IP_1")]
    public string IP_1 { get; set; }
}

public class FK
{
    [JsonProperty("EP")]
    public string EP { get; set; }
    [JsonProperty("XOR_1")]
    public string XOR_1 { get; set; }
    [JsonProperty("Sbox")]
    public string Sbox { get; set; }
    [JsonProperty("P4")]
    public string P4 { get; set; }
    [JsonProperty("XOR_2")]
    public string XOR_2 { get; set; }
}

public class KeyGeneration
{
    [JsonProperty("P10")]
    public string P10 { get; set; }
    [JsonProperty("LS1_L")]
    public string LS1_L { get; set; }
    [JsonProperty("LS1_R")]
    public string LS1_R { get; set; }
    [JsonProperty("P8_1")]
    public string P8_1 { get; set; }
    [JsonProperty("LS2_L")]
    public string LS2_L { get; set; }
    [JsonProperty("LS2_R")]
    public string LS2_R { get; set; }
    [JsonProperty("P8_2")]
    public string P8_2 { get; set; }
}

public class Root
{
    [JsonProperty("KeyGeneration")]
    public KeyGeneration KeyGeneration { get; set; }
    [JsonProperty("Encryption")]
    public Transform Encryption { get; set; }
    [JsonProperty("Decryption")]
    public Transform Decryption { get; set; }
}

