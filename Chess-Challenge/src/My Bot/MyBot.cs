using System.Collections.Generic;
using System.Linq;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    private Dictionary<PieceType, int> pieceRatings = new Dictionary<PieceType, int>()
    {
        { PieceType.Pawn, 1 },
        { PieceType.Knight, 3 },
        { PieceType.Bishop, 3 },
        { PieceType.Rook, 5 },
        { PieceType.Queen, 9 },
        { PieceType.King, int.MaxValue }
    };
    public Move Think(Board board, Timer timer)
    {
        Move[] firstMoves = board.GetLegalMoves()
                                    .Where(move => move.MovePieceType == PieceType.Pawn).Take(4).ToArray();
        Move[] movesThatCapture = board.GetLegalMoves().Where(move => move.IsCapture).ToArray();

        return movesThatCapture.Length > 0 ? movesThatCapture[0] : firstMoves[0];
    }
}