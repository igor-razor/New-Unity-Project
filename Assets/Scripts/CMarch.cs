using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//
public class CMarch : MonoBehaviour
{
    //static int SIZE = CMazeGen.SIZE;
    public static int iNULL = CMazeGen.iNULL;

    public static void FMarch(GameObject[,] goMmaze, float[,] H)
    {
        for (int i = 0;i < goMmaze.GetLength(0); i++)
            for (int j = 0; j < goMmaze.GetLength(1); j++)
            if (goMmaze[i,j].activeSelf == true)
            {
                GameObject goCD = goMmaze[i, j].transform.Find("CubeD").gameObject;
                GameObject goCT = goMmaze[i, j].transform.Find("CubeT").gameObject;
                GameObject goCR = goMmaze[i, j].transform.Find("CubeR").gameObject;
         
                if (H[i, j] == iNULL)
                    {
                        goCD.SetActive(false);
                        goCT.SetActive(false);
                        goCR.SetActive(false);

                        if ((i + 1 < goMmaze.GetLength(0)) && (j + 1 < goMmaze.GetLength(0)))
                            if ((H[i, j] < H[i + 1, j]) && (H[i, j] < H[i, j + 1]) && (H[i, j] < H[i + 1, j + 1]))
                            {
                                goCD.transform.position = new Vector3(goCD.transform.position.x, H[i + 1, j + 1], goCD.transform.position.z);
                                goCD.SetActive(true);
                            }
                    }//if (H[i, j] == iNULL)

                if (H[i, j] > iNULL)
                    {
                        if (i + 1 < goMmaze.GetLength(0))
                            if (H[i, j] > H[i + 1, j]) { goCR.SetActive(false); }

                        if (j + 1 < goMmaze.GetLength(1))
                            if (H[i, j] > H[i, j + 1]) { goCT.SetActive(false); }

                        if ((i + 1 < goMmaze.GetLength(0)) && (j + 1 < goMmaze.GetLength(0)))
                        {
                            if ((H[i, j] > H[i + 1, j]) && (H[i, j] > H[i, j + 1])) { goCD.SetActive(false); goCT.SetActive(false); goCR.SetActive(false); }
                            if ((H[i, j] > H[i+1, j+1]) && (H[i, j] > H[i, j + 1])) { goCD.SetActive(false); goCT.SetActive(false); }
                            if ((H[i, j] > H[i+1, j+1]) && (H[i, j] > H[i + 1, j])) { goCD.SetActive(false); goCR.SetActive(false); }                         
                        }

                        if (i + 1 == goMmaze.GetLength(0)) { goCR.SetActive(false); goCD.SetActive(false); }
                        if (j + 1 == goMmaze.GetLength(1)) { goCT.SetActive(false); goCD.SetActive(false); }
                       
                    }//if (H[i, j] > iNULL)
                }// for i // for j
    }//private void FMarch(GameObject goMmaze)

}//public class CMarch : MonoBehaviour
