using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
