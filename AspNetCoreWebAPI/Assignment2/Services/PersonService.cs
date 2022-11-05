using Assignment2.Models;

namespace Assignment2.Services;

public class PersonService : IPersonService
{
    private static List<PersonModel> _people = new List<PersonModel>()
    {
        new PersonModel()
        {
            FirstName = "Truong",
            LastName = "Nguyen Cong",
            DateOfBirth = new DateTime(2002, 07, 22),
            Gender = "Male",
            BirthPlace = "Ha Noi"
        },
        new PersonModel()
        {
            FirstName = "Tai",
            LastName = "Pham Tien",
            DateOfBirth = new DateTime(2000, 02, 15),
            Gender = "Female",
            BirthPlace = "Ha Noi"
        },
        new PersonModel()
        {
            FirstName = "Than",
            LastName = "Nguyen Van",
            DateOfBirth = new DateTime(2000, 10, 08),
            Gender = "Others",
            BirthPlace = "Ha Noi"
            },
        new PersonModel()
        {
            FirstName = "Vinh",
            LastName = "Nguyen",
            DateOfBirth = new DateTime(2002, 08, 07),
            Gender = "Male",
            BirthPlace = "Ho Chi Minh",
        },
        new PersonModel()
        {
            FirstName = "Minh",
            LastName = "Do Tran",
            DateOfBirth = new DateTime(1998, 07, 22),
            Gender = "Female",
            BirthPlace = "Da Nang",
        },
        new PersonModel()
        {
            FirstName = "Tran Thi",
            LastName = "Thao",
            DateOfBirth = new DateTime(1998, 05, 17),
            Gender = "Female",
            BirthPlace = "Hai Phong",
        }
    };

    public PersonModel Create(PersonCreateModel createModel)
    {
        var createEntity = new PersonModel()
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            DateOfBirth = createModel.DateOfBirth,
            Gender = createModel.Gender,
            BirthPlace = createModel.BirthPlace
        };

        _people.Add(createEntity);

        return createEntity;
    }

    public bool Delete(Guid id)
    {
        var entity = _people.FirstOrDefault(p => p.Id == id);

        if (entity != null)
        {
            return _people.Remove(entity);
        }

        return false;
    }

    public IEnumerable<PersonModel> GetFilterList(string? name, string? gender, string? birthPlace)
    {
        var entities = _people.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            entities = entities.Where(p => p.FullName.ToLower().Trim() == name.ToLower().Trim());
        }

        if (!string.IsNullOrEmpty(gender))
        {
            entities = entities.Where(p => p.Gender.ToLower().Trim() == gender.ToLower().Trim());
        }

        if (!string.IsNullOrEmpty(birthPlace))
        {
            entities = entities.Where(p => p.BirthPlace.ToLower().Trim() == birthPlace.ToLower().Trim());
        }

        return entities;
    }

    public List<PersonModel> GetAll()
    {
        return _people;
    }

    public PersonModel? GetOne(Guid id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

    public List<PersonModel> GetPagnition(Pagination pagination)
    {
        return GetAll()
            .OrderBy(on => on.FirstName)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToList();
    }

    public bool Exist(Guid id)
    {
        return _people.Any(p => p.Id == id);
    }

    public PersonModel? Update(Guid id, PersonUpdateModel updateModel)
    {
        var updateEntity = _people.FirstOrDefault(p => p.Id == id);

        if (updateEntity != null)
        {
            updateEntity.FirstName = updateModel.FirstName;
            updateEntity.LastName = updateModel.LastName;
            updateEntity.DateOfBirth = updateModel.DateOfBirth;
            updateEntity.Gender = updateModel.Gender;
            updateEntity.BirthPlace = updateModel.BirthPlace;

            return updateEntity;
        }

        return null;
    }
}