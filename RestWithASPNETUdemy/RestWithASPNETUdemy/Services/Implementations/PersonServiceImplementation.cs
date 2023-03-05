using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations;
public class PersonServiceImplementation : IPersonService
{
    private volatile int count;

    public Person Create(Person person)
    {
        return person;
    }

    public void Delete(long id)
    {

    }

    public IList<Person> FindAll()
    {
        var people = new List<Person>();
        for (int i = 0; i < 8; i++)
        {
            var person = MockPerson(i);
            people.Add(person);
        }
        return people;
    }

    public Person FindByID(long id)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = "Osvaldo",
            LastName = "Ribeiro",
            Address = "São Gonçalo, RJ",
            Gender = "Male"
        };
    }

    public Person Update(Person person)
    {
        return person;
    }

    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = IncrementAndGet(),
            FirstName = $"Person FirstName {i}",
            LastName = $"Person LastName {i}",
            Address = $"Person Address {i}",
            Gender = "Male"
        };
    }

    private long IncrementAndGet()
    {
        return Interlocked.Increment(ref count);
    }
}