﻿using SM.Common.Enums;
using SM.Common.Interfaces;
using System;

namespace SM.Common.Models
{
    /// <summary>
    /// Defines a student.
    /// </summary>
    public class Student : IModel
    {
        /// <summary>
        /// Gets or sets the student name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the student type.
        /// </summary>
        public SchoolType SchoolType { get; set; }

        /// <summary>
        /// Gets or sets the student gender.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets or sets the student last modified date.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the student Id.
        /// </summary>
        public Guid Id { get; set; }

        public override string ToString()
        {
            var schoolType = SchoolType.ToString();
            var gender = Gender == GenderType.Female ? 'F' : 'M';
            var timestamp = LastModifiedDate.ToString("yyyyMMddHHmmss");
            return $"{schoolType},{Name},{gender},{timestamp}";
        }
    }
}