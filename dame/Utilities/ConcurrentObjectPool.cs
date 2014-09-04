using System;
using System.Collections.Concurrent;

namespace dame.Utilities
{
    public class ConcurrentObjectPool<T> : ObjectPool<T>
    {
        private ConcurrentBag<T> _objects;

        public ConcurrentObjectPool(Func<ObjectPool<T>,T> objectGenerator) : base(objectGenerator)
        {
            _objects = new ConcurrentBag<T>();
        }

        override public T Get()
        {
            T item;
            if (_objects.TryTake(out item))
                return item;
            return _objectGenerator(this);
        }

        override public T TryGet()
        {
            T item;
            _objects.TryTake(out item);
            return item;
        }

        override public void Put(T item)
        {
            _objects.Add(item);
        }
    }
}

