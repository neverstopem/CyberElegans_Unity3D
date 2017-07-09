using UnityEngine;

public class Axon
{
    CRenderObject render;
    protected float mWeight;
    protected Synapse mSynapse;
    float size;

    public Vector3 getPos()
    {
        return mSynapse.drawPos;
    }
    public Axon(float weight, Synapse synapse)
    {
        mWeight = weight;
        mSynapse = synapse;
        size = 0.001f * Globals.scale;
        if ((Globals.renderSwitch & EWormParts.axon) != 0) render = ResManager.CreateObject(EWormParts.axon, Color.red, size);
    }

    public void send(float senderActivity)
    {
        mSynapse.ReceiveSignal(senderActivity);
    }

    public string getTargName()
    {
        return mSynapse.name;
    }

    public bool isTargSelected()
    {
        return mSynapse.select;
    }
    public void Draw(Vector3 p1, Vector3 p2, Color c, bool select = false)
    {
        if (!render) return;
        float width = size;
        if (select) width = size * 2;

        render.Setup(c, width);
        render.Draw(p1, p2);
    }
    public void Hide()
    {
        if (!render) return;
        render.Hide();
    }
};

