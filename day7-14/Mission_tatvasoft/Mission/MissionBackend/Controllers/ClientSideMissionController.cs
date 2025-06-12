using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using MissionBackend.Services;
using System.Reflection;

namespace MissionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSideMissionController : ControllerBase
    {

        private readonly IMissionService _service;
        public ClientSideMissionController(IMissionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/api/ClientMission/ClientSideMissionList/{userId:int}")]
        public async Task<IActionResult> GetClientSideMissionListAsync(int userId)
        {
            
                   
            var res = await _service.GetClientSideMissionList(userId);
            
            
            return Ok(new LoginResponse() { Data = res, Result =1, Message = "" });
        }

        [HttpPost]
        [Route("/api/ClientMission/ApplyMission")]
        public async Task<IActionResult> ApplyMission(ApplyMissionRequest mission)
        {
            var res = await _service.ApplyMission(mission);
            if (res == false)
            {
                return BadRequest(new LoginResponse() { Data =null, Result = 0, Message = "Not Applied" });
            }
            return Ok(new LoginResponse() { Data = mission, Result = 1, Message = "Applied" });
        }
    }
}
