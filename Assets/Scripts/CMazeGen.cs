using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//
public static class CMazeGen
{
    public static int SIZE = 30;
    public static int iNULL = 0;

    public static float[,] FMazeGen(int index, float Pscale, float Pborder)
    {
        float[,] H = new float[SIZE, SIZE];

        System.Random rnd = new System.Random();
             
        // 2 - fill plane
        if (index == 2) { return Fplane(); }
        // 1 - standart random
        if (index == 1) { return Frandom(); }
        // 0 - Perlin noise
        if (index == 0) { return Fperlin(Pscale, Pborder); }

        // 100 - test
        if (index == 100) { return Ftest(); }

        return H;
    }//    public static void FMazeGen()

    private static float[,] Fplane()
    {
        float[,] H = new float[SIZE, SIZE];

        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
            {
                H[i, j] = (float)(iNULL + 1);
            }

        return H;
    }//private static byte[,] Fplane()

    private static float[,] Frandom()
    {
        float[,] H = new float[SIZE, SIZE];
        System.Random rnd = new System.Random();

        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
            {
                H[i, j] = (float)rnd.Next(0, 2);
            }

        return H;
    }//private static byte[,] Frandom()

    private static float[,] Fperlin(float scale, float border)
    {
        float[,] H = new float[SIZE, SIZE];

        ////float scale = 3.0f;
        ////float border = 0.5f;

        border = UnityEngine.Random.Range(border - 0.05f, border + 0.05f);
        //Debug.Log(border);

        if (scale <= 0) { scale = 0.0001f; }

        System.Random rnd = new System.Random();
        int delta = rnd.Next(0,100);

        for (int i = 0; i < SIZE; i++)
            for (int j = 0; j < SIZE; j++)
            {
                float dX = i / scale;
                float dY = j / scale;

                float PerlinH = Mathf.PerlinNoise(dX + delta, dY + delta);

                if (PerlinH >= border) { H[i, j] = (float)(iNULL + 1); }
                if (PerlinH < border) { H[i, j] = (float)iNULL; }
            }

        return H;
    }//private static byte[,] Fperlin()

    /////////////////////
    private static float[,] Ftest()
    {
        float[,] H = new float[SIZE, SIZE];

        H[0, 0] = 1.0f;
        H[1, 1] = 1.0f;
        H[2, 2] = 1.0f;
        H[0, 2] = 1.0f;
        H[2, 0] = 1.0f;

        H[4, 4] = 1.0f;
        H[4, 5] = 1.0f;

        H[7, 4] = 1.0f;
        H[8, 4] = 1.0f;

        H[10, 10] = 1.0f;
        H[10, 11] = 1.0f;
        H[11, 10] = 1.0f;
        H[11, 11] = 1.0f;

        H[20, 10] = 1.0f;
        H[20, 11] = 1.0f;
        H[21, 10] = 1.0f;

        H[10, 20] = 1.0f;
        H[11, 20] = 1.0f;
        H[11, 21] = 1.0f;

        H[15, 15] = 1.0f;
        H[16, 14] = 1.0f;
        H[16, 15] = 1.0f;
        H[17, 15] = 1.0f;

        H[15, 7] = 1.0f;
        H[16, 7] = 1.0f;
        H[16, 6] = 1.0f;

        H[15, 20] = 1.0f;
        H[16, 20] = 1.0f;
        H[17, 20] = 1.0f;
        H[16, 21] = 1.0f;
        H[16, 19] = 1.0f;

        return H;
    }//private static float[,] Ftest()

}// public static class CMazeGen
