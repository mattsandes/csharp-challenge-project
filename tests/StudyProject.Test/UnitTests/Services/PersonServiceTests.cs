using Moq;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;
using StudyProject.Services;

public class PersonServiceTests
{
    private Person person;
    private Device device;
    private User user;

    private Mock<IPersonRepository> personRepository;
    private PersonServices services;

    [SetUp]
    public void SetUp()
    {
        personRepository = new Mock<IPersonRepository>();

        services = new PersonServices(personRepository.Object);

        person = new Person
        {
            Id = 1,
            Name = "Test Person",
            Users = new List<User>()
        };

        user = new User
        {
            Id = 1,
            Accesses = 4,
            Date = new DateTime(),
            Device = device,
            Login = "Test User",
            Password = "Teste@123",
            Person = person,
            PersonId = 1
        };

        device = new Device
        {
            Id = 1,
            DeviceName = "Test Device",
            User = user,
            UserId = 1
        };

        user.Device = device;
        person.Users.Add(user);
    }

    [Test]
    public async Task GetAllPeople_Should_ListTheCreatePeople()
    {
        personRepository.Setup(r => r.GetAllPersons()).ReturnsAsync(new List<Person> { person });

        var peopleList = await services.GetAllPeople();

        Assert.NotNull(peopleList);
        Assert.That(peopleList.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Create_Should_CreateANewPerson()
    {
        personRepository.Setup(r => r.CreatePerson(It.IsAny<Person>())).ReturnsAsync(new Person());

        var newPerson = new CreatePersonUserDTO
        {
            Name = "Test User",
            CreateUserDTOs = new List<CreateUserDTOs>
            {
                new CreateUserDTOs
                {
                    Login = "test.user",
                    Accesses = 3,
                    Password = "Teste@123"
                }
            }
        };

        var createdPerson = await services.CreatePerson(newPerson);

        Assert.IsNotNull(newPerson);
        Assert.That(newPerson.Name, Is.EqualTo("Test User"));
        Assert.IsNotNull(newPerson.CreateUserDTOs);
    }
}