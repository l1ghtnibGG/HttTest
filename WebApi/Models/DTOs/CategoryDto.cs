﻿namespace WebApi.Models.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    
    public string  Name { get; set; }
    
    public string  Description { get; set; }

    public Guid? ProductId { get; set; }
    public Product? Products { get; set; }
}