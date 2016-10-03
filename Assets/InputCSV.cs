using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class InputCSV : MonoBehaviour
{

    //public string fileName = "flights_mod.csv";
    //public StreamReader sr;
    //public List<double> d1, d2, d3;

    public void ReadCSV(string fileName, List<float> d1, List<float> d2, List<float> d3)
    {

        StreamReader sr = new StreamReader(fileName);
        try
        {
            for (int cnt = 0; sr.EndOfStream == false; cnt++)
            {

                string line = sr.ReadLine();
                if (cnt == 0) continue;

                string[] fields = line.Split(',');

                d1.Add(float.Parse(fields[0]));
                d2.Add(float.Parse(fields[1]));
                d3.Add(float.Parse(fields[2]));

                for (int i = 0; i < fields.Length; i++)
                {

                }

            }
        }
        finally
        {
            sr.Close();
        }

    }
    // Use this for initialization
    /*void Start()
    {
        sr = new StreamReader(fileName);
        try
        {
            for (int cnt = 0; sr.EndOfStream == false; cnt++)
            {

                string line = sr.ReadLine();
                if (cnt == 0) continue;

                string[] fields = line.Split(',');

                d1.Add(double.Parse(fields[0]));
                d2.Add(double.Parse(fields[1]));
                d3.Add(double.Parse(fields[2]));

                for (int i = 0; i < fields.Length; i++)
                {

                }

            }
        }
        finally
        {
            sr.Close();
        }
        d1.ForEach(d => print(d));
    }
    */

}
