using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI text;

    EnemyPool ep;

    bool isCount = true;
    float gameTimer = 0.0f;
    int currentScore = 0;

    int wave1_enemy_value = 10;

    // Start is called before the first frame update
    void Start()
    {
        ep = GetComponent<EnemyPool>();

        for (int i = 0; i < wave1_enemy_value; i++)
        {
            ep.CreateEnemy(true, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountingTime();
        UpdateUI();
    }

    void UpdateUI()
    {
        //経過時間をテキスト表示
        text.text = "Time:" + gameTimer.ToString("f2") + "\t" + "Score:" + currentScore;
    }

    void CountingTime()
    {
        if(isCount)
        {
            gameTimer += Time.deltaTime;
        }
    }

    void ChangeFlag()
    {
        if(isCount)
        {
            isCount = false;
        }
        else
        {
            isCount = true;
        }
    }

    //スコアの加算
    public void AddScore(int score)
    {
        currentScore += score;
    }

    //スコアの減算
    public void SubScore(int score)
    {
        currentScore -= score;
    }
}
