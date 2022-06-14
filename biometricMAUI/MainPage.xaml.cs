using Plugin.Fingerprint.Abstractions;

namespace biometricMAUI;
public partial class MainPage : ContentPage
{
	private readonly IFingerprint fingerprint;

	public MainPage(IFingerprint fingerprint)
	{
		InitializeComponent();
		this.fingerprint = fingerprint;
	}

	private async void OnBiometricClicked(object sender, EventArgs e)
	{
		var request = new AuthenticationRequestConfiguration("Validate that you have fingers", "Because without them you will not be able to access");
		var result = await fingerprint.AuthenticateAsync(request);
		if (result.Authenticated)
		{
			await DisplayAlert("Authenticate!", "Access Granted", "OK");
		}
		else
		{
			await DisplayAlert("Unauthenticated", "Access Denied", "OK");
		}
	}
}