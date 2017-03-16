using Xamarin.Forms;

namespace SliderDrawer
{
	public partial class SliderDrawerPage : ContentPage
	{
		private MainPageModel mainPageModel;
		public SliderDrawerPage()
		{
			InitializeComponent();
			mainPageModel = new MainPageModel();
			this.BindingContext = mainPageModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			mainPageModel.DefaultHeight = App.Current.MainPage.Height;
			mainPageModel.DefaultWidth = App.Current.MainPage.Width;
		}
	}
}
