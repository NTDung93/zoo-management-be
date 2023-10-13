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
                        AreaName = "Carnivore"
                    },
                    new Area
                    {
                        AreaId = "B",
                        AreaName = "Herbivore"
                    },
                    new Area
                    {
                        AreaId = "C",
                        AreaName = "Bird"
                    },
                    new Area
                    {
                        AreaId = "D",
                        AreaName = "Reptile"
                    },
                };
                _dbContext.Areas.AddRange(areas);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Cages.Any())
            {
                var cages = new List<Cage>()
                {
                    new Cage
                    {
                        CageId = "A0001",
                        Name = "Lion",
                        MaxCapacity = 10,
                        AreaId = "A"
                    },
                    new Cage
                    {
                        CageId = "A0002",
                        Name = "Tiger",
                        MaxCapacity = 10,
                        AreaId = "A"
                    },
                    new Cage
                    {
                        CageId = "B0001",
                        Name = "Girrafe",
                        MaxCapacity = 10,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "B0002",
                        Name = "Elephant",
                        MaxCapacity = 10,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "C0001",
                        Name = "Peacook and Flamingo",
                        MaxCapacity = 10,
                        AreaId = "C"
                    },
                    new Cage
                    {
                        CageId = "C0002",
                        Name = "Rooster and Parrot",
                        MaxCapacity = 10,
                        AreaId = "C"
                    },
                    new Cage
                    {
                        CageId = "D0001",
                        Name = "Crocodile",
                        MaxCapacity = 10,
                        AreaId = "D"
                    },
                };
                _dbContext.Cages.AddRange(cages);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Certificates.Any())
            {
                var certificates = new List<Certificate>()
                {
                    new Certificate
                    {
                        CertificateCode = "3FQLO",
                        CertificateName = "Reptile Specialist",
                        Level = "Expert",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development"
                    },
                    new Certificate
                    {
                        CertificateCode = "CER001",
                        CertificateName = "Animal Care Specialist",
                        Level = "Intermeidate",
                        TrainingInstitution = "Nong Lam University"
                    },
                    new Certificate
                    {
                        CertificateCode = "CER002",
                        CertificateName = "Zoologist Certification",
                        Level = "Beginner",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development"
                    },
                    new Certificate
                    {
                        CertificateCode = "CER2ND49",
                        CertificateName = "Tiger Training Specilization",
                        Level = "Intermediate",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development"
                    },
                    new Certificate
                    {
                        CertificateCode = "CEREZ769",
                        CertificateName = "Elephant Training Certificate",
                        Level = "Expert",
                        TrainingInstitution = "Ho Chi Minh City Department of Agriculture and Rural Development"
                    },
                };
                _dbContext.Certificates.AddRange(certificates);
                _dbContext.SaveChanges();
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
                        Password = "1",
                        PhoneNumber = "0981342455",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E002",
                        FullName = "Tran Minh Nhat",
                        CitizenId = "841135889",
                        Email = "minhnhat2000@gmail.com",
                        Password = "1",
                        PhoneNumber = "0981342455",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E003",
                        FullName = "Nguyen Tien Dung",
                        CitizenId = "590254810",
                        Email = "dungnt93@gmail.com",
                        Password = "1",
                        PhoneNumber = "0897876321",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E004",
                        FullName = "Ta Vu Thanh Van",
                        CitizenId = "6941670627",
                        Email = "thanhvan03@gmail.com",
                        Password = "2",
                        PhoneNumber = "0923463674",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E005",
                        FullName = "David Copperfield",
                        CitizenId = "8481289654",
                        Email = "davidcopperfield@gmail.com",
                        Password = "2",
                        PhoneNumber = "0823458761",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E006",
                        FullName = "John Doe",
                        CitizenId = "2502417558",
                        Email = "johndoeno1@gmail.com",
                        Password = "1",
                        PhoneNumber = "0876312334",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                };
                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.FoodInventories.Any())
            {
                var foods = new List<FoodInventory>()
                {
                    new FoodInventory
                    {
                        FoodId = "FD01",
                        FoodName = "Carrot",
                        InventoryQuantity = 100
                    },
                    new FoodInventory
                    {
                        FoodId = "FD02",
                        FoodName = "Grass",
                        InventoryQuantity = 100
                    },
                    new FoodInventory
                    {
                        FoodId = "FD03",
                        FoodName = "Beef",
                        InventoryQuantity = 100
                    },
                    new FoodInventory
                    {
                        FoodId = "FD04",
                        FoodName = "Chicken",
                        InventoryQuantity = 100
                    },
                    new FoodInventory
                    {
                        FoodId = "FD05",
                        FoodName = "Sugarcane",
                        InventoryQuantity = 100
                    },
                    new FoodInventory
                    {
                        FoodId = "FD06",
                        FoodName = "Watermelon",
                        InventoryQuantity = 100
                    },
                    new FoodInventory
                    {
                        FoodId = "FD07",
                        FoodName = "Squirrel",
                        InventoryQuantity = 100
                    },
                };
                _dbContext.FoodInventories.AddRange(foods);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.AnimalSpecies.Any())
            {
                var species = new List<AnimalSpecies>()
                {
                    new AnimalSpecies
                    {
                        SpeciesName = "Girrafe",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Elephant",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Peafowl",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Rhino",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Hippo",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Alligator",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Tiger",
                    },
                };
                _dbContext.AnimalSpecies.AddRange(species);
                _dbContext.SaveChanges();
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
                        Behavior = "Indochinese Tigers live solitarily and hide in deep forests with hilly terrain, " +
                        "primarily hunt medium-sized and large ungulate species in the wild",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253396/images/thu-an-thit/tiger/g8iszebifjsocj92xae2.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/sj2qglno6netfrt9ki3j.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/mr7xtin4sirnqri0rzqq.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/z4bhexybccpmzmqlvnx8.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_CRITICALLY_ENDANGERED,
                        EmployeeId = "E001",
                        CageId = "A0001",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2021, 10, 20),
                        SpeciesId = 4
                    },
                    new Animal
                    {
                        AnimalId = "ANI002",
                        Name = "Asian Elephant",
                        Region = "Indochina",
                        Gender = AnimalConstraints.FEMALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        EmployeeId = "E003",
                        CageId = "B0002",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2022, 9, 30),
                        SpeciesId = 2
                    },
                    new Animal
                    {
                        AnimalId = "ANI003",
                        Name = "Indo Flamingo",
                        Region = "Indo",
                        Gender = AnimalConstraints.FEMALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        EmployeeId = "E005",
                        CageId = "C0001",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2022, 8, 15),
                        SpeciesId = 3
                    },
                    new Animal
                    {
                        AnimalId = "ANI004",
                        Name = "Angola Girrafe",
                        Region = "South African",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253393/images/thu-an-thuc-vat/giraffe/yoi6zxjqqykoryindntl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/mlibbgxp756qtpcecn4o.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/ln6w1lbpzm973julylx5.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/giraffe/ah7gnlqazxd7jxlpsk57.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        EmployeeId = "E005",
                        CageId = "B0001",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 1
                    },
                };
                _dbContext.Animals.AddRange(animals);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.EmployeeCertificates.Any())
            {
                var empCertificates = new List<EmployeeCertificate>()
                {
                    new EmployeeCertificate
                    {
                        EmployeeId = "E001",
                        CertificateCode = "3FQLO",
                        Description = "7 years working",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E001",
                        CertificateCode = "CER001",
                        Description = "1 year working",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E003",
                        CertificateCode = "CER2ND49",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E003",
                        CertificateCode = "CER002",
                    },
                };
                _dbContext.EmployeeCertificates.AddRange(empCertificates);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Tickets.Any())
            {
                var tickets = new List<Ticket>()
                {
                    new Ticket
                    {
                        TicketId = "AMA_ENTRANCE_01",
                        Type = "Adult",
                        UnitPrice = 100000
                    },
                    new Ticket
                    {
                        TicketId = "AMA_ENTRANCE_02",
                        Type = "Child",
                        UnitPrice = 60000
                    },
                };
                _dbContext.Tickets.AddRange(tickets);
                _dbContext.SaveChanges();
            }
        }
    }
}
