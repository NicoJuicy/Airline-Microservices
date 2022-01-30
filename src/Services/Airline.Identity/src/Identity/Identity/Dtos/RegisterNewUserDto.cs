using System;

namespace Identity.Identity.Dtos;

public record RegisterNewUserDto(int Id, string FirstName, string LastName, string Username);
