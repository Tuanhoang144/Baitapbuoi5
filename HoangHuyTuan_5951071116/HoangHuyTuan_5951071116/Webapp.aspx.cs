using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HoangHuyTuan_5951071116
{
    public partial class Webapp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://graph.facebook.com/utc2hcmc/posts?access_token=EAAAAZAw4FxQIBAMsPUssv8fy6y4TgFNZAAZB7wP6SQ7PetxEBaHOIVzriGVZBlzJnBwcx3Ex0nYcYpzuhYzt683a3iNqlT7kZBh6EF0g1P6ew57hmBPYJzSsUZBkjlLwBRih3NX6NzCXiZAYajrd583zwvdJd87FuAHG5uZA21LvikSyeDQkDGxRszLj5faTo4IZD");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStr = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStr);
            string responseString = reader.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(responseString);
            var results = new List<JsonObject>();
            foreach (var item in json.data)
            {
                results.Add(new JsonObject
                {
                    Thoigian = item.created_time,
                    Noidung = item.message,
                });
            }
            string a = "";
            for (int i = 0; i < 3; i++)
            {
                a += "<p>Bài " + (i + 1) + ": </p>" + "";
                a += "<p>Ngày đăng: </p>" + results[i].Thoigian + "</br>";
                a += "<p>Nội dung: </p>" + results[i].Noidung + "</br>";
            }
            Label1.Text = a;
        }
    }
    }
