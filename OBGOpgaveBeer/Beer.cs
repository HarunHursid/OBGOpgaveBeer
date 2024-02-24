namespace OBGOpgaveBeer
{
    public class Beer
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int abv { get; set; }


        public override string ToString()
        {
            return $"{Id} {Name} {abv}";
        }


        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("name is empty");
            }
            if (Name.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("Name must be at least 3 characters long");
            }
        }   

        public void ValidateAbv()
        {
            if (abv <= 0)
            {
                throw new ArgumentOutOfRangeException("abv must be a positive number");
            }
            if (abv >= 67)
            {
                throw new ArgumentOutOfRangeException("abv must be less than 67");
            }
        }


        
    }
}
