﻿namespace Scrabble
{
    using System.IO;
    using System.Diagnostics;


    internal class WordChecker
    {
        private static string run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\Mrah\AppData\Local\Programs\Python\Python38-32\python.exe";
            start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args);
            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    return result;
                }
            }
        }

        public static bool checkWord(string word)
        {
            string result = run_cmd(@"C:\Users\Mrah\PycharmProjects\WordChecker\CheckWord.py", "\"" + word + "\"");

            return string.Equals(result.ToLower().Trim(), "true");
        }
    }
}