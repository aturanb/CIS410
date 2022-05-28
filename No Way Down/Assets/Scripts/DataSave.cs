using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataSave : MonoBehaviour
{
    public bool L2 { get; set; } = false;
    public bool L3 { get; set; } = false;
    public int L1Time { get; set; } = 1000000;
    public int L1Score { get; set; } =0;
    public int L2Time { get; set; } = 1000000;
    public int L2Score { get; set; } =0;
    public int L3Time { get; set; } = 1000000;
    public int L3Score { get; set; } = 0;
    public bool L1NA { get; set; } = true;
    public bool L2NA { get; set; } = true;
    public bool L3NA { get; set; } = true;
    public static DataSave Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        print(L3Time);
        print(L3Score);
    }


}
