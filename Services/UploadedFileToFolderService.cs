using MovieDatabaseBlazorServerApp.Models;

namespace MovieDatabaseBlazorServerApp.Services
{
    public class UploadedFileToFolderService
    {
        private IWebHostEnvironment Environment { get; }

        public UploadedFileToFolderService(IWebHostEnvironment environment)
        {
            this.Environment = environment;
        }

        public async Task<string> CreateInFolder(UploadedFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";

            using (var stream = new FileStream(Path.Combine($"{Environment.WebRootPath}/UploadedFiles/", fileName), FileMode.Create))
            {
                // Save the file
                await stream.WriteAsync(file.Data);

                // Return the path of the file
                return ($"/UploadedFiles/{fileName}");
            }
        }

        public Task<bool> RemoveFromFolder(string filePath)
        {
            return Task.Run(() =>
            {
                var absolutePathToFile = $"{Environment.WebRootPath}{filePath}";
                if (!string.IsNullOrEmpty(filePath)
                    && File.Exists(absolutePathToFile))
                {
                    File.Delete(absolutePathToFile);
                    return true;
                }
                return false;
            });
        }
    }
}

