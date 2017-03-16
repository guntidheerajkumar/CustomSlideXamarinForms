using Xamarin.Forms;
using System.Windows.Input;
using PropertyChanged;
using System.Collections.Generic;

namespace SliderDrawer
{
	public class Person
	{
		public string Name { get; set; }
	}

	[ImplementPropertyChanged]
	public class MainPageModel
	{
		public double DefaultHeight { get; set; }

		public double DefaultWidth { get; set; }

		public bool IsSlideAddressOpen { get; set; }

		public ICommand ButtonCommand { get; set; }

		public List<Person> PersonList { get; set; }

		public MainPageModel()
		{
			ButtonCommand = new Command(OpenPopup);
			IsSlideAddressOpen = false;
			PersonList = new List<Person>();
			PersonList.Add(new Person() { Name = "Dheeraj Kumar Gunti" });
		}

		private void OpenPopup()
		{
			if (IsSlideAddressOpen) {
				IsSlideAddressOpen = false;
			} else {
				IsSlideAddressOpen = true;
			}
		}
	}
}
