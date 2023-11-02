using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTower : MonoBehaviour
{

    private Tower thisTower;
    // Start is called before the first frame update
    void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisTower. enemiesUpdate) //�� ����Ʈ�� ���� �Ǿ��� ��
        {
            if(thisTower.enemiesinRange.Count > 0) //���� �ȿ� ���� ������ ��
            {
                foreach(EnemyController enemy in thisTower. enemiesinRange)
                {
                    enemy.SetMode(thisTower.fireRate);  //���ο� ����
                }
            }
        }
    }
}
