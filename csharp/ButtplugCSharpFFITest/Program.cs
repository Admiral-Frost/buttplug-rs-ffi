﻿using System;
using System.Threading.Tasks;
using ButtplugCSharpFFI;

namespace ButtplugCSharpFFITest
{
    class Program
    {
        private static async Task WaitForKey()
        {
            Console.WriteLine("Press any key to continue.");
            while (!Console.KeyAvailable)
            {
                await Task.Delay(10);
            }
            Console.ReadKey(true);
        }

        private static async Task RunExample()
        {
            Console.WriteLine("Hello World!");
            var client = new ButtplugCSharpFFI.ButtplugClient("Test Client");
            await client.ConnectLocal();
            await WaitForKey();
        }

        static void Main(string[] args)
        {
            RunExample().Wait();
        }
    }
}