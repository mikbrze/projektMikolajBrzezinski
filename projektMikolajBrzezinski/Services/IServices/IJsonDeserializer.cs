namespace projektMikolajBrzezinski.IServices
{
    public interface IJsonDeserializer
    {
        T Deserialize<T>(string json);
    }
}