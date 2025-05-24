namespace SoftDeleteDemo.API.Data.Models
{
	public interface ISoftDeletable
	{
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
