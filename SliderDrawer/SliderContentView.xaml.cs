using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SliderDrawer
{
	public partial class SliderContentView : ContentView
	{
		public static readonly BindableProperty IsSlideOpenProperty =
			BindableProperty.Create<SliderContentView, bool>(p => p.IsSlideOpen, false, BindingMode.TwoWay, propertyChanged: SlideOpenClose);

		public static readonly BindableProperty DefaultHeightProperty =
			BindableProperty.Create<SliderContentView, double>(p => p.DefaultHeight, 0, BindingMode.TwoWay, propertyChanged: DefaultHeightChanged);

		public static readonly BindableProperty StackLayoutProperty =
		BindableProperty.Create<SliderContentView, StackLayout>(p => p.StackLayout, null, BindingMode.TwoWay, propertyChanged: StackLayoutAdded);

		public SliderContentView()
		{
			InitializeComponent();
		}

		public bool IsSlideOpen {
			get { return (bool)GetValue(IsSlideOpenProperty); }
			set { SetValue(IsSlideOpenProperty, value); }
		}

		public StackLayout StackLayout {
			get { return (StackLayout)GetValue(StackLayoutProperty); }
			set { SetValue(StackLayoutProperty, value); }
		}


		private static async void SlideOpenClose(BindableObject bindable, bool oldValue, bool newValue)
		{
			if (newValue) {
				(bindable as SliderContentView).IsVisible = true;
				await (bindable as SliderContentView).TranslateTo(0, 0, 250, Easing.SinInOut);
				newValue = false;
			} else {
				await (bindable as SliderContentView).TranslateTo(0, App.Current.MainPage.Height, 250, Easing.SinInOut);
				(bindable as SliderContentView).IsVisible = false;
				newValue = true;
			}
		}

		private static void StackLayoutAdded(BindableObject bindable, StackLayout oldValue, StackLayout newValue)
		{
			(bindable as SliderContentView).MyStack.Children.Add(newValue);
		}

		private static void DefaultHeightChanged(BindableObject bindable, double oldValue, double newValue)
		{
			(bindable as SliderContentView).IsVisible = false;
			(bindable as SliderContentView).TranslationY = newValue;
		}

		public double DefaultHeight {
			get { return (double)GetValue(DefaultHeightProperty); }
			set { SetValue(DefaultHeightProperty, value); }
		}
	}
}
