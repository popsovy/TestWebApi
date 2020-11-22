using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestWebApiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var threads = new List<Thread>();
            for (var i = 0; i < 100; i++)
            {
                var thread = new Thread(() =>
                {
                    var time = DateTime.Now;
                    var line = $"Starting thread {i} at {time}. ";
                    var result = client.GetStringAsync("http://localhost:2614/api/service1").Result;
                    line += $"Done in {DateTime.Now.Subtract(time).TotalMilliseconds} ms";
                    Console.WriteLine(line);
                });
                thread.Start();
                threads.Add(thread);
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
