using UnityEngine;

public class bullet_sc : MonoBehaviour
{
    public Rigidbody2D _rb;

    [SerializeField] float _shot_range_now, _shot_range_mx;
    [SerializeField] float _bullet_speed;
    [SerializeField] bool _can_move = false;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Get_Setting(float shot_range_mx, float bullet_speed)
    {
        _shot_range_now = 0;
        _shot_range_mx = shot_range_mx;
        _bullet_speed = bullet_speed;

        _can_move = true;
    }

    void Move()
    {
        if (_can_move == true)
        {
            _rb.velocity = transform.right * _bullet_speed;
        }
    }
}
