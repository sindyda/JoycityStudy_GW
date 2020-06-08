using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode_soli : MonoBehaviour
{
    private void Start()
    {
        world_ = transform.localPosition;
        dirty_ = true;
        childNode_ = new List<GraphNode_soli>();
    }

    public void addChild(GraphNode_soli child)
    {
        if(child)
            childNode_.Add(child);
    }

    public void render(Vector3 pos, bool dirty)
    {
        dirty_ |= dirty;

        if (dirty)
        {
            world_ = getWorldPosition(pos);
            dirty_ = false;
        }

        changePosition(world_);

        for (int i = 0; i < childNode_.Count; ++i)
        {
            childNode_[i].render(world_, dirty);
        }
    }

    private Vector3 getWorldPosition(Vector3 pos)
    {
        return new Vector3(pos.x, 0, 0);
    }

    private void changePosition(Vector3 pos)
    {
        transform.localPosition += pos;
    }

    Vector3 world_;
    private bool dirty_;
    List<GraphNode_soli> childNode_;
}
