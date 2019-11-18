using System;
using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Starter.Data.Commands;
using Starter.Data.Entities;
using Starter.Framework.Clients;
using Starter.Framework.Extensions;

namespace Starter.Data.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCatSelected => _selectedCat != null;

        public bool IsLoading
        {
            get => _isLoading;

            set
            {
                _isLoading = value;

                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private bool AllowSave
        {
            get
            {
                if (SelectedCat == null) return false;

                return SelectedCat.AbilityId != 0 && SelectedCat.Name.IsNotEmpty();
            }
        }

        public ICommand CreateCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

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

        public MainViewModel(IApiClient apiClient)
        {
            _apiClient = apiClient;

            CreateCommand = new CatCommand(Create, param => !_isNew);
            SaveCommand = new CatCommand(Save, canExecute => AllowSave);
            DeleteCommand = new CatCommand(Delete, canExecute => IsCatSelected && !_isNew);

            Abilities = new ObservableCollection<object>(GetEnum<Ability>());

            GetAll();
        }

        private async void GetAll()
        {
            IsLoading = true;

            Cats = new ObservableCollection<IEntity>(await _apiClient.GetAllAsync<Cat>());

            IsLoading = false;
        }

        public async void GetById(Guid id)
        {
            IsLoading = true;

            _selectedCat = await _apiClient.GetByIdAsync<Cat>(id);

            OnPropertyChanged(nameof(SelectedCat));
            OnPropertyChanged(nameof(IsCatSelected));

            IsLoading = false;
        }

        private void Create(object obj)
        {
            _isNew = true;

            _selectedCat = new Cat
            {
                Id = Guid.NewGuid(),
                AbilityId = 0
            };

            OnPropertyChanged(nameof(SelectedCat));
            OnPropertyChanged(nameof(IsCatSelected));
        }

        private async void Save(object obj)
        {
            IsLoading = true;

            if (_isNew)
            {
                await _apiClient.CreateAsync(SelectedCat);
            }
            else
            {
                await _apiClient.UpdateAsync(SelectedCat);
            }

            ResetSelection();

            GetAll();
        }

        public async void Delete(object obj)
        {
            IsLoading = true;

            await _apiClient.DeleteAsync(SelectedCat.Id);

            ResetSelection();

            GetAll();
        }

        private void ResetSelection()
        {
            _selectedCat = null;

            OnPropertyChanged(nameof(SelectedCat));
            OnPropertyChanged(nameof(IsCatSelected));
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

        private bool _isLoading;

        private bool _isNew;
    }
}