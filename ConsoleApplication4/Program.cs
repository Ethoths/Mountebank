using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using ConsoleApplication4.Config;
using Contracts;
using MbDotNet;
using MbDotNet.Models.Imposters;
using static System.Console;

namespace ConsoleApplication4
{
    public partial class Program
    {
        private static bool _exitSystem;

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        private delegate bool EventHandler(CtrlType sig);
        private static EventHandler _handler;
        private MountebankClient _client;
        
        private bool Handler(CtrlType sig)
        {
            CursorLeft = 0;
            WriteLine("Shutting down all endpoints...");
            _client.DeleteAllImposters();
            Thread.Sleep(5000);
            _exitSystem = true;
            Environment.Exit(-1);

            return true;
        }

        public static void Main()
        {
            new Program().Start();
        }

        private void Start()
        {
            _client = new MountebankClient();
            _handler += Handler;
            SetConsoleCtrlHandler(_handler, true);
            StartLateBoundServices();
            WriteLine();
            Write("Ready for requests...");
            ReadKey(false);

            while (!_exitSystem)
            {
                Thread.Sleep(500);
            }
        }

        private void StartLateBoundServices()
        {
            var serviceConfigSection = ConfigurationManager.GetSection("ServicesSection") as ServiceConfigurationSection;
            var imposterList = new List<Imposter>();
            var dlls = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Imposters"), "*.dll");
            var foregroundColour = ForegroundColor;
            WriteLine("--------------------------");
            WriteLine("| Service         | Port |");
            WriteLine("--------------------------");

            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFrom(dll);

                foreach (var executable in assembly.DefinedTypes)
                {
                    if (executable.ImplementedInterfaces.Contains(typeof(IDiscoverableImposter)))
                    {
                        var serviceConfig = serviceConfigSection?.GetServiceConfig(executable.Name);
                        var port = serviceConfig?.Port;
                        var serviceName = serviceConfig?.Description;
                        var serviceRecordRequests = serviceConfig?.ServiceRecordRequests;
                        var headers = serviceConfig?.Headers;

                        if (Activator.CreateInstance(executable, serviceName, port, serviceRecordRequests, _client, imposterList) is DiscoverableImposter imposter)
                        {
                            // Type type = Type.GetType("Namespace.MyClass, MyAssembly");
                            // Create a base class and cast it to the sub-type
                            imposter.SetUpStubbs();
                            WriteLine($"| {serviceName?.PadRight(15)} | {port?.ToString().PadRight(4)} |");
                        }
                        else
                        {
                            Write("| ");
                            ForegroundColor = ConsoleColor.Red;
                            Write("{executable.Name.PadRight(15)}");
                            ForegroundColor = foregroundColour;
                            Write(" | ");
                            ForegroundColor = ConsoleColor.Red;
                            Write("Port");
                            ForegroundColor = foregroundColour;
                            WriteLine(" |");
                        }
                    }
                }
            }

            WriteLine("--------------------------");
            try
            {
                _client.Submit(imposterList);
            }
            catch (Exception)
            {
                Write("Error starting imposters. Ensure the Mountebank server is running...");
            }
        }
    }
}