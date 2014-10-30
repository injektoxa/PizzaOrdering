using System;

namespace Pizza.Model
{
    /// <summary>
    /// Creates a unique identifier
    /// </summary>
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}