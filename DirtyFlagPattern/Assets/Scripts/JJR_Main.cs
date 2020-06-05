using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Main : MonoBehaviour
{
    public List<JJR_Object> objects = new List<JJR_Object>();
    int selectIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objects.Count - 1; ++i)
        {
            objects[i].SetChild(objects[i + 1]);
        }

        var firstObject = GetFirstObject();
        if (firstObject != null)
        {
            firstObject.Apply();
        }

        ChangeSelectObject(0);
    }

    JJR_Object GetSelectObject()
    {
        if (selectIndex < 0 || selectIndex >= objects.Count)
        {
            return null;
        }

        return objects[selectIndex];
    }

    JJR_Object GetFirstObject()
    {
        if (objects.Count < 0)
        {
            return null;
        }

        return objects[0];
    }

    void ChangeSelectObject(int selectIndex)
    {
        if (selectIndex >= objects.Count)
        {
            selectIndex = 0;
        }

        var befSelectObject = GetSelectObject();
        if (befSelectObject)
        {
            befSelectObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }

        this.selectIndex = selectIndex;

        var selectObject = GetSelectObject();
        if (selectObject != null)
        {
            selectObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var firstObject = GetFirstObject();
        if (firstObject != null)
        {
            firstObject.Apply();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSelectObject(selectIndex + 1);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            var selectObject = GetSelectObject();
            if (selectObject != null)
            {
                selectObject.Move(new Vector3(0, 0.1f));
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            var selectObject = GetSelectObject();
            if (selectObject != null)
            {
                selectObject.Move(new Vector3(0, -0.1f));
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            var selectObject = GetSelectObject();
            if (selectObject != null)
            {
                selectObject.Move(new Vector3(-0.1f, 0));
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            var selectObject = GetSelectObject();
            if (selectObject != null)
            {
                selectObject.Move(new Vector3(0.1f, 0));
            }
        }
    }
}
