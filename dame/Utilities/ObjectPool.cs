using System;

namespace Utilities
{
    abstract public class ObjectPool<T>
    {
        protected Func<ObjectPool<T>,T> _objectGenerator;

        public ObjectPool(Func<ObjectPool<T>,T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            _objectGenerator = objectGenerator;
        }

        abstract public T Get();
        abstract public void Put(T item);
    }
}

