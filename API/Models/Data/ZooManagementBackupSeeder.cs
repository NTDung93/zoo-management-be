using API.Helpers;
using API.Models.Entities;

namespace API.Models.Data
{
    public class ZooManagementBackupSeeder
    {
        private readonly ZooManagementBackupContext _dbContext;

        public ZooManagementBackupSeeder(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Areas.Any())
            {
                var areas = new List<Area>()
                {
                    new Area
                    {
                        AreaId = "A",
                        AreaName = "Carnivore",
                        EmployeeId = "E001",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Area
                    {
                        AreaId = "B",
                        AreaName = "Herbivore",
                        EmployeeId = "E003",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Area
                    {
                        AreaId = "C",
                        AreaName = "Underwater",
                        EmployeeId = "E006",
                        CreatedDate = DateTimeOffset.Now
                    }
                };
                _dbContext.Areas.AddRange(areas);
            }

            if (!_dbContext.Cages.Any())
            {
                var cages = new List<Cage>()
                {
                    new Cage
                    {
                        CageId = "A0001",
                        Name = "Lion Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "A",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "A0002",
                        Name = "Tiger Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "A",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "B0001",
                        Name = "Giraffe Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "B0002",
                        Name = "Elephant Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "B0003",
                        Name = "Peacook and Flamingo Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "B0004",
                        Name = "Rooster and Parrot Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "B0005",
                        Name = "Zebra Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "C0001",
                        Name = "Hippo Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "C",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Cage
                    {
                        CageId = "C0002",
                        Name = "Alligator Enclosure",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "C",
                        CreatedDate = DateTimeOffset.Now
                    },

                };
                _dbContext.Cages.AddRange(cages);
            }

            if (!_dbContext.Certificates.Any())
            {
                var certificates = new List<Certificate>()
                {
                    new Certificate
                    {
                        CertificateCode = "UDYO5UYK",
                        CertificateName = "Reptile Specilization",
                        Level = "Expert",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Certificate
                    {
                        CertificateCode = "Z1XM30E1",
                        CertificateName = "Animal Care Specialist",
                        Level = "Intermeidate",
                        TrainingInstitution = "Nong Lam University",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Certificate
                    {
                        CertificateCode = "4WT7BN49",
                        CertificateName = "Zoologist Certification",
                        Level = "Beginner",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Certificate
                    {
                        CertificateCode = "OESN5O1H",
                        CertificateName = "Tiger Training Specilization",
                        Level = "Intermediate",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Certificate
                    {
                        CertificateCode = "INZ08ISN",
                        CertificateName = "Elephant Training Certificate",
                        Level = "Expert",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Certificate
                    {
                        CertificateCode = "NIOV30OMXB",
                        CertificateName = "Zebra Training Qualification",
                        Level = "Intermediate",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Certificate
                    {
                        CertificateCode = "NG8LXLFCX2",
                        CertificateName = "Herbivore Specilization",
                        Level = "Expert",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development",
                        CreatedDate = DateTimeOffset.Now
                    },
                };
                _dbContext.Certificates.AddRange(certificates);
            }

            if (!_dbContext.Employees.Any())
            {
                var employees = new List<Employee>()
                {
                    new Employee
                    {
                        EmployeeId = "E001",
                        FullName = "Nguyen Duc Son",
                        CitizenId = "943370230",
                        Email = "nguyenducson2003@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0981342455",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E002",
                        FullName = "Tran Minh Nhat",
                        CitizenId = "841135889",
                        Email = "minhnhat2000@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0981342455",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E003",
                        FullName = "Nguyen Tien Dung",
                        CitizenId = "590254810",
                        Email = "dungnt93@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0897876321",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E004",
                        FullName = "Ta Vu Thanh Van",
                        CitizenId = "6941670627",
                        Email = "thanhvan03@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "2",
                        PhoneNumber = "0923463674",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E005",
                        FullName = "David Copperfield",
                        CitizenId = "8481289654",
                        Email = "davidcopperfield@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "2",
                        PhoneNumber = "0823458761",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E006",
                        FullName = "John Doe",
                        CitizenId = "2502417558",
                        Email = "johndoeno1@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0876312334",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E007",
                        FullName = "John Smith",
                        CitizenId = "1234567890",
                        Email = "john.smith@example.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0589169697",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E008",
                        FullName = "Jane Doe",
                        CitizenId = "9876543210",
                        Email = "jane.doe@example.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0986665343",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED, 
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E009",
                        FullName = "John Doe",
                        CitizenId = "2502417558",
                        Email = "johndoeno1@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0881230814",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E010",
                        FullName = "Abigail Scott",
                        CitizenId = "2402223095",
                        Email = "parents@verizon.net",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "1",
                        PhoneNumber = "0954715955",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E011",
                        FullName = "Daniel Harris",
                        CitizenId = "7383372105",
                        Email = "sjava@icloud.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "3",
                        PhoneNumber = "0831713773",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E012",
                        FullName = "Christopher Wilson",
                        CitizenId = "4975833434",
                        Email = "carmena@mac.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "3",
                        PhoneNumber = "0304835408",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E013",
                        FullName = "Isabella Hernandez",
                        CitizenId = "8956520907",
                        Email = "studyabr@gmail.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "4",
                        PhoneNumber = "0978803964",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new Employee
                    {
                        EmployeeId = "E014",
                        FullName = "Sophia Martinez",
                        CitizenId = "6721102359",
                        Email = "gslondon@live.com",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg",
                        Password = "4",
                        PhoneNumber = "0786008864",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED,
                        CreatedDate = DateTimeOffset.Now
                    },
                };
                _dbContext.Employees.AddRange(employees);
            }

            if (!_dbContext.FoodInventories.Any())
            {
                var foods = new List<FoodInventory>()
                {
                    new FoodInventory
                    {
                        FoodId = "FD01",
                        FoodName = "Carrot",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD02",
                        FoodName = "Grass",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD03",
                        FoodName = "Beef",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD04",
                        FoodName = "Chicken",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD05",
                        FoodName = "Sugarcane",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD06",
                        FoodName = "Watermelon",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD07",
                        FoodName = "Squirrel",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD08",
                        FoodName = "FruitBlend",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD09",
                        FoodName = "Mixed beans",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FoodInventory
                    {
                        FoodId = "FD11",
                        FoodName = "Corn",
                        InventoryQuantity = 10,
                        CreatedDate = DateTimeOffset.Now
                    },
                };
                _dbContext.FoodInventories.AddRange(foods);
            }

            if (!_dbContext.AnimalSpecies.Any())
            {
                var species = new List<AnimalSpecies>()
                {
                    new AnimalSpecies
                    {
                        SpeciesName = "Giraffe",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Elephant",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Peacook",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Lion",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Hippo",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Alligator",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Tiger",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Flamingo",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Zebra",
                        CreatedDate = DateTimeOffset.Now
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Parrot",
                        CreatedDate = DateTimeOffset.Now
                    }
                };
                _dbContext.AnimalSpecies.AddRange(species);
            }

            if (!_dbContext.Animals.Any())
            {
                var animals = new List<Animal>()
                {
                    new Animal
                    {
                        AnimalId = "ANI001",
                        Name = "Corbett Tiger",
                        Region = "Indochina",
                        Behavior = "The Corbett Tiger, a subspecies of the Bengal tiger, is native to India's Corbett National Park. These solitary nocturnal predators are territorial and fiercely protect their domains. They are excellent swimmers, often crossing rivers in search of prey. Their diet consists mainly of deer and wild boar, hunted stealthily from within tall grass.",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253396/images/thu-an-thit/tiger/g8iszebifjsocj92xae2.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/sj2qglno6netfrt9ki3j.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/mr7xtin4sirnqri0rzqq.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/z4bhexybccpmzmqlvnx8.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_CRITICALLY_ENDANGERED,
                        MaxFeedingQuantity = 10,
                        EmployeeId = "E001",
                        CageId = "A0002",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2021, 10, 20),
                        SpeciesId = 7
                    },
                    new Animal
                    {
                        AnimalId = "ANI002",
                        Name = "Asian Elephant (Luna)",
                        Region = "Indochina",
                        Gender = AnimalConstraints.FEMALE,
                        Behavior = "Asian elephants are known for their strong sense of community and social bonds. They often travel in close-knit family groups, led by the oldest female, and communicate through vocalizations, body language, and tactile interactions. Their intelligence is remarkable, allowing them to problem-solve, learn from experience, and even display self-awareness.",
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 12,
                        EmployeeId = "E003",
                        CageId = "B0002",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2022, 9, 30),
                        SpeciesId = 2
                    },
                    new Animal
                    {
                        AnimalId = "ANI003",
                        Name = "Asian Elephant (Leo)",
                        Region = "Indochina",
                        Behavior = "Asian elephants are known for their strong sense of community and social bonds. They often travel in close-knit family groups, led by the oldest female, and communicate through vocalizations, body language, and tactile interactions. Their intelligence is remarkable, allowing them to problem-solve, learn from experience, and even display self-awareness.",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 15,
                        EmployeeId = "E003",
                        CageId = "B0002",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2022, 8, 30),
                        SpeciesId = 2
                    },
                    new Animal
                    {
                        AnimalId = "ANI004",
                        Name = "Indo Flamingo (Daisy)",
                        Region = "Indo",
                        Behavior = "The Indo Flamingo, or the Greater Flamingo (Phoenicopterus roseus), is a striking and elegant wading bird known for its vivid pink plumage and distinct long, slender legs. These birds are primarily found in the Indian subcontinent and some parts of Africa and Europe. Indo Flamingos are characterized by their graceful behavior and their affinity for shallow, saline wetlands.",
                        Gender = AnimalConstraints.FEMALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        MaxFeedingQuantity = 8,
                        EmployeeId = "E008",
                        CageId = "B0003",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2022, 8, 15),
                        SpeciesId = 8
                    },
                    new Animal
                    {
                        AnimalId = "ANI005",
                        Name = "Indo Flamingo (Buddy)",
                        Region = "Indo",
                        Behavior = "The Indo Flamingo, or the Greater Flamingo (Phoenicopterus roseus), is a striking and elegant wading bird known for its vivid pink plumage and distinct long, slender legs. These birds are primarily found in the Indian subcontinent and some parts of Africa and Europe. Indo Flamingos are characterized by their graceful behavior and their affinity for shallow, saline wetlands.",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        MaxFeedingQuantity = 12,
                        EmployeeId = "E008",
                        CageId = "B0003",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2021, 7, 12),
                        SpeciesId = 8
                    },
                    new Animal
                    {
                        AnimalId = "ANI006",
                        Name = "Angola Giraffe",
                        Behavior = "The Angola Giraffe, scientifically known as Giraffa camelopardalis angolensis, is a captivating subspecies of giraffe primarily found in southwestern Africa, particularly in Angola and parts of Namibia. These gentle giants are known for their unique and intricate spotted coat, characterized by irregular and jagged patterns.",
                        Region = "South African",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253393/images/thu-an-thuc-vat/giraffe/yoi6zxjqqykoryindntl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/mlibbgxp756qtpcecn4o.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/ln6w1lbpzm973julylx5.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/giraffe/ah7gnlqazxd7jxlpsk57.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        MaxFeedingQuantity = 10,
                        EmployeeId = "E006",
                        CageId = "B0001",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 1
                    },
                    new Animal
                    {
                        AnimalId = "ANI007",
                        Name = "African Zebra",
                        Region = "South African",
                        Behavior = "The African Zebra, part of the Equus zebra species, is an iconic and unmistakable creature native to the grasslands and savannahs of Africa. Renowned for their striking black and white striped coats, these herbivorous animals are characterized by their social and spirited behavior.",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/xd7jzximk4clmoyrzaje.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/w2zfbqlpkxtexs2vhqed.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/zebra/wpkh0hlq40yd0aykuzpl.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 10,
                        EmployeeId = "E006",
                        CageId = "B0005",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2020, 12, 31),
                        SpeciesId = 9
                    },
                    new Animal
                    {
                        AnimalId = "ANI008",
                        Name = "African Parrot",
                        Behavior = "The African Parrot, a diverse group of colorful and intelligent parrot species, graces the forests and savannahs of Africa with its vibrant plumage and lively behavior. These avian wonders are celebrated for their charming personalities and impressive vocal abilities.",
                        Region = "Africa",
                        Gender = AnimalConstraints.FEMALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253387/images/thu-an-thuc-vat/parrot/myeyqf3wvj2ojyfgvmkl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253386/images/thu-an-thuc-vat/parrot/lp7fwviqprlpbum0r8pm.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253386/images/thu-an-thuc-vat/parrot/jo1pwznbgslpfsujguqm.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        MaxFeedingQuantity = 2,
                        EmployeeId = "E007",
                        CageId = "B0004",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 10
                    },
                    new Animal
                    {
                        AnimalId = "ANI009",
                        Name = "Thailand Crocodile (Charlie)",
                        Region = "Southeast Asia",
                        Behavior = "The Thailand Crocodile, scientifically known as Crocodylus siamensis, is a critically endangered reptile native to Southeast Asia, including Thailand. These crocodiles are semi-aquatic, spending much of their time in and around freshwater habitats. They exhibit a solitary nature, with adult individuals leading independent lives, and they can be territorial during the breeding season.",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/aptsdg9ozv3q86ebjrhs.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/pqoetvgxhfjccftwkzzj.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253373/images/thu-duoi-nuoc/alligator/rrcuxxtbrtf6hpudl7g6.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 6,
                        EmployeeId = "E010",
                        CageId = "C0002",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 6
                    },
                    new Animal
                    {
                        AnimalId = "ANI010",
                        Name = "Thailand Crocodile (Sophie)",
                        Region = "Southeast Asia",
                        Gender = AnimalConstraints.FEMALE,
                        Behavior = "The Thailand Crocodile, scientifically known as Crocodylus siamensis, is a critically endangered reptile native to Southeast Asia, including Thailand. These crocodiles are semi-aquatic, spending much of their time in and around freshwater habitats. They exhibit a solitary nature, with adult individuals leading independent lives, and they can be territorial during the breeding season.",
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/aptsdg9ozv3q86ebjrhs.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/pqoetvgxhfjccftwkzzj.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253373/images/thu-duoi-nuoc/alligator/rrcuxxtbrtf6hpudl7g6.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 4,
                        EmployeeId = "E010",
                        CageId = "C0002",
                        ImportDate = DateTime.Now,
                        CreatedDate = DateTimeOffset.Now,
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 6
                    },
                };
                _dbContext.Animals.AddRange(animals);
            }

            if (!_dbContext.EmployeeCertificates.Any())
            {
                var empCertificates = new List<EmployeeCertificate>()
                {
                    new EmployeeCertificate
                    {
                        EmployeeId = "E001",
                        CertificateCode = "OESN5O1H",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E001",
                        CertificateCode = "4WT7BN49",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E003",
                        CertificateCode = "INZ08ISN",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E003",
                        CertificateCode = "NG8LXLFCX2",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E006",
                        CertificateCode = "UDYO5UYK",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E006",
                        CertificateCode = "NIOV30OMXB",
                    },
                };
                _dbContext.EmployeeCertificates.AddRange(empCertificates);
            }

            if (!_dbContext.FeedingMenus.Any())
            {
                var menus = new List<FeedingMenu>()
                {
                    new FeedingMenu
                    {
                        MenuNo = "MNU001",
                        MenuName = "Breakfast for Tiger in 1st week of November",
                        FoodId = "FD04",
                        SpeciesId = 7,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU002",
                        MenuName = "Afternoon for Tiger 1st week of November",
                        FoodId = "FD03",
                        SpeciesId = 7,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU003",
                        MenuName = "Breakfast for Elephant in 1st week of November",
                        FoodId = "FD05",
                        SpeciesId = 2,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU004",
                        MenuName = "Lunch for Elephant in 1st week of November",
                        FoodId = "FD06",
                        SpeciesId = 2,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU005",
                        MenuName = "Flamingo 1st week",
                        FoodId = "FD09",
                        SpeciesId = 8,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU006",
                        MenuName = "Breakfast for Giraffe 1st week of November",
                        FoodId = "FD01",
                        SpeciesId = 1,
                        CreatedDate = DateTimeOffset.Now
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU007",
                        MenuName = "Lunch for Giraffe in 1st week of November",
                        FoodId = "FD02",
                        SpeciesId = 1,
                        CreatedDate = DateTimeOffset.Now
                    },
                };
                _dbContext.FeedingMenus.AddRange(menus);
            }

            if (!_dbContext.Tickets.Any())
            {
                var tickets = new List<Ticket>()
                {
                    new Ticket
                    {
                        TicketId = "AMA_ENTRANCE_01",
                        Type = "Adult",
                        Description = "Entrance ticket for adult",
                        UnitPrice = 100000
                    },
                    new Ticket
                    {
                        TicketId = "AMA_ENTRANCE_02",
                        Type = "Child",
                        Description = "Entrance ticket for child",
                        UnitPrice = 60000
                    },
                };
                _dbContext.Tickets.AddRange(tickets);
            }

            if (!_dbContext.News.Any())
            {
                var news = new List<News>()
                {
                    new News
                    {
                        Title = "Giraffle is coming guys",
                        Content = "<div>The giraffe, scientifically known as Giraffa camelopardalis, is one of the most iconic and distinctively tall mammals on Earth. Native to the African continent, giraffes are renowned for their long necks, which can reach up to 18 feet in length, allowing them to graze on treetop foliage that is out of reach for most other herbivores. These gentle giants have a unique spotted coat, with irregularly shaped patches that vary in color, acting as a form of camouflage in their natural habitat.</div><div><br></div><div><img src=\"http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698766472/vdkxczjngpimymdt6lpn.jpg\"></div><div><br></div><div>Giraffes are social animals, often found in groups known as towers. They have a calm and peaceful demeanor, relying on their remarkable vision and acute hearing for communication and protection. Their diet primarily consists of leaves, buds, and flowers from acacia and other trees. Despite their towering stature, giraffes are vulnerable to predation, particularly from lions.</div><div>Conservation efforts are crucial to ensure the survival of these majestic creatures, as their populations have declined due to habitat loss and poaching. Giraffes continue to be a symbol of Africa's diverse wildlife and the importance of preserving the natural world.</div><div><br></div><div><img src=\"http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698766524/tg7ydupy5vrspyavrqza.jpg\"></div><div><br></div>",
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698766561/otzqufrhcunztrfvfg1x.jpg",
                        WritingDate = DateTime.Now,
                        AnimalId = "ANI006",
                        SpeciesId = 1,
                        EmployeeId = "E004"
                    },
                    new News
                    {
                        Title = "The Majestic Peacock's Vibrant Beauty",
                        Content = "<div>The peacock, scientifically known as Pavo cristatus, is a magnificent and iconic bird renowned for its striking beauty and vibrant plumage. Native to the Indian subcontinent, this avian species is famous for its resplendent tail feathers, which are adorned with iridescent hues of blue, green, and gold. These stunning feathers are fanned out in an elaborate display during courtship rituals, making the peacock a symbol of grace and elegance. While the male, known as a peacock, boasts these eye-catching plumage, the female, called a peahen, exhibits a more subdued appearance.</div><div><br></div><div><img src=\"http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698844334/s9vvaghqn4vxrsexylks.jpg\"></div><div><br></div><div>Beyond their captivating appearance, peacocks are also known for their distinctive, haunting calls that echo through their natural habitats, creating a harmonious soundscape. These birds have a significant cultural and symbolic presence in many societies, often representing themes of beauty, pride, and renewal. The peacock's striking appearance and symbolic significance continue to captivate and inspire people worldwide, making it one of the most recognized and cherished birds in the avian kingdom.</div><div><br></div><div><img src=\"http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698844374/vgpcef5bnseobn2edwzr.jpg\"></div>",
                        WritingDate = DateTime.Now,
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698844280/jojqhcbjbkw283nyp0q0.jpg",
                        EmployeeId = "E004",
                        SpeciesId = 3
                    },
                    new News
                    {
                        Title = "The Graceful Elegance of Red Flamingos",
                        Content = "<div>The red flamingo, scientifically known as Phoenicopterus ruber, is a remarkable and iconic bird celebrated for its vibrant and striking appearance. Native to the Caribbean, coastal areas of northern South America, and some parts of West Africa, this avian species stands out with its distinctive pinkish-red plumage, long legs, and gracefully curved neck. These flamingos are known for their striking appearance and their unique feeding behavior, often seen standing on one leg in shallow waters. While the flamingos' pink coloration is captivating, the pigments in their diet, including carotenoids, contribute to their vibrant hue.</div><div><br></div><div><img src=\"http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698846056/nrutwjcrdjakwugcjbml.jpg\"></div><div><br></div><div>Beyond their enchanting coloration, red flamingos are a symbol of elegance and grace in the avian world. Their striking appearance and characteristic group formations create a mesmerizing spectacle in their natural habitats. Red flamingos have a significant presence in various cultures and are often associated with themes of beauty, vitality, and unity. Their vivid plumage and graceful demeanor continue to captivate people around the world, making them one of the most recognized and cherished birds in the bird kingdom.</div><div><br></div><div><img src=\"http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698846078/y56i8a8twcop56cututf.webp\"></div>",
                        WritingDate = DateTime.Now,
                        Image = "https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698846085/uonis6swfpoajbhds0jb.jpg",
                        EmployeeId = "E002",
                        SpeciesId = 8,
                        AnimalId = "ANI005"
                    }
                };
                _dbContext.News.AddRange(news);
            }
            _dbContext.SaveChanges();
        }
    }
}
