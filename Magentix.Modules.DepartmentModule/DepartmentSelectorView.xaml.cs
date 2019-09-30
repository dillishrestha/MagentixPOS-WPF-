﻿using System.ComponentModel.Composition;
using System.Windows.Controls;
using Magentix.Presentation.Services;
using Magentix.Services;

namespace Magentix.Modules.DepartmentModule
{
    /// <summary>
    /// Interaction logic for DepartmentButtonView.xaml
    /// </summary>

    [Export]
    public partial class DepartmentSelectorView : UserControl
    {
        private readonly IApplicationStateSetter _applicationStateSetter;

        [ImportingConstructor]
        public DepartmentSelectorView(IApplicationStateSetter applicationStateSetter, IApplicationState applicationState,
             IUserService userService)
        {
            InitializeComponent();
            _applicationStateSetter = applicationStateSetter;
            DataContext = new DepartmentSelectorViewModel(applicationState, _applicationStateSetter, userService);
        }
    }
}
