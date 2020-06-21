using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster_generator : MonoBehaviour
{
    [SerializeField] GameObject chicken;
    [SerializeField] GameObject kiwi;
    [SerializeField] GameObject langsat;
    [SerializeField] centertree centertree;

    int level = 4;
    public cameracenter cameracenter;
    float MONSTER_GEN_PERIOD = 10.0f;
    const float MONSTER_INIT_DIS=44.0f;
    int monster_gen_time = 0;
    float time = 0f;
    float scale1 = 0.8f;
    float scale2 = 0.9f;
    GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePrimitives();
    }

    // Update is called once per frame
    void Update()
    {
        if(!cameracenter.PlantMode)
        {
            time += Time.deltaTime;
            if (time> MONSTER_GEN_PERIOD)
            {
                time = 0;
                monster_gen_time++;
                GeneratePrimitives();
            }
        }

        if(level*100>centertree.time_to_win)
        {
            level -= 1;
            MONSTER_GEN_PERIOD -= 1;
            scale1 -= 0.2f;
            scale2 -= 0.1f;
        }
    }
    void GeneratePrimitives()
    {
        float tmp = Random.Range(-20f, 20f);
        float tmp1= Random.Range(0f, 1f);
        decide(tmp1);
        var primitiveIns1 = GameObject.Instantiate(a);
        tmp1 = Random.Range(0f, 1f);
        decide(tmp1);
        var primitiveIns2 = GameObject.Instantiate(a);
        tmp1 = Random.Range(0f, 1f);
        decide(tmp1);
        var primitiveIns3 = GameObject.Instantiate(a);
        tmp1 = Random.Range(0f, 1f);
        decide(tmp1);
        var primitiveIns4 = GameObject.Instantiate(a);
        primitiveIns1.transform.localPosition = new Vector3(MONSTER_INIT_DIS, 0f,tmp);
        primitiveIns1.transform.Rotate(0, 180.0f, 0);
        primitiveIns2.transform.localPosition = new Vector3(-MONSTER_INIT_DIS, 0f, tmp);
        primitiveIns3.transform.localPosition = new Vector3(tmp, 0f, MONSTER_INIT_DIS);
        primitiveIns3.transform.Rotate(0, 90.0f, 0);
        primitiveIns4.transform.localPosition = new Vector3(tmp, 0f, -MONSTER_INIT_DIS);
        primitiveIns4.transform.Rotate(0, -90.0f, 0);

    }

    void decide(float tmp)
    {
        if (tmp < scale1)
            a = chicken;
        else if (tmp > scale2)
            a = kiwi;
        else
            a = langsat;
    }
}
