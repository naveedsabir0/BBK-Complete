using Microsoft.AspNetCore.Components.Forms;
using MovieDatabaseBlazorServerApp.Models;

namespace MovieDatabaseBlazorServerApp.Converters
{
    public static class UploadedFileConverter
    {
        public static async Task<UploadedFile> ConvertToUploadedFileAsync(this IBrowserFile formFile)
        {
            UploadedFile? file = null;

            using (var ms = new MemoryStream())
            {
                var fileStream = formFile.OpenReadStream(4096000);
                await fileStream.CopyToAsync(ms);

                file = new UploadedFile()
                {
                    Data = ms.ToArray(),
                    ContentType = formFile.ContentType,
                    Name = formFile.Name
                };
            }

            return file;
        }

        public static string? ConvertToBrowserRenderableFile(this UploadedFile theFile)
        {
            if (theFile != null)
            {
                return $"data:{theFile.ContentType};base64,{Convert.ToBase64String(theFile.Data)}";
            }
            return null;
        }
    }
}
