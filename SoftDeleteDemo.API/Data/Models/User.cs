namespace SoftDeleteDemo.API.Data.Models
{
	public class User : ISoftDeletable
	{
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public DateTime CreatedAt { get; set; }
		public ICollection<AppTask>? Tasks { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
