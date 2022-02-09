using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Text lifeTXT, bonusTXT;
    static int life, bonus;
    static bool isGameEnabled;
    // Start is called before the first frame update
    void Start()
    {
        lifeTXT = GameObject.Find("LifeCount").GetComponent<Text>();
        bonusTXT = GameObject.Find("BonusCount").GetComponent<Text>();
        life = 3;
        bonus = 0;
        isGameEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 0)
            life = 0;
        lifeTXT.text = life.ToString();
        bonusTXT.text = bonus.ToString();
    }

    public int getLife()
    {
        return life;
    }

    public void reduceLife()
    {
        life--;
    }

    public bool isGamePlaying()
    {
        return isGameEnabled;
    }

    public void disableGame()
    {
        isGameEnabled = false;
    }
    public void addBonus()
    {
        bonus++;
    }
}
