namespace Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message) : base(message) { }
        public InfrastructureException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class DatabaseConnectionException : InfrastructureException
    {
        public DatabaseConnectionException(string connectionString)
            : base($"Failed to connect to database with connection: {connectionString}") { }
    }
}
