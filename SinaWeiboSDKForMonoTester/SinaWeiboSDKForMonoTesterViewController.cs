using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using WeiboSDKForWinRT;

namespace SinaWeiboSDKForMonoTester
{
	public delegate void EventNotifyDelegate (Object sender, Object obj);

	public partial class SinaWeiboSDKForMonoTesterViewController : UIViewController
	{

		private ClientOAuth oauthClient;

		public SinaWeiboSDKForMonoTesterViewController () : base ("SinaWeiboSDKForMonoTesterViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		private void weiboVisitFinish(Object sender, object obj){
			string url = (string)obj;
			string code = SdkUility.GetQueryParameter(url,"code");
			oauthClient.Authorize (code);

			//get at user list
			var engine = new SdkNetEngine();
			ISdkCmdBase cmdbase = null;
			cmdbase = new CmdAtUsers()
			{
				Keyword = "3"
			};
			var result = engine.RequestCmd(SdkRequestType.AT_USERS, cmdbase);
			if (result.errCode == SdkErrCode.SUCCESS)
			{
				System.Console.WriteLine( result.content);
			}
			else
			{
				System.Console.WriteLine( "the api didn't work correctly.");

			}

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			MyHashTable myAppSettings = new MyHashTable ();
			ApplicationData.Current.LocalSettings.Values = myAppSettings;

			SdkData.AppKey = "2999701648";
			SdkData.AppSecret = "bb4d9b4617847315b057967acfd75481";
			SdkData.RedirectUri = "https://api.weibo.com/oauth2/default.html";
			MyWeiboViewDelegate myWeibo = new MyWeiboViewDelegate();
			myWeibo.NotifyDelegate = new EventNotifyDelegate(this.weiboVisitFinish);
			weiboView.Delegate = myWeibo;

			// Perform any additional setup after loading the view, typically from a nib.
			oauthClient = new ClientOAuth();
			// 判断是否已经授权或者授权是否过期.
			if (oauthClient.IsAuthorized == false)
			{
				oauthClient.LoginCallback += (isSucces, err, response) =>
				{
					if (isSucces)
					{

						// TODO: deal the OAuth result.
						System.Console.WriteLine ("Congratulations, Authorized successfully!");
						System.Console.WriteLine (string.Format("AccesssToken:{0}, ExpriesIn:{1}, Uid:{2}",
						                                    response.AccessToken, response.ExpriesIn, response.Uid));
					}
					else
					{
						// TODO: handle the err.
						System.Console.WriteLine ( err.errMessage);
					}
				};
				string url = oauthClient.GetAuthorizeUrl ();
				NSUrlRequest request  = NSUrlRequest.FromUrl(NSUrl.FromString(url));
				weiboView.LoadRequest(request);
//				oauthClient.BeginOAuth();
			}

		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}

	public class MyWeiboViewDelegate : UIWebViewDelegate {

		public EventNotifyDelegate NotifyDelegate {
			get;
			set;
		}

		public override void LoadFailed (UIWebView webView, NSError error)
		{
			System.Console.WriteLine ("webView LoadFailed");
		}
		public override void LoadingFinished (UIWebView webView)
		{
			System.Console.WriteLine ("webView LoadingFinished");
		}
		public override void LoadStarted (UIWebView webView)
		{
			System.Console.WriteLine ("webView LoadStarted");
		}
		public override bool ShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			System.Console.WriteLine ("webView ShouldStartLoad");
			string url = request.Url.ToString ();
			if (url.StartsWith (SdkData.RedirectUri)) {
				System.Console.WriteLine (url);
				if(NotifyDelegate != null){
					NotifyDelegate (this, url);
				}
			}
			return true;
		}	
	}
}

