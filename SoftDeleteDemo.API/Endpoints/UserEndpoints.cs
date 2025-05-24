using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;
using SoftDeleteDemo.API.DTOs;
using SoftDeleteDemo.API.Endpoints.Configuration;
using SoftDeleteDemo.API.Services;

namespace SoftDeleteDemo.API.Endpoints
{
	public class UserEndpoints : IEndpoints
	{
		public void RegisterEndpoints(IEndpointRouteBuilder builder)
		{
			var group = builder
				.MapGroup("/users")
				.WithTags("Users")
				.AddFluentValidationAutoValidation();

			group.MapGet("/", GetAllUsers);
			group.MapGet("/{id}", GetUserById).WithName("UserById");
			group.MapPost("/", CreateUser);
			group.MapPut("/", UpdateUser);
			group.MapDelete("/{id}", DeleteUser);
		}

		private async static Task<IResult> GetAllUsers(UserService userService, bool includeDeleted = false)
		{
			var users = includeDeleted 
				? await userService.GetAllUsersIncludeDeletedAsync() 
				: await userService.GetAllUsersAsync();

			return Results.Ok(users);
		}

		private async static Task<IResult> GetUserById(int id, UserService userService)
		{
			var user = await userService.GetUserByIdAsync(id);
			if(user is null)
			{
				return Results.NotFound("user not found");
			}

			return Results.Ok(user);
		}

		private async static Task<IResult> CreateUser(CreateUserRequest request, UserService userService)
		{
			var userId = await userService.CreateUserAsync(request);
			return Results.CreatedAtRoute("UserById", routeValues: new { id = userId });
		}

		private async static Task<IResult> UpdateUser(UpdateUserRequest request, UserService userService)
		{
			var user = await userService.UpdateUserAsync(request);
			return Results.Ok(user);
		}

		private async static Task<IResult> DeleteUser(int id, UserService userService)
		{
			await userService.DeleteUserAsync(id);
			return Results.Ok("user deleted");
		}
	}
}
