using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyFlag_soli : MonoBehaviour
{
    void Start()
    {
        root?.addChild(node01);
        root?.addChild(node02);

        node01?.addChild(node02);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            root?.render(new Vector3(0.1f,0,0), true);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            root?.render(new Vector3(-0.1f, 0, 0), true);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            node01?.render(new Vector3(-0.1f, 0, 0), true);
        }
    }

    public GraphNode_soli root;
    public GraphNode_soli node01;
    public GraphNode_soli node02;

    private Vector3 pos = Vector3.zero;

}
