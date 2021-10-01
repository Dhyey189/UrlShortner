using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using UrlShortener.Models;
namespace UrlShortener
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string host = HttpContext.Current.Request.Url.Host;
            Label2.Text = path.Substring(path.Length - 6);
            if (Label2.Text != "x.aspx" && Label2.Text != ".aspx/")
            {

                Response.Redirect("https://www.google.com");
            }
            else Label2.Text = "Hello";
        }
          
        protected void Button_Click(object sender, EventArgs e)
        {
            string randomstring = RandomString(6);
            Label1.Text = randomstring;
            urlshortnercontext db = new urlshortnercontext();
            urldata data = new urldata();
            data.originalurl = Texturl.Text;
            data.shorturl = randomstring;
            db.urldata.Add(data);
            db.SaveChanges();
        }
        string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.asd
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }

        protected void Texturl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}