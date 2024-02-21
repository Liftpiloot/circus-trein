namespace CircusTrein;

public class Animal
{
    
    public Size AnimalSize { get; set; }
    public Diet AnimalDiet { get; set; }
    
    public enum Size
    {
        Small = 1,
        Medium = 3,
        Large = 5
    }
    
    public enum Diet
    {
        Carnivore,
        Herbivore
    }
}