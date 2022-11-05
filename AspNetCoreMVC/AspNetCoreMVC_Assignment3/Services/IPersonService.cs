using AspNetCoreMVC_Assignment3.Models;

namespace AspNetCoreMVC_Assignment3.Services;

public interface IPersonService
{
    public List<PersonModel> GetAll();

    public PersonModel? GetOne(int index);

    public PersonModel Create(PersonModel model);

    public PersonModel? Update(int index, PersonModel model);

    public PersonModel? Delete(int index);
}