
using SoftDeleteDemo.API.Data.Enums;

namespace SoftDeleteDemo.API.Data.Models
{
	public class AppTask : ISoftDeletable
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public AppTaskPriority Priority { get; set; }
		public AppTaskStatus Status { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime? CompletedAt { get; set; }
		public int? UserId { get; set; }
		public User? User { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
