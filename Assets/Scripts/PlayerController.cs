using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerExp;
    public int level = 1;
    public float playerHp = 100;
    private float burnDamage = 1;
    private float _speed = 5f;
    private float maxHp = 100;
    [SerializeField]
    private Vector3[] sizeByLevel;
    // Start is called before the first frame update
    void OnEnable()
    {
        playerHp = maxHp;
    }
    private void Start()
    {
        StartCoroutine(SelfDamage());
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);
        Vector3 moveAmount = dir * _speed * Time.deltaTime;
        Vector3 newPosition = transform.position + moveAmount;
        transform.position = newPosition;

        if(playerExp >= (100 * level))
        {
            playerExp %= (100 * level);
            transform.localScale += sizeByLevel[level - 1];
            level++;
        }
        if(playerHp <= 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyComponent = collision.gameObject.GetComponent<Enemy>();
        //먹을 수 있는 레벨의 몬스터
        if (enemyComponent.EnemyData.EnemyType != "Dragon" && collision.tag == "Enemy" && level >= enemyComponent.EnemyData.Level)
        {
            if(playerHp + 10 <= maxHp)
            {
                playerHp += 10;
            }
            else if(playerHp + 10 >= maxHp)
            {
                playerHp = maxHp;
                
            }
            GameManager.instance.GetScore(enemyComponent.EnemyData.Score);
            playerExp += enemyComponent.EnemyData.Exp;
            collision.gameObject.SetActive(false);
        }
        //먹을 수 없는 몬스터
        else if (enemyComponent.EnemyData.EnemyType == "Dragon" || level < enemyComponent.EnemyData.Level)
        {
            playerHp -= 10 * enemyComponent.EnemyData.Level;
        }
        //아이템
        else if(collision.tag == "Item")
        {
            collision.gameObject.SetActive(false);
        }
    }
    private void Die()
    {
        Debug.Log("죽음");
    }
    IEnumerator SelfDamage()
    {
        while (true)
        {
            playerHp -= burnDamage;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
