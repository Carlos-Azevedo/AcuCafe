using System;

namespace AcuCafe
{
    /// <summary>
    /// This class does IO to disk and console and so must be manually tested
    /// </summary>
    public class Outputter : IOutputter
    {
        public void LogError(Exception ex)
        {
            Console.WriteLine("We are unable to prepare your drink.");
            System.IO.File.WriteAllText($"c:\\Error - {DateTime.Now}.txt", ex.ToString());
        }

        public void WriteToConsole(string desc)
        {
            Console.WriteLine(desc);
        }
    }
}
