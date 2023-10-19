namespace BusinessLogic.DTOS.Account;

public class CreateAccount
{
    public CreateAccount(string userName, string password, string email, string phone, DateTime dateOfBirth, DateTime createDate, string? name, string? address, string? studioPhone, string? studioEmail)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Phone = phone;
        DateOfBirth = dateOfBirth;
        CreateDate = createDate;
        Name = name;
        Address = address;
        StudioPhone = studioPhone;
        StudioEmail = studioEmail;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreateDate { get; set; }
    
    public string? Name { get; set; }
    
    public string? Address { get; set; }
    
    public string? StudioPhone { get; set; }
    
    public string? StudioEmail { get; set; }
    
}