using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ObserverDotnetVersion
{


    public struct ProgressInfo
    {
        public float percent;
        public int currentNum;
        public int maxNum;
    }

    public class UnSubscribe : IDisposable
    {
        private Action ondispos;
        public UnSubscribe(List<IObserver<ProgressInfo>> observers, IObserver<ProgressInfo> observer)
        {
            ondispos = () =>
            {
                if(observers.Contains(observer))
                {
                    observers.Remove(observer);
                }
            };
        }

        public void Dispose()
        {
            ondispos?.Invoke();
        }
    }


    public class FileDownloader : IObservable<ProgressInfo>
    {
        public void DownloadStart(string url)
        {
            ProgressInfo progressInfo = new ProgressInfo()
            {
                percent = 0,
                currentNum = 0,
                maxNum = 100
            };

            bool isErrorFork = false;
            for(int i =0; i < 100; i++)
            {
                progressInfo.currentNum++;
                progressInfo.percent = (float)progressInfo.currentNum / progressInfo.maxNum;
                DownloadUpdate(progressInfo);

                if(isErrorFork)
                {
                    DownloadError();
                    return;
                }
            }

            DownloadComplete();
        }

        

        private List<IObserver<ProgressInfo>> Observers = new List<IObserver<ProgressInfo>>();
        public IDisposable Subscribe(IObserver<ProgressInfo> observer)
        {
            if(!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }

            return new UnSubscribe(Observers, observer);
        }

        private void DownloadUpdate(in ProgressInfo info)
        {
            foreach (var ob in Observers)
            {
                ob.OnNext(info);
            }
        }

        private void DownloadComplete()
        {
            foreach (var ob in Observers)
            {
                ob.OnCompleted();
            }
        }

        private void DownloadError()
        {
            foreach(var ob in Observers)
            {
                ob.OnError(new Exception("Download Error!"));
            }
        }
    }



    

    public class ObserverDotnet : MonoBehaviour, IObserver<ProgressInfo>
    {
        IDisposable unsubscribe = null;
        // Start is called before the first frame update
        void Start()
        {
            FileDownloader downloader = new FileDownloader();
            unsubscribe = downloader.Subscribe(this);
            downloader.DownloadStart("test.com");
        }

        private void OnDestroy()
        {
            unsubscribe.Dispose();
        }


        public void OnCompleted()
        {
            Debug.Log($"OnComplete");
            //다운로드 완료!!
        }

        public void OnError(Exception error)
        {
            Debug.Log($"OnError! {error.Message}");
            //다운로드 실패!! 원인은 error
        }

        public void OnNext(ProgressInfo value)
        {
            Debug.Log($"OnUpdate {value.currentNum}/{value.maxNum} - {value.percent * 100}%");
            //다운로드 중...
        }

    }
}


