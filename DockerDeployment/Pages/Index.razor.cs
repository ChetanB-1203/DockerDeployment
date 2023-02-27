using DockerDeployment.Model;
using DockerDeployment.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace DockerDeployment.Pages
{
    public partial class Index
    {

        private  string DefaultStatus { get; set; } = "Choose a zip file";

        private List<ZipEntry> _entries;

        private string? _fileName;
        private long maxAllowedSize= 1024*100000;
        private bool isLoading;

        [Inject] ZipService ZipService { get; set; }    

        private async Task  OnInputFileChange(InputFileChangeEventArgs eventArgs)
        {

            await using var stream = eventArgs.File.OpenReadStream(maxAllowedSize);
            _entries = await ZipService.ExtractFiles(stream);
            _fileName = eventArgs.File.Name;
            DefaultStatus = "File uploaded";
        }

       /* private async void OnSubmit()
        {
        }*/

    }


}
