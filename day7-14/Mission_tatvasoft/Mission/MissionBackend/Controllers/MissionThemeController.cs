using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Dto;
using MissionBackend.Models;
using MissionBackend.Interfaces;

namespace MissionBackend.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class MissionThemeController : ControllerBase
        {
            private readonly IMissionThemeServices _service;

            public MissionThemeController(IMissionThemeServices service)
            {
                _service = service;
            }

            [Authorize]
            [HttpPost("AddMissionTheme")]
            public async Task<IActionResult> AddMissionTheme(MissionThemeDto mission)
            {
                try
                {
                    var createdmission = await _service.AddMissionTheme(mission);
                return Ok(new LoginResponse
                {
                    Result = 1,
                    Message = "Mission Theme added Successfully",
                    Data = createdmission
                });
            }
                catch (Exception ex)
                {
                return BadRequest(new LoginResponse
                {
                    Result = 0,
                    Message = "Mission Theme already exists",
                    Data = null
                });
            }

            }

            [Authorize]
            [HttpGet("GetMissionThemeById/{id}")]
            public async Task<IActionResult> GetMissionThemeById(int id)
            {
                var mission= await _service.GetMissionThemeById(id);
                return mission == null ? NotFound(new LoginResponse
                {
                    Result = 0,
                    Message = "Mission Theme doesn't exists",
                    Data = null
                }) : Ok(new LoginResponse
                {
                    Result = 1,
                    Message = "",
                    Data = mission
                });
            }

        [Authorize]
        [HttpGet("GetMissionThemeList")]
        public async Task<IActionResult> GetAllMissionTheme()
        {
            var mission = await _service.GetAllMissionTheme();
            return mission == null ? NotFound(new LoginResponse
            {
                Result = 0,
                Message = "Mission Theme doesn't exists",
                Data = null
            }) : Ok(new LoginResponse
            {
                Result = 1,
                Message = "",
                Data = mission
            });
        }

        [Authorize]
        [HttpPost("UpdateMissionTheme")]
        public async Task<IActionResult> UpdateMissionTheme(MissionThemeDto mission)
        {
            Console.WriteLine($"Updating Mission Id: {mission.Id}, ThemeName: {mission.ThemeName}, Status: {mission.Status}");

            try
            {
                bool updated = await _service.UpdateMissionTheme(mission);
                if (updated)
                {
                    return Ok(new LoginResponse
                    {
                        Result = 1,
                        Message = "Mission Theme updated",
                        Data = mission
                    });
                }
                else
                {
                    return NotFound(new LoginResponse
                    {
                        Result = 0,
                        Message = "Mission Theme doesn't exist",
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
        [HttpDelete("DeleteMissionTheme{id}")]
            public async Task<IActionResult> DeleteMissionTheme(int id) =>
                await _service.DeleteMissionTheme(id) ? Ok(new LoginResponse
                {
                    Result = 1,
                    Message = "Mission Theme deleted",
                    Data = null
                }) : NotFound(new LoginResponse
                {
                    Result = 0,
                    Message = "Mission Theme doesn't exist",
                    Data = null
                });
        }
    }
