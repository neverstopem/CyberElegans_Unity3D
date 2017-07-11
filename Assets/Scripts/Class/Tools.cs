/* author: em
 *  email: neverstopem@gmail.com
 */

using UnityEngine;

public class Tools
{
    public static Vector3 RotateVector1AroundVector2(Vector3 v1, Vector3 v2, float alpha)
    {
        if (v1 == v2) return v1;

        Vector3 ort1, ort2, ort3;

        alpha *= Mathf.PI / 180.0f;

        ort1 = v2 / v2.magnitude;
        ort2 = Vec3Mode(v1, v2);
        if (ort2.magnitude != 0) ort2 /= ort2.magnitude;

        ort3 = Vec3Mode(ort2, ort1);
        if (ort3.magnitude != 0) ort3 /= ort3.magnitude;

        return ort1 * Vector3.Dot(v1, ort1) + ort2 * Vector3.Dot(v1, ort3) * Mathf.Sin(alpha) + ort3 * Vector3.Dot(v1, ort3) * Mathf.Cos(alpha);
    }

    public static Vector3 Vec3Mode(Vector3 lv, Vector3 rv)
    {
        Vector3 t = new Vector3();
        t.x = lv.y * rv.z - lv.z * rv.y;
        t.y = lv.z * rv.x - lv.x * rv.z;
        t.z = lv.x * rv.y - lv.y * rv.x;
        return t;
    }
}
