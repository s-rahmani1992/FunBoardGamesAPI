using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.User
{
    [Route("UserHandler")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("SignUp")]
        public async Task<Models.User> SignUp(Models.User user)
        {
            using (FunBoardGameDBContext gameContext = new())
            {
                await gameContext.Users.AddAsync(user);
                await gameContext.SaveChangesAsync();
                return user;
            };
        }

        [HttpGet]
        [Route("GetMaxUserId")]
        public async Task<long> GetMaxUserId()
        {
            using (FunBoardGameDBContext gameContext = new())
            {
                var id = await gameContext.Users.MaxAsync(user => user.Id);
                return id;
            };
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<Models.User?> GetUser(string userName, string password, string deviceId)
        {
            using (FunBoardGameDBContext gameContext = new())
            {
                Models.User? user = await gameContext.Users.FirstOrDefaultAsync(user => user.UserName == userName && user.Password == password && user.DeviceId == deviceId);
                return user;
            };
        }
    }
}
