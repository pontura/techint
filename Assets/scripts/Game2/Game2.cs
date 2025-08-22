public class Game2 : Gameplay
{
    int id;

    public override void InitGame()
    {
    }    
    void Done()
    {
        GameManager.Instance.NextGame();
    }

}
