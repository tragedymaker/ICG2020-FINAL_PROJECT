using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpLang: MonoBehaviour
{

    [SerializeField] monster_langset monster_Langset;

    public Image HP_bar;


    // Start is called before the first frame update
    void Start()
    {
        HP_bar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        updateBlood();
    }

    void updateBlood()
    {
        HP_bar.fillAmount = (float)monster_Langset.blood / 20f;

    }
}
