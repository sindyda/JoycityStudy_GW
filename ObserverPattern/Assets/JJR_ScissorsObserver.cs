using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_ScissorsObserver : JJR_Observer
{
    const string myName = "가위 옵저버";
    // Start is called before the first frame update
    void Start()
    {
        var text = GetComponent<UnityEngine.UI.Text>();
        if (text != null)
        {
            text.text = myName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void onNofity(RockPaperScissors type)
    {
        var text = GetComponent<UnityEngine.UI.Text>();

        if (text == null)
        {
            return;
        }

        switch (type)
        {
            case RockPaperScissors.Rock:
                text.text = myName + " : 패";
                break;
            case RockPaperScissors.Paper:
                text.text = myName + " : 승";
                break;
            case RockPaperScissors.Scissors:
                text.text = myName + " : 무";
                break;
        }
    }
}
