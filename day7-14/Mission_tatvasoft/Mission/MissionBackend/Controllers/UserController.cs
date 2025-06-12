using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using System.Reflection;

namespace MissionBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //[Authorize]
        //[HttpPost("/api/Admin/addUser")]
        //public async Task<IActionResult> Create(UserDto user)
        //{
        //    try
        //    {
        //        var createduser = await _service.CreateAsync(user);
        //        return Ok(createduser);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }

        //}

        [Authorize]
        [Route("Login/LoginUserDetailById/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(new LoginResponse
            {
                Result = 1,
                Message = "user updated",
                Data = user
            });
        }

        [Authorize]
        [Route("/api/AdminUser/UserDetailList")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _service.GetAllAsync();
            return user == null ? NotFound(new LoginResponse
            {
                Result = 0,
                Message = "users doesn't exists",
                Data = null
            }) : Ok(new LoginResponse
            {
                Result = 1,
                Message = "",
                Data = user
            });
        }


        [HttpPost("/api/Login/UpdateUser")]
        public async Task<IActionResult> UpdateAsync([FromForm] int id, [FromForm] UserDto user)
        {
            var files = Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    
                    string filerootpath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "UploadedImage", "Mission");
                    if (!Directory.Exists(filerootpath))
                    {
                        Directory.CreateDirectory(filerootpath);
                    }
                    string fname = file.FileName;
                    string filename = Path.GetFileNameWithoutExtension(fname);
                    string extension = Path.GetExtension(fname);
                    string fullfile = filename + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    string fullrootpath = Path.Combine(filerootpath, fullfile);

                    using (var stream = new FileStream(fullrootpath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    user.ProfileImage = Path.Combine("UploadedImage","Mission",fullfile).Replace("\\","/");
                }
            }
            
            return await _service.UpdateAsync(id, user) ? Ok(new LoginResponse
                {
                    Result = 1,
                    Message = "user updated",
                    Data = user
                }) : NotFound(new LoginResponse
                {
                    Result = 0,
                    Message = "user doesn't exist",
                    Data = null
                });

        }
       


        [HttpDelete("/api/AdminUser/DeleteUser/{id}")]
        public async Task<IActionResult> Delete(int id) =>
            await _service.DeleteAsync(id) ? Ok(new LoginResponse
            {
                Result = 1,
                Message = "user deleted",
                Data = null
            }) : NotFound(new LoginResponse
            {
                Result = 0,
                Message = "user doesn't exist",
                Data = null
            });
    }
}
