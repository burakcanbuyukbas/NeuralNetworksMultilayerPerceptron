﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlpProject.models
{
    class ValidationHistory<T> : IEnumerable<T>
    {
        private readonly Queue<T> _queue;
        private readonly int _maxCount;

        public ValidationHistory(int maxCount)
        {
            _maxCount = maxCount;
            _queue = new Queue<T>(maxCount);
        }

        public void Add(T item)
        {
            if (_queue.Count == _maxCount)
                _queue.Dequeue();
            _queue.Enqueue(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
