using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OrbitData {
    public double a, e ,i, o, l, lp, w, M, E, r, v;

    public OrbitData(double a, double e, double i,
    double o, double l, double lp, double w, double M, 
    double E, double r, double v) {
        this.a = a;
        this.e = e;
        this.i = i;
        this.o = o;
        this.l = l;
        this.lp = lp;
        this.w = w;
        this.M = M;
        this.E = E;
        this.r = r;
        this.v = v;
    }
}