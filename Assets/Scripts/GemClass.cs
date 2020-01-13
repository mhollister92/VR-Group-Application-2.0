using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is a class to store values for each gem
//it holds the values for the red, green, and blue and bools for if the colors are active or not
public class GemClass : MonoBehaviour
{
    public float rValue;
    public float gValue;
    public float bValue;

    public bool rActive = false;
    public bool gActive = false;
    public bool bActive = false;

    public bool allActive = false;

    private List<int[]> colors = new List<int[]>();
    private int listLength;

    public int randomNumber;


    private void Start()
    {

        colors.Add(new[] { 255, 156, 202 }); colors.Add(new[] { 255, 250, 207 }); colors.Add(new[] { 124, 193, 204 }); colors.Add(new[] { 124, 255, 204 }); colors.Add(new[] { 233, 156, 255 });
        colors.Add(new[] { 255, 156, 0 }); colors.Add(new[] { 25, 255, 112 }); colors.Add(new[] { 164, 56, 255 }); colors.Add(new[] { 255, 9, 179 }); colors.Add(new[] { 25, 249, 255 });
        colors.Add(new[] { 255, 244, 123 }); colors.Add(new[] { 148, 233, 255 }); colors.Add(new[] { 255, 66, 132 }); colors.Add(new[] { 189, 255, 97 }); colors.Add(new[] { 255, 148, 140 });
        colors.Add(new[] { 255, 165, 234 }); colors.Add(new[] { 184, 255, 102 }); colors.Add(new[] { 255, 77, 64 }); colors.Add(new[] { 119, 58, 255 }); colors.Add(new[] { 224, 33, 255 });
        colors.Add(new[] { 242, 161, 255 }); colors.Add(new[] { 255, 175, 80 }); colors.Add(new[] { 143, 248, 255 }); colors.Add(new[] { 54, 255, 211 }); colors.Add(new[] { 238, 139, 255 });
        colors.Add(new[] { 170, 255, 254 }); colors.Add(new[] { 145, 199, 255 }); colors.Add(new[] { 255, 139, 107 }); colors.Add(new[] { 209, 255, 176 }); colors.Add(new[] { 150, 255, 174 });
        colors.Add(new[] { 255, 101, 70 }); colors.Add(new[] { 255, 140, 43 }); colors.Add(new[] { 255, 203, 231 }); colors.Add(new[] { 0, 248, 255 }); colors.Add(new[] { 255, 246, 58 });
        colors.Add(new[] { 255, 168, 143 }); colors.Add(new[] { 117, 147, 255 }); colors.Add(new[] { 176, 255, 92 }); colors.Add(new[] { 255, 201, 25 }); colors.Add(new[] { 243, 0, 255 });
        colors.Add(new[] { 25, 255, 208 }); colors.Add(new[] { 221, 255, 31 }); colors.Add(new[] { 255, 25, 5 }); colors.Add(new[] { 31, 135, 255 }); colors.Add(new[] { 115, 255, 69 });
        colors.Add(new[] { 255, 113, 43 }); colors.Add(new[] { 18, 21, 255 }); colors.Add(new[] { 69, 255, 130 }); colors.Add(new[] { 255, 171, 43 }); colors.Add(new[] { 136, 18, 255 });
        colors.Add(new[] { 38, 230, 255 }); colors.Add(new[] { 255, 227, 14 }); colors.Add(new[] { 255, 38, 149 }); colors.Add(new[] { 56, 144, 255 }); colors.Add(new[] { 213, 255, 30 });
        colors.Add(new[] { 255, 29, 5 }); colors.Add(new[] { 59, 46, 255 }); colors.Add(new[] { 56, 255, 21 }); colors.Add(new[] { 255, 124, 46 }); colors.Add(new[] { 224, 204, 255 });
        colors.Add(new[] { 179, 255, 195 }); colors.Add(new[] { 255, 209, 153 }); colors.Add(new[] { 255, 196, 241 }); colors.Add(new[] { 172, 255, 254 }); colors.Add(new[] { 255, 237, 145 });
        colors.Add(new[] { 255, 197, 173 }); colors.Add(new[] { 149, 160, 255 }); colors.Add(new[] { 171, 255, 122 }); colors.Add(new[] { 255, 237, 189 }); colors.Add(new[] { 247, 214, 254 });
        colors.Add(new[] { 189, 255, 234 }); colors.Add(new[] { 255, 247, 156 }); colors.Add(new[] { 255, 130, 173 }); colors.Add(new[] { 105, 225, 255 }); colors.Add(new[] { 120, 255, 132 });
        colors.Add(new[] { 255, 172, 95 }); colors.Add(new[] { 119, 69, 255 }); colors.Add(new[] { 156, 255, 193 }); colors.Add(new[] { 255, 208, 130 }); colors.Add(new[] { 187, 105, 255 });
        colors.Add(new[] { 230, 255, 251 }); colors.Add(new[] { 255, 244, 203 }); colors.Add(new[] { 255, 179, 255 }); colors.Add(new[] { 02, 237, 255 }); colors.Add(new[] { 255, 235, 76 });
        colors.Add(new[] { 255, 51, 155 }); colors.Add(new[] { 153, 192, 255 }); colors.Add(new[] { 220, 255, 127 }); colors.Add(new[] { 255, 122, 102 }); colors.Add(new[] { 105, 97, 255 });
        colors.Add(new[] { 101, 255, 72 }); colors.Add(new[] { 255, 123, 46 }); colors.Add(new[] { 206, 168, 255 }); colors.Add(new[] { 142, 255, 172 }); colors.Add(new[] { 255, 196, 117 });
        colors.Add(new[] { 242, 92, 255 }); colors.Add(new[] { 67, 255, 211 }); colors.Add(new[] { 255, 203, 41 }); colors.Add(new[] { 255, 112, 255 }); colors.Add(new[] { 86, 255, 249 });
        colors.Add(new[] { 255, 221, 61 }); colors.Add(new[] { 255, 41, 33 }); colors.Add(new[] { 8, 143, 255 }); colors.Add(new[] { 246, 255, 33 }); colors.Add(new[] { 255, 123, 46 });
        colors.Add(new[] { 33, 21, 255 }); colors.Add(new[] { 81, 255, 46 });

        listLength = colors.Count;

        randomNumber = Random.Range(0, listLength);
        Debug.Log(randomNumber);

        rValue = colors[randomNumber][0];
        gValue = colors[randomNumber][1];
        bValue = colors[randomNumber][2];

    }
}
