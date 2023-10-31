using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
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
        //�o�ߎ��Ԃ��e�L�X�g�\��
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

    //�X�R�A�̉��Z
    public void AddScore(int score)
    {
        current_score += score;
    }

    //�X�R�A�̌��Z
    public void SubScore(int score)
    {
        current_score -= score;
    }
}
