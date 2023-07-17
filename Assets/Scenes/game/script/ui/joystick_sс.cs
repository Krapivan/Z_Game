using UnityEngine;

public class joystick_sñ : MonoBehaviour
{
    public hero_sc _hero_sc;

    public GameObject _stick;
    bool _touch;


    public void FixedUpdate()
    {
        if (_touch == true)
        {
            Vector3 t_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _stick.transform.position = new Vector3(t_pos.x, t_pos.y, 0);
            Bound();
            if (Vector().x != 0 || Vector().y != 0)
            {
                _hero_sc._move_v = Vector();
            }
        }
        else if (_touch == false)
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
        var p = _stick.transform.localPosition - new Vector3(0, 0, 0);

        float x = p.x / (gameObject.GetComponent<RectTransform>().rect.width / 2), y = p.y / (gameObject.GetComponent<RectTransform>().rect.width / 2);

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
