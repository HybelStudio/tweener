using System;
using UnityEngine;

namespace Hybel
{
    public partial class Interpolate
    {
        public delegate float EaseFunction(float t);

        // Interpolator Functions

        // Scalar
        public static float Scalar(float start, float end, float t) =>
            Scalar(start, end, t, Linear);

        public static float Scalar(float start, float end, float t, EaseFunction ease) =>
            start + (end - start) * ease(Clamp01(t));

        public static float ScalarUnclamped(float start, float end, float t) =>
            ScalarUnclamped(start, end, t, Linear);

        public static float ScalarUnclamped(float start, float end, float t, EaseFunction ease) =>
            start + (start - end) * ease(t);

        public static float BiScalar(float bottomLeft, float bottomRight, float topLeft, float topRight, float t1, float t2) =>
            BiScalar(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static float BiScalar(
            float bottomLeft,
            float bottomRight,
            float topLeft,
            float topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            float bottom = Scalar(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            float top = Scalar(topLeft, topRight, t1, topHorizontalEase);
            return Scalar(bottom, top, t2, verticalEase);
        }

        public static float BiScalar(BiLerpData<float> biLerpData, float t1, float t2) =>
            BiScalar(biLerpData, t1, t2, Linear, Linear, Linear);

        public static float BiScalar(
            BiLerpData<float> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiScalar(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static float BiScalarUnclamped(float bottomLeft, float bottomRight, float topLeft, float topRight, float t1, float t2) =>
            BiScalarUnclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static float BiScalarUnclamped(
            float bottomLeft,
            float bottomRight,
            float topLeft,
            float topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            float bottom = ScalarUnclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            float top = ScalarUnclamped(topLeft, topRight, t1, topHorizontalEase);
            return ScalarUnclamped(bottom, top, t2, verticalEase);
        }

        public static float BiScalarUnclamped(BiLerpData<float> biLerpData, float t1, float t2) =>
            BiScalarUnclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static float BiScalarUnclamped(
            BiLerpData<float> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiScalarUnclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        // Vector2
        public static Vector2 Vector2(Vector2 start, Vector2 end, float t) =>
            Vector2(start, end, t, Linear);

        public static Vector2 Vector2(Vector2 start, Vector2 end, float t, EaseFunction ease) =>
            UnityEngine.Vector2.Lerp(start, end, ease(t));

        public static Vector2 Vector2Unclamped(Vector2 start, Vector2 end, float t) =>
            Vector2Unclamped(start, end, t, Linear);

        public static Vector2 Vector2Unclamped(Vector2 start, Vector2 end, float t, EaseFunction ease) =>
            UnityEngine.Vector2.LerpUnclamped(start, end, ease(t));

        public static Vector2 BiVector2(Vector2 bottomLeft, Vector2 bottomRight, Vector2 topLeft, Vector2 topRight, float t1, float t2) =>
            BiVector2(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2(
            Vector2 bottomLeft,
            Vector2 bottomRight,
            Vector2 topLeft,
            Vector2 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector2 bottom = Vector2(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector2 top = Vector2(topLeft, topRight, t1, topHorizontalEase);
            return Vector2(bottom, top, t2, verticalEase);
        }

        public static Vector2 BiVector2(BiLerpData<Vector2> biLerpData, float t1, float t2) =>
            BiVector2(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2(
            BiLerpData<Vector2> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector2(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Vector2 BiVector2Unclamped(Vector2 bottomLeft, Vector2 bottomRight, Vector2 topLeft, Vector2 topRight, float t1, float t2) =>
            BiVector2Unclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2Unclamped(
            Vector2 bottomLeft,
            Vector2 bottomRight,
            Vector2 topLeft,
            Vector2 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector2 bottom = Vector2Unclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector2 top = Vector2Unclamped(topLeft, topRight, t1, topHorizontalEase);
            return Vector2Unclamped(bottom, top, t2, verticalEase);
        }

        public static Vector2 BiVector2Unclamped(BiLerpData<Vector2> biLerpData, float t1, float t2) =>
            BiVector2Unclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2Unclamped(
            BiLerpData<Vector2> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector2Unclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Vector3
        public static Vector3 Vector3(Vector3 start, Vector3 end, float t) =>
            Vector3(start, end, t, Linear);

        public static Vector3 Vector3(Vector3 start, Vector3 end, float t, EaseFunction ease) =>
            UnityEngine.Vector3.Lerp(start, end, ease(t));

        public static Vector3 Vector3Unclamped(Vector3 start, Vector3 end, float t) =>
            Vector3Unclamped(start, end, t, Linear);

        public static Vector3 Vector3Unclamped(Vector3 start, Vector3 end, float t, EaseFunction ease) =>
            UnityEngine.Vector3.LerpUnclamped(start, end, ease(t));

        public static Vector3 BiVector3(Vector3 bottomLeft, Vector3 bottomRight, Vector3 topLeft, Vector3 topRight, float t1, float t2) =>
            BiVector3(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3(
            Vector3 bottomLeft,
            Vector3 bottomRight,
            Vector3 topLeft,
            Vector3 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector3 bottom = Vector3(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector3 top = Vector3(topLeft, topRight, t1, topHorizontalEase);
            return Vector3(bottom, top, t2, verticalEase);
        }

        public static Vector3 BiVector3(BiLerpData<Vector3> biLerpData, float t1, float t2) =>
            BiVector3(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3(
            BiLerpData<Vector3> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector3(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Vector3 BiVector3Unclamped(Vector3 bottomLeft, Vector3 bottomRight, Vector3 topLeft, Vector3 topRight, float t1, float t2) =>
            BiVector3Unclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3Unclamped(
            Vector3 bottomLeft,
            Vector3 bottomRight,
            Vector3 topLeft,
            Vector3 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector3 bottom = Vector3Unclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector3 top = Vector3Unclamped(topLeft, topRight, t1, topHorizontalEase);
            return Vector3Unclamped(bottom, top, t2, verticalEase);
        }

        public static Vector3 BiVector3Unclamped(BiLerpData<Vector3> biLerpData, float t1, float t2) =>
            BiVector3Unclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3Unclamped(
            BiLerpData<Vector3> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector3Unclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Vector4
        public static Vector4 Vector4(Vector4 start, Vector4 end, float t) =>
            Vector4(start, end, t, Linear);

        public static Vector4 Vector4(Vector4 start, Vector4 end, float t, EaseFunction ease) =>
            UnityEngine.Vector4.Lerp(start, end, ease(t));

        public static Vector4 Vector4Unclamped(Vector4 start, Vector4 end, float t) =>
            Vector4Unclamped(start, end, t, Linear);

        public static Vector4 Vector4Unclamped(Vector4 start, Vector4 end, float t, EaseFunction ease) =>
            UnityEngine.Vector4.LerpUnclamped(start, end, ease(t));

        public static Vector4 BiVector4(Vector4 bottomLeft, Vector4 bottomRight, Vector4 topLeft, Vector4 topRight, float t1, float t2) =>
            BiVector4(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector4 BiVector4(
            Vector4 bottomLeft,
            Vector4 bottomRight,
            Vector4 topLeft,
            Vector4 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector4 bottom = Vector4(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector4 top = Vector4(topLeft, topRight, t1, topHorizontalEase);
            return Vector4(bottom, top, t2, verticalEase);
        }

        public static Vector4 BiVector4(BiLerpData<Vector4> biLerpData, float t1, float t2) =>
            BiVector4(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector4 BiVector4(
            BiLerpData<Vector4> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector4(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Vector4 BiVector4Unclamped(Vector4 bottomLeft, Vector4 bottomRight, Vector4 topLeft, Vector4 topRight, float t1, float t2) =>
            BiVector4Unclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector4 BiVector4Unclamped(
            Vector4 bottomLeft,
            Vector4 bottomRight,
            Vector4 topLeft,
            Vector4 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector4 bottom = Vector4Unclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector4 top = Vector4Unclamped(topLeft, topRight, t1, topHorizontalEase);
            return Vector4Unclamped(bottom, top, t2, verticalEase);
        }

        public static Vector4 BiVector4Unclamped(BiLerpData<Vector4> biLerpData, float t1, float t2) =>
            BiVector4Unclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector4 BiVector4Unclamped(
            BiLerpData<Vector4> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector4Unclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Vector2Int
        public static Vector2 Vector2Int(Vector2Int start, Vector2Int end, float t) =>
            Vector2Int(start, end, t, Linear);

        public static Vector2 Vector2Int(Vector2Int start, Vector2Int end, float t, EaseFunction ease) =>
            Vector2(start, end, t, ease);

        public static Vector2 Vector2IntUnclamped(Vector2Int start, Vector2Int end, float t) =>
            Vector2IntUnclamped(start, end, t, Linear);

        public static Vector2 Vector2IntUnclamped(Vector2Int start, Vector2Int end, float t, EaseFunction ease) =>
            Vector2Unclamped(new Vector2(start.x, start.y), new Vector2(end.x, end.y), t, ease);

        public static Vector2 BiVector2Int(Vector2Int bottomLeft, Vector2Int bottomRight, Vector2Int topLeft, Vector2Int topRight, float t1, float t2) =>
            BiVector2Int(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2Int(
            Vector2Int bottomLeft,
            Vector2Int bottomRight,
            Vector2Int topLeft,
            Vector2Int topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector2 bottom = Vector2Int(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector2 top = Vector2Int(topLeft, topRight, t1, topHorizontalEase);
            return Vector2(bottom, top, t2, verticalEase);
        }

        public static Vector2 BiVector2Int(BiLerpData<Vector2Int> biLerpData, float t1, float t2) =>
            BiVector2Int(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2Int(
            BiLerpData<Vector2Int> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector2Int(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Vector2 BiVector2IntUnclamped(Vector2Int bottomLeft, Vector2Int bottomRight, Vector2Int topLeft, Vector2Int topRight, float t1, float t2) =>
            BiVector2IntUnclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2IntUnclamped(
            Vector2Int bottomLeft,
            Vector2Int bottomRight,
            Vector2Int topLeft,
            Vector2Int topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector2 bottom = Vector2IntUnclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector2 top = Vector2IntUnclamped(topLeft, topRight, t1, topHorizontalEase);
            return Vector2Unclamped(bottom, top, t2, verticalEase);
        }

        public static Vector2 BiVector2IntUnclamped(BiLerpData<Vector2Int> biLerpData, float t1, float t2) =>
            BiVector2IntUnclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector2IntUnclamped(
            BiLerpData<Vector2Int> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector2IntUnclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Vector3Int
        public static Vector3 Vector3Int(Vector3Int start, Vector3Int end, float t) =>
            Vector3Int(start, end, t, Linear);

        public static Vector3 Vector3Int(Vector3Int start, Vector3Int end, float t, EaseFunction ease) =>
            Vector3(start, end, t, ease);

        public static Vector3 Vector3IntUnclamped(Vector3Int start, Vector3Int end, float t) =>
            Vector3IntUnclamped(start, end, t, Linear);

        public static Vector3 Vector3IntUnclamped(Vector3Int start, Vector3Int end, float t, EaseFunction ease) =>
            Vector3Unclamped(new Vector3(start.x, start.y, start.z), new Vector3(end.x, end.y, end.z), t, ease);

        public static Vector2 BiVector3Int(Vector3Int bottomLeft, Vector3Int bottomRight, Vector3Int topLeft, Vector3Int topRight, float t1, float t2) =>
            BiVector3Int(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector2 BiVector3Int(
            Vector3Int bottomLeft,
            Vector3Int bottomRight,
            Vector3Int topLeft,
            Vector3Int topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector2 bottom = Vector3Int(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector2 top = Vector3Int(topLeft, topRight, t1, topHorizontalEase);
            return Vector2(bottom, top, t2, verticalEase);
        }

        public static Vector3 BiVector3Int(BiLerpData<Vector3Int> biLerpData, float t1, float t2) =>
            BiVector3Int(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3Int(
            BiLerpData<Vector3Int> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector3Int(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Vector3 BiVector3IntUnclamped(Vector3Int bottomLeft, Vector3Int bottomRight, Vector3Int topLeft, Vector3Int topRight, float t1, float t2) =>
            BiVector3IntUnclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3IntUnclamped(
            Vector3Int bottomLeft,
            Vector3Int bottomRight,
            Vector3Int topLeft,
            Vector3Int topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Vector2 bottom = Vector3IntUnclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Vector2 top = Vector3IntUnclamped(topLeft, topRight, t1, topHorizontalEase);
            return Vector2Unclamped(bottom, top, t2, verticalEase);
        }

        public static Vector3 BiVector3IntUnclamped(BiLerpData<Vector3Int> biLerpData, float t1, float t2) =>
            BiVector3IntUnclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Vector3 BiVector3IntUnclamped(
            BiLerpData<Vector3Int> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiVector3IntUnclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Quaternion
        public static Quaternion Quaternion(Quaternion start, Quaternion end, float t) =>
            Quaternion(start, end, t, Linear);

        public static Quaternion Quaternion(Quaternion start, Quaternion end, float t, EaseFunction ease) =>
            UnityEngine.Quaternion.Lerp(start, end, ease(t));

        public static Quaternion QuaternionUnclamped(Quaternion start, Quaternion end, float t) =>
            QuaternionUnclamped(start, end, t, Linear);

        public static Quaternion QuaternionUnclamped(Quaternion start, Quaternion end, float t, EaseFunction ease) =>
            UnityEngine.Quaternion.LerpUnclamped(start, end, ease(t));

        public static Quaternion BiQuaternion(Quaternion bottomLeft, Quaternion bottomRight, Quaternion topLeft, Quaternion topRight, float t1, float t2) =>
            BiQuaternion(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Quaternion BiQuaternion(
            Quaternion bottomLeft,
            Quaternion bottomRight,
            Quaternion topLeft,
            Quaternion topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Quaternion bottom = Quaternion(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Quaternion top = Quaternion(topLeft, topRight, t1, topHorizontalEase);
            return Quaternion(bottom, top, t2, verticalEase);
        }

        public static Quaternion BiQuaternion(BiLerpData<Quaternion> biLerpData, float t1, float t2) =>
            BiQuaternion(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Quaternion BiQuaternion(
            BiLerpData<Quaternion> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiQuaternion(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Quaternion BiQuaternionUnclamped(Quaternion bottomLeft, Quaternion bottomRight, Quaternion topLeft, Quaternion topRight, float t1, float t2) =>
            BiQuaternionUnclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Quaternion BiQuaternionUnclamped(
            Quaternion bottomLeft,
            Quaternion bottomRight,
            Quaternion topLeft,
            Quaternion topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Quaternion bottom = QuaternionUnclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Quaternion top = QuaternionUnclamped(topLeft, topRight, t1, topHorizontalEase);
            return QuaternionUnclamped(bottom, top, t2, verticalEase);
        }

        public static Quaternion BiQuaternionUnclamped(BiLerpData<Quaternion> biLerpData, float t1, float t2) =>
            BiQuaternionUnclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Quaternion BiQuaternionUnclamped(
            BiLerpData<Quaternion> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiQuaternionUnclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Color
        public static Color Color(Color start, Color end, float t) =>
            Color(start, end, t, Linear);

        public static Color Color(Color start, Color end, float t, EaseFunction ease) =>
            UnityEngine.Color.Lerp(start, end, ease(t));

        public static Color ColorUnclamped(Color start, Color end, float t) =>
            ColorUnclamped(start, end, t, Linear);

        public static Color ColorUnclamped(Color start, Color end, float t, EaseFunction ease) =>
            UnityEngine.Color.LerpUnclamped(start, end, ease(t));

        public static Color BiColor(Color bottomLeft, Color bottomRight, Color topLeft, Color topRight, float t1, float t2) =>
            BiColor(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Color BiColor(
            Color bottomLeft,
            Color bottomRight,
            Color topLeft,
            Color topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Color bottom = Color(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Color top = Color(topLeft, topRight, t1, topHorizontalEase);
            return Color(bottom, top, t2, verticalEase);
        }

        public static Color BiColor(BiLerpData<Color> biLerpData, float t1, float t2) =>
            BiColor(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Color BiColor(
            BiLerpData<Color> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiColor(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Color BiColorUnclamped(Color bottomLeft, Color bottomRight, Color topLeft, Color topRight, float t1, float t2) =>
            BiColorUnclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Color BiColorUnclamped(
            Color bottomLeft,
            Color bottomRight,
            Color topLeft,
            Color topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Color bottom = ColorUnclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Color top = ColorUnclamped(topLeft, topRight, t1, topHorizontalEase);
            return ColorUnclamped(bottom, top, t2, verticalEase);
        }

        public static Color BiColorUnclamped(BiLerpData<Color> biLerpData, float t1, float t2) =>
            BiColorUnclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Color BiColorUnclamped(
            BiLerpData<Color> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiColorUnclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Color32
        public static Color32 Color32(Color32 start, Color32 end, float t) =>
            Color32(start, end, t, Linear);

        public static Color32 Color32(Color32 start, Color32 end, float t, EaseFunction ease) =>
            UnityEngine.Color32.Lerp(start, end, ease(t));

        public static Color32 Color32Unclamped(Color32 start, Color32 end, float t) =>
            Color32Unclamped(start, end, t, Linear);

        public static Color32 Color32Unclamped(Color32 start, Color32 end, float t, EaseFunction ease) =>
            UnityEngine.Color32.LerpUnclamped(start, end, ease(t));

        public static Color32 BiColor32(Color32 bottomLeft, Color32 bottomRight, Color32 topLeft, Color32 topRight, float t1, float t2) =>
            BiColor32(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Color32 BiColor32(
            Color32 bottomLeft,
            Color32 bottomRight,
            Color32 topLeft,
            Color32 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Color32 bottom = Color32(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Color32 top = Color32(topLeft, topRight, t1, topHorizontalEase);
            return Color32(bottom, top, t2, verticalEase);
        }

        public static Color32 BiColor32(BiLerpData<Color32> biLerpData, float t1, float t2) =>
            BiColor32(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Color32 BiColor32(
            BiLerpData<Color32> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiColor32(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);

        public static Color32 BiColor32Unclamped(Color32 bottomLeft, Color32 bottomRight, Color32 topLeft, Color32 topRight, float t1, float t2) =>
            BiColor32Unclamped(bottomLeft, bottomRight, topLeft, topRight, t1, t2, Linear, Linear, Linear);

        public static Color32 BiColor32Unclamped(
            Color32 bottomLeft,
            Color32 bottomRight,
            Color32 topLeft,
            Color32 topRight,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase)
        {
            Color32 bottom = Color32Unclamped(bottomLeft, bottomRight, t1, bottomHorizontalEase);
            Color32 top = Color32Unclamped(topLeft, topRight, t1, topHorizontalEase);
            return Color32Unclamped(bottom, top, t2, verticalEase);
        }

        public static Color32 BiColor32Unclamped(BiLerpData<Color32> biLerpData, float t1, float t2) =>
            BiColor32Unclamped(biLerpData, t1, t2, Linear, Linear, Linear);

        public static Color32 BiColor32Unclamped(
            BiLerpData<Color32> biLerpData,
            float t1,
            float t2,
            EaseFunction bottomHorizontalEase,
            EaseFunction topHorizontalEase,
            EaseFunction verticalEase) =>
            BiColor32Unclamped(
                biLerpData.BottomLeft,
                biLerpData.BottomRight,
                biLerpData.TopLeft,
                biLerpData.TopRight,
                t1,
                t2,
                bottomHorizontalEase,
                topHorizontalEase,
                verticalEase);


        // Interpolation Functions
        public static float Clamp(float t) => Mathf.Round(t);
        public static float Linear(float t) => t;

        public static float SineIn(float t) => 1 - Mathf.Cos(t * Mathf.PI * .5f);
        public static float SineOut(float t) => Mathf.Sin((t * Mathf.PI) * .5f);
        public static float SineInOut(float t) => -(Mathf.Cos(t * Mathf.PI) - 1) * .5f;

        public static float QuadIn(float t) => t * t;
        public static float QuadOut(float t)
        {
            float v = 1 - t;
            return 1f - v * v;
        }

        public static float QuadInOut(float t)
        {
            if (t < .5f)
                return 2f * t * t;

            float v = -2f * t + 2f;
            return 1f - v * v * .5f;
        }

        public static float CubeIn(float t) => t * t * t;
        public static float CubeOut(float t)
        {
            float v = 1 - t;
            return 1f - v * v * v;
        }

        public static float CubeInOut(float t)
        {
            if (t < .5f)
                return 4f * t * t * t;

            float v = -2f * t + 2f;
            return 1f - v * v * v * .5f;
        }

        public static float QuartIn(float t) => t * t * t * t;
        public static float QuartOut(float t)
        {
            float v = 1f - t;
            return 1f - v * v * v * v;
        }

        public static float QuartInOut(float t)
        {
            if (t < .5f)
                return 8f * t * t * t * t;

            float v = -2f * t + 2f;
            return 1f - v * v * v * v * .5f;
        }

        public static float QuintIn(float t) => t * t * t * t * t;
        public static float QuintOut(float t)
        {
            float v = 1 - t;
            return 1f - v * v * v * v * v;
        }

        public static float QuintInOut(float t)
        {
            if (t < .5f)
                return 16f * t * t * t * t * t;

            float v = -2f * t + 2f;
            return 1f - v * v * v * v * v * .5f;
        }

        public static float SextIn(float t) => t * t * t * t * t * t;
        public static float SextOut(float t)
        {
            float v = 1 - t;
            return 1f - v * v * v * v * v * v;
        }

        public static float SextInOut(float t)
        {
            if (t < .5f)
                return 32f * t * t * t * t * t * t;

            float v = -2f * t + 2;
            return 1f - v * v * v * v * v * v * .5f;
        }

        public static float SeptIn(float t) => t * t * t * t * t * t * t;
        public static float SeptOut(float t)
        {
            float v = 1 - t;
            return 1f - v * v * v * v * v * v * v;
        }

        public static float SeptInOut(float t)
        {
            if (t < .5f)
                return 64f * t * t * t * t * t * t * t;

            float v = -2f * t + 2;
            return 1f - v * v * v * v * v * v * v * .5f;
        }

        public static float OctIn(float t) => t * t * t * t * t * t * t * t;
        public static float OctOut(float t)
        {
            float v = 1 - t;
            return 1f - v * v * v * v * v * v * v * v;
        }

        public static float OctInOut(float t)
        {
            if (t < .5f)
                return 128f * t * t * t * t * t * t * t * t;

            float v = -2f * t + 2;
            return 1f - v * v * v * v * v * v * v * v * .5f;
        }

        public static float ExpoIn(float t) => t == 0f ? 0f : Mathf.Pow(2f, 10f * t - 10f);
        public static float ExpoOut(float t) => t == 1f ? 1f : 1f - Mathf.Pow(2f, -10f * t);
        public static float ExpoInOut(float t) => t == 0f ? 0f : t == 1f ? 1f : t < .5f ? Mathf.Pow(2f, 20f * t - 10f) * .5f : (2f - Mathf.Pow(2f, -20f * t + 10f)) * .5f;

        public static float CircIn(float t) => 1f - Mathf.Sqrt(1f - t * t);
        public static float CircOut(float t)
        {
            float v = (t - 1f);
            return Mathf.Sqrt(1f - v * v);
        }

        public static float CircInOut(float t)
        {
            if (t < .5f)
            {
                float v = (2f * t);
                return (1f - Mathf.Sqrt(1f - v * v)) * .5f;
            }

            {
                float v = -2f * t + 2;
                return (Mathf.Sqrt(1f - v * v) + 1) * .5f;
            }
        }

        public static float BackIn(float t)
        {
            const float C1 = 1.70158f;
            const float C2 = C1 + 1f;
            return C2 * t * t * t - C1 * t * t;
        }

        public static float BackOut(float t)
        {
            const float C1 = 1.70158f;
            const float C2 = C1 + 1f;

            float v = t - 1f;
            return 1f + C2 * v * v * v + C1 * v * v;
        }

        public static float BackInOut(float t)
        {
            const float C3 = 3.22658f;

            if (t < .5f)
            {
                float v = 2f * t;
                return v * v * ((C3 + 1f) * 2f * t - C3) * .5f;
            }

            {
                float v = 2f * t - 2f;
                return (v * v * ((C3 + 1) * v + C3) + 2f) * .5f;
            }
        }

        public static float ElasticIn(float t)
        {
            const float C4 = 2f * Mathf.PI * .333f;
            return t == 0f ? 0f : t == 1f ? 1f : -Mathf.Pow(2f, 10f * t - 10f) * Mathf.Sin((t * 10f - 10.75f) * C4);
        }

        public static float ElasticOut(float t)
        {
            const float C4 = 2f * Mathf.PI * .333f;
            return t == 0f ? 0f : t == 1f ? 1f : Mathf.Pow(2f, -10f * t) * Mathf.Sin((t * 10f - 0.75f) * C4) + 1f;
        }

        public static float ElasticInOut(float t)
        {
            const float C5 = (2f * Mathf.PI) * .222f;
            return t == 0f ? 0f : t == 1f ? 1f : t < .5f ? -(Mathf.Pow(2f, 20f * t - 10f) * Mathf.Sin((20f * t - 11.125f) * C5)) * .5f : (Mathf.Pow(2f, -20f * t + 10f) * Mathf.Sin((20f * t - 11.125f) * C5)) * 2f + 1f;
        }

        public static float BounceIn(float t) => Flip(BounceOut(Flip(t)));
        public static float BounceOut(float t)
        {
            const float N1 = 7.5625f;
            const float D1 = 2.75f;

            return t switch
            {
                var x when x < 1f / D1 => N1 * t * t,
                var x when x < 2f / D1 => N1 * (t - 1.5f / D1) * (t - 1.5f / D1) + 0.75f,
                var x when x < 2.5f / D1 => N1 * (t - 2.25f / D1) * (t - 2.25f / D1) + 0.9375f,
                var _ => N1 * (t - 2.625f / D1) * (t - 2.625f / D1) + 0.984375f,
            };
        }
        public static float BounceInOut(float t) => t < .5f ? (1f - BounceOut(1f - 2f * t)) * .5f : (1f + BounceOut(2f * t - 1f)) * .5f;

        public static float Parabola(float t, float p) => Mathf.Pow(4f * t * (1f - t), p);
        public static float Triangle(float t) => 1f - 2f * Mathf.Abs(t - .5f);

        public static float SmoothStep(float t)
        {
            t = Mathf.Clamp01(t);
            return t * t * (3 - 2 * t);
        }

        public static float SmoothStep(float p, float t) => SmoothStep(p, 1f - p, t);
        public static float SmoothStep(float p1, float p2, float t)
        {
            t = Mathf.Max(0f, Mathf.Min(1f, (t - p1) / (p2 - p1)));
            float smoothStep = t * t * (3 - 2 * t);

            return smoothStep;
        }

        public static EaseFunction Ease(Ease ease)
        {
            return ease switch
            {
                Hybel.Ease.Clamp => Clamp,
                Hybel.Ease.Linear => Linear,
                Hybel.Ease.SineIn => SineIn,
                Hybel.Ease.SineOut => SineOut,
                Hybel.Ease.SineInOut => SineInOut,
                Hybel.Ease.QuadIn => QuadIn,
                Hybel.Ease.QuadOut => QuadOut,
                Hybel.Ease.QuadInOut => QuadInOut,
                Hybel.Ease.CubeIn => CubeIn,
                Hybel.Ease.CubeOut => CubeOut,
                Hybel.Ease.CubeInOut => CubeInOut,
                Hybel.Ease.QuartIn => QuartIn,
                Hybel.Ease.QuartOut => QuartOut,
                Hybel.Ease.QuartInOut => QuartInOut,
                Hybel.Ease.QuintIn => QuintIn,
                Hybel.Ease.QuintOut => QuintOut,
                Hybel.Ease.QuintInOut => QuintInOut,
                Hybel.Ease.SextIn => SextIn,
                Hybel.Ease.SextOut => SextOut,
                Hybel.Ease.SextInOut => SextInOut,
                Hybel.Ease.SeptIn => SeptIn,
                Hybel.Ease.SeptOut => SeptOut,
                Hybel.Ease.SeptInOut => SeptInOut,
                Hybel.Ease.OctIn => OctIn,
                Hybel.Ease.OctOut => OctOut,
                Hybel.Ease.OctInOut => OctInOut,
                Hybel.Ease.ExpoIn => ExpoIn,
                Hybel.Ease.ExpoOut => ExpoOut,
                Hybel.Ease.ExpoInOut => ExpoInOut,
                Hybel.Ease.CircIn => CircIn,
                Hybel.Ease.CircOut => CircOut,
                Hybel.Ease.CircInOut => CircInOut,
                Hybel.Ease.BackIn => BackIn,
                Hybel.Ease.BackOut => BackOut,
                Hybel.Ease.BackInOut => BackInOut,
                Hybel.Ease.ElasticIn => ElasticIn,
                Hybel.Ease.ElasticOut => ElasticOut,
                Hybel.Ease.ElasticInOut => ElasticInOut,
                Hybel.Ease.BounceIn => BounceIn,
                Hybel.Ease.BounceOut => BounceOut,
                Hybel.Ease.BounceInOut => BounceInOut,
                Hybel.Ease.Triangle => Triangle,
                Hybel.Ease.SmoothStep => SmoothStep,
                _ => Linear,
            };
        }

        public static EaseFunction FromCurve(AnimationCurve curve) => t => curve.Evaluate(t);

        // Modifier Functions
        public static float Wrap(float t) => t % 1f;

        public static float Spiked(float t)
        {
            if (t <= .5f)
                return t * 2f;

            return Flip(t) * 2f;
        }

        public static float Spiked(float t, float bias)
        {
            if (t <= bias)
                return t / bias;

            return Flip(t) / (1 - bias);
        }

        public static float Spiked(float t, float bias, int spikes)
        {
            if (spikes == 0)
                return t;

            spikes = Mathf.Abs(spikes);

            float period = 1f / spikes;
            int spikeIndex = Mathf.FloorToInt(t * spikes);

            float spikeProgress = (t - spikeIndex * period) / period;

            float lineProgress = Mathf.InverseLerp(0f, bias, spikeProgress);

            if (spikeProgress > bias)
                lineProgress = Mathf.InverseLerp(1f, bias, spikeProgress);

            return Mathf.Lerp(0f, 1f, lineProgress) + Mathf.Floor(t);
        }

        public static float Flip(float t) => 1 - t;

        public static float Flip(float t, float threshold)
        {
            threshold = Mathf.Clamp01(threshold);

            if (t >= threshold)
                return 1f - t;

            return t;
        }

        public static float ScaleUp(float t, float scale) => t * scale;
        public static float ScaleDown(float t, float scale) => t / scale;

        private static float Clamp01(float t) => Mathf.Clamp01(t);

        public struct BiLerpData<T>
        {
            public T BottomLeft;
            public T BottomRight;
            public T TopLeft;
            public T TopRight;
            private readonly Func<T, T, float, T> _lerpFunc;

            public BiLerpData(T bottomLeft, T bottomRight, T topLeft, T topRight, Func<T, T, float, T> lerpFunc)
            {
                BottomLeft = bottomLeft;
                BottomRight = bottomRight;
                TopLeft = topLeft;
                TopRight = topRight;
                _lerpFunc = lerpFunc;
            }

            public T Lerp(float t1, float t2)
            {
                T bottom = _lerpFunc(BottomLeft, BottomRight, t1);
                T top = _lerpFunc(TopLeft, TopRight, t1);
                return _lerpFunc(bottom, top, t2);
            }
        }

        public struct TriLerpData<T>
        {
            public BiLerpData<T> Left;
            public BiLerpData<T> Right;

            public TriLerpData(BiLerpData<T> left, BiLerpData<T> right)
            {
                Left = left;
                Right = right;
            }
        }
    }
}
