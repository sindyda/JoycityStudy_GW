using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_ProtoType
{
    public GameObject obj = null;
    public List<Vector3> position = new List<Vector3>();
    public List<Vector3> scale = new List<Vector3>();
    public List<Vector3> rotation = new List<Vector3>();

    Vector3 originalPosition;

    public JJR_ProtoType()
    {

    }

    public JJR_ProtoType(GameObject obj, List<Vector3> position, List<Vector3> scale, List<Vector3> rotation)
    {
        this.obj = obj;
        this.position = new List<Vector3>(position);
        this.scale = new List<Vector3>(scale);
        this.rotation = new List<Vector3>(rotation);
    }

    virtual public JJR_ProtoType Clone()
    {
        var newObject = GameObject.Instantiate(obj);
        var clone = new JJR_ProtoType(newObject, position, scale, rotation);

        if (clone.obj != null)
        {
            clone.obj.transform.position = clone.obj.transform.position + new Vector3(0, -1.5f, 0);
            clone.originalPosition = clone.obj.transform.position;
        }

        return clone;
    }

    public void Update()
    {
        if (obj != null)
        {
            for (int i = 0; i < position.Count; ++i)
            {
                obj.transform.position = originalPosition + position[i];
            }

            for (int i = 0; i < scale.Count; ++i)
            {
                obj.transform.localScale = scale[i];
            }

            for (int i = 0; i < rotation.Count; ++i)
            {
                obj.transform.Rotate(rotation[i]);
            }
        }
    }



    
}

public class JJR_Spawner
{
    public JJR_ProtoType spawnMove(JJR_ProtoType protoType)
    {
        var clone = protoType.Clone();
        int posX = Random.Range(1, 2);
        clone.position.Add(new Vector3(posX, 0, 0));
        return clone;
    }

    public JJR_ProtoType spawnScale(JJR_ProtoType protoType)
    {
        var clone = protoType.Clone();
        int scaleX = Random.Range(0, 300);
        int scaleY = Random.Range(0, 300);
        int scaleZ = Random.Range(0, 300);
        clone.scale.Add(new Vector3(scaleX / 100.0f, scaleY / 100.0f, scaleZ / 100.0f));
        return clone;
    }

    public JJR_ProtoType spawnRotation(JJR_ProtoType protoType)
    {
        var clone = protoType.Clone();

        int rotationX = Random.Range(0, 360);
        int rotationY = Random.Range(0, 360);
        int rotationZ = Random.Range(0, 360);
        clone.rotation.Add(new Vector3(rotationX, rotationY, rotationZ));

        return clone;
    }
}

