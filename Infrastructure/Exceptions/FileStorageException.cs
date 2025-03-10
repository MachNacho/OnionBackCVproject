namespace Infrastructure.Exceptions
{
    public class FileStorageException : Exception
    {
        public FileStorageException(string message) : base(message) { }
    }
}
