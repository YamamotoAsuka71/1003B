using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossController : MonoBehaviour
{
    int hp = 1000;
    int bind_damage = 48;
    int push_damage = 52;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BindAttack(int player_hp)
    {
        player_hp -= bind_damage;
    }

    public void PushAttack(int player_hp)
    {
        player_hp -= push_damage;
    }
}
