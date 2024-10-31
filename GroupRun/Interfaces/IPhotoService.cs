using System;
using CloudinaryDotNet.Actions;

namespace GroupRun.Interfaces
{
	public interface IPhotoService
	{
		Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

		Task<DeletionResult> DeletePhotoAsync(string piblicId);
	}
}

