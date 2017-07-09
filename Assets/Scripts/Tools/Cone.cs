using UnityEngine;

public class Cone : CRenderObject
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
        if (args.Length != 2) Debug.LogError("Cone argument error, count:" + args.Length);

        meshRender = gameObject.GetComponent<MeshRenderer>();
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
        Vector3 p = (e - s);
        float len = p.magnitude;

        transform.localScale = new Vector3(width, width, len);
        gameObject.transform.position = s;
        transform.LookAt(e);
        if (gameObject.activeSelf == false) gameObject.SetActive(true);
    }
}
