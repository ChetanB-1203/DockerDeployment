
using DockerDeployment.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace DockerDeployment.Pages
{
    public partial class Index
    {

        [Inject] DockerService DockerService { get; set; }  

        string  WorkingDirectory { get; set; }


        public  async void OnClickButton()
        {
             DockerService.ShareFiles3(WorkingDirectory);
        }
 
        
     

    }


}
