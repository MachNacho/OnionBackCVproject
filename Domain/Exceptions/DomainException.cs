namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string entityName, int id) : base($"Entity '{entityName}' with ID {id} was not found") { }
    }
}
