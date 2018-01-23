using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PM.Adevertisement.Access.Helpers
{
    internal class FileToObjectMapper<T> : IFileToObjectMapper<T> where T : IDesrializeFromText<T>, new()
    {
        private readonly char _delimiter;

        public FileToObjectMapper(char delimiter)
        {
            _delimiter = delimiter;
        }

        public IList<T> Read(string fileFullName, bool includesHeader)
        {
            var startline = includesHeader ? 1 : 0;
            return File.ReadAllLines(fileFullName)
                .Skip(startline)
                .Select(line => (new T()).DeserializeFromText(line, _delimiter))
                .ToList();
        }
    }
}