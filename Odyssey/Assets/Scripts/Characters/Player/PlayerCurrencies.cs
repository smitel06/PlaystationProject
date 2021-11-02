using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCurrencies : MonoBehaviour
{
    public int coins;
    int oldCoinAmount;
    float lerpedCoins;
    [SerializeField] TextMeshProUGUI coinValueText;
    public int gems;
    [SerializeField] TextMeshProUGUI gemValueText;
    public int keys;
    [SerializeField] TextMeshProUGUI keyValueText;
    bool setCoinLerp;

    private void FixedUpdate()
    {
        if(setCoinLerp)
        {
            if(lerpedCoins != coins)
            {
                lerpedCoins ++;
                coinValueText.text = lerpedCoins.ToString();
            }

            if(lerpedCoins == coins)
            {
                setCoinLerp = false;
            }
        }
    }
    private void Start()
    {
        //always start with no coins
        setCoins(0);
    }

    public void setCoins(int amount)
    {
        lerpedCoins = oldCoinAmount;
        oldCoinAmount = coins;
        coins += amount;
        setCoinLerp = true;
    }

    public void setGems(int amount)
    {
        gems += amount;
        gemValueText.text = gems.ToString();
    }

    public void setKeys(int amount)
    {
        keys += amount;
        keyValueText.text = keys.ToString();
    }
}
