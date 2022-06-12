using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controls 
{
    public static bool Thrusting() 
    {
        return Input.GetKey(KeyCode.UpArrow);
    }
    public static bool TurnLeft() 
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
    public static bool TurnRight() 
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
    public static bool Firing ()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public static bool Teleporting ()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }
}
