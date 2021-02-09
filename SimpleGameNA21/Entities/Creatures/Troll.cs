namespace SimpleGameNA21
{
    class Troll : Creature
    {
        public Troll(Cell cell, int maxHealth) : base(cell, "T ", maxHealth)
        {
            Damage = 30;
        }
    }
}
