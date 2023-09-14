using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
       public static Singleton Instance { get; private set; }               //�ν��Ͻ��� ������ ����

    private void Awake()
    {
        if(Instance == null)                                               //lnstance�� NULL�˶�
        {
            Instance = this;                                                //���� ������Ʈ�� Scene��
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);                                            //1���� ������Ű�� ����
        }
    }

public int playerScore = 0;                                                //������ �÷��̾� ���ھ�

    public void InscreaseScore(int amount)                                //�Լ��� ���ؼ� ���ھ
    {
        playerScore += amount;
    }
}