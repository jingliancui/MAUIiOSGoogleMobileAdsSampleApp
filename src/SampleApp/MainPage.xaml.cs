using System.Diagnostics;
using GoogleMobileAds;

namespace SampleApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
#if IOS
		GADMobileAds.SharedInstance.StartWithCompletionHandler(null);

		GAMRequest request=GAMRequest.Request() as GAMRequest;
		GAMInterstitialAd.LoadWithAdManagerAdUnitID(
			"/21775744923/example/interstitial",
			request!,
			(ad,error)=>
			{
				if(error!=null)
				{
					Debug.WriteLine("Detect Google Ads Error:"+error.LocalizedDescription);
				}
				else
				{
					ad.PresentFromRootViewController(null);
				}
			});
#endif
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

