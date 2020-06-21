using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planter : MonoBehaviour
{

    public int money = 0;


    const int REWARD_PER_CROPS = 5;
    int[] farm_planted=new int[12] { 0,0,0,0,0,0,0,0,0,0,0,0 };
    GameObject[] capsule = new GameObject[12];
    public ground[] farm = new ground[12];
    float[] plant_time = new float[12] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f,0.0f,0.0f,0.0f };
    [SerializeField] GameObject[] m_capsulePrefab=new GameObject[3];

    [SerializeField] GameUI my_gameui;
    bool plant_mode = false;
    public ground last_farm;
    private MeshRenderer last_renderer;
    private Color last_color;

    public cameracenter cameracenter;
    // Start is called before the first frame update
    void Start()
    {
    }

    public int getPlant(int i)
    {
        return farm_planted[i];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (last_renderer)
            {
                last_renderer.material.color = last_color;
            }
            my_gameui.setActionVicible(false);
            last_farm = null;
            last_renderer = null;
            plant_mode = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            plant_mode = false ;
            if (last_renderer)
            {
                last_renderer.material.color = last_color;
            }
        }
        if (Input.GetMouseButtonDown(0) && plant_mode)
        {
            FireRaycast();
        }
        if(Input.GetKeyDown(KeyCode.Z) && plant_mode)
        {
            for(int i=0;i<12;i++)
            {
                if (farm_planted[i] != 0)
                    continue;
                else
                {
                    farm_planted[i] = 1;
                    plant_time[i] = 0f;
                    var primitiveIns1 = GameObject.Instantiate(m_capsulePrefab[0]);
                    primitiveIns1.transform.SetParent(farm[i].transform, false);
                    capsule[i] = primitiveIns1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && plant_mode)
        {
            for (int i = 0; i < 12; i++)
            {
                if (farm_planted[i] != 0)
                    continue;
                else
                {
                    farm_planted[i] = 2;
                    plant_time[i] = 0f;
                    var primitiveIns1 = GameObject.Instantiate(m_capsulePrefab[1]);
                    primitiveIns1.transform.SetParent(farm[i].transform, false);
                    capsule[i] = primitiveIns1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.C) && plant_mode)
        {
            for (int i = 0; i < 12; i++)
            {
                if (farm_planted[i] != 0)
                    continue;
                else
                {
                    farm_planted[i] = 3;
                    plant_time[i] = 0f;
                    var primitiveIns1 = GameObject.Instantiate(m_capsulePrefab[2]);
                    primitiveIns1.transform.SetParent(farm[i].transform, false);
                    capsule[i] = primitiveIns1;
                }
            }
        }
        for (int i=0;i<12;i++)
        {
            if (farm_planted[i]!=0)
            {
                if (!capsule[i])
                    continue;
                float tmp = plant_time[i];
                if(!plant_mode)
                    plant_time[i] += Time.deltaTime;
                if ((int)(plant_time[i]/5)- (int)(tmp / 5)==1)
                    capsule[i].transform.localScale += new Vector3(10f, 10f, 10f);
                if (plant_time[i]>=10.0f && farm_planted[i]==1)
                {
                    GameObject.Destroy(capsule[i].gameObject);
                    money += REWARD_PER_CROPS;
                    farm_planted[i] = 0;
                    
                }
                else if (plant_time[i] >= 20.0f && farm_planted[i] == 2)
                {
                    GameObject.Destroy(capsule[i].gameObject);
                    money += 3*REWARD_PER_CROPS;
                    farm_planted[i] = 0;
                    
                }
                else if (plant_time[i] >= 30.0f && farm_planted[i] == 3)
                {
                    GameObject.Destroy(capsule[i].gameObject);
                    money += 5*REWARD_PER_CROPS;
                    farm_planted[i] = 0;
                    
                }
            }
        }

    }

    void FireRaycast()
    {

        Ray ray = cameracenter.camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.GetComponent<ground>())
            {
                if (last_renderer)
                {
                    last_renderer.material.color = last_color;
                }
                my_gameui.setActionVicible(true);
                last_renderer = hit.collider.GetComponent<MeshRenderer>();
                last_farm = hit.collider.GetComponent<ground>();
                last_color = last_renderer.material.color;
                if (last_farm != null)
                {
                    last_renderer.material.color = Color.green;
                }
            }
            
        }
    }
    public void Plant(int j)
    {
        if (j == -1)
            return;
        if (!last_renderer)
            Debug.Log("U must select where to plant first^^");
        else
        {
            for(int i=0;i<12;i++)
            {
                if(last_farm==farm[i])
                {
                    if(farm_planted[i]==0)
                    {
                        farm_planted[i] = j+1;
                        var primitiveIns1 = GameObject.Instantiate(m_capsulePrefab[j]);
                        primitiveIns1.transform.SetParent(last_farm.transform, false);
                        plant_time[i] = 0f;
                        capsule[i] = primitiveIns1;
                        break;
                    }
                }
            }
        }
    }
}
