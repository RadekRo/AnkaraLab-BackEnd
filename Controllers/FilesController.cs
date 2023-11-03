using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm] Files files)
        {
            if (files.UserFiles == null || files.UserFiles.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            foreach (var file in files.UserFiles)
            {
                var filePath = Path.Combine("uploads", file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return Ok("Files uploaded successfully");

        }
    }
}
