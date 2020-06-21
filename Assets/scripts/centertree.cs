using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class centertree : MonoBehaviour
{
    [SerializeField] ground center;
    public float time_to_win = 500.0f;
    [SerializeField] GameObject centerTree;
    GameObject tree;
    bool plant_mode = false;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        var primitiveIns1 = GameObject.Instantiate(centerTree);
        primitiveIns1.transform.SetParent(center.transform, false);
        tree = primitiveIns1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            plant_mode = true;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            plant_mode = false;
        float tmp = time_to_win;
        if(!plant_mode)
            time_to_win -= Time.deltaTime;
        if ((int)(tmp / 50) - (int)(time_to_win / 50) == 1)
            tree.transform.localScale += new Vector3(0.2f, 0f, 0.2f);
        if(time_to_win<0)
        {
            SceneManager.LoadScene(2);
        }
        if(!center)
        {
            SceneManager.LoadScene(3);
        }
    }
    
    public void irrigate()
    {
        float tmp = time_to_win;
        time_to_win -= 10f;
        if ((int)(tmp / 50) - (int)(time_to_win / 50) == 1)
            tree.transform.localScale += new Vector3(0.2f, 0f, 0.2f);
    }

}
