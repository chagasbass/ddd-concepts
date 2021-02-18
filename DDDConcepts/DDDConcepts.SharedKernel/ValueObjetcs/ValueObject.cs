using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDDConcepts.SharedKernel.ValueObjetcs
{
    /// <summary>
    /// Classe base para objetos de valor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            T other = obj as T;

            return Equals(other);
        }

        public virtual bool Equals(T other)
        {
            if (other is null)
                return false;

            Type t = GetType();
            Type otherType = other.GetType();

            if (t != otherType)
                return false;

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in  fields)
            {
                object valueOne = field.GetValue(other);
                object valueTwo = field.GetValue(this);

                if (valueOne is null)
                {
                    if (valueTwo != null)
                        return false;
                }
                else if (!valueOne.Equals(valueTwo))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();

            int valorInicial = 17;
            int multiplicador = 59;

            int hashCode = valorInicial;

            foreach (var field in fields)
            {
                object value = field.GetValue(this);

                if (value != null)
                    hashCode = hashCode * multiplicador + value.GetHashCode();
            }

            return hashCode;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();

            List<FieldInfo> fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y) => x.Equals(y);

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y) => !(x == y);
    }
}
