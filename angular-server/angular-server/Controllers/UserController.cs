using angular_server;
using Microsoft.AspNetCore.Mvc;


// UserController
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Data.Users;
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = Data.Users.FirstOrDefault(u => u.Code == id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        Data.Users.Add(user);
        return user;
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, User updatedUser)
    {
        var user = Data.Users.FirstOrDefault(u => u.Code == id);
        if (user == null)
        {
            return NotFound();
        }
                
         user.Name = updatedUser.Name;
         user.Email = updatedUser.Email;
         user.Address = updatedUser.Address;
         user.Password = updatedUser.Password;
      

        return user;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = Data.Users.FirstOrDefault(u => u.Code == id);
        if (user == null)
        {
            return NotFound();
        }

        Data.Users.Remove(user);
        return NoContent();
    }
}
