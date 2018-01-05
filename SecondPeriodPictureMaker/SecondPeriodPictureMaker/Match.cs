namespace SecondPeriodPictureMaker
{
    public class Game
    {
        private Team teamHost;
        private Team teamGuest;

        internal Team TeamHost { get => teamHost; set => teamHost = value; }
        internal Team TeamGuest { get => teamGuest; set => teamGuest = value; }
    }
}