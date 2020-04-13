using LinqToDB.Mapping;
using System;
using System.Diagnostics.CodeAnalysis;

namespace addressbook_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        // These are fields:
        private string name;
        private string header;
        private string footer;

        //Class methods:
        public bool Equals(GroupData other)
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
        public int CompareTo(GroupData other)
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

        public GroupData()
        {
        }

        // These are properties:
        // Auto-property (private field is unnecessary):
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public int Id { get; set; }
        [Column(Name = "group_name"), NotNull]
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
        [Column(Name = "group_header"), NotNull]
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
        [Column(Name = "group_footer"), NotNull]
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

    }
}




