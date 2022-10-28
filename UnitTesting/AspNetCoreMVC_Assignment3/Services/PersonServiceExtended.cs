using AspNetCoreMVC_Assignment3.Models;

namespace AspNetCoreMVC_Assignment3.Services;

public class PersonServiceExtended : IPersonService
{
    private static List<PersonModel> _people = new List<PersonModel>()
    {
        new PersonModel()
        {
            FirstName = "Truong",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(2002, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi",
            IsGraduated = true
        },
        new PersonModel()
        {
            FirstName = "Tai",
            LastName = "Pham Tien",
            Gender = "Female",
            DateOfBirth = new DateTime(2000, 02, 15),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi",
            IsGraduated = false
        },
        new PersonModel()
        {
            FirstName = "Than",
            LastName = "Nguyen Van",
            Gender = "Others",
            DateOfBirth = new DateTime(2000, 10, 08),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi",
            IsGraduated = true
            },
        new PersonModel()
        {
            FirstName = "Vinh",
            LastName = "Nguyen",
            Gender = "Male",
            DateOfBirth = new DateTime(2002, 08, 07),
            PhoneNumber = "0123456789",
            BirthPlace = "Ho Chi Minh",
            IsGraduated = false
        },
        new PersonModel()
        {
            FirstName = "Minh",
            LastName = "Do Tran",
            Gender = "Female",
            DateOfBirth = new DateTime(1998, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Da Nang",
            IsGraduated = true
        },
        new PersonModel()
        {
            FirstName = "Tran Thi",
            LastName = "Thao",
            Gender = "Female",
            DateOfBirth = new DateTime(1998, 05, 17),
            PhoneNumber = "0123456789",
            BirthPlace = "Hai Phong",
            IsGraduated = false
        }
    };

    public List<PersonModel> GetAll()
    {
        return _people;
    }

    public PersonModel? GetOne(int index)
    {
        throw new NotImplementedException();
    }

    public PersonModel Create(PersonModel model)
    {
        _people.Add(model);
        return model;
    }

    public PersonModel? Update(int index, PersonModel model)
    {
        if (index >= 0 && index < _people.Count)
        {
            _people[index] = model;
            return model;
        }
        return null;
    }

    public PersonModel? Delete(int index)
    {
        if (index >= 0 && index < _people.Count)
        {
            var person = _people[index];
            _people.RemoveAt(index);
            return person;
        }
        return null;
    }
}