using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissionBackend.Data;
using MissionBackend.Interfaces;
using MissionBackend.Models;

namespace MissionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICommonService _service;

        public CommonController(AppDbContext context, ICommonService service)
        {
            _context = context;
            _service = service;
        }

        [Authorize]
        [HttpGet("CountryList")]

        public LoginResponse CountryList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.CountryList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpGet("CityList/{countryid}")]

        public LoginResponse CityList(int countryid)
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.CityList(countryid) };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpGet("MissionCountryList")]

        public LoginResponse MissionCountryList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.MissionCountryList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpGet("MissionCityList")]

        public LoginResponse MissionCityList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.MissionCityList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpGet("MissionThemeList")]

        public LoginResponse MissionThemeList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.MissionThemeList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpGet("MissionSKillList")]

        public LoginResponse MissionSKillList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.MissionSkillList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpGet("MissionTitleList")]

        public LoginResponse MissionTitleList()
        {
            try
            {
                return new LoginResponse { Result = 1, Message = "Success", Data = _service.MissionTitleList() };
            }
            catch (Exception ex)
            {
                return new LoginResponse { Result = 0, Message = "Failure", Data = null };
            }

        }

        [Authorize]
        [HttpPost("UploadImage")]

        public async Task<IActionResult> UploadImage()
        {
            List<string> filelist = new List<string>();
            var files = Request.Form.Files;
            try
            {
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {

                        string filerootpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImage", "Mission");
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
                        filelist.Add($"/UploadedImage/Mission/{fullfile}");
                    }
                }
                return Ok(new LoginResponse { Result = 1, Message = "success", Data = filelist });
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResponse { Result = 0, Message = "failure", Data = null });
            }

        }
    }
}
