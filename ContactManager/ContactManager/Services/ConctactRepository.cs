namespace ContactManager.Services;
using Microsoft.AspNetCore.Http;
using ContactManager.Models;

public class ContactRepository
{
    private const string CacheKey = "ContactStore";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ContactRepository(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Contact[] GetAllContacts()
    {
        var ctx = _httpContextAccessor.HttpContext;

        if (ctx != null)
        {
            return (Contact[])ctx.Items[CacheKey];
        }

        return new Contact[]
        {
            new Contact
            {
                Id = 0,
                Name = "Placeholder"
            }
        };
    }

    public ContactRepository()
    {
        var ctx = _httpContextAccessor.HttpContext;

        if (ctx != null && ctx.Items[CacheKey] == null)
        {
            var contacts = new Contact[]
            {
                new Contact
                {
                    Id = 1, Name = "Glenn Block"
                },
                new Contact
                {
                    Id = 2, Name = "Dan Roth"
                }
            };

            ctx.Items[CacheKey] = contacts;
        }
    }

    public bool SaveContact(Contact contact)
    {
        var ctx = _httpContextAccessor.HttpContext;

        if (ctx != null)
        {
            try
            {
                var currentData = ((Contact[])ctx.Items[CacheKey]).ToList();
                currentData.Add(contact);
                ctx.Items[CacheKey] = currentData.ToArray();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        return false;
    }
}
