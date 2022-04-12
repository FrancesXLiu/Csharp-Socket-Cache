using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Drawing;

class Server
{
    char[] charsToTrim = { ' ', '\n', '\r' };
    public Server()
    {
        String folderPath = @"./Images";
        List<string> fileList = new List<string>();
        StringBuilder fileNameString = new StringBuilder();

        DirectoryInfo folder = new DirectoryInfo(folderPath);
        foreach (FileInfo file in folder.GetFiles())
        {
            fileList.Add(file.Name);
            fileNameString.AppendLine(file.Name.Trim(charsToTrim));
        }
        string availableFiles = fileNameString.ToString().Trim(charsToTrim);
        System.Diagnostics.Debug.WriteLine(availableFiles);


        try
        {
            IPAddress ipAddr = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            TcpListener server = new TcpListener(ipAddr, 7788);
            server.Start(); // TcpListener start listening
            Console.WriteLine("Server is listening...");
            System.Diagnostics.Debug.WriteLine("Server is listening...");

            while (true)
            {
                TcpClient serverCacheSocket = server.AcceptTcpClient();
                System.Diagnostics.Debug.WriteLine("Connected to cache: " + serverCacheSocket.Client.RemoteEndPoint.ToString());
                Console.WriteLine(String.Format("Cache {0} is connected to server.", serverCacheSocket.Client.RemoteEndPoint.ToString()));
                NetworkStream ns = serverCacheSocket.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                StreamReader sr = new StreamReader(ns);

                // 往cache发送所有文件名
                string request = sr.ReadLine();
                System.Diagnostics.Debug.WriteLine("request: " + request);
                // cache请求所有文件名
                if(request == "@request=filenames") 
                {
                    sw.WriteLine("@response=filenames");
                    sw.WriteLine(availableFiles);
                    sw.WriteLine("EOF");
                    sw.Flush();
                    sw.Close();
                    System.Diagnostics.Debug.WriteLine(String.Format("Trying to send file names {0} to cache...", availableFiles));
                    serverCacheSocket.Close();
                }
                // cache请求文件下载
                else if (request.Contains("@request=download:"))
                {
                    string[] msgString = request.Split("@request=download:");
                    string filename = msgString[1];
                    System.Diagnostics.Debug.WriteLine("Client wants to download this: " + filename);

                    string path = string.Format("./Images/{0}", filename);
                    string filePath = @path;
                    System.Diagnostics.Debug.WriteLine("filepath is: " + filePath);
                    sw.Flush();
                    
                    string ext = Path.GetExtension(filePath);
                    System.Diagnostics.Debug.WriteLine("File extension: " + ext);

                    if (ext == ".txt")
                    {
                        string txtContent = File.ReadAllText(path);
                        System.Diagnostics.Debug.WriteLine("txtContent: " + txtContent);
                        sw.WriteLine("ext=txt:::"+txtContent);
                        sw.Flush();
                        sw.Close();
                    } else
                    {
                        // get byte[] of image
                        Bitmap img = new Bitmap(filePath);
                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        byte[] bmpBytes = ms.ToArray();
                        ms.Close();
                        string imgBase64 = Convert.ToBase64String(bmpBytes);
                        System.Diagnostics.Debug.WriteLine("imgBase64's length: " + imgBase64.Length);
                        sw.WriteLine(imgBase64);
                        // sw.WriteLine("EOF");
                        sw.Flush();
                        sw.Close();
                    }
                    

                    serverCacheSocket.Close();
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    static void Main(String[] args)
    {
        new Server();
    }
}