using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
       public static Singleton Instance { get; private set; }               //인스턴스를 전역에 선언

    private void Awake()
    {
        if(Instance == null)                                               //lnstance가 NULL알때
        {
            Instance = this;                                                //게임 오브젝트가 Scene이
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);                                            //1개로 유지시키기 위해
        }
    }

public int playerScore = 0;                                                //관리할 플레이어 스코어

    public void InscreaseScore(int amount)                                //함수를 통해서 스코어를
    {
        playerScore += amount;
    }
}