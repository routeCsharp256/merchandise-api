using System;

namespace CSharpCourse.MerchandiseApi.Domain.Root
{
    /// <summary>
    /// Общее доменное исключение
    /// TODO: лучше использовать определенные исключения для конкретных случаев
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string description)
            : base(description)
        {
        }

        public DomainException(string description, Exception innerException)
            : base(description, innerException)
        {
        }
    }
}
