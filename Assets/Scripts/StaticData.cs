using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    //timer
    public static int surviveMin;
    public static int surviveSec;

    //player stats
    public static int playerMaxHealth = 10; //damage
    public static int playerAttack = 1; //damage
    public static int playerLevel = 1; //exp
    public static int playerExp = 0; //exp
    public static float playerSpeed = 200f; //playercontroller
    public static float playerDashCooldown = 5f; //playercontroller
    public static float playerDashForce = 1.25f; //playercontroller
    public static float playerReloadTime = 1.25f; //bullet

    //misc
    public static int level;
}
