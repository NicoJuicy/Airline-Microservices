using System;

namespace Identity.Identity.Dtos;

public record RegisterNewUserResponseDto(int Id, string FirstName, string LastName, string Username);
