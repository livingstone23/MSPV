namespace WebApiTemplate.Services
{
    public class StoreLocalFiles : IStoreFiles
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StoreLocalFiles(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _environment = env;
            _httpContextAccessor = httpContextAccessor;


        }


        public Task DeleteFiles(string path, string conteiner)
        {
            
            if (path != null)
            {

                var fileName = Path.GetFileName(path);
                string directoryFile = Path.Combine(_environment.WebRootPath, conteiner, fileName);

                if (File.Exists(directoryFile))
                {
                    File.Delete(directoryFile);
                }
            }

            return Task.FromResult(0);

        }

        public async Task<string> EditFiles(byte[] content, string extension, string conteiner, string path, string contentType)
        {

            await DeleteFiles(path, conteiner);
            return await SaveFiles(content, extension, conteiner, contentType);

        }

        public async Task<string> SaveFiles(byte[] content, string extension, string conteiner, string contentType)
        {

            var nameFile = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_environment.WebRootPath, conteiner);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string path = Path.Combine(folder, nameFile);
            await File.WriteAllBytesAsync(path, content);

            var urlActual = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var urltoDB = Path.Combine(urlActual, conteiner, nameFile).Replace("\\","/");

            return urltoDB;

        }
    }
}
