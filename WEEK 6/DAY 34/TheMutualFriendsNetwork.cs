namespace WEEK_6
{
    class Person
    {
        public string Name { get; }

        private readonly List<Person> _friends = new();

        public IReadOnlyList<Person> Friends => _friends.AsReadOnly();

        public Person(string name)
        {
            Name = name;
        }

        public void AddFriend(Person person)
        {
            if (person == null || person == this)
                return;

            if (!_friends.Contains(person))
            {
                _friends.Add(person);
                person._friends.Add(this); 
            }
        }
    }

    class SocialNetwork
    {
        private readonly List<Person> _members = new();

        public void AddMember(Person person)
        {
            if (person != null && !_members.Contains(person))
                _members.Add(person);
        }

        public void ShowNetwork()
        {
            foreach (var member in _members)
            {
                string friendsList = string.Join(", ", member.Friends.Select(f => f.Name));
                Console.WriteLine($"{member.Name}: {friendsList}");
            }
        }
    }

    internal class TheMutualFriendsNetwork
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            Person aman = new Person("Aman");
            Person ravi = new Person("Ravi");
            Person neha = new Person("Neha");

            aman.AddFriend(ravi);
            aman.AddFriend(neha);

            network.AddMember(aman);
            network.AddMember(ravi);
            network.AddMember(neha);

            network.ShowNetwork();
        }
    }
}
