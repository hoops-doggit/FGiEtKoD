using System;
using System.Collections;

public class HighScore : IComparable<HighScore>
{

    public int Rank { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }

    public HighScore (int rank, string name, int score)
    {
        this.Rank = rank;
        this.Name = name;
        this.Score = score;
    }

    public int CompareTo(HighScore other)
    {
        //first > second return -1
        //first < second return 1
        //first == second return 0

        if (other.Score < this.Score){
            return -1;
        }
        else if (other.Score > this.Score){
            return 1;
        }
        return 0;
    }
}
