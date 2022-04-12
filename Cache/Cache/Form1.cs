using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Cache
{
    public partial class Form1 : Form
    {
        char[] charsToTrim = { ' ', '\n', '\r' };
        private StringBuilder availableFiles = new StringBuilder();
        IDictionary<string, string> cacheDic = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((p) => initCache());
        }

        public void initCache()
        {
            try
            {
                IPAddress ipAddr = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];

                // Socket from cache to client
                TcpListener cache = new TcpListener(ipAddr, 8899);
                cache.Start();
                System.Diagnostics.Debug.WriteLine("cache is listening...");
                
                // 连接client
                while (true)
                {
                    try
                    {
                        // 从client接收请求
                        TcpClient cacheClientSocket = cache.AcceptTcpClient();
                        NetworkStream clientNs = cacheClientSocket.GetStream();
                        StreamWriter clientSw = new StreamWriter(clientNs);
                        StreamReader clientSr = new StreamReader(clientNs);
                        string msgFromClient;
                        string filename = "";
                        string serverRes = "";

                        msgFromClient = clientSr.ReadLine();
                        System.Diagnostics.Debug.WriteLine("msgFromClient: " + msgFromClient);


                        // 把msgFromClient发给server并获取返回的string
                        if (msgFromClient.Contains("@request=download:"))
                        {
                            filename = msgFromClient.Split("@request=download:")[1].Trim(charsToTrim);
                            string timeStamp = DateTime.Now.ToString();
                            if (!cacheDic.ContainsKey(filename))
                            {
                                serverRes = ConnectToServer(msgFromClient);
                                System.Diagnostics.Debug.WriteLine("File retrieved from server.");
                                cacheLog.AppendText(string.Format("User request: {0} at {1}, retrieved from server.{2}", filename, timeStamp, Environment.NewLine));
                                cachedDataFragList.Items.Add(filename);
                            }
                            else
                            {
                                serverRes = cacheDic[filename];
                                System.Diagnostics.Debug.WriteLine("File retrieved from dictionary.");
                                cacheLog.AppendText(string.Format("User request: {0} at {1}, cached.{2}", filename, timeStamp, Environment.NewLine));
                            };
                            System.Diagnostics.Debug.WriteLine("Server's response's length: " + serverRes.Length);
                            cacheDic[filename] = serverRes;
                            var items = from kvp in cacheDic
                                        select kvp.Key + "=" + kvp.Value.Length;
                            System.Diagnostics.Debug.WriteLine("{" + string.Join(",", items) + "}");
                        } else
                        {
                            serverRes = ConnectToServer(msgFromClient);
                        }
                        
                        

                        // 把server返回的string发给client
                        clientSw.WriteLine(serverRes);
                        clientSw.Flush();
                        clientSr.Close();
                        clientSw.Close();
                        cacheClientSocket.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("接收client请求报错：" + ex);
                    }

                }
                


            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private string ConnectToServer(string msg)
        {
            // Socket from cache to server
            IPAddress ipAddr = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            TcpClient cacheServerSocket = new TcpClient(ipAddr.ToString(), 7788);
            System.Diagnostics.Debug.WriteLine("CacheServer connected to server.");
            NetworkStream serverNs = cacheServerSocket.GetStream();
            StreamWriter serverSw = new StreamWriter(serverNs);
            StreamReader serverSr = new StreamReader(serverNs);
            string res = "";
            try
            {
                if (msg == "@request=filenames")
                {
                    serverSw.WriteLine(msg);
                    serverSw.Flush();
                }
                else if (msg.Contains("@request=download:"))
                {
                    serverSw.WriteLine(msg);
                    serverSw.Flush();
                }
                res = serverSr.ReadToEnd();
                serverSr.Close();
                serverSw.Close();
                cacheServerSocket.Close();
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ConnectToServer报错：" + ex.Message);
            }
            return res;
        }

        private void cachedDataFragList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            cacheDic.Clear();
            cachedDataFragList.Items.Clear();
            cacheLog.AppendText(String.Format("You cleared the cache.{0}", Environment.NewLine));
        }
    }
}