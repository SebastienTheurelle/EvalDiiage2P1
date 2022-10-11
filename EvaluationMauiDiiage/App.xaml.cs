using EvaluationMauiDiiage.Views;

namespace EvaluationMauiDiiage;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        // Workaround for: 'Either set MainPage or override CreateWindow.'??
        if (this.MainPage == null)
        {
            this.MainPage = new MainPage();
        }

        return base.CreateWindow(activationState);
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        //Save the state of your ViewModel.
    }

    protected override void OnResume()
    {
        base.OnResume();
        //Restore the state of your ViewModel.
    }
}	

