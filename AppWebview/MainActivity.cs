using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;

namespace AppWebview
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtURL;
        Button btnOK;
        WebView webview1;
        string url;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtURL = FindViewById<EditText>(Resource.Id.txtURL);
            btnOK = FindViewById<Button>(Resource.Id.btnOK);
            webview1 = FindViewById<WebView>(Resource.Id.webView1);
            webview1.Settings.JavaScriptEnabled = true;

            btnOK.Click += BtnOK_click;
            url = "http://clo.netlify.app";
            webview1.LoadUrl(url);
        }

        private void BtnOK_click(object sender, System.EventArgs e)
        {
            webview1.SetWebViewClient(new MeuWebViewClient());
            url = txtURL.Text;
            if (!url.Contains("http://"))
            {
                url = "http://" + url;
            }
            webview1.LoadUrl(url);
        }

        public class MeuWebViewClient : WebViewClient
        {
            [System.Obsolete]
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}