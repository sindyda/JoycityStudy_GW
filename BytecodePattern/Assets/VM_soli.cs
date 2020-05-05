using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VM_soli : MonoBehaviour
{
    enum Instruction : int
    {
        SET_COLOR = 0x00,
        SET_SIZE = 0x01,
        SET_ROTATION = 0x02
    }

    enum Instruction_Who : int
    {
        OUR = 0x00,
        OTHER = 0x01
    }

    enum Instruction_Color : int
    {
        BASIC = 0x00,
        RED = 0x01,
        YELLOW = 0x02,
        BLUE = 0x03,
        GREEN = 0x04
    }

    private const int MAX_STACK = 128;
    private int stackSize_ = 0;
    private int[] stack_ = new int[MAX_STACK];

    private Button button_our = null;
    private Button button_other = null;

    private Button button_apply = null;

    private Dropdown dropdown_whoColor = null;
    private Dropdown dropdown_whatColor = null;

    private Color color_ourBasic = new Color();
    private Color color_OtherBasic = new Color();

    private Dropdown dropdown_whoSize = null;
    private InputField inputField_width = null;
    private InputField inputField_height = null;

    void Start()
    {
        button_our = transform.Find("Button_Our").gameObject.GetComponent<Button>();
        button_other = transform.Find("Button_Other").gameObject.GetComponent<Button>();

        color_ourBasic = button_our.image.color;
        color_OtherBasic = button_other.image.color;

        button_apply = transform.Find("Change").transform.Find("Button_Apply").gameObject.GetComponent<Button>();

        dropdown_whoColor = transform.Find("Change").transform.Find("Dropdown_WhoColor").gameObject.GetComponent<Dropdown>();
        dropdown_whatColor = transform.Find("Change").transform.Find("Dropdown_WhatColor").gameObject.GetComponent<Dropdown>();

        dropdown_whoSize = transform.Find("Change").transform.Find("Dropdown_WhoSize").gameObject.GetComponent<Dropdown>();
        inputField_width = transform.Find("Change").transform.Find("InputField_Width").gameObject.GetComponent<InputField>();
        inputField_height = transform.Find("Change").transform.Find("InputField_Height").gameObject.GetComponent<InputField>();

        button_apply?.onClick.AddListener(setButtonEvent);
    }
    
    private void setButtonEvent()
    {
        push(dropdown_whoColor.value);
        push(dropdown_whatColor.value);
        push((int)Instruction.SET_COLOR);
        
        push(dropdown_whoSize.value);
        push(int.Parse(inputField_width.text));
        push(int.Parse(inputField_height.text));
        push((int)Instruction.SET_SIZE);

        interpret();
    }

    private void push(int value)
    {
        if (stackSize_ > MAX_STACK)
            return;

        stack_[stackSize_++] = value;
    }

    private int pop()
    {
        if (stackSize_ < 0)
            return 0;

        return stack_[--stackSize_];
    }

    private void setColor(int who, int color)
    {
        Color tempColor = new Color();

        switch (color)
        {
            case (int)Instruction_Color.BASIC:
                if (who == (int)Instruction_Who.OUR)
                    tempColor = color_ourBasic;
                else
                    tempColor = color_OtherBasic;
                break;
            case (int)Instruction_Color.RED:
                tempColor = Color.red;
                break;
            case (int)Instruction_Color.YELLOW:
                tempColor = Color.yellow;
                break;
            case (int)Instruction_Color.BLUE:
                tempColor = Color.blue;
                break;
            case (int)Instruction_Color.GREEN:
                tempColor = Color.green;
                break;
        }

        if (who == (int)Instruction_Who.OUR)
            button_our.image.color = tempColor;
        else
            button_other.image.color = tempColor;
    }

    private void setSize(int who, int width, int height)
    {
        if (who == (int)Instruction_Who.OUR)
            button_our.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        else
            button_other.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    public void interpret()
    {
        while (stackSize_ > 0)
        {
            int instruction = pop();
            switch (instruction)
            {
                case (char)Instruction.SET_COLOR:
                    int color = pop();
                    int who_color = pop();
                    setColor(who_color, color);
                    break;

                case (char)Instruction.SET_SIZE:
                    int height = pop();
                    int width = pop();
                    int who_size = pop();
                    setSize(who_size, width, height);
                    break;
            }
        }
    }
}
