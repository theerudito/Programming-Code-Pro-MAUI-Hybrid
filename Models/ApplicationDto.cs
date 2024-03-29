﻿namespace ProgrammingCodePro.Models
{
	public class ApplicationDto : Images
	{
		public int IdApplication { get; set; }
		public int IdUser { get; set; }
		public int IdCourse { get; set; }
		public int IdImageCourse { get; set; }
		public int IdType { get; set; }
		public double ScoreCourse { get; set; }
		public bool LikeCourse { get; set; }
		public string Title { get; set; } = string.Empty;
		public string TypeName { get; set; } = string.Empty;
	}
}