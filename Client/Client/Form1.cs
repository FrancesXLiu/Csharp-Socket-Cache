using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class Client : Form
    {
        char[] charsToTrim = { ' ', '\n', '\r' };
        // Socket clientCacheSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        bool isTxt = false;
        MemoryStream currImg = new MemoryStream();
        string currTxt = "";
        
        public Client()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            initClient();
        }

        private void initClient()
        {
            IPAddress ipAddr = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            TcpClient clientCacheSocket = new TcpClient(ipAddr.ToString(), 8899);
            NetworkStream ns = clientCacheSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            System.Diagnostics.Debug.WriteLine("clientCacheSocket is connected...");

            // 从cache接收文件名
            try
            {
                // 发送文件名请求
                sw.WriteLine("@request=filenames");
                System.Diagnostics.Debug.WriteLine("向cache请求文件名");
                sw.Flush();
                string cacheRes = "";
                string filenames = "";

                while (true)
                {
                    string res = sr.ReadToEnd();
                    if (res.Contains("@response=filenames"))
                    {
                        filenames += res.Trim(charsToTrim) + "\n";
                        if (res.IndexOf("EOF") > -1) break;
                    }
                }
                System.Diagnostics.Debug.WriteLine("filenames: " + filenames);
                string[] fileNames = filenames.Split("\n");
                foreach (string fileName in fileNames)
                {
                    if (!fileName.Contains("EOF") & !(fileName == "") && !(fileName == " ") && !(fileName == "\n") && !(fileName.Contains("@response=filenames")))
                    {
                        System.Diagnostics.Debug.WriteLine("filename is: " + fileName);
                        availableFiles.Items.Add(fileName.Trim(charsToTrim));
                    }
                }
                sr.Close();
                sw.Close();
                clientCacheSocket.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AppendFileNames Read报错：" + ex.ToString());
            }
            clientCacheSocket.Close();

        }

        private void availableFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (availableFiles.SelectedIndex != -1)
            {
                string selectedFileName = availableFiles.SelectedItem.ToString();
                System.Diagnostics.Debug.WriteLine("Selected filename: " + selectedFileName);

                IPAddress ipAddr = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                TcpClient clientCacheSocket = new TcpClient(ipAddr.ToString(), 8899);
                NetworkStream ns = clientCacheSocket.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                StreamReader sr = new StreamReader(ns);
                sw.WriteLine("@request=download:" + selectedFileName.Trim(charsToTrim));
                sw.Flush();
                string cacheRes = sr.ReadToEnd();
                sr.Close();
                sw.Close();
                clientCacheSocket.Close();

                if (cacheRes.Contains("ext=txt:::"))
                {
                    isTxt = true;
                    textDisplay.Clear();
                    string txtContent = cacheRes.Split("ext=txt:::")[1];
                    System.Diagnostics.Debug.WriteLine("txtContent: " + txtContent);
                    textDisplay.AppendText(txtContent);
                    currTxt = txtContent;
                } else
                {
                    isTxt=false;
                    System.Diagnostics.Debug.WriteLine("cacheRes's length: " + cacheRes.Length);
                    // System.Diagnostics.Debug.WriteLine(cacheRes.Substring(75800, cacheRes.Length - 1));

                    System.Diagnostics.Debug.WriteLine(String.Format("Sending download request of {0} to cache...", selectedFileName));

                    byte[] imgBytes = Convert.FromBase64String(cacheRes);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(imgBytes, 0, Convert.ToInt32(imgBytes.Length));
                    Bitmap bm = new Bitmap(ms, false);
                    currImg = ms;
                    ms.Dispose();
                    pictureBox1.Image = bm;
                    var imageSize = pictureBox1.Image.Size;
                    var fitSize = pictureBox1.ClientSize;
                    pictureBox1.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ?
                        PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
                }
                
            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (isTxt == true)
            {
                if (currTxt != "")
                {
                    string fileName = "txt_" + DateTime.Now.ToString("HHmmss");
                    string path = string.Format("./download/{0}.txt", fileName);
                    // FileStream fs = new FileStream(@path, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(@path, false);
                    sw.Write(currTxt);
                    sw.Flush();
                    // fs.Close();
                    currTxt = "";
                    MessageBox.Show("TXT file saved.");
                }
            } else
            {
                if (currImg != null)
                {
                    byte[] buffer = currImg.ToArray();
                    string fileName = "txt_" + DateTime.Now.ToString("HHmmss");
                    string path = string.Format("./download/{0}.bmp", fileName);
                    FileStream fs = new FileStream(@path, FileMode.OpenOrCreate);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                    MessageBox.Show("Image file saved.");
                }
            }
        }
    }
}