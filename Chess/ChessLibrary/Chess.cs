﻿using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    public class Chess
    {
        public string fen { get; private set; }
        Board board;
        Moves moves;
        List<FigureMoving> allMoves;

        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
            this.board = new Board(fen);
            moves = new Moves(board);
        }

        Chess(Board board)
        {
            this.board = board;
            this.fen = board.fen;
            moves = new Moves(board);
        }

        public Chess Move(string move)
        {
            FigureMoving fm = new FigureMoving(move);

            if (!moves.CanMove(fm))
				return this;
			if (board.IsCheckAfterMove(fm))
				return this;


			Board nextBoard = board.Move(fm);
            Chess nextChess = new Chess(nextBoard);

            return nextChess;
        }

        public char GetFigureAt(int x, int y)
        {
            Square square = new Square(x, y);
            Figure f = board.GetFigureAt(square);

            return f == Figure.none ? '.' : (char)f;
        }

		//my
		public char GetFigureAt(string s)
		{
			Square square = new Square(s);
			Figure f = board.GetFigureAt(square);

			return f == Figure.none ? '.' : (char)f;
		}
        //

		private void FindAllMoves()
        {
            allMoves = new List<FigureMoving>();
            foreach (FigureOnSquare fs in board.YieldFigures())
            {
                foreach (Square to in Square.YieldSquares())
                {
                    FigureMoving fm = new FigureMoving(fs, to);
                    if (moves.CanMove(fm))
                        if (!board.IsCheckAfterMove(fm))
                            allMoves.Add(fm);
                }
            }
        }

        public bool IsCheck()
        {
            return board.IsCheck();
        }

        public List<string> GetAllMoves()
        {
            FindAllMoves();
            List<string> list = new List<string>();
            foreach (FigureMoving fm in allMoves)
            {
                list.Add(fm.ToString());
            }
            return list;
        }
    }

}
