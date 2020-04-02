using System;
using System.Diagnostics.CodeAnalysis;

namespace addressbook_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        // These are fields:
        private string name;
        private string header;
        private string footer;

        //Class methods:
        public bool Equals([AllowNull] GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name + "\nheader=" + Header + "\nfooter=" + Footer;
        }
        public int CompareTo([AllowNull] GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);

        }

        // This is constructor:
        public GroupData(string name)
        {
            this.name = name;
        }

        // These are properties: 
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        // Auto-property (private field is unnecessary):
        public int Id { get; set; }

    }
}




