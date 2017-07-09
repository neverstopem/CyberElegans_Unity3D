using UnityEngine;

public class Line : CRenderObject
{
    MeshRenderer meshRender;
    Color mColor = Color.black;
    public Color color {
        get { return mColor; }
        set { Setup(value); }
    }

    public float mWidth = 0;
    public float width {
        get { return mWidth; }
        set { mWidth = value; transform.localScale = new Vector3(mWidth, mWidth, transform.localScale.z); }
    }
    public override void Hide() { gameObject.SetActive(false); }

    public override void Init(object[] args)
    {
        if (args.Length != 2) Debug.LogError("Cline argument error, count:" + args.Length);

        meshRender = gameObject.GetComponentInChildren<MeshRenderer>();
        meshRender.material = new Material(Shader.Find("Standard"));
        Setup((Color)args[0], (float)args[1]);
    }


    public override void Setup(Color c, float w = -1)
    {
        if (w > 0) mWidth = w;
        meshRender.material.color = c;
    }

    public override void Draw(params Vector3[] args)
    {
        if (args.Length != 2) return;

        Vector3 s = args[0];
        Vector3 e = args[1];
        Vector3 p = e - s;
        float len = p.magnitude / 2;
        transform.localScale = new Vector3(width, width, len);

        gameObject.transform.position = (s + e) / 2;
        transform.LookAt(e);
        gameObject.SetActive(true);
    }
}
