using API.Model.Entities;

namespace API.Data
{
    public class DbInitializer
    {
        public static void Initialize(ZooContext context)
        {
            if (context.Animals.Any())
            {
                return;
            }

            var animals = new List<Animal>
            {
                new Animal
                {
                    animalID = 1,
                    animalName = "Lion",
                    region = "Africa",
                    description = "The lion is a majestic big cat known for its strength and courage.",
                    birthDate = "January 15, 2018",
                    gender = "Male",
                    healthCheck = true,
                    rarity = "Common"
                },
                new Animal
                {
                    animalID = 2,
                    animalName = "Panda",
                    region = "Asia",
                    description = "The panda is a cute bear-like creature known for its bamboo diet.",
                    birthDate = "March 8, 2016",
                    gender = "Female",
                    healthCheck = true,
                    rarity = "Endangered"
                },
                new Animal
                {
                    animalID = 3,
                    animalName = "Giraffe",
                    region = "Africa",
                    description = "The giraffe is a tall, graceful herbivore with a long neck.",
                    birthDate = "July 20, 2019",
                    gender = "Male",
                    healthCheck = false,
                    rarity = "Common"
                },
                new Animal
                {
                    animalID = 4,
                    animalName = "Koala",
                    region = "Australia",
                    description = "The koala is an adorable marsupial known for its eucalyptus diet.",
                    birthDate = "May 5, 2020",
                    gender = "Female",
                    healthCheck = true,
                    rarity = "Vulnerable"
                },
                new Animal
                {
                    animalID = 5,
                    animalName = "Elephant",
                    region = "Africa",
                    description = "The elephant is the largest land animal known for its tusks and strength.",
                    birthDate = "October 12, 2015",
                    gender = "Male",
                    healthCheck = true,
                    rarity = "Endangered"
                },
                new Animal
                {
                    animalID = 6,
                    animalName = "Tiger",
                    region = "Asia",
                    description = "The tiger is a powerful predator known for its striking orange coat with black stripes.",
                    birthDate = "February 3, 2017",
                    gender = "Female",
                    healthCheck = true,
                    rarity = "Endangered"
                },
                new Animal
                {
                    animalID = 7,
                    animalName = "Dolphin",
                    region = "Ocean",
                    description = "The dolphin is an intelligent marine mammal known for its playful behavior.",
                    birthDate = "April 25, 2020",
                    gender = "Male",
                    healthCheck = true,
                    rarity = "Common"
                },
                new Animal
                {
                    animalID = 8,
                    animalName = "Red Panda",
                    region = "Asia",
                    description = "The red panda is a small, tree-dwelling mammal known for its bushy tail.",
                    birthDate = "December 9, 2019",
                    gender = "Female",
                    healthCheck = true,
                    rarity = "Vulnerable"
                },
                new Animal
                {
                    animalID = 9,
                    animalName = "Zebra",
                    region = "Africa",
                    description = "The zebra is a striped herbivore known for its unique black and white coat.",
                    birthDate = "June 7, 2021",
                    gender = "Male",
                    healthCheck = true,
                    rarity = "Common"
                },
                new Animal
                {
                    animalID = 10,
                    animalName = "Snow Leopard",
                    region = "Asia",
                    description = "The snow leopard is a secretive big cat known for its fur adapted to cold climates.",
                    birthDate = "November 30, 2018",
                    gender = "Female",
                    healthCheck = true,
                    rarity = "Endangered"
                }
            };

            foreach (var animal in animals)
            {
                context.Animals.Add(animal);
            }

            context.SaveChanges();      
        }
    }
}
