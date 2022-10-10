using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC_Assignment1.Models;
using CsvHelper;

namespace AspNetCoreMVC_Assignment1.Controllers;
public class RookiesController : Controller
{
    private static List<PersonModel> _people = new List<PersonModel>()
        {
            new PersonModel()
            {
                FirstName = "Nguyen Cong",
                LastName = "Truong",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 07, 22),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
            new PersonModel()
            {
                FirstName = "Nguyen Tien",
                LastName = "Tai",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 02, 15),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel()
            {
                FirstName = "Nguyen Van",
                LastName = "Thao",
                Gender = "Others",
                DateOfBirth = new DateTime(2000, 10, 08),
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
            new PersonModel()
            {
                FirstName = "Nguyen Duc",
                LastName = "Vinh",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 08, 07),
                PhoneNumber = "0123456789",
                BirthPlace = "Ho Chi Minh",
                IsGraduated = false
            },
            new PersonModel()
            {
                FirstName = "Do Tran",
                LastName = "Minh",
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
        return Json(_people);
    }

    public IActionResult GetMaleMembers()
    {
        var data = _people.Where(p => p.Gender == "Male");

        return Json(data);
    }

    public IActionResult GetOldestMember()
    {
        var maxAgeValue = _people.Max(p => p.Age);
        var oldestMember = _people.FirstOrDefault(x => x.Age == maxAgeValue);

        return Json(oldestMember);
    }

    public IActionResult GetListFullNameOnly()
    {
        var listFullNames = _people.Select(p => p.FullName);

        return Json(listFullNames);
    }

    #region #4

    public IActionResult GetListMemberByBirthYear(int year, string compareType)
    {
        switch (compareType)
        {
            case "equals":
                var memberEquals2000 = _people.FindAll(x => x.DateOfBirth.Year == 2000);

                return Json(memberEquals2000);
            case "greaterThan":
                var memberGreaterThan2000 = _people.FindAll(x => x.DateOfBirth.Year > 2000);

                return Json(memberGreaterThan2000);
            case "lessThan":
                var memberLessThan2000 = _people.FindAll(x => x.DateOfBirth.Year < 2000);

                return Json(memberLessThan2000);
            default:
                return Json(null);
        }
    }

    public IActionResult GetMemberWhoBornIn2000()
    {
        return RedirectToAction("GetListMemberByBirthYear", new { year = 2000, compareType = "equals" });
    }

    public IActionResult GetMemberWhoBornAfter2000()
    {
        return RedirectToAction("GetListMemberByBirthYear", new { year = 2000, compareType = "greaterThan" });
    }

    public IActionResult GetMemberWhoBornBefore2000()
    {
        return RedirectToAction("GetListMemberByBirthYear", new { year = 2000, compareType = "lessThan" });
    }

    #endregion

    #region Export

    public byte[] WriteCsvToMemory(IEnumerable<PersonModel> people)
    {
        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
        {
            csvWriter.WriteRecords(people);
            streamWriter.Flush();
            return memoryStream.ToArray();
        }
    }

    public FileStreamResult ExportFile()
    {
        var result = WriteCsvToMemory(_people);
        var memoryStream = new MemoryStream(result);
        return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "person.csv" };
    }

    #endregion
}
