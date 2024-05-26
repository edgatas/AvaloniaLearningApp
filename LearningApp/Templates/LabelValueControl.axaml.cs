using Avalonia;
using Avalonia.Controls.Primitives;

namespace LearningApp.Templates
{
	public class LabelValueControl : TemplatedControl
	{
		// DISCLAIMER: Registered variable must be public even though IDE want to change it to private.
		// DISCLAIMER: Registered variable must have the same name as public property, but added Property at the end. Good luck finding somewhere where that is specified.
		public static readonly StyledProperty<string> LabelTextProperty = AvaloniaProperty.Register<LabelValueControl, string>(nameof(LabelText), "Label");

		public string LabelText
		{
			get => GetValue(LabelTextProperty);
			set => SetValue(LabelTextProperty, value);
		}

		// DISCLAIMER: Registered variable must be public even though IDE want to change it to private.
		// DISCLAIMER: Registered variable must have the same name as public property, but added Property at the end. Good luck finding somewhere where that is specified.
		public static readonly StyledProperty<string> ValueTextProperty = AvaloniaProperty.Register<LabelValueControl, string>(nameof(ValueText), "Value");

		public string ValueText
		{
			get => GetValue(ValueTextProperty);
			set => SetValue(ValueTextProperty, value);
		}
		
	}
}
