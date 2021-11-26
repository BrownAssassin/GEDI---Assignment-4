using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;


public class Plugin : MonoBehaviour
{
    [DllImport("TestDLL")]
    static extern int GetID();

    [DllImport("TestDLL")]
    static extern void SetID(int id);

    [DllImport("TestDLL")]
    static extern Color RandomColor();

    [DllImport("TestDLL")]
    static extern void SaveColor();


    private Vector3 pos;
    private Color color;

    private SpriteRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = gameObject.GetComponent<SpriteRenderer>();
        if (System.IO.File.Exists(Application.dataPath + "/color.txt"))
        {
            string savestring = File.ReadAllText(Application.dataPath + "/color.txt");

            for (int i = 1; i < savestring.Length; i++)
            {
                string[] vs = savestring.Split(',');
                color = new Color(float.Parse(vs[0]), float.Parse(vs[1]), float.Parse(vs[2]));
            }

            mr.material.color = new Color(color.r, color.g, color.b);
        }
    }

    public void Save()
    {
        SaveColor();

    }
    public void Random()
    {
        Color rc = RandomColor();
        mr.material.color = new Color(rc.r, rc.g, rc.b);
    }
}