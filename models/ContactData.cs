using NUnit.Framework.Internal;
using System;
using System.Diagnostics.CodeAnalysis;

namespace addressbook_tests
{
    public class ContactData : TestCaseParameters, IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string fullName;
        private string allContactDetails;
        private string allEmails;

        public bool Equals(ContactData other)
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

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.LastName == other.LastName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else
                return other.LastName.CompareTo(this.LastName);
        }

        public ContactData(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public ContactData(string infoFromViewPage)
        {
            this.AllContactDetails = infoFromViewPage;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (AllPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (AllEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return Email1 + Email2 + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllContactDetails
        {
            get
            {
                if (AllContactDetails != null)
                {
                    return allContactDetails;
                }
                else
                {
                    return this.FirstName + this.LastName + this.Address + this.AllPhones + this.AllEmails;
                }

            }
            set
            {
                allContactDetails = value;
            }
        }

        public string FullName
        {
            get
            {
                if (FullName != null)
                {
                    return fullName;
                }
                else
                {
                    return FirstName.Trim() + LastName.Trim();
                }
            }
            set
            {
                fullName = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            }
        }
    }
}
