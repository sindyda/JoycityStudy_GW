using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGL;

public class CGLCompData : CGL.ComponentBase
{
    public CGLCompData(GameObject obj) 
    {
        gameObject = obj;
    }
}


public class CGLCompExam : MonoBehaviour
{
    CGLCompData _compData = null;
    private void Awake()
    {
        _compData = new CGLCompData(gameObject);
        _compData.AddComponent<AudioComponent>();
        _compData.AddComponent<GraphicRenderComponent>();

    }

    public void GraphicDraw()
    {
        var draw = _compData.GetComponent<GraphicRenderComponent>();
        if (draw != null)
        {
            draw.RenderGraphic();
        }
    }

    public void PlaySound()
    {
        var sound = _compData.GetComponent<AudioComponent>();
        if (sound != null)
        {
            sound.PlaySound();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
