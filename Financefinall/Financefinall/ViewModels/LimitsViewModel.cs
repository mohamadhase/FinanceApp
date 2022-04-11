using Financefinall.Models;
using Financefinall.Services;
using Financefinall.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace Financefinall.ViewModels
{
    class LimitsViewModel : BindableObject
    {

        CategorieService categorieservice;
        public ObservableCollection<Category> _categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> _noLimitCategories = new ObservableCollection<Category>();
        public ObservableCollection<LimitShow> _limitShow = new ObservableCollection<LimitShow>();
        public ObservableCollection<Category> categories
        {
            get { return _categories; }
            set {
                _categories = value;

            }
        }

        public ObservableCollection<LimitShow> limitShow
        {
            get { return _limitShow; }
            set
            {
                _limitShow = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Category> noLimitCategories
        {
            get { return _noLimitCategories; }
            set
            {
                _noLimitCategories = value;
                OnPropertyChanged();
            }
        }
        Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (value != null)
                {
                    
                    Application.Current.MainPage.Navigation.PushAsync(new AddLimit(value));

                }
                else
                {
                    Console.WriteLine("value IS NULL");
                }

                OnPropertyChanged();


            }
        }
        
        public LimitsViewModel()
        {
            categorieservice = new CategorieService();
            categories = categorieservice.getUserCategories("User1");
            categories.CollectionChanged += OnCollectionChanged;
        }
        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

                Console.WriteLine(e.Action);
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    limitShow.Clear();
                    foreach (Category cat in categories)
                    {
                        if (cat.limits == null)
                        {
                        Category newCatLimit = new Category(cat);
                        noLimitCategories.Add(newCatLimit);
                        continue;
                        }
                    
                        bool hasLimit = false;
                        int index = 0;
                        for(int i = 0; i < cat.limits.Count; i++)
                        {
                            if(cat.limits[i].month==DateTime.Now.Month.ToString() && cat.limits[i].year == DateTime.Now.Year.ToString())
                            {
                                index = i;
                                hasLimit = true;
                                break;
                            }
                        }
                        if (hasLimit)
                        {
                            LimitShow newLimit = new LimitShow();
                            newLimit.categorie_id = cat.categorie_id;
                            newLimit.categorie_name = cat.categorie_name;
                            newLimit.photo_id = cat.photo_id;
                            newLimit.type = cat.type;
                            newLimit.spend = cat.limits[index].spend;
                            newLimit.limitAmount = cat.limits[index].limitAmount;
                            limitShow.Add(newLimit);

                        }
                    else
                    {
                        Category newCatLimit = new Category(cat);
                        noLimitCategories.Add(newCatLimit);
                    }

                    }

                }

            

        }
        public ICommand ButtonSelectedCommand
        {
            get
            {
                return new Command((e) =>
                {

                });
            }
        }
    }
}
