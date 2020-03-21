using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace LeeChangi
{

    public struct ProcessWorker
    {
        public long index { get; private set; }
        public long CompleteTime { get; private set; }
        public ProcessWorker(long i, long c)
        {
            index = i;
            CompleteTime = c;
        }
        public bool IsComplete(long currentTime)
        {
            return CompleteTime < currentTime;
        }

        public void CompleteLogic()
        {

        }
    }


    public class InterLockedQueue<T>
    {
        private T[] buffers = null;
        private int MaxSize = 0;
        private int index = -1;
        public int Index => index;
        public InterLockedQueue(int size)
        {
            buffers = new T[size];
            MaxSize = size;
            index = -1;
        }

        public bool Push(T item)
        {
            if (MaxSize <= index)
            {
                Debug.LogError("Queue Is Full!");
                //Push 실패 큐가 다 찼다.
                return false;
            }

            int incValue = Interlocked.Increment(ref index);
            buffers[incValue] = item;
            return true;
        }

        public T Pop()
        {
            int decvalue = Interlocked.Decrement(ref index);
            T result = buffers[decvalue + 1];
            buffers[decvalue + 1] = default(T);
            return result;
        }

        public IEnumerator<T> PopAll()
        {
            int count = index + 1;
            for(int i =0;i<count;i++)
            {
                yield return Pop();
            }
        }
    }

    //실제로 되는지 안되는지는 확인을 하지 못했습니다.
    //스위칭 타임에 동기화가 있는지도 확인이 필요합니다.
    //그냥 만들어본겁니다.
    public class ThreadSafeManager
    {
        private InterLockedQueue<ProcessWorker>[] pendingList = new InterLockedQueue<ProcessWorker>[2];
        public ThreadSafeManager()
        {
            pendingList[0] = new InterLockedQueue<ProcessWorker>(10000);
            pendingList[1] = new InterLockedQueue<ProcessWorker>(10000);
        }
        private int index = 0;
        private void Switch()
        {
            index = 1 - index;
        }
        private List<ProcessWorker> workers = new List<ProcessWorker>();

        public void AddWorker(ProcessWorker worker)
        {
            pendingList[index].Push(worker);
        }

        public void UpdateLogic(long currentTime)
        {
            Debug.Log($"Count : {workers.Count}||First:{pendingList[0].Index}/Second{pendingList[1].Index}");
            int origin = index;
            Switch();
            var pending = pendingList[origin];
            var iter = pending.PopAll();
            
            HashSet<long> duplicateChecker = new HashSet<long>();
            while(iter.MoveNext())
            {
                if(duplicateChecker.Contains(iter.Current.index))
                {
                    Debug.LogError($"Error! {iter.Current.index}");
                }
                else
                {
                    duplicateChecker.Add(iter.Current.index);
                }
                workers.Add(iter.Current);
            }


            foreach (var worker in workers)
            {
                if (worker.IsComplete(currentTime))
                {
                    worker.CompleteLogic();

                }
            }
            workers.RemoveAll(x => x.CompleteTime < currentTime);
        }
    }



}
