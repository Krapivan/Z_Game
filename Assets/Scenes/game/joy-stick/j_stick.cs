using UnityEngine;

public class j_stick : MonoBehaviour
{
    public hero_sc _hero_sc;
    public Canvas _canvas;
    public Camera _cam;

    public GameObject _stick;
    bool _touch;

    public void FixedUpdate()
    {
        if (_touch == true)
        {
            Vector3 t_pos = _cam.ScreenToWorldPoint(Input.mousePosition);
            _stick.transform.position = new Vector3(t_pos.x, t_pos.y, _canvas.transform.position.z);
            Bound();
            if (Vector().x != 0 || Vector().y != 0)
            {
                _hero_sc._move_v = Vector();
            }
        }
        else 
        {
            _stick.transform.localPosition = new Vector3(0,0,0);
            _hero_sc._move_v = new Vector3(0, 0, 0);
        }
    }
    void Bound()
    {
        float dist = Mathf.Sqrt(Mathf.Pow((0 - _stick.transform.localPosition.x),2) + Mathf.Pow((0 - _stick.transform.localPosition.y), 2));
        float r = gameObject.GetComponent<RectTransform>().rect.width/2;

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
    Vector3 Vector()
    {
        float r = gameObject.GetComponent<RectTransform>().rect.width / 2;
        float lc = 0.25f;

        float x = _stick.transform.localPosition.x / r;
        float y = _stick.transform.localPosition.y / r;

        if (x < lc && x > -lc)
        {
            x = 0;
        }
        if (y < lc && y > -lc)
        {
            y = 0;
        }

        float dx = x, dy = y;
        if (dx < 0)
        {
            dx *= -1;
        }
        if (dy < 0)
        {
            dy *= -1;
        }

        if (dx > dy)
        {
            if (x < 0)
            {
                x = -1;
            }
            else
            {
                x = 1;
            }

        }
        else if (dy > dx)
        {
            if (y < 0)
            {
                y = -1;
            }
            else
            {
                y = 1;
            }
        }


        x = (float)System.Math.Round(x, 1);
        y = (float)System.Math.Round(y, 1);
        Vector3 v = new Vector3(x, y, 0);

        return v;
    }


    public void B_Down()
    {
        _touch = true;
    }
    public void B_Up()
    {
        _touch = false;
    }
}
