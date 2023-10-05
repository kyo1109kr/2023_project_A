using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController[] enemisToSpawn;               //���� ���� �迭 ��

    public Transform spawnpoint;  

    public float timeBetweenSpawns = 0.5f;                //���� ���� �ð�
    private float spawnCounter;                           //���ڸ� ī���� �ϴ� ���� �ð�


    public int amountToSpawn = 15;                        //�����ɶ� ���� ����



    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(amountToSpawn > 0 ) //�����ִ� ������ ���ڰ� ������
        {
            spawnCounter -= Time.deltaTime; //�����Ӹ��� �ð��� ���� ��Ŵ
            if(spawnCounter <= 0 )          //spawnCount 0 �����϶�
            {
                spawnCounter = timeBetweenSpawns;  //������ ���� ���� ���� �ð��� �ٽ� ����
                //Random.Range(0, enemiesToSpawn.Length)�迭���� ������ ���ؼ� �������� ���� , ��ġ�� �����̼� ��
                Instantiate(enemisToSpawn[Random.Range(0, enemisToSpawn.Length )], spawnpoint.position, spawnpoint.rotation);

                amountToSpawn--; //������ ���ڸ� ���ش�.
            }
        }
    }
}
