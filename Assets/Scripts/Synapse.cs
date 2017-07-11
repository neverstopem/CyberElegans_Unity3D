using UnityEngine;


public class Synapse : WormBase
{
    public float activity { get { return income; } }
    public Vector3 drawPos;
    public bool select;
    public float income;
    public float threshold;

    public Synapse(float threshold, string name, Vector3 pos) : base(name, pos)
    {
        select = false;
        //activity = 0;
        income = 0;
        this.threshold = threshold;
    }

    public void ReceiveSignal(float signal)
    {
        income += signal * 0.1f;
    }

    public void checkActivity()
    {
        /*
        if(income >= threshold) {
            activity = 1;
        } else {
            activity = 0;
        }
       */
        //activity = min(income,1.f);
        income = Mathf.Min(income, 1);

        income *= 0.9f;
    }
}
