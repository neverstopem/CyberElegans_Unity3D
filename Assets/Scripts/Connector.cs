using UnityEngine;

class CConnector
{
    public int status = 0;
    public CMassPoint p1;
    public CMassPoint p2;
    
    public CConnector() { }
    public CConnector(CMassPoint p1, CMassPoint p2) {
        status = 1;
        this.p1 = p1;
        this.p2 = p2;
    }
    
    public void Copy(CConnector connector) {
        p1 = connector.p1;
        p2 = connector.p2;
    }
    
    public Vector3 getP1Pos() {
        return p1.pos;
    }
    public Vector3 getP2Pos() {
        return p2.pos;
    }
    
    public void applyForceP1(Vector3 i_force) {
        p1.applyForce(i_force);
    }
    public void applyForceP2(Vector3 i_force) {
        p2.applyForce(i_force);
    }
}




class CSpring : CConnector
{
    CRenderObject render;
    float length;
    float stiffness;
    float friction;

    public CSpring(float len, float stiffness, float friction, CMassPoint p1, CMassPoint p2) : base(p1, p2)
    {
        length = len;
        if (len <= 0)
            length = (p1.pos - p2.pos).magnitude * Mathf.Abs(len);

        this.stiffness = stiffness;
        this.friction = friction;
        if ((Globals.renderSwitch & EWormParts.spring) != 0) render = ResManager.CreateObject(EWormParts.spring, Color.gray, 0.005f * Globals.scale);
    }

    public void Copy(CSpring spring)
    {
        length = spring.length;
        stiffness = spring.stiffness;
        friction = spring.friction;
    }

    public void Draw()
    {
        if (!render) return;
        //Vector3 rpos = (ort1*p1->getX() + ort2*p1->getY() + ort3*(GroundHeight-0.1))*scale + vcenter;
        // shadow ?!! haha
        //Vector3 rpos = (Globals.ort1 * (p1.x - Globals.pos_rc.x) + Globals.ort2 * (p1.y - Globals.pos_rc.y) + Globals.ort3 * (Globals.GroundHeight - 0.1f -  Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;
        //Vector3 rpos2 = (Globals.ort1 * (p2.x - Globals.pos_rc.x) + Globals.ort2 * (p2.y - Globals.pos_rc.y) + Globals.ort3 * (Globals.GroundHeight - 0.1f -     Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;
        //rpos = (ort1*p2->getX() + ort2*p2->getY() + ort3*(GroundHeight-0.1))*scale + vcenter;
        /*
          glLineWidth(5);
          glBegin(GL_LINES);
          glColor3ub(150, 150, 150);
          glVertex3d(	rpos.x,rpos.y,rpos.z);
          glVertex3d(	rpos2.x,rpos2.y,rpos2.z);
          glEnd();

          glLineWidth(3);
          glBegin(GL_LINES);
          glColor3ub(80, 80, 80);
          glVertex3d(	rpos.x,rpos.y,rpos.z);
          glVertex3d(	rpos2.x,rpos2.y,rpos2.z);
       glEnd();
     */

        //render[0].Draw(rpos, rpos2);

        if (status == 0) {
            render.Setup(Color.gray);
        } else {
            render.Setup(Color.blue);
        }

        //rpos = (ort1*p1->getX() + ort2*p1->getY() + ort3*p1->getZ())*scale + vcenter;
        Vector3 rpos = (Globals.ort1 * (p1.x - Globals.pos_rc.x) + Globals.ort2 * (p1.y - Globals.pos_rc.y) + Globals.ort3 * (p1.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;

        //rpos = (ort1*p2->getX() + ort2*p2->getY() + ort3*p2->getZ())*scale + vcenter;
        Vector3 rpos2 = (Globals.ort1 * (p2.x - Globals.pos_rc.x) + Globals.ort2 * (p2.y - Globals.pos_rc.y) + Globals.ort3 * (p2.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;

        render.Draw(rpos, rpos2);
    }

    public void UpdateLogic()
    {
        if (status == 1) {
            Vector3 springVector = p1.pos - p2.pos;

            float r = springVector.magnitude;

            if ((r <= 0.05) || (r >= 2)) {
                status = 0;
                return;
            }
            //Now Spring can be broken;


            Vector3 force = new Vector3(0, 0, 0);
            if (r != 0) {
                force = (springVector / r) * (r - length) * (-stiffness);
            }

            force = force + -(p1.getVel() - p2.getVel()) * friction;

            p1.applyForce(force);
            p2.applyForce(-force);
            /*
            //Ground 
            Vector3 p1Pos;
            Vector3 p2Pos;
            Vector3 p1Vel;
            Vector3 p2Vel;
            Vector3 slip;
            float coeff;

            p1Pos = p1.pos;
            p2Pos = p2.pos;
            p1Vel = p1->getVel();
            p2Vel = p2->getVel();
            slip = p2Pos - p1Pos;

            if(p1Pos.z <= 0)
            {
                  p1Vel.z = 0;
                  slip.z = 0;	
                  if(p1Vel.scaleM(slip) / p1Vel.meas() / slip.meas() > 0.95)
                  {
                    p1->applyForce(- p1Vel * (0 * GroundFrictionConstant));					
                  }
                  else
                  {
                    p1->applyForce(- p1Vel * GroundFrictionConstant);
                  }

            }

            if(p2Pos.z <= 0)
            {
                p2Vel.z = 0;
                slip.z = 0;
                if(p2Vel.scaleM(slip) / p2Vel.meas() / slip.meas() < - 0.95)
                {
                  p2->applyForce(- p2Vel * (0 * GroundFrictionConstant));					
                }
                else
                {
                  p2->applyForce(- p2Vel * GroundFrictionConstant);
                }

            }
          */


        }
    }
}   // end of CSpring







