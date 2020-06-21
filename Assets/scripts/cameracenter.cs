using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracenter : MonoBehaviour
{
    [SerializeField] Camera[] m_Cameras = new Camera[5];
    Camera cur_camera;
    public Camera camera { get { return cur_camera; } }
    public bool PlantMode {get{return cur_camera==m_Cameras[0];}}
    // Start is called before the first frame update
    void Start()
    {
        SelectCamera(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectCamera(3);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectCamera(2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectCamera(4);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectCamera(0);
        }
    }


    void SelectCamera(int index)
    {
        cur_camera = m_Cameras[index];
        for (int i = 0; i < m_Cameras.Length; i++)
        {
            m_Cameras[i].enabled = i == index;
        }
    }
}
