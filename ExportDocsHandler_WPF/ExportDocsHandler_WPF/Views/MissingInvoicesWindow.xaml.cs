﻿using ExportDocsHandler_WPF.ViewModels;
using ExportDocsHandler_WPF.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExportDocsHandler_WPF.Views
{
    /// <summary>
    /// Interaction logic for MissingInvoicesWindow.xaml
    /// </summary>
    public partial class MissingInvoicesWindow : Window, ICloseable
    {
        public MissingInvoicesWindow()
        {
            InitializeComponent();
        }

    }
}
