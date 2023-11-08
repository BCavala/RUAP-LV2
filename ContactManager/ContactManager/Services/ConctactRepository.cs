﻿namespace ContactManager.Services;
using ContactManager.Models;
public class ContactRepository
{
    public Contact[] GetAllContacts()
    {
        return new Contact[]
        {
            new Contact
            {
                Id = 1,
                Name = "Glenn Block"
            },
            new Contact
            {
                Id = 2,
                Name = "Dan Roth"
            }
        };
    }
}
