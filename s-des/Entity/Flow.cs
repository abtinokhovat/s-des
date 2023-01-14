namespace s_des.Entity;

public class Response<T>
{
    public Response(T exit, SuperDic results)
    {
        Exit = exit;
        Results = results;
    }

    public T Exit { get; set; }
    public SuperDic Results { get; set; }
}

public class SuperDic : List<KeyValuePair<string, string>>
{
    public SuperDic Add(string key, string value)
    {
        var element = new KeyValuePair<string, string>(key, value);
        Add(element);

        return this;
    }

    public SuperDic Concat(SuperDic dic)
    {
        foreach (var element in dic) Add(element.Key, element.Value);

        return this;
    }

    // to stringList List<KeyValuePair<string, string>>
    public List<KeyValuePair<string, string>> ToStringList()
    {
        return this.Select(element => new KeyValuePair<string, string>(element.Key, element.Value.ToString())).ToList();
    }
}