using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MO2Helpers
{
    public static class FileUploader
    {
        /// <summary>
        /// Upload Base64 string file onto the server.
        /// </summary>
        /// <param name="base64String">A base64 string represents the uploaded file.</param>
        /// <param name="fileExtension">The extension of the uploaded file.</param>
        /// <param name="rootPath">The application root path on a server.</param>
        /// <param name="uploadDirectory">A directory name to upload the file on it, in case want to create a specific uploaded directory.</param>
        /// <param name="dateDirectory">A flag to manage directory creation based on the date 'yyyy/mm/dd'.</param>
        /// <returns>
        /// A Url for the uploaded file.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Case <param name="base64String"> null or empty, <param name="fileExtension"> null or empty, or <param name="rootPath"> null or empty.
        /// </exception>
        public static async Task<string> Upload(
            this string base64String,
            string fileExtension,
            string rootPath,
            string? uploadDirectory = null,
            bool dateDirectory = false)
        {
            // validate
            ValidateBase64(base64String, rootPath, fileExtension);

            // handel directory
            string url = HandelDirectory(rootPath, uploadDirectory, dateDirectory);
            string filePath = string.IsNullOrEmpty(url) ?
                rootPath : Path.Combine(rootPath, url);
            string fileName = $"{Path.GetRandomFileName()}.{fileExtension}";
            byte[] binaryData = Convert.FromBase64String(base64String);

            using var fileStream = new FileStream(
                Path.Combine(filePath, fileName),
                FileMode.Create, FileAccess.Write);

            await fileStream.WriteAsync(binaryData);

            return string.IsNullOrEmpty(url) ?
                fileName : Path.Combine(url, fileName);

            static void ValidateBase64(string base64String,
                string rootPath, string fileExtension)
            {
                if (string.IsNullOrEmpty(base64String))
                    throw new ArgumentNullException(nameof(base64String));
                if (string.IsNullOrEmpty(rootPath))
                    throw new ArgumentNullException(nameof(rootPath));
                if (string.IsNullOrEmpty(fileExtension))
                    throw new ArgumentNullException(nameof(fileExtension));
            }
        }


        /// <summary>
        /// Upload IFormFile file onto the server.
        /// </summary>
        /// <param name="file">An IFormFile represents the uploaded file.</param>
        /// <param name="rootPath">The application root path on a server.</param>
        /// <param name="uploadDirectory">A directory name to upload the file on it, in case want to create a specific uploaded directory.</param>
        /// <param name="dateDirectory">A flag to manage directory creation based on the date 'yyyy/mm/dd'.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Case <param name="file"> null or empty, or <param name="rootPath"> null or empty.
        /// </exception>
        public static async Task<string> Upload(
            this IFormFile file,
            string rootPath,
            string? uploadDirectory = null,
            bool dateDirectory = false)
        {
            // validate
            ValidateFile(file, rootPath);

            // handel directory
            string url = HandelDirectory(rootPath, uploadDirectory, dateDirectory);
            string filePath = string.IsNullOrEmpty(url) ?
                rootPath : Path.Combine(rootPath, url);

            string fileName = $"{Path.GetRandomFileName()}.{file.FileName.Split('.')[^1]}";

            using FileStream fileStream = File.Create(Path.Combine(filePath, fileName));
            await file.CopyToAsync(fileStream);
            fileStream.Flush();

            return string.IsNullOrEmpty(url) ?
                fileName : Path.Combine(url, fileName);

            static void ValidateFile(IFormFile file,
                string rootPath)
            {
                if (file is null)
                    throw new ArgumentNullException(nameof(file));
                if (string.IsNullOrEmpty(rootPath))
                    throw new ArgumentNullException(nameof(rootPath));
            }
        }

        private static string HandelDirectory(
            string rootPath,
            string? uploadDirectory,
            bool dateDirectory)
        {
            string filePath = string.Empty;

            if (!string.IsNullOrEmpty(uploadDirectory))
                filePath = uploadDirectory;
            else if (dateDirectory)
                filePath = Path.Combine(DateTime.Today.Year.ToString(),
                    DateTime.Today.Month.ToString(),
                    DateTime.Today.Day.ToString());

            if (!Directory.Exists(Path.Combine(rootPath, filePath)))
                Directory.CreateDirectory(Path.Combine(rootPath, filePath));

            return filePath;
        }
    }

}

