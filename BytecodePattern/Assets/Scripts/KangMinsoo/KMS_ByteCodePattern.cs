using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum BYTE_CODE
{
    OBJECT_MOVE_Z = 0x01,
    OBJECT_ROTATION_X = 0x02,
    OBJECT_MOVE_X = 0x03,
    OBJECT_MOVE_Y = 0x04,
    OBJECT_HIDE = 0x05,
    OBJECT_SHOW = 0x06,
    OBJECT_ROTATION_Y = 0x07,
    OBJECT_ROTATION_Z = 0x08,
}

public class KMS_ByteCodePattern : MonoBehaviour
{
    public InputField inputfield = null;

    [HideInInspector]
    public float moveValue;
    [HideInInspector]
    public BYTE_CODE byteCommand;

    List<byte> bytecode = new List<byte>();

    public GameObject obj;

    int MAX_VALUE = 15;

    string Mask = "1234567890ABCDEF";
    Dictionary<char, int> charMap = new Dictionary<char, int>();
    string byteString = "";

    private void Start()
    {
        for (int i = 0; i < Mask.Length; ++i)
        {
            charMap[Mask[i]] = i + 1;
        }
    }

    public void CreateByteCode()
    {
        //int index = 0;
        //byteString += Mask[index];

        bytecode.Add((byte)byteCommand);

        if (moveValue > MAX_VALUE)
            moveValue = 15;

        switch (byteCommand)
        {
            case BYTE_CODE.OBJECT_MOVE_X:
            case BYTE_CODE.OBJECT_MOVE_Y:
            case BYTE_CODE.OBJECT_MOVE_Z:
            case BYTE_CODE.OBJECT_ROTATION_X:
            case BYTE_CODE.OBJECT_ROTATION_Y:
            case BYTE_CODE.OBJECT_ROTATION_Z:
                bytecode.Add((byte)moveValue);
                break;
            case BYTE_CODE.OBJECT_HIDE:
            case BYTE_CODE.OBJECT_SHOW:
                break;
        }

        inputfield.text = Encoding();
        moveValue = 0.0f;
    }

    string Encoding()
    {
        byteString = "";

        for (int i = 0; i < bytecode.Count; ++i)
        {
            byteString += Mask[bytecode[i] - 1];
        }

        return byteString;
    }

    public void MoveX()
    {
        byteCommand = BYTE_CODE.OBJECT_MOVE_X;
        moveValue += 1.0f;
    }

    public void MoveY()
    {
        byteCommand = BYTE_CODE.OBJECT_MOVE_Y;
        moveValue += 1.0f;
    }

    public void MoveZ()
    {
        byteCommand = BYTE_CODE.OBJECT_MOVE_Z;
        moveValue += 1.0f;
    }

    public void RotationX()
    {
        byteCommand = BYTE_CODE.OBJECT_ROTATION_X;
        moveValue += 1.0f;
    }

    public void RotationY()
    {
        byteCommand = BYTE_CODE.OBJECT_ROTATION_Y;
        moveValue += 1.0f;
    }

    public void RotationZ()
    {
        byteCommand = BYTE_CODE.OBJECT_ROTATION_Z;
        moveValue += 1.0f;
    }

    public void Hide()
    {
        byteCommand = BYTE_CODE.OBJECT_HIDE;
    }

    public void Show()
    {
        byteCommand = BYTE_CODE.OBJECT_SHOW;
    }

    public void Decoding()
    {
        bytecode.Clear();

        byteString = inputfield.text;

        for (int i = 0; i < byteString.Length; ++i)
        {
            bytecode.Add((byte)charMap[byteString[i]]);
        }

        StartCoroutine(Interpret());
    }

    IEnumerator Interpret()
    {
        for (int i = 0; i < bytecode.Count; ++i)
        {
            byte instrucion = bytecode[i];

            switch ((BYTE_CODE)instrucion)
            {
                case BYTE_CODE.OBJECT_MOVE_X:
                    obj.transform.localPosition = new Vector3(bytecode[++i], obj.transform.localPosition.y, obj.transform.localPosition.z);
                    break;
                case BYTE_CODE.OBJECT_MOVE_Y:
                    obj.transform.localPosition = new Vector3(obj.transform.localPosition.y, bytecode[++i], obj.transform.localPosition.z);
                    break;
                case BYTE_CODE.OBJECT_MOVE_Z:
                    obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, bytecode[++i]);
                    break;
                case BYTE_CODE.OBJECT_ROTATION_X:
                    obj.transform.Rotate(new Vector3(
                        bytecode[++i] * 10,
                        0, 
                        0));
                    break;
                case BYTE_CODE.OBJECT_ROTATION_Y:
                    obj.transform.Rotate(new Vector3(
                        0,
                        bytecode[++i] * 10, 
                        0));
                    break;
                case BYTE_CODE.OBJECT_ROTATION_Z:
                    obj.transform.Rotate(new Vector3(
                        0,
                        0, 
                        bytecode[++i] * 10));
                    break;
                case BYTE_CODE.OBJECT_HIDE:
                    obj.SetActive(false);
                    break;
                case BYTE_CODE.OBJECT_SHOW:
                    obj.SetActive(true);
                    break;
            }

            yield return new WaitForSeconds(1.0f);
        }

        yield break;
    }
}
