using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrbitCalculator
{

    private OrbitData[] data;
    private double AU = 149597870d;
    public DateTime nowTime;
    public DateTime J2000;
    public TimeSpan timeSpan;
    public double d;
    public double c;

    public double[] nowData = new double[6];
    public double w;//근일점 편각
    public double M;//펼균 근점이각
    public double[] toRad = new double[5];
    public double E;//편심이각
    public double r;
    public double v;

    public OrbitCalculator(OrbitData[] orbit, DateTime now) {
        data = orbit;

        nowTime = now;
        J2000  = Convert.ToDateTime("2000/01/01 00:00");

        data[0].a *= AU;
        data[1].a *= AU;
    }

    public double prev_rad = 0, p = 0; 

    public OrbitData[] calculate(double t) {
        nowTime  = nowTime.AddMilliseconds(t);
        timeSpan = nowTime.Subtract(J2000);
        d = timeSpan.TotalMilliseconds / (1000) / 60 / 60 / 24;
        c = d / 100 / 365.25;

        data[2].a = data[0].a + (data[1].a * c);
        data[2].e = data[0].e + (data[1].e * c);
        data[2].i = data[0].i + (data[1].i * c);
        data[2].o = data[0].o + (data[1].o * c);
        data[2].l = data[0].l + (data[1].l * c);
        data[2].lp = data[0].lp + (data[1].lp * c);
        //a 장반경, e이심률, i기울기, o승교점 적경, l평균 경도, lp근일점 경도[J200, 1Century]

        data[2].w = data[2].lp - data[2].o;//근일점 편각
        data[2].M = data[2].l - data[2].lp;//평균 근점이각

        double DEG_RAD = Math.PI / 180;
        data[2].a *= 1000;//a
        data[2].i *= DEG_RAD;//i
        data[2].o *= DEG_RAD;//o
        data[2].w *= DEG_RAD;//w
        data[2].M *= DEG_RAD;//M

        data[2].E = kepler(data[2].e, data[2].M, 20);
        E = data[2].E;


        double RAD_DEG = 180 / Math.PI;
        double x = data[2].a * (Math.Cos(data[2].E) - data[2].e);
        double y = data[2].a * (Math.Sqrt(1 - (data[2].e * data[2].e)))
                                                 * Math.Sin(data[2].E);

        r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        v = Math.Atan2(y, x);

        r /= (1000*AU);

        data[2].r = r;
        data[2].v = v;

        return data;
    }

    private double kepler(double e, double M, int count) {
        bool isFirst = true;
        double result = 0;
        double x = 0;
        for(int a = 0;a < count;a++) {
            if (isFirst) {
                isFirst = false;
                x = M + (M + e * Math.Sin(M) - M) / (1 - e * Math.Cos(M));
                result = x;
            } else {
                result = x + (M + e * Math.Sin(x) - x) / (1 - e * Math.Cos(x));
                x = result;
            }
        }
        return result;
    }
}
