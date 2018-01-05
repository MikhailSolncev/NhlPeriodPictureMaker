namespace SecondPeriodPictureMaker
{
    internal class Team
    {
        private string name;
        public string Name { get => name; set => name = value; }

        override public string ToString() { return name; }
    }
}