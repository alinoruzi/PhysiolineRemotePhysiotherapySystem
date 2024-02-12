using Microsoft.AspNetCore.Mvc;

namespace Physioline.Endpoint.WebAPI.ApiControllers.ExpertControllers
{
	//[Authorize(Roles = "Expert")]
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
				return BadRequest("Please select a valid image file.");
			}
			
			var allowedExtensions = new[] { ".png", ".gif", ".jpg" };
			var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
			if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
			{
				return BadRequest("Invalid file extension. Supported extensions are .png, .gif, and .jpg.");
			}

			const long maxFileSize = 5 * 1024 * 1024;
			if (imageFile.Length > maxFileSize)
			{
				return BadRequest("File size exceeds the maximum allowed limit (5MB).");
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
				return BadRequest("Please select a valid image file.");
			}
			
			var allowedExtensions = new[] { ".png", ".jpg" };
			var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
			if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
			{
				return BadRequest("Invalid file extension. Supported extensions are .png, .gif, and .jpg.");
			}

			const long maxFileSize = 3 * 1024 * 1024;
			if (imageFile.Length > maxFileSize)
			{
				return BadRequest("File size exceeds the maximum allowed limit (3MB).");
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
