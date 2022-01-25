
namespace Library.Domain
{
    /// <summary>
    /// Базовый класс для сущностей, имеющих имя
    /// </summary>
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }
    }
}
