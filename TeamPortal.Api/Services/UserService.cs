
using TeamPortal.Api.Dtos;
using TeamPortal.Data;
using TeamPortal.Data.Entities;

using BRc = BCrypt.Net;

namespace TeamPortal.Api.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                FamilyName = userDto.FamilyName,
                Email = userDto.Email,
                PasswordHash = BRc.BCrypt.HashPassword(userDto.Password),
                Role = "User",
                IsActive = true
            };

            _context.Users.Add(user);

            //  Personal Note: user.Id is initialized to 0 by default. Add() tell EF tracker 'pending insert'

            await _context.SaveChangesAsync();

            //  Personal Note Cont': EF executes INSERT... and then, reads its back in a select statement
            // "EF immediately queries back the generated Id and any DB-defaulted columns (CreatedOnUtc) so the entity in memory stays in sync with what's in the database."

            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                FamilyName = user.FamilyName,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedOnUtc = user.CreatedOnUtc
            };
        }

    }
}
