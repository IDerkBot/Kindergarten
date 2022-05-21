namespace Kindergarten.Models
{
	internal class Data
	{
		public static int Access { get; set; }
		public static int IDUser { get; set; }
		public static bool IsParent => Access == 0;
		public static bool IsTeacher => Access == 1;
		public static bool IsAdmin => Access == 2;
	}
}
