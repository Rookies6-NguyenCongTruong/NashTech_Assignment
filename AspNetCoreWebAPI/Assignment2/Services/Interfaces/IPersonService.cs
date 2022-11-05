using Assignment2.Models;

namespace Assignment2.Services;

public interface IPersonService
{
    List<PersonModel> GetAll();
    PersonModel? GetOne(Guid id);
    IEnumerable<PersonModel> GetFilterList(string? name, string? gender, string? birthPlace);
    PersonModel Create(PersonCreateModel createModel);
    PersonModel? Update(Guid id, PersonUpdateModel updateModel);
    bool Delete(Guid id);
    bool Exist(Guid id);
    List<PersonModel> GetPagnition(Pagination pagination);
}