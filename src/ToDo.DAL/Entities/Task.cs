﻿using ToDo.DAL.Entities.Core;

namespace ToDo.DAL.Entities;
public class Task : Entity
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; }
}