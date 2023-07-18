using System;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }
}

public class UserRegistrationSystem
{
    public void RegisterUser()
    {
        try
        {
            Console.WriteLine("User Registration");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || name.Length < 6)
            {
                throw new ValidationException("Invalid name. Name must have at least 6 characters.");
            }

            if (!IsValidEmail(email))
            {
                throw new ValidationException("Invalid email format.");
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                throw new ValidationException("Invalid password. Password must have at least 8 characters.");
            }

            Console.WriteLine("User registration success. All details inserted.");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine("Validation Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private bool IsValidEmail(string email)
    {
        // Validate email format
        return email.Contains("@") && email.Contains(".");
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserRegistrationSystem registrationSystem = new UserRegistrationSystem();
        registrationSystem.RegisterUser();
    }
}


