
namespace LearningApp.Models
{
	public class SimpleModel
	{
		public int SimpleModelId { get; set; }
		public string Caption { get; set; } = string.Empty;
		public decimal Cost { get; set; }

		public override string ToString()
		{
			return SimpleModelId + " " + Caption;
		}

	}
}
