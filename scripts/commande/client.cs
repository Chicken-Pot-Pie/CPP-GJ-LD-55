public class Client
{
    public Client(Mood mood, int temps_attente_max)
    {
        _mood = mood;
        this._temps_attente_max = temps_attente_max;
    }
    private Mood _mood;
    private int _temps_attente_max;

}