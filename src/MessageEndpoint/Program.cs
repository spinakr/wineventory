﻿using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MessageEndpoint;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using Wineventory.MessageEndpoint.Configuration;
using Wineventory.MessageEndpoint.Vinmonopolet;

namespace Wineventory.MessageEndpoint
{
    class Program
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(0);

        static async Task Main(string[] args)
        {
            Console.CancelKeyPress += CancelKeyPress;
            AppDomain.CurrentDomain.ProcessExit += ProcessExit;

            var host = new Host();

            Console.Title = host.EndpointName;

            await host.Start();
            await Console.Out.WriteLineAsync("Press Ctrl+C to exit...");

            // wait until notified that the process should exit
            await semaphore.WaitAsync();

            await host.Stop();
        }

        static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            semaphore.Release();
        }

        static void ProcessExit(object sender, EventArgs e)
        {
            semaphore.Release();
        }

        static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            semaphore.Release();

            return true;
        }

        delegate bool HandlerRoutine(CtrlTypes ctrlType);

        enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
    }
}
