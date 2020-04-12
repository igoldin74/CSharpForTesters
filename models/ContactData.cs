using System;
using System.Diagnostics.CodeAnalysis;

namespace addressbook_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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
            if (FirstName == null)
            {
                return AllContactDetails.ToString();
            }
            else
            {
                return FirstName.ToString();
            }
            
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
        public ContactData()
        {
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
                if (allPhones != null)
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
                if (allEmails != null)
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
                if (allContactDetails != null)
                {
                    return allContactDetails;
                }
                else
                {
                    return this.FirstName + " " + this.LastName + "\r\n" +
                        this.Address + "\r\n" + "\r\n" + 
                        "H: " + this.HomePhone + "\r\n" +
                        "M: " + this.MobilePhone + "\r\n" +
                        "W: " + this.WorkPhone + "\r\n" + "\r\n" +
                        this.Email1 + "\r\n" +
                        this.Email2 + "\r\n" +
                        this.Email3;
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
                if (fullName != null)
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
