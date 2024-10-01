using Microsoft.AspNetCore.Http;

namespace Core.Interfaces
{
	public interface IFileService
    {
		Task<string> SaveProductImage(IFormFile file);
		void DeleteProductImage(string path);
		Task<string> EditProductImage(string oldPath, IFormFile newFile);
	}
}
