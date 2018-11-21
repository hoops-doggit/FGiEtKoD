
public class HighScore {

    public string name00;
    public int score00;
    public string name01;
    public int score01;
    public string name02;
    public int score02;
    public string name03;
    public int score03;
    public string name04;
    public int score04;

    public int Rank { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }


    public HighScore (int rank, string name, int score){
        this.Rank = rank;
        this.Name = name;
        this.Score = score;
    }

}
