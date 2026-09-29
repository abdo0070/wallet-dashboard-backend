using Microsoft.AspNetCore.Identity.Data;
using Wallet.DTOs;
using Wallet.Models;

namespace Wallet.Services
{
    public class AuthService
    {
        private readonly TokenService _tokenService;
        private readonly WalletContext _context;
        public AuthService(TokenService tokenService,WalletContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }
        public AuthResponseDto Login(AuthLoginRequest auth)
        {
            // query into the database
            var user = _context.users.FirstOrDefault(u => u.Email == auth.Email && u.Password == auth.Password);
            if (user is null) throw new Exception("Wrong Username or Password");

            UserDto userDto = new UserDto { Username = user.Username, Email = user.Email, Balance = user.Balance, Invest_amount = user.Invest_amount };
            return new AuthResponseDto
            {
                token = _tokenService.TokenGenerate(user),
                user = userDto
            };
        }
        public void Register(AuthRegisterRequest registerRequest)
        {
            var newUser = new User()
            {
                Username = registerRequest.Username,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
            };
            var user = _context.users.Add(newUser);
            _context.SaveChanges();
            return;
        }
    }
}
