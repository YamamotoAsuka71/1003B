using UnityEngine;
using TMPro;

public class Gamemanaget : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    bool isCount = true;

    float timer = 0.0f;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Counting();
        UpdateUI();
    }

    void UpdateUI()
    {
        //経過時間をテキスト表示
        text.text = "Time:" + timer.ToString("f2") + "\t" + "Score" + score;
    }

    void Counting()
    {
        if(isCount)
        {
            timer += Time.deltaTime;
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
}
