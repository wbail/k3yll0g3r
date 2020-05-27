using System.IO;
using System.Net;
using System.Configuration;

namespace SecProj.Desktop
{
    class ServerClientService
    {
        public static async void UploadFiles(string zipFile)
        {
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"]);

                string fileName = Path.GetFileName(zipFile);

                string uri = ConfigurationManager.AppSettings["protocol"] +
                    ConfigurationManager.AppSettings["server"] +
                    ConfigurationManager.AppSettings["port"] +
                    "/" + fileName;

                client.UploadFile(uri, WebRequestMethods.Ftp.UploadFile, zipFile);
            }
        }
    }
}
