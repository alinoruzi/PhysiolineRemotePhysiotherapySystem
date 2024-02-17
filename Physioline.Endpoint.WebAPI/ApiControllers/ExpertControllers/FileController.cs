using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	[Authorize(Roles = "Expert,Admin")]
	[Route("api/expert/[controller]/[action]")]
	[ApiController]
	public class FileController : ControllerBase
	{
		private readonly IWebHostEnvironment _env;

		public FileController(IWebHostEnvironment env)
		{
			_env = env;
		}
		
		[HttpPost]
		public async Task<IActionResult> UploadExercisePicture(IFormFile imageFile)
		{
			if (imageFile == null || imageFile.Length == 0)
			{
				return BadRequest("لطفا یک فایل مناسب ارسال کنید.");
			}
			
			var allowedExtensions = new[] { ".png", ".gif", ".jpg" };
			var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
			if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
			{
				return BadRequest("فرمت تصویر ارسال شده مجاز نیست. فرمت مجاز شامل: .png, .gif, and .jpg.");
			}

			const long maxFileSize = 5 * 1024 * 1024;
			if (imageFile.Length > maxFileSize)
			{
				return BadRequest("فایل نباید بیشتر از 5 مگابایت باشد (5MB).");
			}

			var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

			var imagePath = Path.Combine(_env.WebRootPath, "ExercisePictures", uniqueFileName);
			await using (var fileStream = new FileStream(imagePath, FileMode.Create))
			{
				await imageFile.CopyToAsync(fileStream);
			}

			return Ok(uniqueFileName);
		}
		
		
		[HttpPost]
		public async Task<IActionResult> UploadProfilePicture(IFormFile imageFile)
		{
			if (imageFile == null || imageFile.Length == 0)
			{
				return BadRequest("لطفا یک فایل مناسب ارسال کنید.");
			}
			
			var allowedExtensions = new[] { ".png", ".jpg" };
			var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
			if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
			{
				return BadRequest("فرمت تصویر ارسال شده مجاز نیست. فرمت مجاز شامل: .png, .jpg.");
			}

			const long maxFileSize = 3 * 1024 * 1024;
			if (imageFile.Length > maxFileSize)
			{
				return BadRequest("فایل نباید بیشتر از 3 مگابایت باشد (3MB).");
			}

			var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

			var imagePath = Path.Combine(_env.WebRootPath, "ProfilePictures", uniqueFileName);
			await using (var fileStream = new FileStream(imagePath, FileMode.Create))
			{
				await imageFile.CopyToAsync(fileStream);
			}

			return Ok(uniqueFileName);
		}
	}
}
