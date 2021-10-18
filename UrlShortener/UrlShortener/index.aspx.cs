using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using UrlShortener.Models;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace UrlShortener
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string Scheme = HttpContext.Current.Request.Url.Scheme;
            string code = path.Substring(path.Length - 6);

            
            if (code != "x.aspx" && code != ".aspx/")
            {
                urlshortnercontext db = new urlshortnercontext();
                urldata data = db.urldata.Where(s => s.shorturl == code).FirstOrDefault<urldata>();
                if (data != null)
                    Response.Redirect(data.originalurl);
                else Response.Redirect("https://localhost:44379/index.aspx/");
            }

            Copy.Visible = false;
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Copy.Visible = false;
            string randomstring = RandomString(6);
            Label1.Text = "https://localhost:44379/index.aspx/"+randomstring;
            urlshortnercontext db = new urlshortnercontext();
            urldata data = new urldata();
            string str = Texturl.Text.Substring(0,4);
            if(str!="http")
            {
                Texturl.Text = "http://" + Texturl.Text; 
            }
            var regex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
            if (regex.Match(Texturl.Text).Success)
            {
                data.originalurl = Texturl.Text;
                data.shorturl = randomstring;
                db.urldata.Add(data);
                db.SaveChanges();
                Copy.Visible = true;
            }

            else
            {
                Copy.Visible = false;
                Label1.Text = "Not valid Url";
            }
        }
        public bool IsValidUri(string uri)
        {
            Uri validatedUri;
            return Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out validatedUri);
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

        private static string _Val;
        public static string Val
        {
            get { return _Val; }
            set { _Val = value; }
        }
        protected void Copy_Click(object sender, EventArgs e)
        {
            Val = Label1.Text;
            Thread staThread = new Thread(new ThreadStart(myMethod));
            staThread.ApartmentState = ApartmentState.STA;
            staThread.Start();
        }
        public static void myMethod()
        {
            Clipboard.SetText(Val);
        }
    }
}