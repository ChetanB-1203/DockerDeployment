
using System.IO.Compression;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using DockerDeployment.Connection;
using System.Net;

namespace DockerDeployment.Service
{
    public class DockerService
    {
       
        public static  void DockerImageCreation(string workingDirectory)
        {   
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                
                   // startInfo.WorkingDirectory = $"{workingDirectory}\\setup";
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                     startInfo.FileName = "cmd.exe";
                     startInfo.RedirectStandardInput = true;
                     startInfo.UseShellExecute = false;
                   // startInfo.Arguments = "/C for %i in (*.gz) do docker load -i %i";
                   
                    process.StartInfo = startInfo;
                    Console.WriteLine("process starting");
                    process.Start();
                   
                   

                     using(StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine($"pushd {workingDirectory}\\setup");
                       // sw.WriteLine("for %i in (*.gz) do docker load -i %i");
                        
                        sw.WriteLine($"echo D|xcopy {workingDirectory}\\docker_files  C:\\ProgramData\\GearEngine\\docker_files");
                        sw.WriteLine("popd");
                        sw.WriteLine($"docker-compose -f C:\\ProgramData\\GearEngine\\docker_files\\docker-compose.common.yml -f C:\\ProgramData\\GearEngine\\docker_files\\docker-compose.yml --env-file C:\\ProgramData\\GearEngine\\docker_files\\.env up -d --remove-orphans");
                        
                    }
                }
                     process.WaitForExit();
                Console.WriteLine("container created");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

        public static void ShareFiles(string workingDirrectory, string targetDirectory= @"\\kladmin@portainer1\home\machine")
        {
           
            string res =NetworkShare.ConnectToShare(@"\\kladmin@portainer1.eastus.cloudapp.azure.com\home","Welcome@2023", "kladmin");
            Console.WriteLine(res);
            Console.WriteLine("connection made");
            if (!Directory.Exists(targetDirectory))
            {  
                Directory.CreateDirectory(targetDirectory);  

                Console.WriteLine("directory created");
            }

            File.Copy(workingDirrectory, targetDirectory);


            Console.WriteLine("file copied");

        }


        public static void ShareFiles2(string workingDirrectory, string targetDirectory = @"\\kladmin@portainer1\machine")
        {

            using (UserImpersonation user = new UserImpersonation("kladmin", @"\\kladmin@portainer1.eastus.cloudapp.azure.com", "Welcome@2023"))
            {
                if (user.ImpersonateValidUser())
                {
                    Console.WriteLine("user connected");
                }
                else 
                {
                    Console.WriteLine("connection failed");
                }
            }

                if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);

                Console.WriteLine("directory created");
            }

            File.Copy(workingDirrectory, targetDirectory);


            Console.WriteLine("file copied");

        }

        public static void ShareFiles3(string workingDirrectory, string targetDirectory = @"\\kladmin@portainer1\machine")
        {


            NetworkCredential theNetworkCredential = new NetworkCredential( @"\\kladmin@portainer1.eastus.cloudapp.azure.com", "Welcome@2023");
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@"\\kladmin@portainer1.eastus.cloudapp.azure.com"), "Basic", theNetworkCredential);
            string[] theFolders = Directory.GetDirectories(@"\\kladmin@portainer1\kladmin");
        }
    }
  
    }

