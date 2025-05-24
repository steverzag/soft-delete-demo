using SoftDeleteDemo.API.Data.Enums;

namespace SoftDeleteDemo.API.DTOs
{
	public record TaskDTO
	(
		int Id,
		string Title,
		string? Description,
		DateTime CreatedAt,
		AppTaskPriority Priority,
		AppTaskStatus Status,
		bool IsCompleted,
		DateTime? CompletedAt,
		int? UserId
	);

	public record CreateTaskRequest
	(
		string Title,
		string Description,
		AppTaskPriority Priority,
		AppTaskStatus Status,
		int? UserId
	);

	public record UpdateTaskRequest
	(
		int Id,
		string Title,
		string Description,
		AppTaskPriority Priority,
		AppTaskStatus Status,
		int? UserId
	);

	public record AssignTaskUserRequest(int TaskId, int? UserId);
}
