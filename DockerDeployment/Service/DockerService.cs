
using System.IO.Compression;
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
                
                    startInfo.WorkingDirectory = $"{workingDirectory}\\setup";
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    Console.WriteLine(startInfo.WorkingDirectory);
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C for %i in (*.gz) do docker load -i %i";
                    //startInfo.Arguments = "/C type nul > filename.txt";
                    process.StartInfo = startInfo;
                    Console.WriteLine("process starting");
                    process.Start();
                    process.WaitForExit();
                    Console.WriteLine("images created");


         
             
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
              
            }

           
        }
    }
}
