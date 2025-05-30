﻿using Domain.Enums;
using System;

public class RegDataActionDTO
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime? RequestTime { get; set; }
    public EURole UserRole { get; set; }
}

