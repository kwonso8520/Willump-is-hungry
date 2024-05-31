using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Enemy : MonoBehaviour//적의 움직임
{
    [SerializeField]
    EnemyData enemyData;
    public EnemyData EnemyData { get { return enemyData; } set { enemyData = value; } }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if((Vector3.zero.x - transform.parent.position.x) < 0)
        {
            transform.position += transform.right * -1 * enemyData.MoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.right * enemyData.MoveSpeed * Time.deltaTime;
        }
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
