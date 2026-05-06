namespace AlgoMonster.LLD.PvZ
{
    public class User
    {
        public int UserId { get; set; }
        public CharacterType Character { get; set; }
        public int DifficultyLevel { get; set; }

        public void SetCharacter(CharacterType characterType) { }

        public void SetDifficultyLevel(int  difficultyLevel) { }

     }
}
