using System;
using System.Collections.Generic;
using System.Text;

using Financefinall.Models;

using Xamarin.Forms;

namespace Financefinall.ViewModels
{
    class EditCategoryViewModel: BindableObject
    {
        public Category category;
        public EditCategoryViewModel()
        {
            category = new Category();
        }

    }
}
