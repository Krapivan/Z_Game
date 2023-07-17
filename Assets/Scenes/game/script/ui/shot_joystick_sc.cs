using UnityEngine;

public class shot_joystick_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;

    public hero_sc _hero_sc;

    public GameObject _stick;
    bool _touch;

    public void FixedUpdate()
    {
        Touch();
        Aiming();
    }
    void Bound()
    {
        float dist = Mathf.Sqrt(Mathf.Pow((0 - _stick.transform.localPosition.x), 2) + Mathf.Pow((0 - _stick.transform.localPosition.y), 2));
        float r = gameObject.GetComponent<RectTransform>().rect.width / 2;

        if (dist > r)
        {
            if (_stick.transform.localPosition.x > r)
            {
                _stick.transform.localPosition = new Vector3(r, _stick.transform.localPosition.y, 0);
            }
            if (_stick.transform.localPosition.x < r * -1)
            {
                _stick.transform.localPosition = new Vector3(r * -1, _stick.transform.localPosition.y, 0);
            }

            if (_stick.transform.localPosition.y > r)
            {
                _stick.transform.localPosition = new Vector3(_stick.transform.localPosition.x, r, 0);
            }
            if (_stick.transform.localPosition.y < r * -1)
            {
                _stick.transform.localPosition = new Vector3(_stick.transform.localPosition.x, r * -1, 0);
            }
        }
    }

    public void B_Down()
    {
        if (_inv_db._chosen_wp != null)
        {
            _touch = true;
            _hero_sc._arm_an.enabled = false;
        }
    }
    public void B_Up()
    {
        if (_touch == true && _inv_db._chosen_wp != null)
        {
            var dir = _stick.transform.position - transform.position;
            var ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Atack(ang);
            _touch = false;
            _hero_sc._arm_an.enabled = true;
        }
    }

    void Touch()
    {
        if (_touch == true)
        {
            Vector3 t_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _stick.transform.position = new Vector3(t_pos.x, t_pos.y, 0);
            Bound();
        }
        else if (_touch == false)
        {
            _stick.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    void Aiming()
    {
        if (_touch == true)
        {
            var dir = _stick.transform.position - transform.position;
            var ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (_hero_sc.transform.localScale.x == 1)
            {
                if (ang >= 0 && ang > 50)
                {
                    ang = 50;
                }
                else if (ang < 0 && ang < -50)
                {
                    ang = -50;
                }
                _hero_sc._arm_1.transform.rotation = Quaternion.Euler(0, 0, ang);
            }
            else if (_hero_sc.transform.localScale.x == -1)
            {
                if (ang >= 0 && ang < 130)
                {
                    ang = 130;
                }
                else if (ang < 0 && ang > -130)
                {
                    ang = -130;
                }
                _hero_sc._arm_1.transform.rotation = Quaternion.Euler(0, 0, ang + 180);
            }
        }
    }


    void Atack(float ang)
    {
        GameObject weapon = _inv_db._chosen_wp;
        weapon.GetComponent<item_sc>().Attack(ang);
    }
}
