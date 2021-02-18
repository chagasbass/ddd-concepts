using System;

namespace DDDConcepts.SharedKernel.Entities
{
    public abstract class Entity<T> :IEquatable<Entity<T>>
    {
       public T Id { get; protected set; }

        protected Entity(T id)
        {
            if (object.Equals(id, default(T)))
                throw new ArgumentException("Id invalido");

            Id = id;
        }

        protected Entity() { }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity<T>;

            if (entity != null)
                return this.Equals(entity);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<T> other)
        {
            if (other == null)
                return false;

            return this.Id.Equals(other.Id);
        }
    }
}
