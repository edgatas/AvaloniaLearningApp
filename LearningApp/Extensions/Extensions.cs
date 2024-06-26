﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LearningApp.Extensions
{
	public static class Extensions
	{
		public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
		{
			List<T> sorted = collection.OrderBy(x => x).ToList();
			for (int i = 0; i < sorted.Count(); i++)
			{
				collection[i] = sorted[i];
			}
				
		}
	}
}
