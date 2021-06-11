using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Rounds;

    public static int money; 
    public int startMoney = 400;

    public static int oxygen;
    public int startOxygen = 400;

    void Start ()
    {
        money = startMoney;
        Rounds = 0;
        oxygen = startOxygen;
    }

}
