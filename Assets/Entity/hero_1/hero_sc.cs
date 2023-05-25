using UnityEngine;

public class hero_sc : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Animator _an;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _an = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
        Shot();
    }


    public Vector3 _move_v;
    public float _move_spd = 10;
    public float _run_spd = 22;
    [SerializeField] float spd;
    void Pc_Move()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            //vy = 1f;
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            //vy = -1f;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            //vx = 1f;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            //vx = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //move
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.A) == true)
        {
            _an.SetBool("move", true);
        }
        else
        {
            _an.SetBool("move", false);
        }
        //run
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            _an.SetBool("run", true);
            spd = _run_spd;
        }
        else
        {
            _an.SetBool("run", false);
            spd = _move_spd;
        }
    }
    void Move()
    {
        //flip
        if (_move_v.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_move_v.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //move an
        if (_move_v != new Vector3(0,0,0))
        {
            _an.SetBool("move", true);
        }
        else
        {
            _an.SetBool("move", false);
        }

        //spd
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            _an.SetBool("run", true);
            spd = _run_spd;
        }
        else 
        {
            _an.SetBool("run", false);
            spd = _move_spd; 
        }

        _rb.velocity = new Vector2(_move_v.x * spd, _move_v.y * spd);
    }
    void Shot()
    {
        if (Input.GetKey(KeyCode.Space) == true && _an.GetBool("run") != true)
        {
            _an.SetBool("pistol_shot", true);
        }
        else
        {
            _an.SetBool("pistol_shot", false);
        }
    }


}
