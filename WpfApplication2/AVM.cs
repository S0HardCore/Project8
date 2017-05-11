using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace WpfApplication2
{
    public class AVM : INotifyPropertyChanged
    {
        #region JSON

        static string GET(string Param, string url = "http://solarstudio.org/json.php")
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url + "?" + Param);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            string result;
            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                result = stream.ReadToEnd();
            return result;
        }

        static void DELETE(string Param, string Data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://solarstudio.org/json.php" + "?" + Param);
            req.Method = "DELETE";
            byte[] sentData = Encoding.UTF8.GetBytes(Data);
            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(sentData, 0, sentData.Length);
                dataStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //if (resp.StatusCode == HttpStatusCode.NoContent || resp.StatusCode == HttpStatusCode.OK)
            //    Console.Write(Param + "was deleted.\n");
            //else
            //    Console.Write("Unsuccessfully.\n");
        }

        static string POST(string Param)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://solarstudio.org/json.php" + "?" + Param);
            req.Method = "POST";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            string result;
            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                result = stream.ReadToEnd();
            return result;
        }

        static void PUT(string Param, string Data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://solarstudio.org/json.php" + "?" + Param);
            req.Method = "PUT";
            byte[] sentData = Encoding.UTF8.GetBytes(Data);
            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(sentData, 0, sentData.Length);
                dataStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //if (resp.StatusCode == HttpStatusCode.Created || resp.StatusCode == HttpStatusCode.OK)
            //    Console.Write(Param + "was putted.\n");
            //else
            //    Console.Write("Unsuccessfully.\n");
        }
        #endregion

        public List<dynamic> Products { get; set; }
        public ObservableCollection<dynamic> Fields { get; set; }
        DefaultDialogService dds;
        DataGrid grid;

        public Dictionary<string, string> propsNames = new Dictionary<string, string>()
            {
                { "id", "Идентификатор" },
                { "label", "Название" },
                { "amount", "Количество" }
            };

        RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            if (dds.SaveFileDialog())
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (var item in Products)
                                {
                                    sb.Append(item.ToString());

                                    if (Products.Count > 1 && Products.IndexOf(item) != Products.Count - 1)
                                        sb.Append("," + Environment.NewLine);
                                }
                                if (Products.Count > 1)
                                {
                                    sb.Insert(0, "[" + Environment.NewLine);
                                    sb.Append(Environment.NewLine + "]");
                                }
                                using (StreamWriter sw = new StreamWriter(dds.FilePath, false, Encoding.Default))
                                    sw.Write(sb);
                                dds.ShowMessage("File is saved!");
                            }
                        }
                        catch (Exception) { }
                    }));
            }
        }

        public AVM(DataGrid grid, DefaultDialogService dds)
        {
            this.dds = dds;
            this.grid = grid;
            grid.SelectedIndex = 0;
            grid.SelectedCellsChanged += gridChangingSelection;
            string json = GET("");

            Fields = new ObservableCollection<dynamic>();
            List<dynamic> source = new List<dynamic>();

            DateTime start = DateTime.Now;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(json);
                for (int a = 0; a < 1000; ++a)
                    foreach (var instance in data)
                        source.Add(a == 0 ? instance : JsonConvert.DeserializeObject(JsonConvert.SerializeObject(instance)));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { }
            Products = source;
            Random r = new Random();

            for (int b = 0; b < Products.Count; ++b)
                foreach (JProperty jp in Products[b])
                { 
                    if (jp.Name == "id")
                        jp.Value = b + 1;
                    if (jp.Name == "amount")
                        jp.Value = r.Next(999);
                    if (jp.Name == "label")
                    {
                        StringBuilder sb = new StringBuilder(jp.Value.ToString());
                        for (int a = 0; a < sb.Length; ++a)
                        {
                            if (sb[a] >= 'A' && 'Z' >= sb[a])
                                sb[a] = (char)('A' + r.Next(26));
                            else
                            if (sb[a] >= 'a' && 'z' >= sb[a])
                                sb[a] = (char)('a' + r.Next(26));
                            else
                            if (sb[a] >= '0' && '9' >= sb[a])
                                sb[a] = (char)('0' + r.Next(10));
                        }
                        jp.Value = sb.ToString();
                    }
                }
            MakeFields(0);
            TimeSpan diff = new TimeSpan(DateTime.Now.Ticks - start.Ticks);
            string diffstr = Products.Count.ToString() + " записей за " + diff.Seconds.ToString() + "." + diff.Milliseconds.ToString() + " сек.";
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => { dds.ShowMessage(diffstr); }));
        }

        void MakeFields(int line = -1)
        {
            try
            {
                if (line == -1)
                    line = grid.SelectedIndex;
                Fields.Clear();

                foreach (JProperty jp in Products[line])
                {
                    TextBlock tbl = new TextBlock();
                    tbl.Margin = new System.Windows.Thickness(6, 4, 0, 2);
                    TextBox tb = new TextBox();
                    tbl.Text = propsNames.ContainsKey(jp.Name) ? propsNames[jp.Name] : jp.Name;
                    if (jp.Value.Count() > 1)
                        foreach (var ch in jp.First.Children())
                            tb.Text += ch.ToString() + "\n";
                    else
                        tb.Text = jp.Value.ToString();
                    tb.Name = jp.Name;
                    Fields.Add(tbl);
                    Fields.Add(tb);
                    tb.TextChanged += fieldTextChanged;
                }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { }
        }

        void gridChangingSelection(object sender, EventArgs e)
        {
            MakeFields();
        }

        void fieldTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            foreach (JProperty jp in Products[grid.SelectedIndex])
                if (jp.Name == tb.Name)
                    jp.Value = tb.Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}