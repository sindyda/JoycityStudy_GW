using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class InComponentsData
{
    public double tempD1 = 0;
    public double tempD2 = 0;
    public double tempD3 = 0;
    public double tempD4 = 0;
    public double tempD5 = 0;
}


public class ComponentListData
{
    public long temp1 = 0;
    public long temp2 = 0;
    public long temp3 = 0;
    public long temp4 = 0;
    public long temp5 = 0;
    public long temp6 = 0;
    public long temp7 = 0;
    public long temp8 = 0;
    public long temp9 = 0;
    public long temp10 = 0;

    public InComponentsData inComponents = new InComponentsData();
}


public class KMS_DataCache : MonoBehaviour
{
    // 조건 1 2개의 리스트에서 Add를 일괄적으로 진행 ( 메모리 정렬 예상 )
    // 조건 3 2개의 리스트에서 Add를 따로따로 진행 ( 메모라 파편화 예상 ) 
    // 조건 2 2개의 리스트로 저장 후 로드
    // 조건 4 2개의 배열로 저장 후 로드
    
    List<ComponentListData> listData1 = new List<ComponentListData>();
    List<ComponentListData> listData2 = new List<ComponentListData>();
    ComponentListData[] arr1Data = new ComponentListData[1000000];
    ComponentListData[] arr2Data = new ComponentListData[1000000];
    int arrDataCount = 0;
    Stopwatch sw = new Stopwatch();

    public Text text = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Type_1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Type_2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartTimeCheck();
            Type_3();
            CompleteTimeCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartTimeCheck();
            Type_4();
            CompleteTimeCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartTimeCheck();
            Type_5();
            CompleteTimeCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartTimeCheck();
            Type_6();
            CompleteTimeCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartTimeCheck();
            Type_7();
            CompleteTimeCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartTimeCheck();
            Type_8();
            CompleteTimeCheck();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            text.text = "Clear Data";
            listData1.Clear();
            listData2.Clear();
            arrDataCount = 0;
            sw.Reset();
        }

    }

    void Type_1()
    {
        for (int i = 0; i < 1000000; ++i)
        {
            listData1.Add(new ComponentListData());
            listData2.Add(new ComponentListData());
        }
        StartTimeCheck();

        for (int i = 0; i < 1000000; ++i)
        {
            listData1[i].temp1 = 100;
            listData2[i].temp1 = 100;
        }

        CompleteTimeCheck();
    }

    void Type_2()
    {
        for (int i = 0; i < 1000000; ++i)
        {
            listData1.Add(new ComponentListData());
        }

        for (int i = 0; i < 1000000; ++i)
        {
            listData2.Add(new ComponentListData());
        }

        StartTimeCheck();

        for (int i = 0; i < 1000000; ++i)
        {
            listData1[i].temp1 = 100;
            listData2[i].temp1 = 100;
        }

        CompleteTimeCheck();
    }

    void Type_3()
    {
        StartTimeCheck();

        for (int i = 0; i < 1000000; ++i)
        {
            listData1.Add(new ComponentListData());
            listData2.Add(new ComponentListData());
        }

        for (int i = 0; i < 1000000; ++i)
        {
            listData1[i].temp1 = 100;
            listData2[i].temp1 = 100;
        }

        CompleteTimeCheck();
    }

    void Type_4()
    {
        StartTimeCheck();

        for (int i = 0; i < 1000000; ++i)
        {
            arr1Data[i] = new ComponentListData();
            arr2Data[i] = new ComponentListData();
        }

        for (int i = 0; i < 1000000; ++i)
        {
            if (arr1Data[i].temp1 == 0)
                arr1Data[i].temp1 = 100;
            if (arr2Data[i].temp1 == 0)
                arr2Data[i].temp1 = 100;
        }

        CompleteTimeCheck();
    }

    void Type_5()
    {

    }

    void Type_6()
    {

    }

    void Type_7()
    {

    }

    void Type_8()
    {

    }

    void StartTimeCheck()
    {
        sw.Start();
    }

    void CompleteTimeCheck()
    {
        sw.Stop();
        text.text = sw.ElapsedMilliseconds.ToString() + "ms";

    }

}