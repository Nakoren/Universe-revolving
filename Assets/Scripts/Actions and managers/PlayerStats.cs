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
}
