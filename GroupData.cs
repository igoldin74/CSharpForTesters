using System;
namespace addressbook_tests
{
    public class GroupData
    {
        // These are fields:
        private string name;
        private string header;
        private string footer;

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
    }
}
