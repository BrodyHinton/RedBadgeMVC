public class Suspect
{
    public Suspect()
    {
        
    }

    public Suspect(string name, string description, string height, string weight, bool IsGuilty)
    {
        Name=name;
        Description=description;
        Height=height;
        Weight=weight;
        this.IsGuilty = IsGuilty;
    }

      public Suspect(string name, string description)
    {
        Name=name;
        Description=description;
    }
      public string Name {get; set; }  

      public string Description { get; set;}

      public string Height {get; set;}

      public string Weight { get; set;}

      public bool IsGuilty {get; set;}
}
