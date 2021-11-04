using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCurrencies : MonoBehaviour
{
    public int coins;
    int oldCoinAmount;
    [SerializeField]float lerpedCoins;
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
            if(lerpedCoins < coins)
            {
                lerpedCoins ++;
                coinValueText.text = lerpedCoins.ToString();

            }
            else if(lerpedCoins > coins)
            {
                lerpedCoins -= 2;
                coinValueText.text = lerpedCoins.ToString();
            }


            if (lerpedCoins == coins)
            {
                setCoinLerp = false;
            }
        }
    }
    private void Start()
    {
        
        
    }

    public void setCoins(int amount)
    {
        oldCoinAmount = coins;
        lerpedCoins = oldCoinAmount;
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
