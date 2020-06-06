using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class une : MonoBehaviour
{
    const int MAX = 1000;
    class Array
    {
        protected GameObject _parentGo = null;
        protected List<GameObject> _datas = new List<GameObject>();
        private float time = 0F;

        public void Clear()
        {
            if (_parentGo != null)
            {
                foreach (GameObject data in _datas)
                {
                    Destroy(data.gameObject);
                }
                Destroy(_parentGo);
            }
        }
        virtual public float Calculate()
        {
            time = Time.realtimeSinceStartup;
            return time;
        }
        protected float Print(string name)
        {
            var stopTime = Time.realtimeSinceStartup;
            var diff = (stopTime - time) * 1000;
            Debug.LogFormat("<color=yellow>{0}</color> {1:f6}", name, diff);
            return diff;
        }
    }
    class ContinuousArray : Array
    {
        public ContinuousArray()
        {
            _parentGo = new GameObject("Continuous Array");
            for (int i = 0; i < MAX; ++i)
            {
                var childGo = new GameObject(string.Format("Continuous ", i));
                childGo.SetActive(Random.Range(0, 2) == 1);
                childGo.transform.SetParent(_parentGo.transform);
                _datas.Add(childGo);
            }
        }
        override public float Calculate()
        {
            base.Calculate();
            for (int i = 0; i < MAX; ++i)
            {
                var data = _datas[i];
                if (data.activeInHierarchy)
                    data.GetType();
            }

            return Print("Continuous");
        }
    }
    class SortingArray : Array
    {
        int _activeIndex = 0;
        public SortingArray(int randomIndex)
        {
            _parentGo = new GameObject("Sorting Array");
            _activeIndex = randomIndex;

            for (int i = 0; i < _activeIndex; ++i)
            {
                var childGo = new GameObject(string.Format("Sorting ", i));
                childGo.SetActive(false);
                childGo.transform.SetParent(_parentGo.transform);
                _datas.Add(childGo);
            }
        }
        override public float Calculate()
        {
            base.Calculate();
            for (int i = 0; i < _activeIndex; ++i)
            {
                var data = _datas[i];
                data.GetType();
            }

            return Print("Sorting");
        }
    }

    ContinuousArray _ca = null;
    SortingArray _sa = null;
    int _randomIndex = 0;
    bool _bBlock = false;

    List<float> _caTimes = new List<float>();
    List<float> _saTimes = new List<float>();

    [SerializeField]
    Text text = null;
    // Start is called before the first frame update
    void Start()
    {
        GetRandomIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if (_bBlock)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _ca?.Clear();
            _ca = new ContinuousArray();
            _caTimes.Add(_ca.Calculate());

            _bBlock = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _sa?.Clear();
            _sa = new SortingArray(1000);// _randomIndex);
            _saTimes.Add(_sa.Calculate());

            _bBlock = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GetRandomIndex();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            var str1 = GetAverageValue(_caTimes);
            var str2 = GetAverageValue(_saTimes);

            var str3 = string.Format("Continuous({0})\nSorting({1})", str1, str2);
            text.text = str3;
        }
    }
    void GetRandomIndex()
    {
        _randomIndex = Random.Range(5, MAX);
        Debug.Log("RandomIndex: " + _randomIndex);
    }

    string GetAverageValue(List<float> list)
    {
        if (list.Count > 0)
        {
            var sum = 0F;
            for (int i = 0; i < list.Count; ++i)
            {
                sum += list[i];
            }
            return string.Format("TotalCount:({0})Average:{1}", list.Count, sum / list.Count);
        }

        return string.Format("No information available.");
    }
}
