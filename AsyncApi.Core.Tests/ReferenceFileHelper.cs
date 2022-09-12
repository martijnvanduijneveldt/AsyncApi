using System.IO;
using System.Reflection;

namespace AsyncApi.Core.Tests
{
    public static class ReferenceFileHelper
    {
        public static string ReadFile(string path)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var textPath = Path.Combine(assemblyDirectory, "../../../ReferenceFiles", path);
            return File.ReadAllText(textPath);
        }
        
        public static void WriteFile(string path, string content)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var textPath = Path.Combine(assemblyDirectory, "../../../ReferenceFiles", path);
            File.WriteAllText(textPath, content);
        }
    }
}