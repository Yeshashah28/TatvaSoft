using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;

namespace MissionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionApplicationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMissionApplicationService _service;

        public MissionApplicationController(AppDbContext context, IMissionApplicationService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        [Route("/api/Mission/MissionApplicationList")]
        public async Task<IActionResult> MissionApplicationList()
        {
            var res = await _service.MissionApplicationList();
            if (res == null)
            {
                return NotFound(new LoginResponse() { Data = res, Result = 0, Message = "not found" });
            }
            return Ok(new LoginResponse() { Data = res, Result = 1, Message = "" });
        }

        [HttpPost]
        [Route("/api/Mission/MissionApplicationApprove")]
        public async Task<IActionResult> MissionApplicationApprove(MissionApplicationDto mission)
        {
            var res = await _service.MissionApplicationApprove(mission.Id);
            if (res == null)
            {
                return NotFound(new LoginResponse() { Data = res, Result = 0, Message = "not approved" });
            }
            return Ok(new LoginResponse() { Data = res, Result = 1, Message = "approved" });
        }

        [HttpPost]
        [Route("/api/Mission/MissionApplicationDelete")]
        public async Task<IActionResult> MissionApplicationDelete(MissionApplicationDto mission)
        {
            var res = await _service.MissionApplicationDelete(mission.Id);
            if (res == null)
            {
                return NotFound(new LoginResponse() { Data = res, Result = 0, Message = "not deleted" });
            }
            return Ok(new LoginResponse() { Data = res, Result = 1, Message = "deleted" });
        }
    }
}
