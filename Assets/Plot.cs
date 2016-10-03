using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Plot : MonoBehaviour
{

    string fileName = "data.csv";
    InputCSV inputCSV;
    public List<float> d1, d2, d3;
    public float d1Max, d1Min, d1Wid;
    public float d2Max, d2Min, d2Wid;
    public float d3Max, d3Min, d3Wid;

    public float dataNum;

    // Use this for initialization
    void Awake()
    {
        inputCSV = this.GetComponent<InputCSV>();
        inputCSV.ReadCSV(fileName, d1, d2, d3);
        dataNum = d1.Count;

        PlotNorm(d1, d2, d3, dataNum);
    }
    void PlotRaw(List<float> d1, List<float> d2, List<float> d3, float dataNUm)
    {

        for (int i = 0; i < dataNum; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = this.transform;
            cube.transform.position = new Vector3(d1[i], d3[i] / 2, d2[i]);
            cube.transform.localScale = new Vector3(1, d3[i], 1);
        }
    }
    void PlotNorm(List<float> d1, List<float> d2, List<float> d3, float dataNUm)
    {

        d1Max = d1.Max(); d1Min = d1.Min(); d1Wid = d1Max - d1Min;
        d2Max = d2.Max(); d2Min = d2.Min(); d2Wid = d2Max - d2Min;
        d3Max = d3.Max(); d3Min = d3.Min(); d3Wid = d3Max - d3Min;

        d1 = d1.Select(d => (d - d1Min) / (d1Max - d1Min)).ToList<float>();
        d2 = d2.Select(d => (d - d2Min) / (d2Max - d2Min)).ToList<float>();
        d3 = d3.Select(d => d / d3Max).ToList<float>();

        for (int i = 0; i < dataNum; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = this.transform;
            cube.transform.position = new Vector3(d1[i], d3[i] / 2, d2[i]);
            cube.transform.localScale = new Vector3(1 / d1Wid, d3[i], 1 / d2Wid);
        }
        d1Max = d1.Max(); d1Min = d1.Min(); d1Wid = d1Max - d1Min;
        d2Max = d2.Max(); d2Min = d2.Min(); d2Wid = d2Max - d2Min;
        d3Max = d3.Max(); d3Min = d3.Min(); d3Wid = d3Max - d3Min;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
