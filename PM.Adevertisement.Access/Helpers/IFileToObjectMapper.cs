using System.Collections.Generic;

namespace PM.Adevertisement.Access.Helpers
{
    public interface IFileToObjectMapper<T> where T : IDesrializeFromText<T>, new()
    {
        IList<T> Read(string fileFullName, bool includesHeader);
    }
}