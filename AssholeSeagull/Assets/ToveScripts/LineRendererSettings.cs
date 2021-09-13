using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LineRendererSettings : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    Vector3[] points;

    public GameObject panel;
    public Image img;
    public Button button;

    public LayerMask layerMask;

    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 20);

        rend.SetPositions(points);
        rend.enabled = true;

        img = panel.GetComponent<Image>();
    }

    private void Update()
    {
        AlignLineRenderer(rend);

        if(AlignLineRenderer(rend) && Input.GetAxis("Submit") > 0)
        {
            button.onClick.Invoke();
        }
    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitButton = false;

        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, layerMask))
        {
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);

            button = hit.collider.gameObject.GetComponent<Button>();

            hitButton = true;
        }
        else
        {
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            points[1] = transform.forward + new Vector3(0, 0, 20);

            hitButton = false;
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;

        return hitButton;
    }

    public void ColorChangeOnClick()
    {
        if(button != null)
        {
            if(button.name == "Red_Button")
            {
                SceneManager.LoadScene("GameScene");
                img.color = Color.red;
            }
        }
        else if (button != null)
        {
            if (button.name == "Blue_Button")
            {
                img.color = Color.blue;
            }
        }
        else if (button != null)
        {
            if (button.name == "Green_Button")
            {
                img.color = Color.green;
            }
        }
    }
}
