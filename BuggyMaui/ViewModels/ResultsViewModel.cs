using BuggyMaui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MetroLog;
using System.Collections.ObjectModel;

namespace BuggyMaui.ViewModels
{
    [QueryProperty(nameof(SearchPerson), nameof(SearchPerson))]
    public partial class ResultsViewModel : ObservableObject
    {
        #region Private fields

        IConnectivity connectivity;

        private ILogger _logger = InternalLogger.Current;

        private Person searchPerson;

        private List<Person> people;

        #endregion

        #region Public properties

        public Person SearchPerson 
        {
            get => searchPerson;
            set
            {
                SetProperty(ref searchPerson, value);

                SearchPeople(value);
            } 
        }

        public List<Person> People
        {
            get => people;
            set => SetProperty(ref people, value);
        }

        #endregion

        #region Constructor for view model

        public ResultsViewModel(IConnectivity connectivity)
        {
            this.connectivity = connectivity;
            _logger.Info("[ResultsViewModel]: constructor initialized");
        }

        #endregion

        #region Custom methods

        private void SearchPeople(Person p)
        {
            _logger.Info("[ResultsViewModel]: searching for specifc people by name");

            People = GetSomePeople()
                    .Where(x => x.FirstName.ToLower() == p.FirstName?.ToLower()
                    || x.LastName.ToLower() == p.LastName?.ToLower())
                    .ToList();
        }

        private List<Person> GetSomePeople()
        {
            _logger.Info("[ResultsViewModel]: building a list of people");

            List<Person> peeps = new();

            Person person1 = new()
            {
                Id = 0,
                FirstName = "John",
                LastName = "Smith",
                Phone = "123-456-7890",
                Email = "jsmith@icloud.com"
            };
            peeps.Add(person1);

            Person person2 = new()
            {
                Id = 10,
                FirstName = "Jane",
                LastName = "Smith",
                Phone = "123-456-7899",
                Email = "jane.smith@icloud.com"
            };
            peeps.Add(person2);

            Person person3 = new()
            {
                Id = 100,
                FirstName = "Rick",
                LastName = "Sanchez",
                Phone = null,
                Email = "picklerick@hotmail.com"
            };
            peeps.Add(person3);

            Person person4 = new()
            {
                Id = 1000,
                FirstName = "Ned",
                LastName = "Flanders",
                Phone = "555-555-3141",
                Email = "flanders4jesus@gmail.com"
            };
            peeps.Add(person4);

            return peeps;
        }

        #endregion
    }
}
