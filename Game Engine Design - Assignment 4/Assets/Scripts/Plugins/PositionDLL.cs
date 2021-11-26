using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;

public class PositionDLL : MonoBehaviour
{
    [DllImport("PositionDLL")]
    static extern int GetID();

    [DllImport("PositionDLL")]
    static extern void SetID(float id);

    [DllImport("PositionDLL")]
    static extern Vector3 GetPosition();

    [DllImport("PositionDLL")]
    static extern void SetPosition(float x, float y, float z);

    [DllImport("PositionDLL")]
    static extern void SavePosition();

    private Vector3 pos;

    void Start()
    {
        if (System.IO.File.Exists(Application.dataPath + "/Plugin/position.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/Plugin/position.txt");
            Debug.Log(saveString);

            for (int i = 1; i < saveString.Length; i++)
            {
                string[] array = saveString.Split(',');

                pos = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));

                Debug.Log(pos);
            }

            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }

    public void SaveMCPosition()
    {
        pos = transform.position;

        SetPosition(pos.x, pos.y, pos.z);

        SavePosition();
    }
}
