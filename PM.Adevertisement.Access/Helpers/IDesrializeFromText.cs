namespace PM.Adevertisement.Access.Helpers
{
    public interface IDesrializeFromText<out T>
    {
        T DeserializeFromText(string line, char delimeter);
    }
}