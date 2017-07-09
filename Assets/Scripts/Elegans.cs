using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

class Elegans
{
	int size;
    float length;
    float time;

    List<CMassPoint> mPoint = new List<CMassPoint>();
    List<CSpring> mSpring = new List<CSpring>();
    List<Muscle> mMuscle = new List<Muscle>();
    List<Neuron> mNeuron = new List<Neuron>();
    List<List<Neuron>> mTable = new List<List<Neuron>>();
    Vector3 mVshift;
    float dl;
    float dx;

    public Elegans(float length, int size)
    {
        this.size = size;
	    this.length = length;

        //float dl = length;
        //float dx = dl*0.5;
        dl = length;
        dx = dl * 0.5f * 73 / 60;
        float[] wp = { 0.35f, 0.50f, 0.61f, 0.68f, 0.75f, 0.81f, 0.85f, 0.88f, 0.91f, 0.93f, 0.95f, 0.97f, 0.99f, 1.00f, 0.99f, 0.98f, 0.97f, 0.96f, 0.95f, 0.93f, 0.91f, 0.88f, 0.83f, 0.79f, 0.70f, 0.53f, 0.34f };       // Width Profile

        mVshift = new Vector3(dl * size / 4 + 0.5f, 0, dl * 3 / 2);

        //for(int ii = 0; ii<27;ii++) wp[ii] /= 9.f/5.5f;

        /**/
        addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3(  -0.7f * dx  ,  0		,  0	  )) );

        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, -0.35f * dl * wp[0], -dl * wp[0] / 2)));	//	-0.456    -0.06125    -0.0875
        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, 0.35f * dl * wp[0], -dl * wp[0] / 2)));	//	-0.456     0.06125    -0.0875
        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, dl * wp[0] / 2, -0.35f * dl * wp[0])));	//	-0.456     0.0875     -0.06125
        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, dl * wp[0] / 2, 0.35f * dl * wp[0])));	//	-0.456     0.0875      0.06125

        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, 0.35f * dl * wp[0], dl * wp[0] / 2)));	//	-0.456     0.06125     0.0875
        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, -0.35f * dl * wp[0], dl * wp[0] / 2)));	//	-0.456    -0.06125     0.0875
        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, -dl * wp[0] / 2, 0.35f * dl * wp[0])));//	-0.456    -0.0875    0.06125
        addMPoint(new CMassPoint(0.05f, mVshift + new Vector3(-1.5f * dx, -dl * wp[0] / 2, -0.35f * dl * wp[0])));//	-0.456    -0.0875    -0.06125

        //
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[1]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[2]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[3]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[4]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[5]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[6]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[7]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[0], mPoint[8]) );
        //
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[1], mPoint[2]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[2], mPoint[3]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[3], mPoint[4]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[4], mPoint[5]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[5], mPoint[6]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[6], mPoint[7]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[7], mPoint[8]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[8], mPoint[1]) );
        //
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[1], mPoint[5]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[2], mPoint[6]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[3], mPoint[7]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[4], mPoint[8]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[1], mPoint[6]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[2], mPoint[5]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[3], mPoint[8]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[4], mPoint[7]) );
		mTable.Add(new List<Neuron>());

        //Head created

        int i;
	    for(i = 1; i<size + 1; i++)
	    {
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1+i)*dx, 0		, 0 )) );

            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx, -0.35f*dl* wp[i], -0.50f*dl* wp[i] )) );
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx,  0.35f*dl* wp[i], -0.50f*dl* wp[i] )) );
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx,  0.50f*dl* wp[i], -0.35f*dl* wp[i] )) );
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx,  0.50f*dl* wp[i],  0.35f*dl* wp[i] )) );

            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx,  0.35f*dl* wp[i],  0.50f*dl* wp[i] )) );
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx, -0.35f*dl* wp[i],  0.50f*dl* wp[i] )) );
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx, -0.50f*dl* wp[i],  0.35f*dl* wp[i] )) );
            addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -(1.5f+i)*dx, -0.50f*dl* wp[i], -0.35f*dl* wp[i] )) );

            //============
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9], mPoint[i * 9]) ); 

            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 1], mPoint[i * 9 + 2]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 2], mPoint[i * 9 + 3]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 3], mPoint[i * 9 + 4]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 4], mPoint[i * 9 + 5]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 5], mPoint[i * 9 + 6]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 6], mPoint[i * 9 + 7]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 7], mPoint[i * 9 + 8]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 8], mPoint[i * 9 + 1]) ); 

            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 1], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 2], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 3], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 4], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 5], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 6], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 7], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[i * 9 + 8], mPoint[i * 9 + 0]) ); 

            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 1], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 2], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 3], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 4], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 5], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 6], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 7], mPoint[i * 9 + 0]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 8], mPoint[i * 9 + 0]) ); 
            //
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 1], mPoint[i * 9 + 2]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 2], mPoint[i * 9 + 3]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 3], mPoint[i * 9 + 4]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 4], mPoint[i * 9 + 5]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 5], mPoint[i * 9 + 6]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 6], mPoint[i * 9 + 7]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 7], mPoint[i * 9 + 8]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 8], mPoint[i * 9 + 1]) ); 
            //
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 2], mPoint[i * 9 + 1]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 3], mPoint[i * 9 + 2]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 4], mPoint[i * 9 + 3]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 5], mPoint[i * 9 + 4]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 6], mPoint[i * 9 + 5]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 7], mPoint[i * 9 + 6]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 8], mPoint[i * 9 + 7]) ); 
            addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff/2, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 1], mPoint[i * 9 + 8]) ); 
		    //
		    mTable.Add(new List<Neuron>());
	    }

        addMuscle( new Muscle(Globals.MStrength, mPoint[0 * 9 + 1], mPoint[1 * 9 + 1],"VL02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 1], mPoint[1 * 9 + 1],"VL02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 1], mPoint[3 * 9 + 1],"VL04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 1], mPoint[3 * 9 + 1],"VL04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 1], mPoint[5 * 9 + 1],"VL06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 1], mPoint[5 * 9 + 1],"VL06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 1], mPoint[7 * 9 + 1],"VL08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 1], mPoint[7 * 9 + 1],"VL08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 1], mPoint[9 * 9 + 1],"VL10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 1], mPoint[9 * 9 + 1],"VL10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 1], mPoint[11 * 9 + 1],"VL12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 1], mPoint[11 * 9 + 1],"VL12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 1], mPoint[13 * 9 + 1],"VL14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 1], mPoint[13 * 9 + 1],"VL14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 1], mPoint[15 * 9 + 1],"VL16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 1], mPoint[15 * 9 + 1],"VL16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 1], mPoint[17 * 9 + 1],"VL18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 1], mPoint[17 * 9 + 1],"VL18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 1], mPoint[19 * 9 + 1],"VL20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 1], mPoint[19 * 9 + 1],"VL20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 1], mPoint[21 * 9 + 1],"VL21") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 1], mPoint[21 * 9 + 1],"VL21") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 1], mPoint[23 * 9 + 1],"VL22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[24 * 9 + 1], mPoint[23 * 9 + 1],"VL22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[24 * 9 + 1], mPoint[25 * 9 + 1],"VL23") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[26 * 9 + 1], mPoint[25 * 9 + 1],"VL23") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[0 * 9 + 2], mPoint[1 * 9 + 2],"VR02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 2], mPoint[1 * 9 + 2],"VR02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 2], mPoint[3 * 9 + 2],"VR04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 2], mPoint[3 * 9 + 2],"VR04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 2], mPoint[5 * 9 + 2],"VR06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 2], mPoint[5 * 9 + 2],"VR06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 2], mPoint[7 * 9 + 2],"VR08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 2], mPoint[7 * 9 + 2],"VR08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 2], mPoint[9 * 9 + 2],"VR10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 2], mPoint[9 * 9 + 2],"VR10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 2], mPoint[11 * 9 + 2],"VR12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 2], mPoint[11 * 9 + 2],"VR12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 2], mPoint[13 * 9 + 2],"VR14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 2], mPoint[13 * 9 + 2],"VR14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 2], mPoint[15 * 9 + 2],"VR16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 2], mPoint[15 * 9 + 2],"VR16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 2], mPoint[17 * 9 + 2],"VR18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 2], mPoint[17 * 9 + 2],"VR18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 2], mPoint[19 * 9 + 2],"VR20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 2], mPoint[19 * 9 + 2],"VR20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 2], mPoint[21 * 9 + 2],"VR22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 2], mPoint[21 * 9 + 2],"VR22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 2], mPoint[23 * 9 + 2],"VR23") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[24 * 9 + 2], mPoint[23 * 9 + 2],"VR23") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[24 * 9 + 2], mPoint[25 * 9 + 2],"VR24") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[26 * 9 + 2], mPoint[25 * 9 + 2],"VR24") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[1 * 9 + 3], mPoint[2 * 9 + 3],"VR01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 3], mPoint[2 * 9 + 3],"VR01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 3], mPoint[4 * 9 + 3],"VR03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 3], mPoint[4 * 9 + 3],"VR03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 3], mPoint[6 * 9 + 3],"VR05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 3], mPoint[6 * 9 + 3],"VR05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 3], mPoint[8 * 9 + 3],"VR07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 3], mPoint[8 * 9 + 3],"VR07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 3], mPoint[10 * 9 + 3],"VR09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 3], mPoint[10 * 9 + 3],"VR09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 3], mPoint[12 * 9 + 3],"VR11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 3], mPoint[12 * 9 + 3],"VR11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 3], mPoint[14 * 9 + 3],"VR13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 3], mPoint[14 * 9 + 3],"VR13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 3], mPoint[16 * 9 + 3],"VR15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 3], mPoint[16 * 9 + 3],"VR15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 3], mPoint[18 * 9 + 3],"VR17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 3], mPoint[18 * 9 + 3],"VR17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 3], mPoint[20 * 9 + 3],"VR19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 3], mPoint[20 * 9 + 3],"VR19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 3], mPoint[22 * 9 + 3],"VR21") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[23 * 9 + 3], mPoint[22 * 9 + 3],"VR21") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[1 * 9 + 4], mPoint[2 * 9 + 4],"DR01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 4], mPoint[2 * 9 + 4],"DR01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 4], mPoint[4 * 9 + 4],"DR03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 4], mPoint[4 * 9 + 4],"DR03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 4], mPoint[6 * 9 + 4],"DR05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 4], mPoint[6 * 9 + 4],"DR05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 4], mPoint[8 * 9 + 4],"DR07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 4], mPoint[8 * 9 + 4],"DR07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 4], mPoint[10 * 9 + 4],"DR09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 4], mPoint[10 * 9 + 4],"DR09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 4], mPoint[12 * 9 + 4],"DR11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 4], mPoint[12 * 9 + 4],"DR11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 4], mPoint[14 * 9 + 4],"DR13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 4], mPoint[14 * 9 + 4],"DR13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 4], mPoint[16 * 9 + 4],"DR15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 4], mPoint[16 * 9 + 4],"DR15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 4], mPoint[18 * 9 + 4],"DR17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 4], mPoint[18 * 9 + 4],"DR17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 4], mPoint[20 * 9 + 4],"DR19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 4], mPoint[20 * 9 + 4],"DR19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 4], mPoint[22 * 9 + 4],"DR21") );	
        addMuscle( new Muscle(Globals.MStrength, mPoint[23 * 9 + 4], mPoint[22 * 9 + 4],"DR21") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[23 * 9 + 4], mPoint[24 * 9 + 4],"DR23") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[25 * 9 + 4], mPoint[24 * 9 + 4],"DR23") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[0 * 9 + 5], mPoint[1 * 9 + 5],"DR02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 5], mPoint[1 * 9 + 5],"DR02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 5], mPoint[3 * 9 + 5],"DR04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 5], mPoint[3 * 9 + 5],"DR04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 5], mPoint[5 * 9 + 5],"DR06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 5], mPoint[5 * 9 + 5],"DR06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 5], mPoint[7 * 9 + 5],"DR08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 5], mPoint[7 * 9 + 5],"DR08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 5], mPoint[9 * 9 + 5],"DR10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 5], mPoint[9 * 9 + 5],"DR10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 5], mPoint[11 * 9 + 5],"DR12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 5], mPoint[11 * 9 + 5],"DR12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 5], mPoint[13 * 9 + 5],"DR14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 5], mPoint[13 * 9 + 5],"DR14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 5], mPoint[15 * 9 + 5],"DR16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 5], mPoint[15 * 9 + 5],"DR16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 5], mPoint[17 * 9 + 5],"DR18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 5], mPoint[17 * 9 + 5],"DR18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 5], mPoint[19 * 9 + 5],"DR20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 5], mPoint[19 * 9 + 5],"DR20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 5], mPoint[21 * 9 + 5],"DR22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 5], mPoint[21 * 9 + 5],"DR22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 5], mPoint[23 * 9 + 5],"DR24") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[24 * 9 + 5], mPoint[23 * 9 + 5],"DR24") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[0 * 9 + 6], mPoint[1 * 9 + 6],"DL02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 6], mPoint[1 * 9 + 6],"DL02") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[2 * 9 + 6], mPoint[3 * 9 + 6],"DL04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 6], mPoint[3 * 9 + 6],"DL04") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[4 * 9 + 6], mPoint[5 * 9 + 6],"DL06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 6], mPoint[5 * 9 + 6],"DL06") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[6 * 9 + 6], mPoint[7 * 9 + 6],"DL08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 6], mPoint[7 * 9 + 6],"DL08") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[8 * 9 + 6], mPoint[9 * 9 + 6],"DL10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 6], mPoint[9 * 9 + 6],"DL10") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[10 * 9 + 6], mPoint[11 * 9 + 6],"DL12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 6], mPoint[11 * 9 + 6],"DL12") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[12 * 9 + 6], mPoint[13 * 9 + 6],"DL14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 6], mPoint[13 * 9 + 6],"DL14") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[14 * 9 + 6], mPoint[15 * 9 + 6],"DL16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 6], mPoint[15 * 9 + 6],"DL16") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[16 * 9 + 6], mPoint[17 * 9 + 6],"DL18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 6], mPoint[17 * 9 + 6],"DL18") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[18 * 9 + 6], mPoint[19 * 9 + 6],"DL20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 6], mPoint[19 * 9 + 6],"DL20") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[20 * 9 + 6], mPoint[21 * 9 + 6],"DL22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 6], mPoint[21 * 9 + 6],"DL22") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[22 * 9 + 6], mPoint[23 * 9 + 6],"DL24") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[24 * 9 + 6], mPoint[23 * 9 + 6],"DL24") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[1 * 9 + 7], mPoint[2 * 9 + 7],"DL01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 7], mPoint[2 * 9 + 7],"DL01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 7], mPoint[4 * 9 + 7],"DL03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 7], mPoint[4 * 9 + 7],"DL03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 7], mPoint[6 * 9 + 7],"DL05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 7], mPoint[6 * 9 + 7],"DL05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 7], mPoint[8 * 9 + 7],"DL07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 7], mPoint[8 * 9 + 7],"DL07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 7], mPoint[10 * 9 + 7],"DL09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 7], mPoint[10 * 9 + 7],"DL09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 7], mPoint[12 * 9 + 7],"DL11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 7], mPoint[12 * 9 + 7],"DL11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 7], mPoint[14 * 9 + 7],"DL13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 7], mPoint[14 * 9 + 7],"DL13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 7], mPoint[16 * 9 + 7],"DL15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 7], mPoint[16 * 9 + 7],"DL15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 7], mPoint[18 * 9 + 7],"DL17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 7], mPoint[18 * 9 + 7],"DL17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 7], mPoint[20 * 9 + 7],"DL19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 7], mPoint[20 * 9 + 7],"DL19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 7], mPoint[22 * 9 + 7],"DL21") );	
        addMuscle( new Muscle(Globals.MStrength, mPoint[23 * 9 + 7], mPoint[22 * 9 + 7],"DL21") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[23 * 9 + 7], mPoint[24 * 9 + 7],"DL23") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[25 * 9 + 7], mPoint[24 * 9 + 7],"DL23") );

        addMuscle( new Muscle(Globals.MStrength, mPoint[1 * 9 + 8], mPoint[2 * 9 + 8],"VL01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 8], mPoint[2 * 9 + 8],"VL01") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[3 * 9 + 8], mPoint[4 * 9 + 8],"VL03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 8], mPoint[4 * 9 + 8],"VL03") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[5 * 9 + 8], mPoint[6 * 9 + 8],"VL05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 8], mPoint[6 * 9 + 8],"VL05") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[7 * 9 + 8], mPoint[8 * 9 + 8],"VL07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 8], mPoint[8 * 9 + 8],"VL07") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[9 * 9 + 8], mPoint[10 * 9 + 8],"VL09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 8], mPoint[10 * 9 + 8],"VL09") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[11 * 9 + 8], mPoint[12 * 9 + 8],"VL11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 8], mPoint[12 * 9 + 8],"VL11") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[13 * 9 + 8], mPoint[14 * 9 + 8],"VL13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 8], mPoint[14 * 9 + 8],"VL13") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[15 * 9 + 8], mPoint[16 * 9 + 8],"VL15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 8], mPoint[16 * 9 + 8],"VL15") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[17 * 9 + 8], mPoint[18 * 9 + 8],"VL17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 8], mPoint[18 * 9 + 8],"VL17") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[19 * 9 + 8], mPoint[20 * 9 + 8],"VL19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 8], mPoint[20 * 9 + 8],"VL19") );
        addMuscle( new Muscle(Globals.MStrength, mPoint[21 * 9 + 8], mPoint[22 * 9 + 8],"VL21") );	
        addMuscle( new Muscle(Globals.MStrength, mPoint[23 * 9 + 8], mPoint[22 * 9 + 8],"VL21") );
        //Body added
        addMPoint( new CMassPoint(0.05f, mVshift+ new Vector3( -1 * dx - i* dx, 0 , 0 )) );

        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 0], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 1], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 2], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 3], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 4], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 5], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 6], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 7], mPoint[i * 9 + 0]) );
        addSpring( new CSpring(Globals.Detect, Globals.StiffCoeff, Globals.FrictCoeff, mPoint[(i - 1) * 9 + 8], mPoint[i * 9 + 0]) );

        LoadNeuronPosition();
        LoadNeuronConnection();
        LoadNeuronMuscle();

        KeysMan.AddKeyEvent(KeyCode.Keypad1, (Action<int>)ChangeSelectionPos, false, new object[1] { 1 });
        KeysMan.AddKeyEvent(KeyCode.Keypad4, (Action<int>)ChangeSelectionPos, false, new object[1] { 2 });
        KeysMan.AddKeyEvent(KeyCode.Keypad2, (Action<int>)ChangeSelectionPos, false, new object[1] { 3 });
        KeysMan.AddKeyEvent(KeyCode.Keypad5, (Action<int>)ChangeSelectionPos, false, new object[1] { 4 });
        KeysMan.AddKeyEvent(KeyCode.Keypad3, (Action<int>)ChangeSelectionPos, false, new object[1] { 5 });
        KeysMan.AddKeyEvent(KeyCode.Keypad6, (Action<int>)ChangeSelectionPos, false, new object[1] { 6 });
        KeysMan.AddKeyEvent(KeyCode.Keypad0, savePosition);
    }	
    public bool LoadNeuronPosition() {
        string file = Globals.NeuronPosFile;
        if(!File.Exists(file)) return false;

        int colorIdx;
        float x, y, z, threshold = 1;                            //default neuron threshold value
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines) {
            string[] vals = line.Split(Globals.splitor);
            if (vals.Length < 5) continue;

            string name = vals[0];
            if (!float.TryParse(vals[1], out x)) continue;
            if (!float.TryParse(vals[2], out y)) continue;
            if (!float.TryParse(vals[3], out z)) continue;
            if (!int.TryParse(vals[4], out colorIdx)) continue;

            char type = 'm';
            string lastChar = name.Substring(name.Length - 1, 1);
            if (lastChar == "L" || lastChar == "R") type = lastChar.ToLower()[0];
            Vector3 position = mVshift + new Vector3(dx * (-1.5f - x * size), y, -dl / 2 + (0.045f + z / 25) / 0.095f * length);
            addNeuron(name, position, threshold, type, colorIdx);
        }
        int count = mTable.Count;

        return true;
    }
    public bool LoadNeuronConnection() {
        string file = Globals.NeuronConnFile;
        if(!File.Exists(file)) return false;

        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines) {
            string[] vals = line.Split(Globals.splitor);
            if (vals.Length < 4) continue;

            int value;
            string neuronName1 = vals[0];
            string neuronName2 = vals[1];
            string ctype = vals[2];
            if (!int.TryParse(vals[3], out value)) continue;

            int i, j = 0, status = 0;
            if((ctype == "EJ") || (ctype[0] == 'S')) {
                for(i = 0; i < mNeuron.Count; i++) {
                    if(mNeuron[i].name == neuronName1) {
                        status = 1;
                        break;
                    }
                }

                if(status != 0) {
                    for(j = 0; j < mNeuron.Count; j++) {
                        if(mNeuron[j].name == neuronName2) {
                            status = 2;
                            break;
                        }
                    }
                }

                if(status == 2) {
                    mNeuron[i].addAxon(mNeuron[j], value);
                }
            }
        }
        return true;
    }
    public bool LoadNeuronMuscle() {
        string file = Globals.NeuronMuscleFile;
        if(!File.Exists(file))
            return false;

        string[] lines = File.ReadAllLines(file);
        foreach(string line in lines) {
            string[] vals = line.Split(Globals.splitor);
            if(vals.Length < 3)
                continue;

            float weight;
            string name1 = vals[0];
            string name2 = vals[1];
            if (name1 == "DD02")
                name1 = name1;
            if(!float.TryParse(vals[2], out weight)) continue;

            weight = 3.0f;
            addNeuroMuscleAxonByNames(name1, name2, weight);
        }
        return true;
    }
    ~Elegans() {
        int i;
        for(i = 0; i < mPoint.Count; ++i) {
            mPoint[i] = null;
        }
        for(i = 0; i < mSpring.Count; ++i) {
            mSpring[i] = null;
        }
        for(i = 0; i < mMuscle.Count; ++i) {
            mMuscle[i] = null;
        }
        for(i = 0; i < mNeuron.Count; ++i) {
            mNeuron[i] = null;
        }
    }

    void addMPoint(CMassPoint point) {
        mPoint.Add(point);
    }
    void addMPoint(float mass, Vector3 pos) {
        CMassPoint nPoint = new CMassPoint(mass, pos);
        mPoint.Add(nPoint);
    }
    void addMuscle(Muscle muscle) {
        mMuscle.Add(muscle);
    }
    void addMuscle(float strength, CMassPoint p1, CMassPoint p2, string name) {
        Muscle nMuscle = new Muscle(strength, p1, p2, name);
        mMuscle.Add(nMuscle);
    }
    void addSpring(float length, float stiffCoeff, float frictCoeff, CMassPoint p1, CMassPoint p2) {
        CSpring nSpring = new CSpring(length, stiffCoeff, frictCoeff, p1, p2);
        mSpring.Add(nSpring);
    }
    void addSpring(CSpring spring) {
        mSpring.Add(spring);
    }
    void addNeuron(string name, Vector3 pos, float threshold, char type, int colorIdx) {
        int i;

        for(i = 0; i < mTable.Count; i++) {
            if((pos.x - mPoint[9 * i + 8].x) * (pos.x - mPoint[9 * i + 17].x) <= 0) {
                break;
            }
        }

        pos.y *= 0.3f * length;
        /*
	    switch(type)
	    {
		    case 'l':
			    pos.y =  0.3 * length;
			    break;
		    case 'r':
			    pos.y = -0.3 * length;
			    break;
		    case 'm':
			    pos.y = 0;
			    break;
	    }
	    */

        float _x1 = mPoint[9 * i + 8].x;
        float _x2 = mPoint[9 * i + 17].x;
        float _y1 = mPoint[9 * i + 3].y;
        float _y2 = mPoint[9 * i + 8].y;
        float _z1 = mPoint[9 * i + 1].z;
        float _z2 = mPoint[9 * i + 6].z;

        float ratioX = (mPoint[9 * i + 8].x - pos.x) / Mathf.Abs(_x1 - _x2);
        float ratioY = (mPoint[9 * i + 3].y - pos.y) / Mathf.Abs(_y1 - _y2);
        float ratioZ = (pos.z - mPoint[9 * i + 1].z) / Mathf.Abs(_z1 - _z2);
        Neuron neuron = new Neuron(name, pos, threshold, ratioX, ratioY, ratioZ, type, colorIdx);
        mNeuron.Add(neuron);
        mTable[i].Add(neuron);
    }
    int addNeuroMuscleAxonByNames(string neuronName, string muscleName, float weight) {
        int i;
        if (neuronName == "DD02")
            i = 0;
        for(i = 0; i < mNeuron.Count; ++i) {
            if(neuronName == mNeuron[i].name) {
                break;
            }
        }

        if(i == mNeuron.Count)
            return 1;

        for(int j = 0; j < mMuscle.Count; ++j) {
            if(muscleName == mMuscle[j].name) {
                mNeuron[i].addAxon(mMuscle[j], weight);
            }
            //if(j == mMuscle.Count)	return 1;
        }
        return 0;
    }

    public void Draw() {
        for(int i = 0; i < mNeuron.Count; ++i) {
            //basic_string <char>::size_type contain;
            //contain = neuron[i].name.find("VB");
            //basic_string <char>::size_type contain1;
            //contain = neuron[i].name.find("DB");
            //if((neuron[i].name[0] == 'V' && neuron[i].name[1] == 'B')||(neuron[i].name[0] == 'D' && neuron[i].name[1] == 'B'))//contain != string::npos || contain1 != string::npos)
            {
                //	neuron[i].select();
                mNeuron[i].Draw();
            }
        }

        //if(!mode) return;
        for(int i = 0; i < mMuscle.Count; ++i) {
            mMuscle[i].Draw();
        }
        //Muscle drawed
        if(Globals.status != EAppStatus.running)
            return;

        for(int i = 0; i < mPoint.Count; ++i) {
            if(i != 10)
                mPoint[i].Draw();
        }
        mPoint[10].Select();

        for (int i = 0; i < mSpring.Count; ++i) {
            mSpring[i].Draw();
        }
        //	Springs drawed

    }
    public void UpdateLogic(float dt) {

        //if(f9) {
        //    mNeuron[mNeuron.Count - 1].ReceiveSignal(1);
        //}
        //if(f10) {
        //    mNeuron[mNeuron.Count - 2].ReceiveSignal(1);
        //}
        //if(f11) {
        //    mNeuron[mNeuron.Count - 3].ReceiveSignal(1);
        //}

        for(int i = 0; i < mNeuron.Count; ++i) {
            mNeuron[i].checkActivity();
        }

        for(int i = 0; i < mMuscle.Count; ++i) {
            mMuscle[i].checkActivity();
        }

        //set activity - 0||1 depending on income and thresold

        for(int i = 0; i < mNeuron.Count; ++i) {
            mNeuron[i].UpdateLogic();
        }


        if (!Globals.mode2) {
            return;
        }
        //Neurons 
        /*if(mode2 || mode3)
	    {
		    for(int k = 0; k < mNeuron.Count; k++)
		    {
			    basic_string <char>::size_type contain_temp;
			    contain_temp = neuron[k].name.find("Pse_");
			    if(contain_temp != string::npos)
			    {
				    if(neuron[k].isSelected())
				    {
					    neuron[k].unselect();
				    }
			    }
		    }
	    }*/
        for (int i = 0; i < mPoint.Count; ++i) {
            mPoint[i].Init();
            //Forses=0
            mPoint[i].UpdateLogic();
        }

        //Friction

        applyFriction();

        for(int i = 0; i < mSpring.Count; ++i) {
            mSpring[i].UpdateLogic();
        }

        //Spring friction added;
        for (int i = 0; i < mMuscle.Count; ++i) {
            mMuscle[i].UpdateLogic();
        }

        /**/
        if (Globals.mode3) {
            float neuro_signal;
            //Vector3 springVector;
            //Vector3 force;
            string m_name;

            //int cnt8 = 0;
            int j = 0;

            /*
		    for(i=0;i<mMuscle.Count;++i)
		    {
			    m_name = muscle[i].name;
			    j = atoi(m_name.c_str()+2)-1;

			    //if(j>6)
			    {
			
			    if( (m_name.find("VL")!=-1) || (m_name.find("VR")!=-1) )
			    {
				    neuro_signal = 2.3*(cos(1.5ff*time*direction+(mMuscle.Count/8-j/2)*0.6f)+0.5f);
				    springVector = muscle[i].getP1Pos() - muscle[i].getP2Pos();
				    springVector.unitize();
				    force = -springVector*neuro_signal;
				    muscle[i].applyForceP1(force);
				    muscle[i].applyForceP2(-force);
			    }
			    if( (m_name.find("DL")!=-1) || (m_name.find("DR")!=-1) )
			    {
				    neuro_signal = 2.3*(cos(1.5ff*time*direction+(mMuscle.Count/8-j/2)*0.6f+3.14159f)+0.5f);
				    springVector = muscle[i].getP1Pos() - muscle[i].getP2Pos();
				    springVector.unitize();
				    force = -springVector*neuro_signal;
				    muscle[i].applyForceP1(force);
				    muscle[i].applyForceP2(-force);
			    }

			    }
		    }
		    /**/

            /**/
            for(int i = 0; i < mMuscle.Count; ++i) {
                m_name = mMuscle[i].name;
                j = int.Parse(m_name.Substring(2)) - 1;
                if((m_name.IndexOf("VL") != -1) || (m_name.IndexOf("VR") != -1)) {
                    neuro_signal = (0.2f * (Mathf.Sin(3 * Mathf.PI * j / 24 - Mathf.PI / 2 - 0.5f * time * Globals.direction) + 1.0f) / 2);


                    //neuro_signal*=neuro_signal;
                    if((j < 2) || (j > 20))
                        neuro_signal *= 0.5f;
                    mMuscle[i].activate(neuro_signal);
                }
                if((m_name.IndexOf("DL") != -1) || (m_name.IndexOf("DR") != -1)) {
                    neuro_signal = (0.2f * (Mathf.Sin(3 * Mathf.PI * j / 24 + Mathf.PI / 2 - 0.5f * time * Globals.direction) + 1.0f) / 2);
                    //neuro_signal*=neuro_signal;
                    if((j < 2) || (j > 20))
                        neuro_signal *= 0.5f;
                    mMuscle[i].activate(neuro_signal);
                }


            }
        } // end of mode3

        if(Globals.mode4) {
            float neuro_signal;


            /*for(int k=0;k<neuron[i].axon.Count;k++)
            {
                neuron[i].axon[k].send()
            }*/

            for(int i = 0; i < mNeuron.Count; i++) {
                string n_name = mNeuron[i].name;
                if((n_name[0] == 'V' && n_name[1] == 'B') || (n_name[0] == 'D' && n_name[1] == 'B')) {
                    int j = int.Parse(n_name.Substring(2)) - 1;

                    if(n_name[0] == 'V' && n_name[1] == 'B') {
                        //neuro_signal = (float)(1.f*(cos(1.5ff*time*direction+(mMuscle.Count/8-j/2)*0.6f)+0.5f));
                        neuro_signal = (float)(1.0f * (Mathf.Sin(2 * Mathf.PI * j / 10 - Mathf.PI / 2 - 0.5f * time * Globals.direction) + 1.0f) / 2);
                        mNeuron[i].ReceiveSignal(neuro_signal);
                    }

                    if(n_name[0] == 'D' && n_name[1] == 'B') {
                        //neuro_signal = (float)(1.f*(cos(1.5ff*time*direction+(mMuscle.Count/8-j/2)*0.6f+3.14159f)+0.5f));
                        neuro_signal = (float)(1.0f * (Mathf.Sin(2 * Mathf.PI * j / 6 + Mathf.PI / 2 - 0.5f * time * Globals.direction) + 1.0f) / 2);
                        mNeuron[i].ReceiveSignal(neuro_signal);
                    }
                }
            }
        } // end of mode4

        time += dt;//0.002f;
        for(int i = 0; i < mPoint.Count; ++i) {
            mPoint[i].timeTick(dt);
        }
        neuronPosCorrection();
    }
    public void applyFriction() {
        Vector3 vel;
        Vector3 tangent;
        Vector3 normal;
        //Vector3 p1;
        //Vector3 p2;
        //Vector3 p3;
        //Vector3 force;
        Vector3 dp;

        int i;

        for(i = 0; i < mPoint.Count; ++i) {
            if(mPoint[i].pos.z <= 0) {

                ///
                vel = mPoint[i].getVel();
                //vel = mPoint[i].getForce();
                vel.z = 0;
                //force = mPoint[i].getForce();
                //force.z = 0;
                //good situation check 
                if(true) {
                    /*
				    float dzetta, kappa, dzetta1, kappa1;
				    if(i <= 8)
				    {
					    p1 = mPoint[i].pos;
					    p1.z = 0;
					    tangent = mPoint[i].pos - mPoint[i+9].pos;
					    tangent.unitize();
					    tangent = tangent + p1;
				    }
				    if(i >= mPoint.Count - 9)
				    {
					    p1 = mPoint[i].pos;
					    p1.z = 0;
					    tangent = mPoint[i - 9].pos - mPoint[i].pos;
					    tangent.unitize();
					    tangent = tangent + p1;
				    }
				    if((i > 8)&&(i < mPoint.Count - 9))
				    {
					    if(vel.magnitude>0.1)
					    {
						    i=i;
					    }
					    p1 = mPoint[i].pos;
					    p1.z = 0;
					    p2 = mPoint[i - 9].pos;
					    p2.z = 0;
					    p3 = mPoint[i + 9].pos;
					    p3.z = 0;
					    float a = (p2 - p3).magnitude, b = (p1 - p3).magnitude, c = (p1 - p2).magnitude;
					    float cosg = (b*b + c*c - a*a) / (2 * b * c);
					    float cosa = sqrt((1 - cosg)/2);
					    float d = sqrt(1 + pow(c,2) - 2 * c * cosa);
					    dzetta = (pow(d, 2) - 1 - pow(p2.x, 2) + pow(p1.x, 2) - pow(p2.y, 2) + pow(p1.y, 2)) / (2 * (p1.x - p2.x)) - p1.x;
					    kappa = (p1.y - p2.y)/(p2.x - p1.x);
					    tangent.z = 0;
					
					    float discr = pow(p1.y - dzetta * kappa, 2) - (pow(dzetta, 2) + pow(p1.y, 2) - 1) * (pow(kappa, 2)+1);
					    if(discr < 0)
					    {
						    discr = 0;
					    }

					    tangent.y = (p1.y - dzetta * kappa - sqrt(discr)) / (pow(kappa, 2) + 1);
					    tangent.x = dzetta + kappa * tangent.y + p1.x;
				
				    }

				    dzetta1 = (1 - pow(tangent.x, 2) + pow(p1.x, 2) - pow(tangent.y, 2) + pow(p1.y, 2)) / (2 * (p1.x - tangent.x)) - p1.x;
				    kappa1 = (p1.y - tangent.y)/(tangent.x - p1.x);
				    normal.z = 0;
				
				    float discr = pow(p1.y - dzetta1 * kappa1, 2) - (pow(dzetta1, 2) + pow(p1.y, 2) - 1) * (pow(kappa1, 2)+1);
				    if(discr < 0)
				    {
					    discr = 0;
				    }
				    normal.y = (p1.y - dzetta1 * kappa1 - sqrt(discr)) / (pow(kappa1, 2) + 1);
				    normal.x = dzetta1 + kappa1 * normal.y + p1.x;
				
			
				    tangent = tangent - p1;
				    normal = normal - p1;


				    float v1, v2, cosn, cost;

				    if(vel.magnitude != 0)
				    {
					    cosn = (pow(normal.magnitude, 2) + pow(vel.magnitude, 2) - pow((vel - normal).magnitude, 2)) / (2 * vel.magnitude * normal.magnitude);
					    cost = (pow(tangent.magnitude, 2) + pow(vel.magnitude, 2) - pow((vel - tangent).magnitude, 2)) / (2 * vel.magnitude * tangent.magnitude); 
					    v1 = vel.magnitude * cosn;
					    v2 = vel.magnitude * cost;
				    }
				    else
				    {
					    v1 = 0;
					    v2 = 0;
				    }
				    */

                    //if(force.magnitude != 0)
                    {
                        if(i <= 8)
                            dp = mPoint[i].pos - mPoint[i + 9].pos;
                        else
                        if(i >= mPoint.Count - 9)
                            dp = mPoint[i - 9].pos - mPoint[i].pos;
                        else
                            dp = (mPoint[i - 9].pos - mPoint[i + 9].pos) / 2;
                        dp.z = 0;

                        dp /= dp.normalized.magnitude;
                        tangent = dp * Vector3.Dot(vel, dp);
                        normal = vel - tangent;



                        /*
						    tangent = mPoint[i].pos - mPoint[i+9].pos;
						    tangent.unitize();
						    tangent = tangent + p1;
						    */



                        //Vector3 force = - (normal * v1 *1.0 + tangent * (v2 * 0.01)) * GroundFrictionConstant;
                        //*0.05f) * GroundFrictionConstant;

                        Vector3 force = -normal - tangent / 32.0f;// K = C_tangent/C_normal = 32 +/- 4, (Berri et. al., 2009);
                        mPoint[i].applyForce(force);
                    }



                }
            }
        }
    }

    void neuronPosCorrection() {
        int i;
        for(i = 0; i < mTable.Count; ++i) {
            Vector3 p1, p2, p3, p4, p5, p6, p7, p8, pp1, pp2, pp3, pp4, q1, q2;
            for(int j = 0; j < mTable[i].Count; ++j) {
                float ratioX = mTable[i][j].ratioX;
                float ratioY = mTable[i][j].ratioY;
                float ratioZ = mTable[i][j].ratioZ;

                /*
			    if(table[i][j].getType() == 'l')
			    {
				    p1 = (mPoint[9 * i + 8].pos * 0.2 + mPoint[9 * i + 3].pos * 0.8) * (1 - ratioX)\
					    + (mPoint[9 * i + 17].pos * 0.2 + mPoint[9 * i + 12].pos * 0.8) * ratioX;
				    p2 = (mPoint[9 * i + 7].pos * 0.2 + mPoint[9 * i + 4].pos * 0.8) * (1 - ratioX)\
					    + (mPoint[9 * i + 16].pos * 0.2 + mPoint[9 * i + 13].pos * 0.8) * ratioX;
				    p3 = (mPoint[9 * i + 1].pos * 0.2 + mPoint[9 * i + 2].pos * 0.8) * (1 - ratioZ)\
					    + (mPoint[9 * i + 6].pos * 0.2 + mPoint[9 * i + 5].pos * 0.8) * ratioZ;
				    p4 = (mPoint[9 * i + 10].pos * 0.2 + mPoint[9 * i + 11].pos * 0.8) * (1 - ratioZ)\
					    + (mPoint[9 * i + 15].pos * 0.2 + mPoint[9 * i + 14].pos * 0.8) * ratioZ;
			    }
			    if(table[i][j].getType() == 'r')
			    {
				    p1 = (mPoint[9 * i + 8].pos * 0.8 + mPoint[9 * i + 3].pos * 0.2) * (1 - ratioX)\
					    + (mPoint[9 * i + 17].pos * 0.8 + mPoint[9 * i + 12].pos * 0.2) * ratioX;
				    p2 = (mPoint[9 * i + 7].pos * 0.8 + mPoint[9 * i + 4].pos * 0.2) * (1 - ratioX)\
					    + (mPoint[9 * i + 16].pos * 0.8 + mPoint[9 * i + 13].pos * 0.2) * ratioX;
				    p3 = (mPoint[9 * i + 1].pos * 0.8 + mPoint[9 * i + 2].pos * 0.2) * (1 - ratioZ)\
					    + (mPoint[9 * i + 6].pos * 0.8 + mPoint[9 * i + 5].pos * 0.2) * ratioZ;
				    p4 = (mPoint[9 * i + 10].pos * 0.8 + mPoint[9 * i + 11].pos * 0.2) * (1 - ratioZ)\
					    + (mPoint[9 * i + 15].pos * 0.8 + mPoint[9 * i + 14].pos * 0.2) * ratioZ;
			    }
			    if(table[i][j].getType() == 'm')
			    {
				    p1 = (mPoint[9 * i + 8].pos * 0.5 + mPoint[9 * i + 3].pos * 0.5) * (1 - ratioX)\
					    + (mPoint[9 * i + 17].pos * 0.5 + mPoint[9 * i + 12].pos * 0.5) * ratioX;
				    p2 = (mPoint[9 * i + 7].pos * 0.5 + mPoint[9 * i + 4].pos * 0.5) * (1 - ratioX)\
					    + (mPoint[9 * i + 16].pos * 0.5 + mPoint[9 * i + 13].pos * 0.5) * ratioX;
				    p3 = (mPoint[9 * i + 1].pos * 0.5 + mPoint[9 * i + 2].pos * 0.5) * (1 - ratioZ)\
					    + (mPoint[9 * i + 6].pos * 0.5 + mPoint[9 * i + 5].pos * 0.5) * ratioZ;
				    p4 = (mPoint[9 * i + 10].pos * 0.5 + mPoint[9 * i + 11].pos * 0.5) * (1 - ratioZ)\
					    + (mPoint[9 * i + 15].pos * 0.5 + mPoint[9 * i + 14].pos * 0.5) * ratioZ;
			    }
			
			    q1 = p1 * (1 - ratioZ) + p2 * ratioZ;
			    q2 = p3 * (1 - ratioX) + p4 * ratioX;
			    table[i][j] .setPos((q1 + q2) / 2);
			    */

                //ratioX = 0.3;
                //ratioZ = 0.3;

                p1 = (mPoint[9 * i + 8].pos + mPoint[9 * i + 1].pos) / 2;
                p2 = (mPoint[9 * i + 2].pos + mPoint[9 * i + 3].pos) / 2;
                p3 = (mPoint[9 * i + 4].pos + mPoint[9 * i + 5].pos) / 2;
                p4 = (mPoint[9 * i + 6].pos + mPoint[9 * i + 7].pos) / 2;

                p5 = (mPoint[9 * i + 17].pos + mPoint[9 * i + 10].pos) / 2;
                p6 = (mPoint[9 * i + 11].pos + mPoint[9 * i + 12].pos) / 2;
                p7 = (mPoint[9 * i + 13].pos + mPoint[9 * i + 14].pos) / 2;
                p8 = (mPoint[9 * i + 15].pos + mPoint[9 * i + 16].pos) / 2;

                pp1 = p1 * (1 - ratioX) + p5 * (ratioX);
                pp2 = p2 * (1 - ratioX) + p6 * (ratioX);
                pp3 = p3 * (1 - ratioX) + p7 * (ratioX);
                pp4 = p4 * (1 - ratioX) + p8 * (ratioX);

                q1 = pp1 * (1 - ratioZ) + pp4 * (ratioZ);
                q2 = pp2 * (1 - ratioZ) + pp3 * (ratioZ);

                /*
			    if(table[i][j].getType() == 'r')
			    {
					    table[i][j].setPos( q1*0.8 + q2*0.2 );
					    if(i< 2) table[i][j].setPos( q1*0.60 + q2*0.40 ); else
					    if(i< 4) table[i][j].setPos( q1*0.70 + q2*0.30 ); else
					    //if(i< 6) table[i][j].setPos( q1*0.70 + q2*0.30 ); else
					    if(i>24) table[i][j].setPos( q1*0.60 + q2*0.40 ); else
					    if(i>22) table[i][j].setPos( q1*0.70 + q2*0.30 ); //else
					    //if(i>20) table[i][j].setPos( q1*0.55 + q2*0.45 ); 
			    }
			    else
			    if(table[i][j].getType() == 'l')
			    {
					    table[i][j].setPos( q2*0.8 + q1*0.2 );
					    if(i< 2) table[i][j].setPos( q2*0.60 + q1*0.40 ); else
					    if(i< 4) table[i][j].setPos( q2*0.70 + q1*0.30 ); else
					    //if(i< 6) table[i][j].setPos( q2*0.70 + q1*0.30 ); else
					    if(i>24) table[i][j].setPos( q2*0.60 + q1*0.40 ); else
					    if(i>22) table[i][j].setPos( q2*0.70 + q1*0.30 ); //else
					    //if(i>20) table[i][j].setPos( q2*0.55 + q1*0.45 ); 
			    }
			    else
			    if(table[i][j].getType() == 'm')
			    {
					    table[i][j].setPos( q1*0.5 + q2*0.5 );
			    }
			    */

                mTable[i][j].pos.Setup(q1 * ratioY + q2 * (1 - ratioY));
                //table[i][j].setPos( q1*0.5 + q2*(0.5) );

            }
        }
    }
    public void rotateWormAroundAnterPosterAxis(float angle) {
        Vector3 vAPaxis = mPoint[0].pos - mPoint[mPoint.Count - 1].pos;
        //ort1 = Vector3::RotateVector1AroundVector2(ort1,Vector3(0,0,1),alpha);

        for(int i = 1; i < mPoint.Count - 2; i++) {
            mPoint[i].pos = Tools.RotateVector1AroundVector2(mPoint[i].pos - mPoint[mPoint.Count - 1].pos, vAPaxis, angle) + mPoint[mPoint.Count - 1].pos;
        }
        neuronPosCorrection();
        for(int i = 0; i < mMuscle.Count; i++) {
            mMuscle[i].UpdateLogic();
        }

        return;
    }


    public void ClearSelection() {
        for(int i = 0; i < mNeuron.Count; ++i)
            mNeuron[i].select = false;
    }
    public void savePosition() {
        string[] lines = new string[mNeuron.Count];
        for(int i = 0; i < mNeuron.Count; i++) {
            float x = (-1.5f - (mNeuron[i].pos.pos - mVshift).x / dx) / size;
            float z = 25 * (((mNeuron[i].pos.pos - mVshift).z + dl / 2) * 0.095f / length - 0.045f);
            float y = (mNeuron[i].pos.pos - mVshift).y / (length * 0.3f);
            //mVshift+Vector3(dx * ( -1.5 - x*size) , y, -dl/2+(0.045 + z/25) / 0.095 * length
            lines[i] = string.Format("{0},{1},{2},{3},{4}", mNeuron[i].name, x, y, z, mNeuron[i].colorIdx);
        }
    }
    public void ChangeSelectionPos(int direction) {
        for(int i = 0; i < mNeuron.Count; i++) {
            if(mNeuron[i].name.IndexOf("Pse_") >= 0)
		    {
                if(mNeuron[i].select) {
                    if(direction == 1)
                        mNeuron[i].addPosX(0.001f);
                    if(direction == 2)
                        mNeuron[i].addPosX(-0.001f);
                    if(direction == 3)
                        mNeuron[i].addPosZ(0.001f);
                    if(direction == 4)
                        mNeuron[i].addPosZ(-0.001f);
                    if(direction == 5)
                        mNeuron[i].addPosY(0.001f);
                    if(direction == 6)
                        mNeuron[i].addPosY(-0.001f);
                    return;
                }
            }
        }
    }
    public Neuron UpdateSelection(int idx) {
        //int i;
        //Vector3 p = (Globals.vbeg - Globals.vend);
        //Vector3 u = p / p.magnitude;
        //Vector3 w, n;
        //float d, z = 0;
        //int j = -1;

        //for(i = 0; i < mNeuron.Count; ++i) {
        //    w = (Globals.ort1 * (mNeuron[i].pos.x - Globals.pos_rc.x) + Globals.ort2 * (mNeuron[i].pos.y - Globals.pos_rc.y) + Globals.ort3 * (mNeuron[i].pos.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter - Globals.vend;
        //    n = u * Vector3.Dot(u, w) + Globals.vend;
        //    w = w + Globals.vend;

        //    d = (n - w).magnitude;

        //    if(d <= Globals.neuron_normal * Globals.scale) {
        //        if((j == -1) || ((j >= 0) && (w.z > z))) {
        //            z = w.z;
        //            j = i;
        //        }
        //    }
        //}

        if (idx >= 0) {
            if(mNeuron[idx].select == false) {
                if(mNeuron[idx].name.IndexOf("Pse_") >= 0)
			    {
                    for(int k = 0; k < mNeuron.Count; k++) {
                        if(mNeuron[k].name.IndexOf("Pse_") >= 0)
					    {
                            if(mNeuron[k].select) {
                                mNeuron[k].select = false;
                            /*sel = true;
                            break;*/
                            }
                        //mNeuron[idx] ->select(); 
                        }
                    }
                    mNeuron[idx].select = true;
                } else {
                    mNeuron[idx].select = true;
                }
                Debug.Log("select " + mNeuron[idx].name + " index:" + idx);
                return mNeuron[idx];
            } else
                mNeuron[idx].select = false;

                Globals.vcenter += (Globals.ort1 * (mNeuron[idx].pos.x - Globals.pos_rc.x) + Globals.ort2 * (mNeuron[idx].pos.y - Globals.pos_rc.y) + Globals.ort3 * (mNeuron[idx].pos.z - Globals.pos_rc.z)) * Globals.scale;

                Globals.pos_rc = mNeuron[idx].pos.pos;
            return null;
        }
	    return null;
    }
}   // end of Elegans
