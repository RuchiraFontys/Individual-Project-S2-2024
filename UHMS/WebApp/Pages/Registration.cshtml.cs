using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic;
using Domain;
using DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly UserManager _userManager;
        private readonly DoctorManager _doctorManager;
        private readonly AdministratorManager _administratorManager;
        private readonly ILogger<RegistrationModel> _logger;

        public RegistrationModel(UserManager userManager, DoctorManager doctorManager, AdministratorManager administratorManager, ILogger<RegistrationModel> logger)
        {
            _userManager = userManager;
            _doctorManager = doctorManager;
            _administratorManager = administratorManager;
            _logger = logger; // Store the injected logger
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel(); // Initializes InputModel

        public void OnGet()
        {
        }

        public class InputModel
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            [Required(ErrorMessage = "Date of birth is required.")]
            public DateTime DateOfBirth { get; set; }
            public Gender Gender { get; set; }
            [Required(ErrorMessage = "Telephone number is required.")]
            [RegularExpression(@"^\+[0-9]{11,14}$", ErrorMessage = "Telephone number must start with + followed by 11 to 14 digits.")]
            public string? TelephoneNumber { get; set; }
            [Required(ErrorMessage = "SSN is required.")]
            [RegularExpression(@"^\d{9}$", ErrorMessage = "SSN must be exactly 9 digits.")]
            public string? SSN { get; set; }
            public string? EmailAddress { get; set; }
            public string? HomeAddress { get; set; }
            public string? Password { get; set; }
            public Role Role { get; set; }
            public string? DoctorJobId { get; set; }
            public Specialization Specialization { get; set; } // Add this line if Specialization is part of your form
            public string? AdministratorJobId { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Log the beginning of the registration process
            _logger.LogInformation("Starting user registration process.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid. Returning to registration page with errors.");
                return Page();
            }

            // Create user instance from form input
            var user = new User
            {
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                DateOfBirth = Input.DateOfBirth,
                Gender = Input.Gender,
                TelephoneNumber = Input.TelephoneNumber,
                SSN = Input.SSN,
                EmailAddress = Input.EmailAddress,
                HomeAddress = Input.HomeAddress,
                Password = Input.Password, // Password should be hashed inside UserManager
                Role = Input.Role
            };

            try
            {
                // Register the user and get the ID of the newly created user record
                int userId = await _userManager.RegisterUserAsync(user);
                _logger.LogInformation($"User registered with ID: {userId}");

                if (userId <= 0)
                {
                    _logger.LogWarning("Registration failed, no user ID returned.");
                    throw new Exception("Registration failed, no user ID returned.");
                }

                // Handling role-specific data insertion
                switch (Input.Role)
                {
                    case Role.Patient:
                        var patient = new Patient
                        {
                            Id = userId
                            // Initialize other properties if necessary
                        };
                        var patientDal = new PatientDAL();
                        patientDal.CreatePatient(patient);
                        _logger.LogInformation("Patient record created successfully.");
                        break;

                    case Role.Doctor:
                        var doctor = new Doctor
                        {
                            Id = userId,
                            DoctorJobId = Input.DoctorJobId,
                            Specialization = Input.Specialization
                            // Initialize other properties if necessary
                        };
                        var doctorDal = new DoctorDAL();
                        doctorDal.CreateDoctor(doctor);
                        _logger.LogInformation("Doctor record created successfully.");
                        break;

                    case Role.Administrator:
                        var administrator = new Administrator
                        {
                            Id = userId,
                            AdministratorJobId = Input.AdministratorJobId
                            // Initialize other properties if necessary
                        };
                        var adminDal = new AdministratorDAL();
                        adminDal.CreateAdministrator(administrator);
                        _logger.LogInformation("Administrator record created successfully.");
                        break;

                    default:
                        _logger.LogWarning($"Unhandled user role: {Input.Role}");
                        break;
                }

                // Redirect to login page after successful registration
                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed.");
                ModelState.AddModelError("", $"Registration failed: {ex.Message}");
                return Page();
            }
        }

    }
}
