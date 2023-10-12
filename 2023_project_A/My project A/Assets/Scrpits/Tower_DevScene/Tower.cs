using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3.0f;             //���� ����
    public float fireRate = 1.0f;        //���� �ӵ�

    public LayerMask isEnemy;            //���̸� ���ؼ� �� ĳ���� ����

    public Collider[] colliderlnRange;   //���� ���� �ȿ� ������ Collider �迭

    public List<EnemyController> enemiesinRange = new List<EnemyController>(); //Collider �迭�� ���ؼ� ���� EnemyController List

    public float checkCounter;
    public float checkTime = 0.2f;       //���� ���� �ٽ� �����ϴ� �ð�

    public bool enemiesUpdate;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;  //0.2�ʸ� Counter�� �Է�
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkCounter -= Time.deltaTime;             //Counter�� ������ �ð��� ���� ���Ѽ� �ֱ������� üũ�ϰ� ����

        if(checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderlnRange = Physics.OverlapSphere(transform.position, range, isEnemy);//�ڽ��� ��ġ ,���� ,���̾�

            enemiesinRange.Clear();                                                     //List�� �ִ°� �ʱ�ȭ

            foreach (Collider col in colliderlnRange)                                    //colliderlnRange �迭����
            {
                enemiesinRange.Add(col.GetComponent<EnemyController>());                //EnemyController�� ��ƿͼ� List�� �ִ´�

            }
            enemiesUpdate = true;
        }
    }
}
