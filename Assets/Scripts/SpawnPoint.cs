using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{//阁胶磐 辆幅
    RockCrab,
    Raptor,
    Krugs,
    Red,
    Dragon
}

[System.Serializable]
class MonsterByLevel
{
    [SerializeField] public List<MonsterByLevelData> monsterByLevelData = new List<MonsterByLevelData>();
}
[System.Serializable]
public class MonsterByLevelData
{
    [SerializeField] public EnemyType enemyType;
}


public class SpawnPoint : MonoBehaviour
{
    public GameObject[] enemyPref;

    [SerializeField]
    private List<EnemyData> enemyDatas;

    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField] private List<MonsterByLevel> monsterByLevel = new List<MonsterByLevel>();

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(MonsterSpawn());
    }

    private IEnumerator MonsterSpawn()
    {
        while (true)
        {
            int playerLevel = playerController.level;
            for (int i = 0;i < monsterByLevel[playerLevel - 1].monsterByLevelData.Count;i++)
            {
                SpawnEnemy(monsterByLevel[playerLevel - 1].monsterByLevelData[i].enemyType);
                yield return new WaitForSeconds(1f);
            }
        }
    }
    public Enemy SpawnEnemy(EnemyType type)//利 积己
    {
        print(type + "积己");
        int spawnNum = Random.Range(0, spawnPoints.Length);
        var newEnemy = Instantiate(enemyPref[(int)type], spawnPoints[spawnNum]).GetComponent<Enemy>();
        newEnemy.EnemyData = enemyDatas[(int)type];
        return newEnemy;
    }
}
