using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Object : MonoBehaviour
{
    bool isDirty = false;

    Vector3 localPosition { get { return _localPosition; } set { _localPosition = value; isDirty = true; } }
    Vector3 _localPosition = new Vector3();
    Vector3 worldPosition = new Vector3();

    JJR_Object childObject = null;
    // Start is called before the first frame update
    void Start()
    {
        localPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetChild(JJR_Object childObject)
    {
        if (childObject != null)
        {
            this.childObject = childObject;

            this.childObject.localPosition -= localPosition;
        }
    }

    public void Move(Vector3 addPosition)
    {
        localPosition += addPosition;
    }

    public void Apply(Vector3 parentPosition = new Vector3(), bool isDirty = false)
    {
        isDirty |= this.isDirty;
        if (isDirty)
        {
            worldPosition = parentPosition + localPosition;
            this.isDirty = false;
        }

        transform.position = worldPosition;

        if (childObject != null)
        {
            childObject.Apply(transform.position, isDirty);
        }
    }
}
