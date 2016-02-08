using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Vec2
    {
        public static Vec2 zero { get { return new Vec2(0, 0); } }

        public float x = 0;
        public float y = 0;


        float magnitude;

        public Vec2(float pX = 0, float pY = 0)
        {
            x = pX;
            y = pY;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }

        public Vec2 Add(Vec2 other)
        {
            x += other.x;
            y += other.y;
            return this;
        }
        public Vec2 Sub(Vec2 other)
        {
            x -= other.x;
            y -= other.y;
            return this;
        }
        public Vec2 Scale(float scalar)
        {
            x *= scalar;
            y *= scalar;
            return this;
        }
        public static float Deg2Rad(float deg)
        {
            float rad = deg * (float)Math.PI / 180;
            return rad;
        }
        public static float Rad2Deg(float rad)
        {
            float deg = rad * 180 / (float)Math.PI;
            return deg;
        }
        public static Vec2 GetUnitVectorDegrees(float degrees)
        {
            Vec2 vectorDegrees = new Vec2();
            vectorDegrees.x = Mathf.Cos(degrees);
            vectorDegrees.y = Mathf.Sin(degrees);
            return vectorDegrees;
        }
        public static Vec2 GetUnitVectorRadians(float radians)
        {
            Vec2 vectorRadians = new Vec2();
            return vectorRadians;
        }
        public static Vec2 RandomUnitVector()
        {
            return GetUnitVectorDegrees(Utils.Random(0, 359));
        }
        public Vec2 SetAngleDegrees(float degrees)
        {
            float radians = Deg2Rad(degrees);
            float length = GetMagnitude();
            x = Mathf.Cos(radians);
            y = Mathf.Sin(radians);
            //Scale(length); //Return old magnitude
            return this;
        }
        public Vec2 SetAngleRadians(float radians)
        {
            float length = GetMagnitude();
            x = Mathf.Sin(radians);
            y = Mathf.Cos(radians);
            Scale(length); //Return old magnitude
            return this;
        }
        public float GetAngleDegrees()
        {

            float radians = Mathf.Atan2(x, y); // Returns angle given x and y in radians
            float degrees = radians * 180 / Mathf.PI;
            return degrees;
        }
        public float GetAngleRadians()
        {
            float radians = Mathf.Atan2(x, y); // Returns angle given x and y in radians
            return radians;
        }

        public void RotateDegrees(float degrees)
        {
            float radians = Deg2Rad(degrees);
            float positionX;
            float positionY;
            positionX = x * Mathf.Cos(radians) - y * Mathf.Sin(radians);
            positionY = x * Mathf.Sin(radians) + y * Mathf.Cos(radians);
            x = positionX;
            y = positionY;
        }

        public void RotateRadians(float radians)
        {
            float positionX;
            float positionY;
            positionX = x * Mathf.Cos(radians) - y * Mathf.Sin(radians);
            positionY = x * Mathf.Sin(radians) + y * Mathf.Cos(radians);
            x = positionX;
            y = positionY;
        }
        public Vec2 RotateAroundDegrees(Vec2 rotatingAround, float degrees)
        {
            x -= rotatingAround.x;
            y -= rotatingAround.y;
            float radians = Deg2Rad(degrees);
            float positionX;
            float positionY;
            positionX = x * Mathf.Cos(radians) - y * Mathf.Sin(radians);
            positionY = x * Mathf.Sin(radians) + y * Mathf.Cos(radians);
            x = positionX + rotatingAround.x;
            y = positionY + rotatingAround.y;
            return this;
        }
        public Vec2 RotateAroundRadians(Vec2 rotatingAround, float radians)
        {
            x -= rotatingAround.x;
            y -= rotatingAround.y;
            float positionX;
            float positionY;
            positionX = x * Mathf.Cos(radians) - y * Mathf.Sin(radians);
            positionY = x * Mathf.Sin(radians) + y * Mathf.Cos(radians);
            x = positionX + rotatingAround.x;
            y = positionY + rotatingAround.y;
            return this;
        }
        public Vec2 Clone()
        {
            Vec2 clone = new Vec2(x, y);
            return clone;
        }
        public float GetMagnitude()
        {
            magnitude = x * x + y * y;
            magnitude = (float)Math.Sqrt(magnitude);
            return magnitude;
        }
        public Vec2 Normal()
        {
            Vec2 unitNormal = new Vec2(-y, x);
            unitNormal.Normalize();
            return unitNormal;
        }
        public float Dot(Vec2 vec)
        {
            float dot = x * vec.x + y * vec.y;
            return dot;
        }
        public Vec2 Normalize()
        {
            magnitude = GetMagnitude();
            if (x != 0 || y != 0)
            {
                x /= magnitude;
                y /= magnitude;
            }
            return this;
        }
        public Vec2 Reflect(Vec2 pNormal, float pBounciness = 1)
        {
            Sub(pNormal.Scale((1 + pBounciness) * Dot(pNormal)));
            return this;
        }
        public void SetXY(float setX, float setY)
        {
            x = setX;
            y = setY;
        }
    }
}
