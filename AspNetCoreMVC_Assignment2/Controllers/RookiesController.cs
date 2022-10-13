using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC_Assignment2.Models;

namespace AspNetCoreMVC_Assignment2.Controllers;
public class RookiesController : Controller
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

    private readonly ILogger<RookiesController> _logger;

    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_people);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PersonCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                BirthPlace = model.BirthPlace,
                IsGraduated = false
            };

            _people.Add(person);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        if (index >= 0 && index < _people.Count)
        {
            var person = _people[index];
            var model = new PersonUpdateModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
            };
            ViewData["Index"] = index;
            return View(model);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Update(int index, PersonUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Gender = model.Gender;
                person.DateOfBirth = model.DateOfBirth;
                person.PhoneNumber = model.PhoneNumber;
                person.BirthPlace = model.BirthPlace;

                _people[index] = person;
            }

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int index)
    {
        if (index >= 0 && index < _people.Count)
        {
            _people.RemoveAt(index);
        }

        return RedirectToAction("Index");
    }
}