using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KMS_DirtyFlagPattern : MonoBehaviour
{
    KMS_ComboSystem comboSystem = new KMS_ComboSystem();
    public Image comboGage = null;
    public Text comboText = null;
    public Text scoreText = null;
    public static int CalcCount = 0;
    float comboTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalcCount = 0;

            comboSystem.AddCombo();
            if (comboText != null)
                comboText.text = comboSystem.GetCurrentScore().ToString();
            if (scoreText != null)
                scoreText.text = comboSystem.GetComboCount().ToString();

            comboTimer = 1.0f;

            Debug.Log(CalcCount);
        }

        comboTimer -= Time.deltaTime;

        if (comboTimer < 0.0f)
        {
            comboSystem.ClearCombo();
        }
        if (comboGage != null)
            comboGage.fillAmount = comboTimer;
    }
}
