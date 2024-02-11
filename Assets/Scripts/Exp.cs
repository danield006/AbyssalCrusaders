using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public int exp;
    public int level;
    public int cap;
    void Start()
    {
        exp = 0;
        level = 1;
        cap = Mathf.RoundToInt( 0.04f * (1 ^ 3) + 0.8f * (1 ^ 2) + 2 * 1);
    }

    void Update()
    {
        if(exp >= cap) {
            levelUp();
        }
    }
    private void levelUp() {
        level++;
        exp = exp - cap;
        cap = Mathf.RoundToInt( 0.04f * (level ^ 3) + 0.8f * (level ^ 2) + 2 * level);
    }
    public void setExp(int gain) {
        exp += gain;
    }
}
