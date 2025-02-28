using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int baseMoveSpeed;
    public float baseHP;
    public int startMoney;
    public int currentMoney;
    public int PlayerXP;

    public void ToDefault(int money)
    {
        currentMoney = money;
    }
    public void PlusMoney(int money)
    {
        currentMoney += money;
    }
    public bool MinusMoney(int money)
    {
        if (currentMoney >= money)
        {
            currentMoney -= money;
            return true;
        }
        else return false;
    }
}
