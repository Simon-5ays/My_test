using Microsoft.AspNetCore.Mvc;

namespace ValidateTheNameWebApplication.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(
                "Index",
                new
                {
                    nameIsValid = false,
                    showNameEvaluation = false
                });
        }

        [HttpPost]
        public IActionResult ValidateName(string name)
        {
            bool nameValidationResult = NameIsValid(name);
            return View(
                "Index",
                new
                {
                    nameIsValid = nameValidationResult,
                    showNameEvaluation = true
                });
        }

        // Ændringer begynder her
        private bool NameIsValid(string name)
        {
            // Tjek for længde - mellem 3 og 20 karakterer
            if (name.Length < 3 || name.Length > 20)
            {
                return false;
            }

            // Regex for at sikre, at navnet kun indeholder bogstaver (ingen tal eller specialtegn)
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+$");

            // Returner om navnet matcher regex (kun alfabetiske tegn)
            return regex.IsMatch(name);
        }
    }
}

