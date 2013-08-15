// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SinaWeiboSDKForMonoTester
{
	[Register ("SinaWeiboSDKForMonoTesterViewController")]
	partial class SinaWeiboSDKForMonoTesterViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView weiboView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (weiboView != null) {
				weiboView.Dispose ();
				weiboView = null;
			}
		}
	}
}
