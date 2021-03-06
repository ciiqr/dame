﻿using System;
using System.Collections.Generic;

namespace dame.Utilities
{
    public class GeneralObjectPool<T> : ObjectPool<T>
    {
        private Queue<T> _objects;

        public GeneralObjectPool(Func<ObjectPool<T>,T> objectGenerator) : base(objectGenerator)
        {
            _objects = new Queue<T>();
        }

        override public T Get()
        {
            if (_objects.Count > 0)
                return _objects.Dequeue();
            else
                return _objectGenerator(this);
        }

        override public T TryGet()
        {
            if (_objects.Count > 0)
                return _objects.Dequeue();
            else
                return default(T);
        }

        override public void Put(T item)
        {
            _objects.Enqueue(item);
        }
    }
}

