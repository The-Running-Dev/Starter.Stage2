using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Starter.Data.Entities;
using Starter.Framework.Clients;

namespace Starter.Data.ViewModels
{
    public class CatsViewModel : ICatsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCatSelected => _selectedCat != null;

        public Cat SelectedCat
        {
            get => _selectedCat;
            set => GetById(value.Id);
        }

        public ObservableCollection<IEntity> Cats
        {
            get => _cats;

            set
            {
                _cats = value;

                OnPropertyChanged(nameof(Cats));
            }
        }

        public ObservableCollection<object> Abilities
        {
            get => _abilities;

            set
            {
                _abilities = value;

                OnPropertyChanged(nameof(Abilities));
            }
        }

        public CatsViewModel(IApiClient apiClient)
        {
            _apiClient = apiClient;

            GetAll();
        }

        private async void GetAll()
        {
            Cats = new ObservableCollection<IEntity>(await _apiClient.GetAllAsync<Cat>());
            Abilities = new ObservableCollection<object>(GetEnum<Ability>());
        }

        public async void GetById(Guid id)
        {
            _selectedCat = await _apiClient.GetByIdAsync<Cat>(id);

            OnPropertyChanged(nameof(SelectedCat));
            OnPropertyChanged(nameof(IsCatSelected));
        }

        public async void Save()
        {
            await _apiClient.CreateAsync(SelectedCat);

            SelectedCat = new Cat();
            Cats = new ObservableCollection<IEntity>(await _apiClient.GetAllAsync<IEntity>());
        }

        public async void Delete()
        {
            await _apiClient.DeleteAsync(SelectedCat.Id);

            SelectedCat = new Cat();
            Cats = new ObservableCollection<IEntity>(await _apiClient.GetAllAsync<IEntity>());
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static IEnumerable<object> GetEnum<T>()
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);
            var pairs =
                Enumerable.Range(0, names.Length)
                    .Select(i => new
                    {
                        Name = (string)names.GetValue(i),
                        Value = (int)values.GetValue(i)
                    });

            pairs.Append(new
            {
                Name = string.Empty,
                Value = -1
            });

            return pairs.OrderBy(pair => pair.Name);
        }

        private ObservableCollection<IEntity> _cats;

        private ObservableCollection<object> _abilities;

        private Cat _selectedCat;

        private readonly IApiClient _apiClient;
    }
}