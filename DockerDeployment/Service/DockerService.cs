
using System.IO.Compression;
using System.Net.Sockets;
using System.Text;

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
    }
}
