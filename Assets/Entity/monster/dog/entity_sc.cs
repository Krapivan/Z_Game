using System.Collections;
using UnityEngine;

public class entity_sc : MonoBehaviour
{
    Vector3 _move_target;
    bool _is_move;
    [SerializeField] float _speed;
    [SerializeField] float _wandering_point_roll_time;


    private void FixedUpdate()
    {
        Wandering_Target_Roll();
        if (_is_move == true) Wandering_Move();
    }


    IEnumerator Wandering_Target_Roll()
    {
        float x = Random.Range(-5.0f, 5.1f);
        float y = Random.Range(-5.0f, 5.1f);
        _move_target = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        _is_move = true;
        yield return new WaitForSeconds(_wandering_point_roll_time);
    }
    void Wandering_Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _move_target, _speed);
        if (transform.position == _move_target)
        {
            _is_move = false;
        }
    }
}
