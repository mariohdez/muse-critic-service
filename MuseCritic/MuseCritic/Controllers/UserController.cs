using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseCritic.Models;
using MuseCritic.Repository;

namespace MuseCritic.Controllers;

[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserRepository userRepository;

    public UserController(UserRepository userRepository)
    {
        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository), "A non-null user Repository must be injected.");
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await this.userRepository.GetAsync();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await this.userRepository.GetAsync(id);

        if (user == null)
        {
            return new NotFoundResult();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await this.userRepository.CreateAsync(user);

        return new CreatedAtActionResult(actionName: nameof(Get), controllerName: "user", routeValues: new { id = user.Id }, value: user);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, [FromBody] User updatedUser)
    {
        var currentUser = await this.userRepository.GetAsync(id);

        if (currentUser is null)
        {
            return NotFound();
        }

        updatedUser.Id = currentUser.Id;

        await this.userRepository.UpdateAsync(id, updatedUser);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await this.userRepository.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await this.userRepository.RemoveAsync(id);

        return NoContent();
    }
}
