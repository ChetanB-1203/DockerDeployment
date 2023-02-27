namespace DockerDeployment.Extension
{
    public static  class StreamExtension
    {
        public static async Task<byte[]> ReadFully(this Stream input)
        {
            await using var ms = new MemoryStream();
            await input.CopyToAsync(ms);
            return ms.ToArray();    
        }
    }
}
