using UnityEngine;
using System.Collections.Generic;


class Neuron : Synapse
{
    const int iAxonSize = 20;

    List<Axon> mAxon = new List<Axon>();
    float mRatioX;
    float mRatioY;
    float mRatioZ;
    char mType;
    int mColorIdx;
    Color mColor, mColorSel, mColorPseSel, mColorAxon;
    float sizeNormal, sizeSelect;
    CRenderObject render;

    public float ratioX { get { return mRatioX; } }
    public float ratioY { get { return mRatioY; } }
    public float ratioZ { get { return mRatioZ; } }
    public int colorIdx { get { return mColorIdx; } }
    public Color color  { get { return mColor; } }
    public char type    { get { return mType; } }

    public void addPosX(float x) { mPos.x += x; }
    public void addPosY(float y) { mPos.y += y; }
    public void addPosZ(float z) { mPos.z += z; }
    public void AddPos(float x, float y, float z) {
        mPos.x += x;
        mPos.y += y;
        mPos.z += z;
    }

    public Neuron(string name,  Vector3 pos,  float threshold,  float ratioX,  float ratioY,  float ratioZ,  char type, int clr_index) : base(threshold, name, pos) {
        mType = type;
        mRatioX = ratioX;
        mRatioY = ratioY;
        mRatioZ = ratioZ;
        mColorIdx = clr_index;
        mColor = Globals.colors[clr_index];
        mColorPseSel = Color.red;
        mColorSel = Color.green;
        sizeNormal = Globals.neuron_normal;
        sizeSelect = Globals.neuron_selected;
        if ((Globals.renderSwitch & EWormParts.neuron) != 0) render = ResManager.CreateObject(EWormParts.neuron, Color.red, sizeNormal);
    }

    ~Neuron() {
        for(int i = 0; i < mAxon.Count; ++i) {
            mAxon[i] = null;
        }
    }

    public void addAxon(Axon axon) {
        mAxon.Add(axon);
    }

    public void addAxon(Synapse synapse, float weight) {
        addAxon(new Axon(weight, synapse));
    }

