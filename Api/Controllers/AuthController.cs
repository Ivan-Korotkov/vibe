using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<CustomIdentityUser> manager) 
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequestDto dto)
    {
        var person = await manager.FindByEmailAsync(dto.Email);
        if (person == null) {
            return Results.Unauthorized();
        }
        
        var result = await manager.CheckPasswordAsync(person, dto.Password);
        if (result)
        {
            var response = new IdentityUserResponseDto(
                person.UserName!, person.Email!, "jwt"
            );

            return Results.Ok(new { result = response});
        }

        return Results.Unauthorized();
    }
}
