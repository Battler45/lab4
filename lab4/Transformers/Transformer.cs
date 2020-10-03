using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace lab4
{
    public static class MatrixExtensions
    {
        public static Matrix Product(this ICollection<Matrix> matrices)
        {
            if (matrices.Count() < 2) return matrices.FirstOrDefault();
            var product = matrices.Skip(1).Aggregate(matrices.First().Clone(), (seed, matrix) =>
            {
                seed.Multiply(matrix);
                return seed;
            });
            return product;
        }
    }

    public class Transformer
    {

        public static Matrix GetRotationMatrix(Point origin, double angleInRadians)
            => new Matrix(
                (float)Math.Cos(angleInRadians), (float)Math.Sin(angleInRadians),
                (float)-Math.Sin(angleInRadians), (float)Math.Cos(angleInRadians),
                (float)(-origin.X * Math.Cos(angleInRadians) + origin.Y * Math.Sin(angleInRadians) + origin.X),
                (float)(-origin.X * Math.Sin(angleInRadians) - origin.Y * Math.Cos(angleInRadians) + origin.Y));


        public static Matrix GetScaleMatrix(Point origin, float scalePercentage)
            => new Matrix(
                scalePercentage, 0,
                0, scalePercentage,
                (1 - scalePercentage) * origin.X, (1 - scalePercentage) * origin.Y);

        public static Transformer GetInstance() => new Transformer();
        public Primitive Transform(Primitive primitive, double[,] transformMatrix)
        {
            var centroid = primitive.Centroid;
            var transformedPolygonPoints = multiply_matrix(primitive.Points, transformMatrix);

            Primitive transformedPrimitive = primitive switch
            {
                _ when primitive is Polygon => new Polygon(transformedPolygonPoints),
                _ when primitive is Edge => new Edge(transformedPolygonPoints),
                _ => throw new Exception()
            };
            transformedPrimitive.SetCentroid(centroid);
            return transformedPrimitive;

           
        }

        public Primitive Transform(Primitive primitive, Matrix transformMatrix)
        {
            var transformedPrimitivePoints = primitive.Points.ToArray();
            transformMatrix.TransformPoints(transformedPrimitivePoints);
            Primitive transformedPrimitive = primitive switch
            {
                _ when primitive is Polygon => new Polygon(transformedPrimitivePoints),
                _ when primitive is Edge => new Edge(transformedPrimitivePoints),
                _ => throw new Exception()
            };
            return transformedPrimitive;
        }

        public Primitive Transform(Primitive primitive, ICollection<Matrix> transformMatrices) => Transform(primitive, transformMatrices.Product());

        private List<Point> multiply_matrix(List<Point> points, double[,] matrix)
        {
            var newPoints = new List<Point>(points);

            for (var i = 0; i < newPoints.Count; i++)
            {
                var currentPoint = new int[3];
                currentPoint[0] = newPoints[0].X;
                currentPoint[1] = newPoints[0].Y;
                currentPoint[2] = 1;

                var resultPoint = new int[3];
                double sum = 0;
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    for (var k = 0; k < matrix.GetLength(0); k++)
                    {
                        sum += currentPoint[k] * matrix[k, j];
                    }
                    resultPoint[j] = (int)sum;
                    sum = 0;
                }

                newPoints.RemoveAt(0);
                newPoints.Add(new Point(resultPoint[0], resultPoint[1]));
            }

            return newPoints;
        }

        private Point TransformPoint(double[] pointMatrix, double[,] transformationMatrix)
        {
            var resultPoint = new int[3];
            double sum = 0;
            for (var j = 0; j < transformationMatrix.GetLength(0); j++)
            {
                for (var k = 0; k < transformationMatrix.GetLength(0); k++)
                {
                    sum += pointMatrix[k] * transformationMatrix[k, j];
                }
                resultPoint[j] = (int)sum;
                sum = 0;
            }
            return new Point(resultPoint[0], resultPoint[1]);
        }

    }
}