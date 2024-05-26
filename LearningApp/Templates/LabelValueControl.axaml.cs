using Avalonia;
using Avalonia.Controls.Primitives;

namespace LearningApp.Templates
{
	public class LabelValueControl : TemplatedControl
	{
		private static readonly StyledProperty<string> LabelProperty = AvaloniaProperty.Register<LabelValueControl, string>(nameof(LabelText), "Label");

		public string LabelText
		{
			get => GetValue(LabelProperty);
			set => SetValue(LabelProperty, value);
		}

		private static readonly StyledProperty<string> ValueProperty = AvaloniaProperty.Register<LabelValueControl, string>(nameof(ValueText), "Value");

		public string ValueText
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}
	}
}
