using API.Models.Dtos;
using API.Models.Entities;
using System;

public class NewsDto
{
    public int NewsId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime? WritingDate { get; set; }
    public string Image { get; set; }
    public string EmployeeId { get; set; }
    public int SpeciesId { get; set; }
    public string AnimalId { get; set; }
    public AnimalDto Animal { get; set; }
    public EmployeeDto Employee { get; set; }
    public AnimalSpeciesDto AnimalSpecies { get; set; }
}
