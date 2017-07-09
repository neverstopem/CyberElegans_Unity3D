using UnityEngine;

public class Point
{
    Vector3 cPos;
    public Vector3 pos {
        get { return cPos; }
        set { cPos = value; }
    }

    public Point(Vector3 p) {
        Setup(p);
    }

    public void Setup(Vector3 p) {
        cPos = p;
    }

    public float x {
        get { return pos.x; }
        set { pos.Set(value, y, z); }
    }

    public float y {
        get { return pos.y; }
        set { pos.Set(x, value, z); }
    }

    public float z {
        get { return pos.z; }
        set { pos.Set(x, y, value); }
    }
}

public class CMassPoint : Point
{
    CRenderObject render;
    float mass;
    Vector3 vel;
    Vector3 force;

    public void applyForce(Vector3 uppforce)
    {
        force = force + uppforce;
    }

    public void timeTick(float dt)
    {
        pos += vel * dt;
        vel += (force / mass) * dt;
    }

    public Vector3 getVel()
    {
        return vel;
    }

    public Vector3 getForce()
    {
        return force;
    }

    public float getMass()
    {
        return mass;
    }

    public CMassPoint(float mass, Vector3 pos) : base(pos)
    {
        this.mass = mass;
        vel.Set(0, 0, 0);
        force.Set(0, 0, 0);
        if ((Globals.renderSwitch & EWormParts.point) != 0) render = ResManager.CreateObject(EWormParts.point, Color.black, 0.02f * Globals.scale);
    }


    public void Select()
    {
        if (!render) return;
        Vector3 rpos = (Globals.ort1 * (pos.x - Globals.pos_rc.x) + Globals.ort2 * (pos.y - Globals.pos_rc.y) + Globals.ort3 * (pos.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;
        render.Draw(rpos);
        render.Setup(Color.red, 0.03f * Globals.scale);
    }

    public void Draw()
    {
        if (!render) return;
        Vector3 rpos = (Globals.ort1 * (pos.x - Globals.pos_rc.x) + Globals.ort2 * (pos.y - Globals.pos_rc.y) + Globals.ort3 * (pos.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;
        render.Draw(rpos);
    }

    public void Init()
    {
        force = new Vector3(0, 0, 0);
    }

    public void UpdateLogic()
    {
        applyForce(new Vector3(0, 0, Globals.Gravity * mass));

        if (pos.z <= Globals.GroundHeight) {
            Vector3 v = vel;
            v.z = 0;
            if (vel.z < 0) {
                v = vel;
                v.x = 0;
                v.y = 0;
                applyForce(-v * Globals.GroundAbsorptionConstant);
                applyForce(new Vector3(0, 0, Globals.GroundRepulsionConstant) * (Globals.GroundHeight - pos.z));
            }
        }

        float r = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.y);
        if (r >= 10) {
            Globals.meet_obstacle++;

            if (Globals.meet_obstacle > 5) {
                //direction *= -1;
                Globals.meet_obstacle = 0;
            }
            Vector3 v;
            Vector3 rad_vect = pos;
            rad_vect /= rad_vect.magnitude;

            v = vel;
            v.z = 0;

            float radial_component = Vector3.Dot(v, rad_vect);

            if (radial_component > 0) {
                v = -pos;
                v.z = 0;
                applyForce(v * Globals.GroundRepulsionConstant * (r - 10));
            }
        }
        applyForce(-vel * Globals.AirFrictionCoefficient);
    }
}
