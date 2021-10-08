using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int remainingLives = 3;
    public int caughtFishes = 0;

    public Text heartText;
    public Text caughtFishText;


    // Start is called before the first frame update
    void Start() {
        heartText.text = "" + remainingLives;
        caughtFishText.text = "" + caughtFishes;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void IncrementCaughtFish(){
        caughtFishes ++;
        caughtFishText.text = "" + caughtFishes;
    }

    public void Decrementhearts(){
        remainingLives --;
        heartText.text = "" + remainingLives;
    }
}
