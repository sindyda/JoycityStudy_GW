using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class JJR_Logger
{
    abstract public void Log(string log);
}

public class JJR_NormalLogger : JJR_Logger
{
    override public void Log(string log)
    {
        Debug.Log(log);
    }
}

public class JJR_ColorLogger : JJR_Logger
{
    override public void Log(string log)
    {
        string colorLog = string.Format("<color=yellow>{0}</color>", log);
        Debug.Log(colorLog);
    }
}

public class JJR_NullLogger : JJR_Logger
{
    override public void Log(string log)
    {
    }
}

public class Locator
{
    static JJR_Logger logService = null;

    static public JJR_Logger GetLogger()
    {
        Debug.Assert(logService != null);

        return logService;
    }

    static public void Provide(JJR_Logger logService)
    {
        Debug.Assert(logService != null);

        Locator.logService = logService;
    }
}


public class JJR_Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Locator.Provide(new JJR_NormalLogger());
        InvokeRepeating("PrintLog", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Locator.Provide(new JJR_NormalLogger());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Locator.Provide(new JJR_ColorLogger());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Locator.Provide(new JJR_NullLogger());
        }
    }

    void PrintLog()
    {
        Locator.GetLogger().Log(string.Format("Test Log! - {0}", Time.renderedFrameCount));
    }
}
