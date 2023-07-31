using System;


namespace MySQL
{
    public class Character
    {
        public int Id { get; set; }
        public int PlayerID { get; set; }
        public string CharName { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public int CharLevel { get; set; }
        public int Money { get; set; }
        public float Health { get; set; }
        public float Armor { get; set; }
        public int? House { get; set; }

        public virtual Player Player { get; set; }

        public string ToString()
        {
            return $"Character:\n  Id: {Id}\n  PlayerID: {PlayerID}\n  CharName: {CharName}\n  Age: {Age}\n  " +
                $"Sex: {((Sex == 0) ? "Woman" : "Man")}\n  CharLevel: {CharLevel}\n  Money: {Money}\n  Health: {Health}\n  Armor: {Armor}\n  " +
                $"House: {House}";
        }
    }
}
