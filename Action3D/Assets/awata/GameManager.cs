using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI text;

    bool isCount = true;
    float gameTimer = 0.0f;
    int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
