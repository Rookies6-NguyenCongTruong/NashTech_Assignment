using AspNetCoreAPi.Models;

namespace AspNetCoreAPi.Services;

public class PersonService : IPersonService
{
    private static readonly List<PersonModel> _peopleList = new()
    {
        new PersonModel("Truong", "Nguyen Cong", new DateTime(2002, 07, 22), "Male", "Ha Noi"),
        new PersonModel("Truong", "Nguyen", new DateTime(2002, 07, 22), "Male", "Ha Tay"),
        new PersonModel("Trinh", "Nguyen Cong", new DateTime(2002, 07, 22), "Male", "Ha Nam"),
        new PersonModel("Nam", "Nguyen", new DateTime(2002, 07, 22), "Male", "Ha Noi"),
        new PersonModel("Tuan", "Nguyen Cong", new DateTime(2002, 07, 22), "Female", "Da Nang"),
        new PersonModel("Nam", "Nguyen Cong", new DateTime(2002, 07, 22), "Female", "Ca Mau"),
        new PersonModel("Tien", "Nguyen", new DateTime(2002, 07, 22), "Female", "Nam Tu Liem"),
        new PersonModel("Lina", "Nguyen Cong", new DateTime(2002, 07, 22), "Other", "Ha Noi"),
    };

    public PersonModel? Create(PersonCreateModel createModel)
    {
        var createEntity = new PersonModel(
            createModel.FirstName,
            createModel.LastName,
            createModel.DateOfBirth,
            createModel.Gender,
            createModel.BirthPlace);

        _peopleList.Add(createEntity);

        return createEntity;
    }

    public bool Delete(Guid id)
    {
        var entity = _peopleList.First(person => person.Id == id);

        return _peopleList.Remove(entity);
    }

    public IEnumerable<PersonModel> GetAll(string? name, string? gender, string? birthPlace)
    {
        var entities = _peopleList.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            entities = entities.Where(person => person.FullName == name.Trim());
        }

        if (!string.IsNullOrEmpty(gender))
        {
            var queryGender = Gender.Other;

            if (string.Equals("Male", gender.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                queryGender = Gender.Male;
            }
            else if (string.Equals("Female", gender.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                queryGender = Gender.Female;
            }

            entities = entities.Where(person => person.Gender == queryGender);
        }

        if (!string.IsNullOrEmpty(birthPlace))
        {
            entities = entities.Where(person => person.BirthPlace == birthPlace.Trim());
        }

        return entities;
    }

    public PersonModel? GetById(Guid id)
    {
        return _peopleList.FirstOrDefault(p => p.Id == id);
    }

    public bool IsExist(Guid id)
    {
        return _peopleList.Any(person => person.Id == id);
    }

    public PersonModel? Update(Guid id, PersonUpdateModel updateModel)
    {
        var entity = _peopleList.First(person => person.Id == id);

        entity.FirstName = updateModel.FirstName;
        entity.LastName = updateModel.LastName;
        entity.DateOfBirth = updateModel.DateOfBirth;
        entity.BirthPlace = updateModel.BirthPlace;

        entity.Gender = updateModel.Gender == "Male" ? Gender.Male
            : updateModel.Gender == "Female" ? Gender.Female
            : Gender.Other;

        return entity;
    }
}