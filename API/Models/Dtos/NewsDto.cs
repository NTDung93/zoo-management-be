﻿using System;

public class NewsDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime? WritingDate { get; set; }

    public string Image { get; set; }

    public string EmpId { get; set; }

    public int SpeciesId { get; set; }

    public string AnimalId { get; set; }
}