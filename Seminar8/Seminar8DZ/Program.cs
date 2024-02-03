using System.Diagnostics.CodeAnalysis;

namespace Seminar8DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];

            string extention = args[1];

            string text = args[2];

            FindFilesWithSpecificContent(path, extention, text);


            void FindFilesWithSpecificContent(string? path, string? extention, string? text)
            {
                Queue<string>? directories = new Queue<string>();

                directories.Enqueue(path);

                bool found = false;
                while (directories?.Count > 0)
                {
                    foreach (string? file in Directory.GetFiles(path))
                        if (Path.GetExtension(file) == "." +  extention)
                        {
                            using (StreamReader sr = new StreamReader(file))
                            {
                                string fileContent = sr.ReadToEnd();
                                if (text != null && fileContent.Contains(text))
                                {
                                    Console.WriteLine("Нашёл!");
                                    Console.WriteLine(Path.GetFullPath(file));
                                    Console.WriteLine(fileContent);
                                    directories = null;
                                    found = true;
                                    break;
                                }
                            }
                        }

                    if (found)
                        continue;

                    foreach (string? dir in Directory.GetDirectories(path))
                        directories?.Enqueue(dir);

                    path = directories?.Dequeue();
                }
            }
        }
    }
}
