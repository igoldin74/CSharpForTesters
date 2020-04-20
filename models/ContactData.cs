using LinqToDB.Mapping;
using System;
using System.Diagnostics.CodeAnalysis;

namespace addressbook_tests
{
    [Table(Name = "addressbook")]
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

        [Column(Name = "id"), PrimaryKey]
        public int Id { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
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
                    return CleanUp2(this.FirstName) + " " + this.LastName + "\r\n" +
                        this.Address + "\r\n" + "\r\n" + 
                        CleanUpPhone(this.HomePhone) +
                        CleanUpPhone(this.MobilePhone) +
                        CleanUpPhone(this.WorkPhone) + "\r\n" +
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

        private string CleanUpPhone(string phone)
        {
            if (phone == this.MobilePhone)
            {
                if(phone == null || phone == "")
                {
                    return "";
                }
                else
                {
                    return "M: " + phone + "\r\n";
                }
            }
            if (phone == this.WorkPhone)
            {
                if (phone == null || phone == "")
                {
                    return "";
                }
                else
                {
                    return "W: " + phone + "\r\n";
                }
            }
            if (phone == this.HomePhone)
            {
                if (phone == null || phone == "")
                {
                    return "";
                }
                else
                {
                    return "H: " + phone + "\r\n";
                }
            }
            else
            {
                return phone;
            }
        }
        private string CleanUp2(string s)
        {
            if(s == null || s == "")
            {
                return s;
            }
            else
            {
                return s + "\r\n";
            }
        }

        private string ContactDataFromViewPage(string fName, string lName, string address, string hPhone, string mPhone, string wPhone, 
            string email, string email2, string email3)
        {
            return null;
        }
    }
}
