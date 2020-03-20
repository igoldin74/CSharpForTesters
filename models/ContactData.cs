﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace addressbook_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;

        public bool Equals([AllowNull] ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return FirstName.ToString();
        }

        public int CompareTo([AllowNull] ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (FirstName + LastName).CompareTo(other.FirstName + LastName);
        }

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

    }
}
