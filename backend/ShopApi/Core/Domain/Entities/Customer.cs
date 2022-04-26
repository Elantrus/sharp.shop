using System.Text.RegularExpressions;
using Core.Exceptions;

namespace Core.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string SurName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    public string Role { get; set; }
    
    private static int CLIENT_MIN_NAME_SIZE = 3;
    private static int CLIENT_MIN_SURNAME_SIZE = 3;
    private static int CLIENT_MIN_EMAIL_SIZE = 10;

    public Customer(string name, string surName, string email, string password)
    {
        SetFullName(name, surName);
        SetEmail(email);
        SetPassword(password);
    }
    
    private void SetFullName(string name, string surName)
    {
        if (name.Length <= CLIENT_MIN_NAME_SIZE) throw new FieldLengthTooLow(nameof(Name), CLIENT_MIN_NAME_SIZE);
        
        if (surName.Length <= CLIENT_MIN_SURNAME_SIZE) throw new FieldLengthTooLow(nameof(Name), CLIENT_MIN_SURNAME_SIZE);
        
        Name = name;
        SurName = surName;
    }

    private void SetEmail(string email)
    {
        if(email.Length <= CLIENT_MIN_EMAIL_SIZE) throw new FieldLengthTooLow(nameof(Name), CLIENT_MIN_EMAIL_SIZE);
        
        Email = email.ToLower();
    }

    private void SetPassword(string password)
    {
        if (!Regex.IsMatch(password, "(?=.*\\d)")) throw new PasswordIsTooWeakException("numeral.");
        if (!Regex.IsMatch(password, "(?=.*[a-z])")) throw new PasswordIsTooWeakException("lowercase character.");
        if (!Regex.IsMatch(password, "(?=.*[A-Z])")) throw new PasswordIsTooWeakException("uppercase character.");
        if (!Regex.IsMatch(password, "(?=.*[@#$%])")) throw new PasswordIsTooWeakException("special symbol.");
        
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        
        using (var hash = System.Security.Cryptography.SHA512.Create())
        {
            var hashedInputBytes = hash.ComputeHash(bytes);

            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            Password = hashedInputStringBuilder.ToString();
        }
    }

    public void SetRoles(string customerRoles)
    {
        Role = customerRoles;
    }
}