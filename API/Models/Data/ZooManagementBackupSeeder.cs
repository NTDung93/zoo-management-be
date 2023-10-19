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
                        EmployeeId = "E001"
                    },
                    new Area
                    {
                        AreaId = "B",
                        AreaName = "Herbivore",
                        EmployeeId = "E003"
                    },
                    new Area
                    {
                        AreaId = "C",
                        AreaName = "Underwater",
                        EmployeeId = "E006"
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
                        Name = "Lion",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "A"
                    },
                    new Cage
                    {
                        CageId = "A0002",
                        Name = "Tiger",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "A"
                    },
                    new Cage
                    {
                        CageId = "B0001",
                        Name = "Giraffe",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "B0002",
                        Name = "Elephant",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "B0003",
                        Name = "Peacook and Flamingo",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "B0004",
                        Name = "Rooster and Parrot",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "B0005",
                        Name = "Zebra",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "B"
                    },
                    new Cage
                    {
                        CageId = "C0001",
                        Name = "Hippo",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "C"
                    },
                    new Cage
                    {
                        CageId = "C0002",
                        Name = "Alligator",
                        MaxCapacity = 10,
                        CurrentCapacity = 0,
                        AreaId = "C"
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
                    new Employee
                    {
                        EmployeeId = "E007",
                        FullName = "John Smith",
                        CitizenId = "1234567890",
                        Email = "john.smith@example.com",
                        Password = "1",
                        PhoneNumber = "0589169697",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E008",
                        FullName = "Jane Doe",
                        CitizenId = "9876543210",
                        Email = "jane.doe@example.com",
                        Password = "1",
                        PhoneNumber = "0986665343",
                        Role = EmployeeConstraints.TRAINER_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E009",
                        FullName = "John Doe",
                        CitizenId = "2502417558",
                        Email = "johndoeno1@gmail.com",
                        Password = "1",
                        PhoneNumber = "0881230814",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
                    },
                    new Employee
                    {
                        EmployeeId = "E010",
                        FullName = "John Doe",
                        CitizenId = "2502417558",
                        Email = "johndoeno1@gmail.com",
                        Password = "1",
                        PhoneNumber = "0327057920",
                        Role = EmployeeConstraints.STAFF_ROLE,
                        EmployeeStatus = EmployeeConstraints.NOT_DELETED
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
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD02",
                        FoodName = "Grass",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD03",
                        FoodName = "Beef",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD04",
                        FoodName = "Chicken",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD05",
                        FoodName = "Sugarcane",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD06",
                        FoodName = "Watermelon",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD07",
                        FoodName = "Squirrel",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD08",
                        FoodName = "FruitBlend",
                        InventoryQuantity = 10
                    },
                    new FoodInventory
                    {
                        FoodId = "FD09",
                        FoodName = "Mixed beans",
                        InventoryQuantity = 10
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
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Elephant",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Peacook",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Lion",
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
                    new AnimalSpecies
                    {
                        SpeciesName = "Flamingo",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Zebra",
                    },
                    new AnimalSpecies
                    {
                        SpeciesName = "Parrot",
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
                        Behavior = "Indochinese Tigers live solitarily and hide in deep forests with hilly terrain, " +
                        "primarily hunt medium-sized and large ungulate species in the wild",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253396/images/thu-an-thit/tiger/g8iszebifjsocj92xae2.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/sj2qglno6netfrt9ki3j.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/mr7xtin4sirnqri0rzqq.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/z4bhexybccpmzmqlvnx8.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_CRITICALLY_ENDANGERED,
                        MaxFeedingQuantity = 10,
                        EmployeeId = "E001",
                        CageId = "A0002",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2021, 10, 20),
                        SpeciesId = 7
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
                        MaxFeedingQuantity = 12,
                        EmployeeId = "E003",
                        CageId = "B0002",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2022, 9, 30),
                        SpeciesId = 2
                    },
                    new Animal
                    {
                        AnimalId = "ANI003",
                        Name = "Asian Elephant",
                        Region = "Indochina",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 15,
                        EmployeeId = "E003",
                        CageId = "B0002",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2022, 8, 30),
                        SpeciesId = 2
                    },
                    new Animal
                    {
                        AnimalId = "ANI004",
                        Name = "Indo Flamingo",
                        Region = "Indo",
                        Gender = AnimalConstraints.FEMALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        MaxFeedingQuantity = 8,
                        EmployeeId = "E008",
                        CageId = "B0003",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2022, 8, 15),
                        SpeciesId = 8
                    },
                    new Animal
                    {
                        AnimalId = "ANI005",
                        Name = "Indo Flamingo",
                        Region = "Indo",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_NORMAL,
                        MaxFeedingQuantity = 12,
                        EmployeeId = "E008",
                        CageId = "B0003",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2021, 7, 12),
                        SpeciesId = 8
                    },
                    new Animal
                    {
                        AnimalId = "ANI006",
                        Name = "Angola Giraffe",
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
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 1
                    },
                    new Animal
                    {
                        AnimalId = "ANI007",
                        Name = "African Zebra",
                        Region = "South African",
                        Gender = AnimalConstraints.MALE,
                        Image = "[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/xd7jzximk4clmoyrzaje.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/w2zfbqlpkxtexs2vhqed.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/zebra/wpkh0hlq40yd0aykuzpl.jpg]",
                        HealthStatus = AnimalConstraints.HEALTH_STATUS_OK,
                        IsDeleted = AnimalConstraints.ANIMAL_NOT_DELETED,
                        Rarity = AnimalConstraints.RARITY_ENDANGERED,
                        MaxFeedingQuantity = 10,
                        EmployeeId = "E006",
                        CageId = "B0005",
                        ImportDate = DateTime.Now,
                        BirthDate = new DateTime(2020, 12, 31),
                        SpeciesId = 9
                    },
                    new Animal
                    {
                        AnimalId = "ANI008",
                        Name = "African Parrot",
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
                        BirthDate = new DateTime(2020, 12, 30),
                        SpeciesId = 1
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
                        CertificateCode = "3FQLO",
                    },
                    new EmployeeCertificate
                    {
                        EmployeeId = "E001",
                        CertificateCode = "CER001",
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
            }

            if (!_dbContext.FeedingMenus.Any())
            {
                var menus = new List<FeedingMenu>()
                {
                    new FeedingMenu
                    {
                        MenuNo = "MNU001",
                        MenuName = "Tiger 1st week",
                        FoodId = "FD04",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU002",
                        MenuName = "Tiger 1st week",
                        FoodId = "FD03",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU003",
                        MenuName = "Tiger 1st week",
                        FoodId = "FD07",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU004",
                        MenuName = "Elephant 1st week",
                        FoodId = "FD05",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU005",
                        MenuName = "Elephant 1st week",
                        FoodId = "FD06",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU006",
                        MenuName = "Flamingo 1st week",
                        FoodId = "FD09",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU007",
                        MenuName = "Giraffe 1st week",
                        FoodId = "FD01",
                    },
                    new FeedingMenu
                    {
                        MenuNo = "MNU008",
                        MenuName = "Giraffe 1st week",
                        FoodId = "FD02",
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
            }
            _dbContext.SaveChanges();
        }
    }
}
