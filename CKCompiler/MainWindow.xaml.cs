﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CKCompiler.Core;
using CKCompiler.GUI;
using CKCompiler.Tokens;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace CKCompiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly Compiler _compiler = new Compiler();
        private DispatcherTimer _compileTimer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void CompileTimerCallback(object sender, EventArgs e)
        {
            Compile();
            _compileTimer.IsEnabled = false;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            LangTokens.Load("CKLexer.tokens");
            ErrorsDataGrid.LoadingRow += (o, e) => e.Row.Header = e.Row.GetIndex() + 1;
            _compileTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 500), DispatcherPriority.Normal, CompileTimerCallback, Dispatcher);
            TextEditor.TextChanged += (o, args) =>
                                      {
                                          _compileTimer.Stop();
                                          _compileTimer.IsEnabled = true;
                                          _compileTimer.Start();
                                      };
            TextEditor.Text = "class Program\n{\n\tMain():void\n\t{\n\t\t\n\t}\n}";
        }

        private void FileOpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().Value)
            {
                TextEditor.Clear();
                var fileContent = File.ReadAllText(dialog.FileName);
                TextEditor.AppendText(fileContent);
            }
        }

        private void PreCompileReset()
        {
            ClearErrors();
            ErrorExpander.IsExpanded = false;
        }

        private void Compile()
        {
            PreCompileReset();
            _compiler.Compile(TextEditor.Text);
            _compiler.GenerateCode(false);

            DisplayErrors();
            LexemDataGrid.ItemsSource = _compiler.Tokens;
            if (_compiler.ProgramContext != null) FillLexerAndParserTables(_compiler.ProgramContext);
            
        }

        private void DisplayErrors()
        {
            ErrorsDataGrid.ItemsSource = _compiler.Errors;
            foreach (var error in _compiler.Errors.Where(x => x.OffendingToken != null))
            {
                TextEditor.TextArea.TextView.LineTransformers.Add(
                    new LineColorizer(error.OffendingToken.Line, error.OffendingToken.StartIndex, error.OffendingToken.StopIndex + 1));
            }

            if (_compiler.HasErrors) ErrorExpander.IsExpanded = true;
        }

        private void FillLexerAndParserTables(IParseTree tree)
        {
            TrvSyntaxTree.Items.Clear();
            FillLexerAndParserTables(tree, null);
        }

        private void FillLexerAndParserTables(IParseTree tree, TreeViewItem parentTreeViewItem)
        {
            if (tree != null)
                for (int i = 0; i < tree.ChildCount; i++)
                {
                    var curItem = tree.GetChild(i);
                    var curToken = curItem.Payload as IToken;
                    var headerText = curToken != null ? curToken.Text : curItem.Payload.GetType().Name;

                    var item = new TreeViewItem { Header = headerText, Tag = curItem };
                    if (parentTreeViewItem == null)
                        TrvSyntaxTree.Items.Add(item);
                    else
                        parentTreeViewItem.Items.Add(item);
                    FillLexerAndParserTables(tree.GetChild(i), item);
                }
        }

        private void ClearErrors()
        {
            var colorizers = TextEditor.TextArea.TextView.LineTransformers.OfType<LineColorizer>().ToList();
            foreach (var lineColorizer in colorizers)
            {
                TextEditor.TextArea.TextView.LineTransformers.Remove(lineColorizer);
            }
        }

        private void CompileExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _compiler.GenerateCode(true);
            if (_compiler.HasErrors)
            {
                DisplayErrors();
            }
            else
            {
                System.Diagnostics.Process.Start("exec.exe");
            }
        }

        private void GenerateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _compiler.GenerateCode(true);
            DisplayErrors();
        }

        private void GenerateCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !_compiler.HasErrors && _compiler.ProgramContext != null;
        }
    }
}
