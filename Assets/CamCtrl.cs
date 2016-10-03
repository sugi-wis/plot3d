using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour
{
    Plot plot;
    Vector3 cPos = Vector3.zero;
    float sAngle, lAngle;
    float rotSp = 0.06f;
    float dtc = 2f;


    // Use this for initialization
    void Start()
    {
        plot = GameObject.Find("Plotter").GetComponent<Plot>();
        cPos = new Vector3(
            (plot.d1Max + plot.d1Min) / (2f)
            , (plot.d3Max + plot.d3Min) / (2f)
            , (plot.d2Max + plot.d2Min) / (2f));
        print(cPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) sAngle -= rotSp;
        if (Input.GetKey(KeyCode.LeftArrow)) sAngle += rotSp;
        if (Input.GetKey(KeyCode.UpArrow) && lAngle < 0.8) lAngle += rotSp;
        if (Input.GetKey(KeyCode.DownArrow) && lAngle > -0.2) lAngle -= rotSp;
        if (Input.GetKey(KeyCode.Z) && dtc >= 1) dtc -= 0.1f;
        if (Input.GetKey(KeyCode.X)) dtc += 0.1f;

        this.transform.position = new Vector3(cPos.x + Mathf.Sin(sAngle) * Mathf.Cos(lAngle) * dtc
            , cPos.y + Mathf.Sin(lAngle) * dtc
            , cPos.z + Mathf.Cos(sAngle) * Mathf.Cos(lAngle) * dtc);
        this.transform.LookAt(cPos);

    }
}
