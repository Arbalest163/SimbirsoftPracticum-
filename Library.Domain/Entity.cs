using System;

namespace Library.Domain
{
    /// <summary>
    /// Базовый класс для сущностей, имеющих Id
    /// </summary>
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
