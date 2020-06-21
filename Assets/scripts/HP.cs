using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] monster_chicken monster_Chicken;

    public Image HP_bar;


    // Start is called before the first frame update
    void Start()
    {
        HP_bar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        updateHPBar();
    }

    void updateHPBar()
    {
        HP_bar.fillAmount = (float)monster_Chicken.blood/5f;

    }
}
