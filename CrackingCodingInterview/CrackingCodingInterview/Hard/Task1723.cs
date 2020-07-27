using System;

namespace CrackingCodingInterview.Hard
{
    public class Task1723
    {
        public Task1723()
        {
            var matrix = new int[,]
            {
                {1, 1, 1, 1, 0},
                {1, 1, 1, 0, 0},
                {1, 1, 0, 0, 0},
                {1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
            };
            
            var square = FindSquare(matrix);

            Console.WriteLine($"{square.Row} {square.Col} {square.SquareSize}");
        }

        private Subsquare FindSquare(int[,] matrix)
        {
            var processed = ProcessSquare(matrix);
            
            for (var i = matrix.GetLength(0); i >= 1; i--)
            {
                var square = FindSquareWithSize(processed, i);
                if (square != null) return square;
            }

            return null;
        }

        private Subsquare FindSquareWithSize(SquareCell[,] processed, int size)
        {
            var count = processed.GetLength(0) - size + 1;

            for (var row = 0; row < count; row++)
            {
                for (var col = 0; col < count; col++)
                {
                    if (IsSquare(processed, row, col, size))
                    {
                        return new Subsquare(row, col, size);
                    }
                }
            }

            return null;
        }

        private bool IsSquare(SquareCell[,] matrix, int row, int col, int sz)
        {
            var topLeft = matrix[row, col];
            var topRight = matrix[row, col + sz - 1];
            var bottomLeft = matrix[row + sz - 1, col];

            return topLeft.ZerosRight >= sz && 
                   topLeft.ZerosBelow >= sz && 
                   topRight.ZerosBelow >= sz && 
                   bottomLeft.ZerosRight >= sz;
        }

        private SquareCell[,] ProcessSquare(int[,] matrix)
        {
            var processed = new SquareCell[matrix.GetLength(0), matrix.GetLength(0)];
            
            for (var r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                for (var c = matrix.GetLength(0) - 1; c >= 0; c--)
                {
                    var rightZeros = 0;
                    var belowZeros = 0;

                    if (matrix[r, c] == 0)
                    {
                        rightZeros++;
                        belowZeros++;

                        if (c + 1 < matrix.GetLength(0))
                        {
                            var previous = processed[r, c + 1];
                            rightZeros += previous.ZerosRight;
                        }

                        if (r + 1 < matrix.GetLength(0))
                        {
                            var previous = processed[r + 1, c];
                            belowZeros += previous.ZerosBelow;
                        }
                    }
                    
                    processed[r, c] = new SquareCell(rightZeros, belowZeros);
                }
            }
            
            return processed;
        }

        private class SquareCell
        {
            public int ZerosRight = 0;
            public int ZerosBelow = 0;

            public SquareCell(int zerosRight, int zerosBelow)
            {
                ZerosRight = zerosRight;
                ZerosBelow = zerosBelow;
            }
        }

        private class Subsquare
        {
            public int Row;
            public int Col;
            public int SquareSize;

            public Subsquare(int row, int col, int squareSize)
            {
                Row = row;
                Col = col;
                SquareSize = squareSize;
            }
        }
    }
}