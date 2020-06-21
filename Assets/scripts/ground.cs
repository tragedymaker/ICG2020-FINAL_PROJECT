
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public planter planter;
    private Color original;
    MeshRenderer m_MeshRenderer;
    public float blood = 30.0f;
    public int blood_tmp  { get{return (int)blood; }}
    bool plant_mode = false;
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = this.GetComponent<MeshRenderer>();
        original = m_MeshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (blood_tmp == 0)
        {
            GameObject.Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            plant_mode = true;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            plant_mode = false;
    }
    void OnTriggerEnter(Collider other)
    {
    }
    void OnTriggerStay(Collider other)
    {
        float multiplier = 1f ;
        for(int i=0;i<12;i++)
        {
            if(this==planter.farm[i])
            {
                if (planter.getPlant(i) == 0 || planter.getPlant(i) == 1)
                    multiplier = 1;
                else if (planter.getPlant(i) == 2)
                    multiplier = 1.5f;
                else
                    multiplier = 2.0f;
                //Debug.Log(multiplier);

                break;
            }
        }
        if (!plant_mode)
        {
            m_MeshRenderer.material.color = Color.red;
            blood -= Time.deltaTime*multiplier;
        }
    }
    void OnTriggerExit(Collider other)
    {
        m_MeshRenderer.material.color = original;
    }
}
