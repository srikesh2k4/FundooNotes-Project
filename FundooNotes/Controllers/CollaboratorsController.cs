using BusinessLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs.Collaborators;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/collaborators")]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorsController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCollaboratorDto dto)
        {
            var ownerUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _collaboratorService.AddAsync(dto, ownerUserId);
            return Ok("Collaborator added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var ownerUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _collaboratorService.RemoveAsync(id, ownerUserId);
            return NoContent();
        }
    }
}
