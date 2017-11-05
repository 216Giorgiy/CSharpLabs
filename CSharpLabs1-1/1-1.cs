using System;
using System.Diagnostics;
using System.Linq;

namespace CSharpLabs1
{
    namespace Exp1
    {
        internal static class Program
        {
            private static void Main()
            {
                var a = new[,]
                {
                    {1, 2, 3, 4},
                    {5, 6, 7, 8},
                    {9, 10, 11, 12}
                };
                var b = new[,]
                {
                    {12, 11, 10},
                    {9, 8, 7},
                    {6, 5, 4},
                    {3, 2, 1}
                };
                var ansFor = MatrixMultiply_For(a, b);
                var ansLinq = MatrixMultiply_Linq(a, b);
                Debug.Assert(ansLinq.Cast<int>().SequenceEqual(ansFor.Cast<int>()));
                for (var i = 0; i < ansFor.GetLength(0); ++i)
                {
                    for (var j = 0; j < ansFor.GetLength(1); ++j)
                        Console.Write("{0,4:d}", ansFor[i, j]);
                    Console.WriteLine();
                }
                Console.Write($"数组共有{ansFor.Length}个元素");
            }

            /// <summary>
            ///     使用for循环实现矩阵乘法
            /// </summary>
            /// <param name="a">左矩阵</param>
            /// <param name="b">右矩阵</param>
            /// <returns>积</returns>
            private static int[,] MatrixMultiply_For(int[,] a, int[,] b)
            {
                Debug.Assert(a.GetLength(1) == b.GetLength(0));
                var x = a.GetLength(0);
                var y = b.GetLength(0);
                var z = b.GetLength(1);
                var res = new int[x, z];

                for (var i = 0; i < x; ++i)
                    for (var j = 0; j < z; ++j)
                        for (var k = 0; k < y; ++k)
                            res[i, j] += a[i, k] * b[k, j];

                return res;
            }

            /// <summary>
            ///     使用Linq实现矩阵乘法
            /// </summary>
            /// <param name="ls">左矩阵</param>
            /// <param name="rs">右矩阵</param>
            /// <returns>积</returns>
            private static int[,] MatrixMultiply_Linq(int[,] ls, int[,] rs) =>
            (from lRow in ls.ToJagged() //获取左矩阵的行
             select
             (from rColunmIndex in rs.ToJagged()[0].Select((_, index) => index) //获取右矩阵对应的列索引
                 select
                     (from rRow in rs.ToJagged() select rRow[rColunmIndex]) //获取右矩阵该列的元素
                     .Zip(lRow, (rowCell, columnCell) => rowCell * columnCell).Sum() //与左矩阵的行相乘求和
             ).ToArray()).ToArray().ToMultiDim(); //转换为二维数组

            /// <summary>
            ///     将二维数组转为交错数组
            /// </summary>
            /// <param name="array">二维数组</param>
            /// <returns>交错数组</returns>
            private static int[][] ToJagged(this int[,] array) =>
            (from rowIndex in Enumerable.Range(0, array.GetLength(0)) //获取行索引
             select
                 (from columnIndex in Enumerable.Range(0, array.GetLength(1)) //获取列索引
                     select
                         array[rowIndex, columnIndex]) //二维数组中当前格的值
                 .ToArray()).ToArray(); //转为交错数组

            /// <summary>
            ///     将交错数组转为二维数组
            /// </summary>
            /// <param name="array">交错数组</param>
            /// <returns>二维数组</returns>
            private static int[,] ToMultiDim(this int[][] array) =>
                new Func<int[,], int, int[,]>((res /*新建二维数组*/, rowIndex /*当前行索引*/) =>
                    array.Aggregate(res,
                        (ans, row) => //获取当前行
                            (from i in row.Select((value, columnIndex) => (value, columnIndex)) //获取当前元素与在列索引
                             select ans[rowIndex, i.columnIndex] = i.value) //赋值
                            .Select(_ => ans).ToList()[(++rowIndex, 0).Item2] //自增行索引并返回
                    ))(new int[array.GetLength(0), array[0].GetLength(0)], 0);
        }
    }
}