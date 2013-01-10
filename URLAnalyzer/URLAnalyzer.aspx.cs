using System;
using System.Collections.Generic;
using System.Net;

namespace URLAnalyzer
{
    public partial class URLAnalyzer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnalyzer_Click(object sender, EventArgs e)
        {
            var urlsTextBox = txtUrl.Text;
            var urlList = GenerateListOfUrl(urlsTextBox);

            gvUrlTable.DataSource = urlList;
            gvUrlTable.DataBind();
        }

        private List<URL> GenerateListOfUrl(string urlsTextBox)
        {
            var UrlFinalList = new List<URL>();
            string[] UrlWithId = urlsTextBox.Split('\n');
            foreach (var url in UrlWithId)
            {
                UrlFinalList.Add(new URL
                                     {
                                         Id = url.Split(',')[0],
                                         Url = url.Split(',')[1]
                                     });
            }

            DeleteAdditionalChars(UrlFinalList);

            UrlFinalList = GetAllStatusCodes(UrlFinalList);

            return UrlFinalList;
        }

        private static void DeleteAdditionalChars(List<URL> urlFinalList)
        {
            foreach (var s in urlFinalList)
            {
                s.Url = s.Url.Split('\r')[0];
                s.Url = s.Url.Replace('\"',' ');
                s.Url = s.Url.Trim();
            }
        }

        private List<URL> GetAllStatusCodes(List<URL> urlFinalList)
        {
            foreach (var url in urlFinalList)
            {
                if (url.Url.Contains("http://") || url.Url.Contains("https://"))
                {
                    url.StatusDescription = GetHttpStatusDescription(url.Url).ToString();
                    url.StatusCode = Convert.ToInt32(GetHttpStatusDescription(url.Url));
                }
                else
                {
                    url.Url = "http://" + url.Url;
                    url.StatusDescription = GetHttpStatusDescription(url.Url).ToString();
                    url.StatusCode = Convert.ToInt32(GetHttpStatusDescription(url.Url));
                }
            }
            return urlFinalList;
        }

        private static HttpStatusCode GetHttpStatusDescription(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode;
                }
            }
            catch (WebException)
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}