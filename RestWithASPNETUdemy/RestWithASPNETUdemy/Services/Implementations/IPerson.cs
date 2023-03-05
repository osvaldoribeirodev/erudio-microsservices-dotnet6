using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations;
public interface IPersonService
{
    Person Create(Person person);
    Person FindByID(long id);
    IList<Person> FindAll();
    Person Update(Person person);
    void Delete(long id);
}