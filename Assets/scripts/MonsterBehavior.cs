using System.Collections;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    GameObject farm;
    const float MONSTER_VEL = 5.0f;
    public int blood = 5;
    bool died = false;
    bool died2 = false;

    bool move = true;
    private Animator animator;
    public bool walking = true;
    public bool attacking = false;
    

    bool can_move = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        this.transform.Rotate(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            can_move = false;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            can_move = true;
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("walking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("attacking", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("attacking", false);
            //transform.Translate(0, 0,  Time.deltaTime * 20);
        }*/
        if(farm)
        {
            move = false;
            animator.SetBool("walking", false);
            animator.SetBool("attacking", true);
            
        }
        else
        {
            if (!move)
            {
                Vector3 origin = new Vector3 (0, 0, 0);
                this.transform.LookAt (origin);
                /*
                float radius = -Mathf.Atan(this.transform.position.z / this.transform.position.x);
                Debug.Log(radius);
                float tmp = (Mathf.Abs(radius)<1.0f)?(radius*180 / Mathf.PI):(-180/Mathf.PI/radius);
                Debug.Log(tmp);
                Debug.Log(this.transform.position.z );
                Debug.Log(this.transform.position.x);

                this.transform.Rotate(0, tmp, 0);*/
            }
            move = true;
            animator.SetBool("walking", true);
            animator.SetBool("attacking", false);
 
        }
        if(can_move)
        {
            if (died2)

                GameObject.Destroy(this.gameObject);
            if (died)
                died2 = died;
            if (blood == 0)
            {
                this.transform.Translate(MONSTER_VEL * 100 * Vector3.up);
                died = true;
            }
            if(move)
                transform.Translate(0, 0, Time.deltaTime * MONSTER_VEL);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (!farm)
            farm = other.gameObject;
    }

}
