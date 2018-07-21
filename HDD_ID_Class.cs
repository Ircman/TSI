using System.Management;
using System.Windows.Forms;

namespace Servis_last_VERSO
{
    internal class HDD_ID_Class
    {
        public void HDD_ID_GET(TextBox text)
        {
            var hdd = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            hdd.Get();
            var id = hdd["VolumeSerialNumber"].ToString();
            text.Text = id;
        }

        public void HDD_ID_GET(string text)
        {
            var hdd = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            hdd.Get();
            var id = hdd["VolumeSerialNumber"].ToString();
            text = id;
        }

        public void HDD_ID_GET(Label text)
        {
            var hdd = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            hdd.Get();
            var id = hdd["VolumeSerialNumber"].ToString();
            text.Text = id;
        }

        public string HDD_ID_GET()
        {
            var hdd = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            hdd.Get();
            var id = hdd["VolumeSerialNumber"].ToString();
            return id;
        }
    }
}