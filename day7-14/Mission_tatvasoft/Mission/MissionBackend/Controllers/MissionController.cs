using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;

namespace MissionBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _service;
        private readonly ICommonService _commonservice;

        public MissionController(IMissionService service, ICommonService commonservice)
        {
            _service = service;
            _commonservice = commonservice;
        }

        [Authorize]
        [HttpGet("MissionDetailById/{id}")]
        public async Task<IActionResult> GetMissionById(int id)
        {
            var mission = await _service.GetMissionById(id);
            if (mission != null)
            {
                return Ok(new LoginResponse { Result = 1, Message = "Mission Fetched Successfully", Data = mission });
            }

            return NotFound(new LoginResponse { Result = 0, Message = "Mission doesn't exist", Data = null });
        }

        [Authorize]
        [HttpGet("MissionList")]
        public async Task<IActionResult> GetAllMission()
        {
            var mission = await _service.GetAllMission();
            if (mission != null)
            {
                return Ok(new LoginResponse { Result = 1, Message = "Missions Fetched Successfully", Data = mission });
            }

            return NotFound(new LoginResponse { Result = 0, Message = "Mission doesn't exist", Data = null });
        }

        [Authorize]
        [HttpPost("AddMission")]
        public async Task<IActionResult> AddMission(MissionDto mission)
        {
            
            var newmission = await _service.AddMission(mission);
            if (newmission == true)
            {
                return Ok(new LoginResponse { Result = 1, Message = "Mission added Successfully", Data = newmission });
            }
            return BadRequest(new LoginResponse { Result = 0, Message = "Mission Didn't get add due to error", Data = null });
        }

        [Authorize]
        [HttpPost("UpdateMission")]
        public async Task<IActionResult> UpdateMission(MissionDto mission)
        {
            var newmission = await _service.UpdateMission(mission);
            if (newmission == true)
            {
                return Ok(new LoginResponse { Result = 1, Message = "Mission updated Successfully", Data = newmission });
            }
            return NotFound(new LoginResponse { Result = 0, Message = "Mission doesn't exist", Data = null });
        }

        [Authorize]
        [HttpDelete("DeleteMission/{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var newmission = await _service.DeleteMission(id);
            if (newmission == true)
            {
                return Ok(new LoginResponse { Result = 1, Message = "Mission deleted Successfully", Data = newmission });
            }
            return NotFound(new LoginResponse { Result = 0, Message = "Mission doesn't exist", Data = null });
        }

        [Authorize]
        [HttpGet("GetMissionThemeList")]
        public LoginResponse GetMissionThemeList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _commonservice.MissionThemeList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }
        }

        [Authorize]
        [HttpGet("GetMissionSkillList")]
        public LoginResponse GetMissionSKillList()
        {

            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _commonservice.MissionSkillList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }
        }
    }
}
