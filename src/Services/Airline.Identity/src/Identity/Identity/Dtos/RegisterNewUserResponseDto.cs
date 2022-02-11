using System;

namespace Identity.Identity.Dtos;

public record RegisterNewUserResponseDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Username { get; init; }
}
