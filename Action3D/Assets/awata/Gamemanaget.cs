using UnityEngine;
using TMPro;

public class Gamemanaget : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    bool isCount = true;
    float game_timer = 0.0f;
    int current_score = 0;

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
        text.text = "Time:" + game_timer.ToString("f2") + "\t" + "Score" + current_score;
    }

    void CountingTime()
    {
        if(isCount)
        {
            game_timer += Time.deltaTime;
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
    void AddScore(int score)
    {
        current_score += score;
    }

    //スコアの減算
    void SubScore(int score)
    {
        current_score -= score;
    }
}
