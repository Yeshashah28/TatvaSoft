using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using MissionBackend.Services;

namespace MissionBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionSkillController : ControllerBase
    {
        private readonly IMissionSkillService _service;

        public MissionSkillController(IMissionSkillService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("AddMissionSkill")]
        public async Task<IActionResult> AddMissionSkill(MissionSkillDto mission)
        {
            try
            {
                var createdmission = await _service.AddMissionSkill(mission);
                return Ok(new LoginResponse
                {
                    Result = 1,
                    Message = "Mission Skill Created Successfully",
                    Data = createdmission
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResponse
                {
                    Result = 0,
                    Message = "Mission already exists",
                    Data = null
                });
            }

        }

        [Authorize]
        [HttpGet("GetMissionSkillById/{id}")]
        public async Task<IActionResult> GetMissionSkillById(int id)
        {
            var mission = await _service.GetMissionSkillById(id);
            return mission == null ? NotFound(new LoginResponse
            {
                Result = 0,
                Message = "Mission skill doesn't exists",
                Data = null
            }) : Ok(new LoginResponse
            {
                Result = 1,
                Message = "",
                Data = mission
            });
        }

        [Authorize]
        [HttpGet("GetMissionSkillList")]
        public async Task<IActionResult> GetAllMissionSkill()
        {
            var mission = await _service.GetAllMissionSkill();
            return mission == null ? NotFound(new LoginResponse
            {
                Result = 0,
                Message = "Mission skill doesn't exist",
                Data = null
            }) : Ok(new LoginResponse
            {
                Result = 1,
                Message = "",
                Data = mission
            });
        }

        [Authorize]
        [HttpPost("UpdateMissionSkill")]
        public async Task<IActionResult> UpdateMissionSkill(MissionSkillDto mission)
        {
            Console.WriteLine($"Updating Mission Id: {mission.Id}, ThemeName: {mission.SkillName}, Status: {mission.Status}");

            try
            {
                bool updated = await _service.UpdateMissionSkill(mission);
                if (updated)
                {
                    return Ok(new LoginResponse
                    {
                        Result = 1,
                        Message = "Mission skill updated",
                        Data = mission
                    });
                }
                else
                {
                    return NotFound(new LoginResponse
                    {
                        Result = 0,
                        Message = "Mission skill doesn't exist",
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                // Log ex.Message and ex.StackTrace here
                return StatusCode(500, new LoginResponse
                {
                    Result = 0,
                    Message = $"Internal server error: {ex.Message}",
                    Data = null
                });
            }
        }


        [Authorize]
        [HttpDelete("DeleteMissionSkill/{id}")]
        public async Task<IActionResult> DeleteMissionSkill(int id) =>
                await _service.DeleteMissionSkill(id) ? Ok(new LoginResponse
                {
                    Result = 1,
                    Message = "Mission skill deleted",
                    Data = null
                }) : NotFound(new LoginResponse
                {
                    Result = 0,
                    Message = "Mission skill doesn't exist",
                    Data = null
                });
    }
}
