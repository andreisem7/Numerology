using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numerology.BL
{
    public class Matrix // 3x3
    {
        public enum Edge
        {
            Vertical1 = 1, // Ego
            Vertical2 = 2, // Finances
            Vertical3 = 3, // Talent
            Horizontal1 = 4, // Aim
            Horizontal2 = 5, // Family
            Horizontal3 = 6, // Stability
            DiagonalLeftTopToRightBottom = 7, // Spirituality
            DiagonalLeftBottomToRightTop = 8 // Sex
        }
        private static int _capacity = 3 * 3;
        public static int Capacity { get { return _capacity; } }
        public List<MatrixCell> Cells { get; set; }

        public Matrix()
        {
            Cells = new List<MatrixCell>(Capacity);
        }
        public void AddCell(int index, int number, int count)
        {
            var cell = new MatrixCell(index, number, count);
            Cells.Add(cell);
        }
        public string GetCellValue(int index)
        {
            var matrixCell = GetCell(index);
            if (matrixCell == null) throw new ArgumentOutOfRangeException("No cell with index " + index.ToString());
            return matrixCell.StringValue;
        }

        private MatrixCell GetCell(int index)
        {
            return Cells.FirstOrDefault(x => x.Index == index);
        }

        public static List<MatrixCell> TwoMatrixAnalisys(Matrix first, Matrix second)
        {
            if (first == null && second == null) return null;

            var result = new List<MatrixCell>();
            for (int i = 0; i < Capacity; i++)
            {
                var sum = first.GetCell(i + 1).CountOfNumber + second.GetCell(i + 1).CountOfNumber;
                var cell = new MatrixCell(i + 1, i + 1, sum);
                result.Add(cell);
            }
            return result;
        }

        public int GetEdgeValue(Edge edge)
        {
            if (Cells == null) return 0;
            switch (edge)
            {
                case Edge.Vertical1: // Ego
                    {
                        return Cells.First(x => x.Index == 1).CountOfNumber + Cells.First(x => x.Index == 2).CountOfNumber + Cells.First(x => x.Index == 3).CountOfNumber;
                    }
                case Edge.Vertical2: // Finances
                    {
                        return Cells.First(x => x.Index == 4).CountOfNumber + Cells.First(x => x.Index == 5).CountOfNumber + Cells.First(x => x.Index == 6).CountOfNumber;
                    }
                case Edge.Vertical3: // Talent
                    {
                        return Cells.First(x => x.Index == 7).CountOfNumber + Cells.First(x => x.Index == 8).CountOfNumber + Cells.First(x => x.Index == 9).CountOfNumber;
                    }
                case Edge.Horizontal1: // Aim
                    {
                        return Cells.First(x => x.Index == 1).CountOfNumber + Cells.First(x => x.Index == 4).CountOfNumber + Cells.First(x => x.Index == 7).CountOfNumber;
                    }
                case Edge.Horizontal2: // Family
                    {
                        return Cells.First(x => x.Index == 2).CountOfNumber + Cells.First(x => x.Index == 5).CountOfNumber + Cells.First(x => x.Index == 8).CountOfNumber;
                    }
                case Edge.Horizontal3: // Stability
                    {
                        return Cells.First(x => x.Index == 3).CountOfNumber + Cells.First(x => x.Index == 6).CountOfNumber + Cells.First(x => x.Index == 9).CountOfNumber;
                    }
                case Edge.DiagonalLeftTopToRightBottom: // Spirituality
                    {
                        return Cells.First(x => x.Index == 1).CountOfNumber + Cells.First(x => x.Index == 5).CountOfNumber + Cells.First(x => x.Index == 9).CountOfNumber;
                    }
                case Edge.DiagonalLeftBottomToRightTop: // Sex
                    {
                        return Cells.First(x => x.Index == 3).CountOfNumber + Cells.First(x => x.Index == 5).CountOfNumber + Cells.First(x => x.Index == 7).CountOfNumber;
                    }
                default: return 0;
            }
        }
    }
    public class MatrixCell
    {
        private string stringValue = String.Empty;
        public int Index { get; set; }
        public int Number { get; set; }
        public int CountOfNumber { get; set; }
        /// <summary>
        /// Readonly string value in format "111" or "55" and etc.
        /// </summary>
        public string StringValue { get { return stringValue; } }

        public MatrixCell(int index, int number, int count)
        {
            Index = index;
            Number = number;
            CountOfNumber = count;
            stringValue = CreateStringValue(Number, CountOfNumber);
        }

        private string CreateStringValue(int number, int count)
        {
            StringBuilder sb = new StringBuilder(count);
            for (int i = 0; i < count; i++)
            {
                sb.Append(number.ToString());
            }
            return sb.ToString();
        }
    }
}
