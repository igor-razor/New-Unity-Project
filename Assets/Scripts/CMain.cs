using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//
public class CMain : MonoBehaviour
{
    public GameObject goCubePref;
    private static int SIZE = CMazeGen.SIZE;
    private static int iNULL = CMazeGen.iNULL;
    private static float delta = Mathf.Sqrt(2);
    private float[,] H = new float[SIZE, SIZE];
    private GameObject[,] goMmaze = new GameObject[SIZE, SIZE];

    public Dropdown ddGenType;
    private int itype = 0;

    public InputField InputScale;
    public InputField InputBorder;

    private float Pscale = 3.0f;
    private float Pborder = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ////FcreateMaze();
        ////CMarch.FMarch(goMmaze,H);
        //FdestroyMaze();

        InputScale.text = Convert.ToString(Pscale);
        InputBorder.text = Convert.ToString(Pborder);

    }//void Start()

    public void FbuttonGen()
    {
        if (itype == 0) { Pscale = Convert.ToSingle(InputScale.text); Pborder = Convert.ToSingle(InputBorder.text); }

        //Debug.Log("GEN");
        FdestroyMaze();
        FcreateMaze();
        CMarch.FMarch(goMmaze, H);
    }//public void FbuttonGen()

    public void FchangeType()
    {
        //Debug.Log(ddGenType.value);
        itype = ddGenType.value;
        if (itype == 0) { InputScale.gameObject.SetActive(true); InputBorder.gameObject.SetActive(true); }
        if (itype != 0) { InputScale.gameObject.SetActive(false); InputBorder.gameObject.SetActive(false); }
    }//public void FchangeType()

    private void FcreateMaze()
    {

        H = CMazeGen.FMazeGen(itype, Pscale, Pborder);

        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
            //if (H[i, j] > iNULL)
            {                
                GameObject goCube = Instantiate(goCubePref);
                goCube.name = "unit_" + Convert.ToString(i) + "_" + Convert.ToString(j)+"_H" + Convert.ToString(Convert.ToInt32(H[i,j]));
                goCube.transform.SetParent(gameObject.transform);
                goCube.transform.position = new Vector3(i * delta, H[i,j],j * delta);
                //if (H[i, j] == iNULL) { goCube.transform.position = new Vector3(i * delta, H[i, j], j * delta); }

                goMmaze[i, j] = goCube;
            }

        FclearSingle();

    }//private void Fcreate()

    private void FclearSingle()
    {
        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
                if (H[i, j] > iNULL )
                {
                    if ((i > 0) && (i < SIZE-1) && (j > 0) && (j < SIZE-1))
                        if ( (H[i, j + 1] < H[i, j]) && (H[i + 1, j] < H[i, j]) && (H[i, j - 1] < H[i, j]) && (H[i - 1, j] < H[i, j]) )
                            { goMmaze[i, j].transform.position = new Vector3(goMmaze[i, j].transform.position.x, iNULL, goMmaze[i, j].transform.position.z); }

                    if ((i==0) && (j > 0) && (j < SIZE - 1))
                        if ( (H[i, j + 1] < H[i, j]) && (H[i + 1, j] < H[i, j]) && (H[i, j - 1] < H[i, j]) )
                            { goMmaze[i, j].transform.position = new Vector3(goMmaze[i, j].transform.position.x, iNULL, goMmaze[i, j].transform.position.z); }

                    if ((i == SIZE - 1) && (j > 0) && (j < SIZE - 1))
                        if ( (H[i, j + 1] < H[i, j]) && (H[i, j - 1] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMmaze[i, j].transform.position = new Vector3(goMmaze[i, j].transform.position.x, iNULL, goMmaze[i, j].transform.position.z); }

                    if ((i > 0) && (i < SIZE - 1) && (j == 0))
                        if ( (H[i, j + 1] < H[i, j]) && (H[i + 1, j] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMmaze[i, j].transform.position = new Vector3(goMmaze[i, j].transform.position.x, iNULL, goMmaze[i, j].transform.position.z); }

                    if ((i > 0) && (i < SIZE - 1) && (j == SIZE - 1))
                        if ( (H[i + 1, j] < H[i, j]) && (H[i, j - 1] < H[i, j]) && (H[i - 1, j] < H[i, j]))
                        { goMmaze[i, j].transform.position = new Vector3(goMmaze[i, j].transform.position.x, iNULL, goMmaze[i, j].transform.position.z); }
                }// for i // for j

    }//private void FclearSingle()

    private void FdestroyMaze()
    {
        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
                if (goMmaze[i,j] != null)
                    Destroy(goMmaze[i, j].gameObject);
    }//private void Fdestroy()

    ///////////////////////////////////////

    // Update is called once per frame
    void Update()
    {

    }//void Update()
}//public class CMain : MonoBehaviour
