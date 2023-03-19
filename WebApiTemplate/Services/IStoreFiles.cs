namespace WebApiTemplate.Services;

public interface IStoreFiles
{
    Task<String> EditFiles(byte[] content, string extension, string conteiner, string path, string contentType);
    Task DeleteFiles(string path, string conteiner);
    Task<String> SaveFiles(byte[] content, string extension, string conteiner, string contentType);
}