    public void Draw() {
        if (!render) return;

        Color c = color;
        float r = color.r;
        float g = color.g;
        float b = color.b;
        bool pseudoneuron = false;

        if (activity < 1) {
            r /= 3;
            g /= 3;
            b /= 3;

            r += (r * 2.0f * activity);
            g += (g * 2.0f * activity);
            b += (b * 2.0f * activity);
        }

        Vector3 rpos = (Globals.ort1 * (pos.x - Globals.pos_rc.x) + Globals.ort2 * (pos.y - Globals.pos_rc.y) + Globals.ort3 * (pos.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;
        //rpos2 = (Globals.ort1 * (pos.x - Globals.pos_rc.x) + Globals.ort2 * (pos.y - Globals.pos_rc.y) + Globals.ort3 * (pos.z - Globals.pos_rc.z + 0.1f)) * Globals.scale + Globals.vcenter;
        //p = rpos2 - rpos;
        //h = p.magnitude;


        if((mName[0] == 'P') && (mName[1] == 's') && (mName[2] == 'e'))
            pseudoneuron = true;

        if (select) {
            if (pseudoneuron) c = mColorPseSel;
            else c = mColorSel;
            render.Setup(c, sizeSelect);
        } else {
            render.Setup(c, sizeNormal);
        }

        render.Draw(rpos);


        /**/
        if (select) {
            //if(mName.magnitude<5)
            //glPrint2(rpos.x, rpos.y, rpos.z, (byte)min(255, r * 1.7), (byte)min(255, g * 1.7), (byte)min(255, b * 1.7), mName.c_str());
        }

        /*
	    if(highlight)
	    if(mName.magnitude<5)
	    glPrint2(rpos.x,rpos.y,rpos.z,(byte)min(255,r*1.7),(byte)min(255,g*1.7),(byte)min(255,b*1.7),mName.c_str());	
	    */
        /**/


        //int n_axon_branches = 0;
        //rpos2 = new Vector3(0, 0, 0);
        //if(mSelected)
        //if(mName.magnitude>5)
        {

            /*
            for(unsigned int j = 0;  j < axon.size(); ++j)
            {
                    rpos2+= (ort1*(axon[j]->getPos().x - pos_rc.x)
                           + ort2*(axon[j]->getPos().y - pos_rc.y)
                           + ort3*(axon[j]->getPos().z - pos_rc.z))*scale + vcenter;// 蝾麝?铗 牝 桎篁 忮蜮??疣珥 礤轲铐囔
                    n_axon_branches++;

            }


            //glEnd();
            if(n_axon_branches>0)
            {
                rpos2 /= n_axon_branches;
                glPushMatrix();
                glColor3ub(r, g, b);

                glTranslated(	rpos2.x,	rpos2.y,	rpos2.z    );
                gluSphere(quadObj,0.7f*neuron_normal*scale ,8,8);
                glPopMatrix();
            }

            glColor3ub(min(255,r*1.0),min(255,g*1.0),min(255,b*1.0));
            if(n_axon_branches>0)
            {
                //rpos2 /= n_axon_branches;
                p = rpos2 - rpos;
                h = p.magnitude;

                glPushMatrix();
                glTranslated(rpos.x, rpos.y, rpos.z);
                glRotated(180.0f*(float)atan2(p.x,p.z)/pi,0,1,0); 
                glRotated(-180.0f*(float)atan2(p.y,sqrt(p.x*p.x+p.z*p.z))/pi,1,0,0); 
                gluCylinder(quadObj, 0.005*scale, 0.005*scale, h, 16, 16);
                glPopMatrix();

                rpos = rpos2;
            }
            */

            Vector3 rpos2;
            int link_with_muscle = 0;
            mColorAxon  = Color.black;
            drawPos = pos.pos;

            for (int j = 0; j < mAxon.Count; ++j) {
                link_with_muscle = 0;

                if((mAxon[j].getTargName()[0] == 'D') || (mAxon[j].getTargName()[0] == 'V'))
                    if((mAxon[j].getTargName()[1] == 'R') || (mAxon[j].getTargName()[1] == 'L'))
                        if((mAxon[j].getTargName()[2] == '0') || (mAxon[j].getTargName()[2] == '1') || (mAxon[j].getTargName()[2] == '2')) {
                            link_with_muscle = 1;

                            if((mName[0] == 'P') && (mName[1] == 's' && (mName[2] == 'e')))
                                if(mName[3] == '_')
                                    if(((mName[4] == 'V') || (mName[4] == 'D')) && (mName[5] == 'B'))
                                        link_with_muscle = 2;
                        }

                if (select) {
                    rpos2 = (Globals.ort1 * (mAxon[j].getPos().x - Globals.pos_rc.x) + Globals.ort2 * (mAxon[j].getPos().y - Globals.pos_rc.y) + Globals.ort3 * (mAxon[j].getPos().z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;

                    string tmp_name = mAxon[j].getTargName();
                    if (((tmp_name[0] == 'D') && (tmp_name[1] == 'L')) || ((tmp_name[0] == 'D') && (tmp_name[1] == 'R')) ||
                       ((tmp_name[0] == 'V') && (tmp_name[1] == 'L')) || ((tmp_name[0] == 'V') && (tmp_name[1] == 'R'))) {
                        mColorAxon = Color.green;
                    } else {
                        mColorAxon = Color.red;
                    }

                    mAxon[j].Draw(rpos, rpos2, mColorAxon, select);
                }  else if((link_with_muscle != 1) || select) {
                    rpos2 = (Globals.ort1 * (mAxon[j].getPos().x - Globals.pos_rc.x)
                           + Globals.ort2 * (mAxon[j].getPos().y - Globals.pos_rc.y)
                           + Globals.ort3 * (mAxon[j].getPos().z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;

                    //p = rpos2 - rpos;
                    //h = p.magnitude;

                    /*	if(mAxon[j]->getTargName().magnitude<5)
                            glPrint2(rpos2.x,rpos2.y,rpos2.z,150,150,150,mAxon[j] ->getTargName().c_str());*/

                    //glPrint2(rpos2.x,rpos2.y,rpos2.z,150,150,150,mAxon[j] ->getTargName().c_str());
                    string tmp_name = mAxon[j].getTargName();
                    if(((tmp_name[0] == 'D') && (tmp_name[1] == 'L')) || ((tmp_name[0] == 'D') && (tmp_name[1] == 'R')) ||
                       ((tmp_name[0] == 'V') && (tmp_name[1] == 'L')) || ((tmp_name[0] == 'V') && (tmp_name[1] == 'R'))) {
                        mColorAxon.r = Mathf.Min(r * 1f, 1);
                        mColorAxon.g = Mathf.Min(g * 1f, 1);
                        mColorAxon.b = Mathf.Min(b * 1f, 1);
                        mColorAxon = Color.yellow;
                    } else {
                        mColorAxon.r = Mathf.Min(r * 0.6f, 1);
                        mColorAxon.g = Mathf.Min(g * 0.6f, 1);
                        mColorAxon.b = Mathf.Min(b * 0.6f, 1);
                        mColorAxon = Color.gray;
                    }
                    mAxon[j].Draw(rpos, rpos2, mColorAxon, select);
                    //glPushMatrix();
                    //glTranslated(rpos.x, rpos.y, rpos.z);
                    //glRotated(180.0f * (float)atan2(p.x, p.z) / pi, 0, 1, 0);
                    //glRotated(-180.0f * (float)atan2(p.y, sqrt(p.x * p.x + p.z * p.z)) / pi, 1, 0, 0);
                    //gluCylinder(quadObj, 0.0025 * scale, 0.001 * scale, h, 16, 16);
                    //glPopMatrix();
                } else {
                    mAxon[j].Hide();
                }
            } //end of for
        }

        return;
        ///////////////////////////////////////////////////
#if false
        rpos = (ort1 * (pos.x - pos_rc.x) + ort2 * (pos.y - pos_rc.y) + ort3 * (pos.z - pos_rc.z)) * scale + vcenter;



        for(unsigned int j = 0; j < axon.size(); ++j) {
            if(axon[j]->isTargSelected()) {
                rpos2 = (ort1 * (axon[j]->getPos().x - pos_rc.x)
                       + ort2 * (axon[j]->getPos().y - pos_rc.y)
                       + ort3 * (axon[j]->getPos().z - pos_rc.z)) * scale + vcenter;

                p = rpos2 - rpos;
                h = p.magnitude;
                glPrint2(rpos.x, rpos.y, rpos.z, 150, 150, 150, mName.c_str());

                glPushMatrix();
                glColor3ub(50, 50, 50);
                glTranslated(rpos.x, rpos.y, rpos.z);
                glRotated(180.0f * (float)atan2(p.x, p.z) / pi, 0, 1, 0);
                glRotated(-180.0f * (float)atan2(p.y, sqrt(p.x * p.x + p.z * p.z)) / pi, 1, 0, 0);
                gluCylinder(quadObj, 0.005 * scale, 0.001 * scale, h, 16, 16);
                glPopMatrix();
            }
        }
#endif
    }

    //int cnt=5;
    public void UpdateLogic() {
        //return;
        drawPos = mPos.pos;

        string neuron_name = name;

        if(Globals.neuron_active && select) {
            //activity = 1.f;
            //if(cnt>0)
            {
                //if(getName().magnitude<7)
                //{
                income += 0.1f;
                //	cnt--;
                //}
            }
            income = Mathf.Min(income, 1);
            //mSelected = false;
            /*
		    if(income>0.99) 
		    {
			    cnt--;
			    if(cnt=0);
			    key_a = 0;
		    }*/

        }

        /*
	    if(mSelected) 
	    {
		    FILE *f = fopen("act_log.txt","a+");
		    //income += 0.0f;
		    fprintf(f,"%s\t%f\t",neuron_name.c_str(),income);
		    if(getName().magnitude>7) fprintf(f,"\n");
		    fclose(f);
	    }*/


        //string tmp_name;

        if(income/*activity*/ > 0) {
            for(int j = 0; j < mAxon.Count; ++j) {
                //tmp_name = mAxon[j].getTargName();

                /*
			    if( 
				    ((tmp_name[0]=='D')&&(tmp_name[1]=='L'))||
				    ((tmp_name[0]=='D')&&(tmp_name[1]=='R'))|| 
				    ((tmp_name[0]=='V')&&(tmp_name[1]=='L'))|| 
				    ((tmp_name[0]=='V')&&(tmp_name[1]=='R')) 
			      )*/
                {
                    mAxon[j].send(1.0f * activity);
                    //j = j;
                }
            }
        }
    }
} // end of class
