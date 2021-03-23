using Common.Interfaces;
using Simplified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Locator : BaseInpc
    {
        private IQuestsDiaryViewModel _viewModel;

        public IQuestsDiaryViewModel ViewModel { get => _viewModel; set => Set(ref _viewModel, value); }
    }
}
