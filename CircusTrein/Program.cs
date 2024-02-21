// See https://aka.ms/new-console-template for more information

// Define constants

using CircusTrein;

int pointsPerWagon = 10;

// Create a fake list of animals
List<Animal> animals = new List<Animal>();

void AddAnimal(Animal.Size size, Animal.Diet diet)
{
    animals.Add(new Animal
    {
        AnimalSize = size,
        AnimalDiet = diet
    });
}

AddAnimal(Animal.Size.Small, Animal.Diet.Herbivore); // Chicken
AddAnimal(Animal.Size.Large, Animal.Diet.Carnivore); // Lion
AddAnimal(Animal.Size.Large, Animal.Diet.Herbivore); // Elephant
AddAnimal(Animal.Size.Large, Animal.Diet.Herbivore); // Giraffe
AddAnimal(Animal.Size.Small, Animal.Diet.Herbivore); // Mouse
AddAnimal(Animal.Size.Medium, Animal.Diet.Carnivore); // Wolf
AddAnimal(Animal.Size.Large, Animal.Diet.Herbivore); // Cow
AddAnimal(Animal.Size.Large, Animal.Diet.Carnivore); // Bear
AddAnimal(Animal.Size.Small, Animal.Diet.Carnivore); // Cat
AddAnimal(Animal.Size.Medium, Animal.Diet.Carnivore); // Dog
AddAnimal(Animal.Size.Medium, Animal.Diet.Herbivore); // Horse
AddAnimal(Animal.Size.Small, Animal.Diet.Herbivore); // Rabbit
AddAnimal(Animal.Size.Small, Animal.Diet.Carnivore); // Rat
AddAnimal(Animal.Size.Small, Animal.Diet.Carnivore); // Snake
AddAnimal(Animal.Size.Small, Animal.Diet.Herbivore); // Hamster
AddAnimal(Animal.Size.Small, Animal.Diet.Carnivore); // Parrot
AddAnimal(Animal.Size.Small, Animal.Diet.Herbivore); // Guinea pig

// Calculate the number of wagons needed
int points = animals.Sum(a => (int) a.AnimalSize);
Console.WriteLine("points: " + points);

animals.Sort((a,b) => -1 * a.AnimalSize.CompareTo(b.AnimalSize));

List<List<Animal>> wagons = new List<List<Animal>>();
wagons.Add(new List<Animal>());

foreach (Animal animal in animals)
{
    bool placed = false;

    foreach (List<Animal> wagon in wagons.OrderByDescending(w => w.Sum(a => (int)a.AnimalSize)))
    {
        // Check if there's a carnivore in the wagon that's equal to or larger than the current animal
        if (wagon.Any(a => a.AnimalDiet == Animal.Diet.Carnivore && a.AnimalSize >= animal.AnimalSize))
        {
            continue; // Skip this wagon
        }
        // check if the animal is a carnivore and there is an animal in the wagon that's the same size or smaller
        if (animal.AnimalDiet == Animal.Diet.Carnivore && wagon.Any(a => a.AnimalSize <= animal.AnimalSize))
        {
            continue; // Skip this wagon
        }

        if (wagon.Sum(a => (int)a.AnimalSize) + (int)animal.AnimalSize <= pointsPerWagon)
        {
            wagon.Add(animal);
            placed = true;
            break;
        }
    }

    // If the animal doesn't fit in any wagon, add a new wagon
    if (!placed)
    {
        List<Animal> newWagon = new List<Animal> { animal };
        wagons.Add(newWagon);
    }
}

Console.WriteLine("Number of wagons needed: " + wagons.Count);

// print the wagons
for (int i = 0; i < wagons.Count; i++)
{
    Console.WriteLine("Wagon " + (i + 1) + ": " + string.Join(", ", wagons[i].Select(a => a.AnimalSize + " " + a.AnimalDiet)));
}