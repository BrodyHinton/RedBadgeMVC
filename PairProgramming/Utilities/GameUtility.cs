   public static class GameUtility
    {
        public static Suspect GetRandomVillain(List<Suspect> suspects)
        {
            Random rnd = new Random();
            Thread.Sleep(500);
            int rndIndex = rnd.Next(0,suspects.Count);
            Suspect personWhoDidIt = suspects[rndIndex];
            return personWhoDidIt;
        }
    }