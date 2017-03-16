using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SliderDrawer
{
	public partial class SliderContentView : ContentView
	{
		public static readonly BindableProperty IsSlideOpenProperty =
			BindableProperty.Create("IsSlideOpen",
						typeof(bool),
						typeof(SliderContentView),
						false,
						BindingMode.TwoWay,
						propertyChanged: SlideOpenClose);

		public static readonly BindableProperty DefaultHeightProperty =
			BindableProperty.Create("DefaultHeight",
						typeof(double),
						typeof(SliderContentView),
						0.0D,
						BindingMode.TwoWay, null,
						propertyChanged: DefaultHeightChanged, propertyChanging: null, coerceValue: null, defaultValueCreator: null);

		public static readonly BindableProperty StackLayoutProperty =
			BindableProperty.Create("StackLayout",
						typeof(StackLayout),
						typeof(SliderContentView),
						null,
						BindingMode.TwoWay, null,
						propertyChanged: StackLayoutAdded, propertyChanging: null, coerceValue: null, defaultValueCreator: null);

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

		public double DefaultHeight {
			get { return (double)GetValue(DefaultHeightProperty); }
			set { SetValue(DefaultHeightProperty, value); }
		}


		private static async void SlideOpenClose(BindableObject bindable, object oldValue, object newValue)
		{
			if ((bool)newValue) {
				(bindable as SliderContentView).IsVisible = true;
				await (bindable as SliderContentView).TranslateTo(0, 0, 250, Easing.SinInOut);
				newValue = false;
			} else {
				await (bindable as SliderContentView).TranslateTo(0, App.Current.MainPage.Height, 250, Easing.SinInOut);
				(bindable as SliderContentView).IsVisible = false;
				newValue = true;
			}
		}

		private static void StackLayoutAdded(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as SliderContentView).MyStack.Children.Add((StackLayout)newValue);
		}

		private static void DefaultHeightChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as SliderContentView).IsVisible = false;
			(bindable as SliderContentView).TranslationY = (double)newValue;
		}
	}
}
