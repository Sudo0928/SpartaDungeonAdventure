using GenshinImpactMovementSystem;

public class CharacterManager : Singleton<CharacterManager>
{
    protected override void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        base.Awake();
    }

    private Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
}
