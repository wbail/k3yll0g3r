using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SecProj.Desktop
{
    class Screenshot
    {
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\secproj\\screenshots";

        public static void Take()
        {
            const int ENUM_CURRENT_SETTINGS = -1;

            DEVMODE devMode = default;
            devMode.dmSize = (short)Marshal.SizeOf(devMode);
            EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref devMode);

            Rectangle rect = new Rectangle(0, 0, devMode.dmPelsWidth, devMode.dmPelsHeight);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            if (FileService.CheckIfDirExists("screenshots"))
            {
                string filename = path + $"\\{DateTime.Now:yyyyMMddHHmmss}_screenshot.png";

                bmp.Save(filename, ImageFormat.Png);
            }
            else
            {
                FileService.CreateDir("screenshots");

                string filename = path + $"\\{DateTime.Now:yyyyMMddHHmmss}_screenshot.png";

                bmp.Save(filename, ImageFormat.Png);
            }
            
        }

        public static async Task TakeScreenshot()
        {
            while (true)
            {
                Task delay = Task.Delay(5000);
                await delay;
                Take();
            }
        }

        [DllImport("user32.dll")]
        static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [StructLayout(LayoutKind.Sequential)]
        struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }
    }
}
