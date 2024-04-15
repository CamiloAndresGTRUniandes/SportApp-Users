namespace Users.Infraestructure.Services ;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplication.Constans;
using Aplication.Contracts.Identity;
using Aplication.Models.Identity;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _singInManager;


        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"Usuario con email {request.Email} no se encuentra registrado");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var resultado = await _singInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new Exception($"las credenciales no son correctas para el usuario con email {request.Email}.");
            }

            var token = await GenerateToken(user);
            var roleApp = roles.ToList().Count > 0 ? roles[0] : string.Empty;


            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = request.Email.ToLower().Trim(),
                UserName = user.Email.ToLower().Trim(),
                Name = user.Name.Trim().Trim(),
                LastName = user.LastName.Trim(),
                Role = roleApp
            }
                ;


            return authResponse;
        }


        public async Task<bool> IsEmailUnique(string email)
        {
            var validateEmail = await _userManager.FindByEmailAsync(email.ToLower());
            if (validateEmail != null)
            {
                return false;
            }
            return true;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var validateEmail = await _userManager.FindByEmailAsync(request.Email);
            if (validateEmail != null)
            {
                throw new Exception($"Usuario con email {request.Email} ya se encuentra registrado");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                EmailConfirmed = true,
                CityId = null,
                StateId = null,
                CountryId = null
            };


            var resultNewUser = await _userManager.CreateAsync(user, request.Password);
            if (resultNewUser.Succeeded)
            {
                if (request.isUser)
                {
                    await _userManager.AddToRoleAsync(user, "Usuario");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Asociado");
                }


                var token = await GenerateToken(user);
                return new RegistrationResponse
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    UserName = user.UserName
                };
            }


            throw new Exception($"Usuario con email {request.Email} no se creo por {resultNewUser.Errors}");
        }


        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var rolesClaims = new List<Claim>();

            foreach (var role in roles)
            {
                rolesClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }.Union(userClaims).Union(rolesClaims);

            ;


            var simetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredetials = new SigningCredentials(simetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredetials
                );


            return jwtSecurityToken;
        }
    }
