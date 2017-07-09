using UnityEngine;

public class WormBase
{
    protected string mName;
    protected Point mPos;

    public WormBase(string name, Vector3 p) { this.mName = name; mPos = new Point(p); }
    public string name { get { return mName; } }
    public Point pos {
        get { return mPos; }
        set { mPos = value; }
    }
}
