namespace DockerDeployment.Connection
{
    public struct ErrorClass
    {
        public int num;
        public string message;
        public ErrorClass(int num, string message)
        {
            this.num = num;
            this.message = message;
        }

    }
}
