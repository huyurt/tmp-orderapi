﻿using System.ComponentModel.DataAnnotations;

namespace OrderApi.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
